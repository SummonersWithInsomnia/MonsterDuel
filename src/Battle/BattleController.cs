using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public class BattleController
{
    private readonly Form sourceForm;

    public Battle Battle { get; set; }
    public List<PictureBox> Gates = new();

    public BattleMessageBox BattleMessageBox;
    public TaskCompletionSource<bool> MessageBoxTcs;

    private int turn;
    private string battleResult;
    private IPlayer winner;
    private bool hasWinner;
    private bool isDraw;

    private readonly Battle battleForRetry;

    public int CriticalHitRate = 15;

    public BattleController(Form source, Battle battle, List<PictureBox> gates)
    {
        sourceForm = source;
        Battle = battle;
        Gates = gates;

        battleForRetry = new Battle(battle);

        BattleMessageBox = new BattleMessageBox(this);
    }

    public async Task Start()
    {
        sourceForm.Controls.Add(BattleMessageBox);
        BattleMessageBox.Visible = false;
        sourceForm.Controls.Add(Battle);

        await Battle.Start(sourceForm, Gates);
        await Task.Delay(1000);

        MessageBoxTcs = new TaskCompletionSource<bool>();
        await BattleMessageBox.Show($"You are challenged by Summoner {Battle.RightPlayer.Name}!");
        await MessageBoxTcs.Task;

        await SendMonstersAtStart();

        await GameLoop();
        await End();
    }

    public async Task End()
    {
        MessageBoxTcs = new TaskCompletionSource<bool>();
        await BattleMessageBox.Show("Duel over!");
        await MessageBoxTcs.Task;

        if (isDraw)
            await BattleMessageBox.ShowWaiting("Both summoners were surrendered!");
        else
            await BattleMessageBox.ShowWaiting($"The winner is Summoner {winner.Name}!");

        await Task.Delay(3000);

        var gates = await SceneEffect.CuttingInLikeClosingGate(sourceForm,
            "MonsterDuel_Data/effects/scenes/battle_opening_top.png",
            "MonsterDuel_Data/effects/scenes/battle_opening_bottom.png", 200, 10);

        BattleMessageBox.CloseWaiting();
        await Dispose();

        var result = new BattleResult(sourceForm, battleResult, battleForRetry, gates);
        await result.Start();
    }

    public async Task GameLoop()
    {
        while (!hasWinner && !isDraw)
        {
            GameLoopStart:
            
            int leftAvailableMonsterCount = 0;
            foreach (var monster in Battle.LeftPlayer.Monsters)
            {
                if (monster.Value.CurrentHealth > 0)
                    leftAvailableMonsterCount++;
            }
            
            int rightAvailableMonsterCount = 0;
            foreach (var monster in Battle.RightPlayer.Monsters)
            {
                if (monster.Value.CurrentHealth > 0)
                    rightAvailableMonsterCount++;
            }
            
            if (leftAvailableMonsterCount == 0)
            {
                hasWinner = true;
                battleResult = "Defeat";
                winner = Battle.RightPlayer;

                await BattleMessageBox.AutoShow("Summoner " + Battle.LeftPlayer.Name + " has no more available monster!");
                break;
            }
            
            if (rightAvailableMonsterCount == 0)
            {
                hasWinner = true;
                battleResult = "Victory";
                winner = Battle.LeftPlayer;

                await BattleMessageBox.AutoShow("Summoner " + Battle.RightPlayer.Name + " has no more available monster!");
                break;
            }
            
            turn++;
            
            var leftPlayerCommand = await Battle.LeftPlayer.GetCommandString(this); // Player

            Battle.Refresh();
            
            var rightPlayerCommand = await Battle.RightPlayer.GetCommandString(this); // AI

            // for surrendering
            if (leftPlayerCommand == "Surrender" && rightPlayerCommand == "Surrender")
            {
                isDraw = true;
                battleResult = "Draw";
                break;
            }

            if (leftPlayerCommand == "Surrender" && rightPlayerCommand != "Surrender")
            {
                hasWinner = true;
                battleResult = "Defeat";
                winner = Battle.RightPlayer;

                await BattleMessageBox.AutoShow($"Summoner {Battle.LeftPlayer.Name} surrenders!");
                break;
            }

            if (leftPlayerCommand != "Surrender" && rightPlayerCommand == "Surrender")
            {
                hasWinner = true;
                battleResult = "Victory";
                winner = Battle.LeftPlayer;

                await BattleMessageBox.AutoShow($"Summoner {Battle.RightPlayer.Name} surrenders!");
                break;
            }

            // for switching monster

            if (leftPlayerCommand.Contains("Switch#"))
            {
                if (Battle.LeftPlayer.Monsters[Battle.LeftPlayer.CurrentMonster].CurrentHealth > 0)
                    await BattleMessageBox.AutoShow($"Come back, {Battle.LeftPlayer.CurrentMonster}!");

                await BattleMessageBox.AutoShow($"Summoning magic! {leftPlayerCommand.Split('#')[1]}!");

                var monsterName = leftPlayerCommand.Split('#')[1];
                Battle.LeftPlayer.CurrentMonster = monsterName;
                await Battle.LeftPlayerSummonsMonster(monsterName, 500, 50);
                
                goto GameLoopStart;
            }

            if (rightPlayerCommand.Contains("Switch#"))
            {
                if (Battle.RightPlayer.Monsters[Battle.RightPlayer.CurrentMonster].CurrentHealth > 0)
                    await BattleMessageBox.AutoShow(
                        $"Summoner {Battle.RightPlayer.Name} calls back {Battle.RightPlayer.CurrentMonster}!");

                await BattleMessageBox.AutoShow(
                    $"Summoner {Battle.RightPlayer.Name} summons {rightPlayerCommand.Split('#')[1]}!");

                var monsterName = rightPlayerCommand.Split('#')[1];
                Battle.RightPlayer.CurrentMonster = monsterName;
                await Battle.RightPlayerSummonsMonster(monsterName, 500, 50);
                
                goto GameLoopStart;
            }

            // If the left monster name is the same as the right monster name, the right monster ownership text will be displayed.
            var rightMonsterOwnership = Battle.LeftPlayer.CurrentMonster == Battle.RightPlayer.CurrentMonster
                ? $"Summoner {Battle.RightPlayer.Name}'s "
                : "";

            var leftMonster = Battle.LeftPlayer.Monsters[Battle.LeftPlayer.CurrentMonster];
            var rightMonster = Battle.RightPlayer.Monsters[Battle.RightPlayer.CurrentMonster];

            var leftMonsterStatusBar = Battle.LeftPlayerMonsterStatusBar;
            var rightMonsterStatusBar = Battle.RightPlayerMonsterStatusBar;

            var leftSkill = leftMonster.Skills[leftPlayerCommand.Split('#')[1]];
            var rightSkill = rightMonster.Skills[rightPlayerCommand.Split('#')[1]];

            var leftRandom = new Random();
            var leftCriticalHit = leftRandom.Next(0, 100) < CriticalHitRate ? true : false;
            var leftSkillHit = leftRandom.Next(0, 100) < leftSkill.HitRate ? true : false;

            var rightRandom = new Random();
            var rightCriticalHit = rightRandom.Next(0, 100) < CriticalHitRate ? true : false;
            var rightSkillHit = rightRandom.Next(0, 100) < rightSkill.HitRate ? true : false;

            var leftMonsterSpeed = leftMonster.Speed;
            var rightMonsterSpeed = rightMonster.Speed;

            if (leftMonsterSpeed == rightMonsterSpeed)
            {
                var random = new Random();
                var randomValue = random.Next(0, 2);
                if (randomValue == 0)
                    leftMonsterSpeed++;
                else
                    rightMonsterSpeed++;
            }

            if (leftSkill is DefenseSkill leftDefenseSkill)
            {
                await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}!");
                if (leftSkillHit)
                {
                    leftMonster.Defense += leftDefenseSkill.Defense;
                    await BattleMessageBox.AutoShow($"{leftMonster.Name}'s defense increase!");
                }
                else
                {
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name} but it missed!");
                }
            }

            if (rightSkill is DefenseSkill rightDefenseSkill)
            {
                await BattleMessageBox.AutoShow($"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name}!");
                if (rightSkillHit)
                {
                    rightMonster.Defense += rightDefenseSkill.Defense;
                    await BattleMessageBox.AutoShow($"{rightMonsterOwnership}{rightMonster.Name}'s defense increase!");
                }
                else
                {
                    await BattleMessageBox.AutoShow(
                        $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name} but it missed!");
                }
            }

            // Combo 1
            if (leftMonsterSpeed > rightMonsterSpeed)
            {
                leftSkill.Limit--;
                
                if (leftSkill is AttackSkill leftAttackSkill)
                {
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}!");
                    if (leftSkillHit)
                    {
                        var damage = leftMonster.Attack + leftAttackSkill.Damage;
                        if (leftCriticalHit)
                        {
                            damage *= 2;
                            await BattleMessageBox.AutoShow("Critical hit!");
                        }

                        damage -= rightMonster.Defense;

                        if (damage < 0)
                            damage = 0;

                        rightMonster.CurrentHealth -= damage;
                        await rightMonsterStatusBar.ApplyValue(-damage);
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} receives {damage} damage!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name} but it missed!");
                    }
                }

                if (leftSkill is FixedDamageSkill leftFixedDamageSkill)
                {
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}!");
                    if (leftSkillHit)
                    {
                        var damage = leftMonster.Attack + leftFixedDamageSkill.FixedDamage;
                        rightMonster.CurrentHealth -= damage;
                        await rightMonsterStatusBar.ApplyValue(-damage);
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} receives {damage} damage!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name} but it missed!");
                    }
                }

                if (leftSkill is HealingSkill leftHealingSkill)
                {
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}!");
                    if (leftSkillHit)
                    {
                        leftMonster.CurrentHealth += leftHealingSkill.Heal;
                        if (leftMonster.CurrentHealth > leftMonster.Health)
                            leftMonster.CurrentHealth = leftMonster.Health;
                        await leftMonsterStatusBar.ApplyValue(leftHealingSkill.Heal);
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} recovers {leftHealingSkill.Heal} HP!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name} but it missed!");
                    }
                }

                if (rightMonster.CurrentHealth <= 0)
                {
                    rightMonster.CurrentHealth = 0;
                    await BattleMessageBox.AutoShow($"{rightMonsterOwnership}{rightMonster.Name} fainted!");
                    await Battle.RightPlayerSummonsMonster(rightMonster.Name, 500, 50);
                    goto GameLoopStart;
                }

                rightSkill.Limit--;
                if (rightSkill is AttackSkill rightAttackSkill)
                {
                    await BattleMessageBox.AutoShow(
                        $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name}!");
                    if (rightSkillHit)
                    {
                        var damage = rightMonster.Attack + rightAttackSkill.Damage;
                        if (rightCriticalHit)
                        {
                            damage *= 2;
                            await BattleMessageBox.AutoShow("Critical hit!");
                        }

                        damage -= leftMonster.Defense;

                        if (damage < 0)
                            damage = 0;

                        leftMonster.CurrentHealth -= damage;
                        await leftMonsterStatusBar.ApplyValue(-damage);
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} receives {damage} damage!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name} but it missed!");
                    }
                }

                if (rightSkill is FixedDamageSkill rightFixedDamageSkill)
                {
                    await BattleMessageBox.AutoShow(
                        $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name}!");
                    if (rightSkillHit)
                    {
                        var damage = rightMonster.Attack + rightFixedDamageSkill.FixedDamage;
                        leftMonster.CurrentHealth -= damage;
                        await leftMonsterStatusBar.ApplyValue(-damage);
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} receives {damage} damage!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name} but it missed!");
                    }
                }

                if (rightSkill is HealingSkill rightHealingSkill)
                {
                    await BattleMessageBox.AutoShow(
                        $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name}!");
                    if (rightSkillHit)
                    {
                        rightMonster.CurrentHealth += rightHealingSkill.Heal;
                        if (rightMonster.CurrentHealth > rightMonster.Health)
                            rightMonster.CurrentHealth = rightMonster.Health;
                        await rightMonsterStatusBar.ApplyValue(rightHealingSkill.Heal);
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} recovers {rightHealingSkill.Heal} HP!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name} but it missed!");
                    }
                }

                if (leftMonster.CurrentHealth <= 0)
                {
                    leftMonster.CurrentHealth = 0;
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} fainted!");
                    await Battle.LeftPlayerSummonsMonster(leftMonster.Name, 500, 50);
                    goto GameLoopStart;
                }
            }

            // Combo 2
            if (rightMonsterSpeed > leftMonsterSpeed)
            {
                rightSkill.Limit--;
                
                if (rightSkill is AttackSkill rightAttackSkill)
                {
                    await BattleMessageBox.AutoShow(
                        $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name}!");
                    if (rightSkillHit)
                    {
                        var damage = rightMonster.Attack + rightAttackSkill.Damage;
                        if (rightCriticalHit)
                        {
                            damage *= 2;
                            await BattleMessageBox.AutoShow("Critical hit!");
                        }

                        damage -= leftMonster.Defense;

                        if (damage < 0)
                            damage = 0;

                        leftMonster.CurrentHealth -= damage;
                        await leftMonsterStatusBar.ApplyValue(-damage);
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} receives {damage} damage!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name} but it missed!");
                    }
                }

                if (rightSkill is FixedDamageSkill rightFixedDamageSkill)
                {
                    await BattleMessageBox.AutoShow(
                        $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name}!");
                    if (rightSkillHit)
                    {
                        var damage = rightMonster.Attack + rightFixedDamageSkill.FixedDamage;
                        leftMonster.CurrentHealth -= damage;
                        await leftMonsterStatusBar.ApplyValue(-damage);
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} receives {damage} damage!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name} but it missed!");
                    }
                }

                if (rightSkill is HealingSkill rightHealingSkill)
                {
                    await BattleMessageBox.AutoShow(
                        $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name}!");
                    if (rightSkillHit)
                    {
                        rightMonster.CurrentHealth += rightHealingSkill.Heal;
                        if (rightMonster.CurrentHealth > rightMonster.Health)
                            rightMonster.CurrentHealth = rightMonster.Health;
                        await rightMonsterStatusBar.ApplyValue(rightHealingSkill.Heal);
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} recovers {rightHealingSkill.Heal} HP!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name} but it missed!");
                    }
                }

                if (leftMonster.CurrentHealth <= 0)
                {
                    leftMonster.CurrentHealth = 0;
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} fainted!");
                    await Battle.LeftPlayerSummonsMonster(leftMonster.Name, 500, 50);
                    goto GameLoopStart;
                }

                leftSkill.Limit--;
                
                if (leftSkill is AttackSkill leftAttackSkill)
                {
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}!");
                    if (leftSkillHit)
                    {
                        var damage = leftMonster.Attack + leftAttackSkill.Damage;
                        if (leftCriticalHit)
                        {
                            damage *= 2;
                            await BattleMessageBox.AutoShow("Critical hit!");
                        }

                        damage -= rightMonster.Defense;

                        if (damage < 0)
                            damage = 0;

                        rightMonster.CurrentHealth -= damage;
                        await rightMonsterStatusBar.ApplyValue(-damage);
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} receives {damage} damage!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name} but it missed!");
                    }
                }

                if (leftSkill is FixedDamageSkill leftFixedDamageSkill)
                {
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}!");
                    if (leftSkillHit)
                    {
                        var damage = leftMonster.Attack + leftFixedDamageSkill.FixedDamage;
                        rightMonster.CurrentHealth -= damage;
                        await rightMonsterStatusBar.ApplyValue(-damage);
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} receives {damage} damage!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name} but it missed!");
                    }
                }

                if (leftSkill is HealingSkill leftHealingSkill)
                {
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}!");
                    if (leftSkillHit)
                    {
                        leftMonster.CurrentHealth += leftHealingSkill.Heal;
                        if (leftMonster.CurrentHealth > leftMonster.Health)
                            leftMonster.CurrentHealth = leftMonster.Health;
                        await leftMonsterStatusBar.ApplyValue(leftHealingSkill.Heal);
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} recovers {leftHealingSkill.Heal} HP!");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name} but it missed!");
                    }
                }

                if (rightMonster.CurrentHealth <= 0)
                {
                    rightMonster.CurrentHealth = 0;
                    await BattleMessageBox.AutoShow($"{rightMonsterOwnership}{rightMonster.Name} fainted!");
                    await Battle.RightPlayerSummonsMonster(rightMonster.Name, 500, 50);
                    goto GameLoopStart;
                }
            }
        }
    }

    public async Task SendMonstersAtStart()
    {
        await BattleMessageBox.AutoShow("Summoner " + Battle.RightPlayer.Name + " summons " +
                                        Battle.RightPlayer.MonsterOrder[0] + ".");
        Battle.RightPlayer.CurrentMonster = Battle.RightPlayer.MonsterOrder[0];
        await Battle.MoveRightPlayerOut(500, 50);
        await Battle.RightPlayerSummonsMonster(Battle.RightPlayer.MonsterOrder[0], 500, 50);

        await Task.Delay(200);

        await BattleMessageBox.AutoShow($"You summon {Battle.LeftPlayer.MonsterOrder[0]}.");
        Battle.LeftPlayer.CurrentMonster = Battle.LeftPlayer.MonsterOrder[0];
        await Battle.MoveLeftPlayerOut(500, 50);
        await Battle.LeftPlayerSummonsMonster(Battle.LeftPlayer.MonsterOrder[0], 500, 50);
    }

    public async Task<string> DisplayBattleMenu()
    {
        await Battle.DisplayMenu();

        var commandFromBattleMenu = Battle.BattleMenu.Command;
        Battle.BattleMenu.Command = "";

        return commandFromBattleMenu;
    }

    public async Task Dispose()
    {
        AudioPlayer.StopBGM();

        sourceForm.Controls.Remove(BattleMessageBox);
        sourceForm.Controls.Remove(Battle);
    }
}