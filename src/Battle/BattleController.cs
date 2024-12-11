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
    }

    public async Task GameLoop()
    {
        while (!hasWinner && !isDraw)
        {
            turn++;
            
            string leftPlayerCommand = await Battle.LeftPlayer.GetCommandString(this); // Player

            Battle.Refresh();

            string rightPlayerCommand = await Battle.RightPlayer.GetCommandString(this); // AI

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
                {
                    await BattleMessageBox.AutoShow($"Come back, {Battle.LeftPlayer.CurrentMonster}!");
                }
                
                await BattleMessageBox.AutoShow($"Summoning magic! {leftPlayerCommand.Split('#')[1]}!");

                Battle.LeftPlayer.Monsters[Battle.LeftPlayer.CurrentMonster].Buffs.Clear();

                string monsterName = leftPlayerCommand.Split('#')[1];
                Battle.LeftPlayer.CurrentMonster = monsterName;
                await Battle.LeftPlayerSummonsMonster(monsterName, 500, 50);
            }

            if (rightPlayerCommand.Contains("Switch#"))
            {
                if (Battle.RightPlayer.Monsters[Battle.RightPlayer.CurrentMonster].CurrentHealth > 0)
                {
                    await BattleMessageBox.AutoShow(
                        $"Summoner {Battle.RightPlayer.Name} calls back {Battle.RightPlayer.CurrentMonster}!");
                }
                
                await BattleMessageBox.AutoShow(
                    $"Summoner {Battle.RightPlayer.Name} summons {rightPlayerCommand.Split('#')[1]}!");

                Battle.RightPlayer.Monsters[Battle.RightPlayer.CurrentMonster].Buffs.Clear();

                string monsterName = rightPlayerCommand.Split('#')[1];
                Battle.RightPlayer.CurrentMonster = monsterName;
                await Battle.RightPlayerSummonsMonster(monsterName, 500, 50);
            }

            if (leftPlayerCommand.Contains("Switch#") || rightPlayerCommand.Contains("Switch#"))
            {
                continue;
            }
            
            // Preparing for applying buffs/debuffs and using skills
            // If the left monster name is the same as the right monster name, the right monster ownership text will be displayed.
            string rightMonsterOwnership = Battle.LeftPlayer.CurrentMonster == Battle.RightPlayer.CurrentMonster
                ? $"Summoner {Battle.RightPlayer.Name}'s "
                : "";
            
            var leftMonster = Battle.LeftPlayer.Monsters[Battle.LeftPlayer.CurrentMonster];
            var rightMonster = Battle.RightPlayer.Monsters[Battle.RightPlayer.CurrentMonster];
            
            var leftMonsterStatusBar = Battle.LeftPlayerMonsterStatusBar;
            var rightMonsterStatusBar = Battle.RightPlayerMonsterStatusBar;
            
            var leftSkill = leftMonster.Skills[leftPlayerCommand.Split('#')[1]];
            var rightSkill = rightMonster.Skills[rightPlayerCommand.Split('#')[1]];
            
            var leftBuffs = leftMonster.Buffs;
            var rightBuffs = rightMonster.Buffs;
            
            var leftRandom = new Random();
            var leftCriticalHit = leftRandom.Next(0, 100) < CriticalHitRate ? true : false;
            var leftSkillHit = leftRandom.Next(0, 100) < leftSkill.HitRate ? true : false;
            
            var rightRandom = new Random();
            var rightCriticalHit = rightRandom.Next(0, 100) < CriticalHitRate ? true : false;
            var rightSkillHit = rightRandom.Next(0, 100) < rightSkill.HitRate ? true : false;
            
            // Applying and updating buffs/debuffs
            var leftBuffEffect = new BuffEffect();
            foreach (var buff in leftBuffs)
            {
                if (buff.Property == "Health")
                {
                    if (buff.Value < 0)
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} gets {buff.Name}'s damage.");
                        leftMonster.CurrentHealth += buff.Value;
                        await leftMonsterStatusBar.ApplyValue(buff.Value);
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} gets {buff.Name}'s healing.");
                        leftMonster.CurrentHealth += buff.Value;
                        await leftMonsterStatusBar.ApplyValue(buff.Value);
                    }
                }
                else if (buff.Property == "Attack")
                {
                    leftBuffEffect.Attack += buff.Value;
                }
                else if (buff.Property == "Defense")
                {
                    leftBuffEffect.Defense += buff.Value;
                }
                else if (buff.Property == "Speed")
                {
                    leftBuffEffect.Speed += buff.Value;
                }
                else if (buff.Property == "TurnSkip")
                {
                    leftBuffEffect.TurnSkip = leftRandom.Next(0, 100) < buff.Value;
                }

                buff.Duration--;
            }

            foreach (var buff in leftBuffs)
                if (buff.Duration < 0)
                    leftBuffs.Remove(buff);

            var rightBuffEffect = new BuffEffect();
            foreach (var buff in rightBuffs)
            {
                if (buff.Property == "Health")
                {
                    if (buff.Value < 0)
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} gets {buff.Name}'s damage.");
                        rightMonster.CurrentHealth += buff.Value;
                        await rightMonsterStatusBar.ApplyValue(buff.Value);
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} gets {buff.Name}'s healing.");
                        rightMonster.CurrentHealth += buff.Value;
                        await rightMonsterStatusBar.ApplyValue(buff.Value);
                    }
                }
                else if (buff.Property == "Attack")
                {
                    rightBuffEffect.Attack += buff.Value;
                }
                else if (buff.Property == "Defense")
                {
                    rightBuffEffect.Defense += buff.Value;
                }
                else if (buff.Property == "Speed")
                {
                    rightBuffEffect.Speed += buff.Value;
                }
                else if (buff.Property == "TurnSkip")
                {
                    rightBuffEffect.TurnSkip = rightRandom.Next(0, 100) < buff.Value;
                }

                buff.Duration--;
            }

            foreach (var buff in rightBuffs)
                if (buff.Duration < 0)
                    rightBuffs.Remove(buff);

            if (leftBuffEffect.TurnSkip && rightBuffEffect.TurnSkip)
            {
                await BattleMessageBox.AutoShow($"{leftMonster.Name} cannot move!");
                await BattleMessageBox.AutoShow($"{rightMonsterOwnership}{rightMonster.Name} cannot move!");
                continue;
            }

            if (leftBuffEffect.TurnSkip)
            {
                await BattleMessageBox.AutoShow($"{leftMonster.Name} cannot move!");
            }
            else
            {
                if (leftSkill is DefenseSkill leftDefenseSkill)
                {
                    if (leftSkillHit)
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftDefenseSkill.Name}.");
                        leftBuffEffect.Defense += leftDefenseSkill.Defense;
                        await BattleMessageBox.AutoShow($"{leftMonster.Name}'s defense increased in this turn.");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} failed to use {leftDefenseSkill.Name}.");
                    }
                }
            }
            
            if (rightBuffEffect.TurnSkip)
            {
                await BattleMessageBox.AutoShow($"{rightMonsterOwnership}{rightMonster.Name} cannot move!");
            }
            else
            {
                if (rightSkill is DefenseSkill rightDefenseSkill)
                {
                    if (rightSkillHit)
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} uses {rightDefenseSkill.Name}.");
                        rightBuffEffect.Defense += rightDefenseSkill.Defense;
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name}'s defense increased in this turn.");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} failed to use {rightDefenseSkill.Name}.");
                    }
                }
            }
            
            var leftMonsterSpeed = leftMonster.Speed + leftBuffEffect.Speed;
            var rightMonsterSpeed = rightMonster.Speed + rightBuffEffect.Speed;

            if (leftMonsterSpeed == rightMonsterSpeed)
            {
                var random = new Random();
                var randomValue = random.Next(0, 2);
                if (randomValue == 0)
                    leftMonsterSpeed++;
                else
                    rightMonsterSpeed++;
            }
            
            // Using skills

            // left can move and speed is faster (Combo 1)
            if (!leftBuffEffect.TurnSkip && leftMonsterSpeed > rightMonsterSpeed)
            {
            }
            
            // right can move and speed is faster (Combo 2)
            if (!rightBuffEffect.TurnSkip && rightMonsterSpeed > leftMonsterSpeed)
            {
            }
            
            // checkpoint for current HP
            if (leftMonster.CurrentHealth <= 0 || rightMonster.CurrentHealth <= 0)
            {
                if (leftMonster.CurrentHealth <= 0)
                {
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} fainted!");
                    await Battle.LeftPlayerSummonsMonster(leftMonster.Name, 500, 50);
                }
                
                if (rightMonster.CurrentHealth <= 0)
                {
                    await BattleMessageBox.AutoShow($"{rightMonsterOwnership}{rightMonster.Name} fainted!");
                    await Battle.RightPlayerSummonsMonster(rightMonster.Name, 500, 50);
                }
            }
            else
            {
                // left can move and speed is slower (Combo 2)
                if (!leftBuffEffect.TurnSkip && leftMonsterSpeed < rightMonsterSpeed)
                {
                }
            
                // right can move and speed is slower (Combo 1)
                if (!rightBuffEffect.TurnSkip && rightMonsterSpeed < leftMonsterSpeed)
                {
                }
                
                // checkpoint 2 for current HP
                if (leftMonster.CurrentHealth <= 0 || rightMonster.CurrentHealth <= 0)
                {
                    if (leftMonster.CurrentHealth <= 0)
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} fainted!");
                        await Battle.LeftPlayerSummonsMonster(leftMonster.Name, 500, 50);
                    }
                
                    if (rightMonster.CurrentHealth <= 0)
                    {
                        await BattleMessageBox.AutoShow($"{rightMonsterOwnership}{rightMonster.Name} fainted!");
                        await Battle.RightPlayerSummonsMonster(rightMonster.Name, 500, 50);
                    }
                }
            }
        }

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

        // foreach (Control control in sourceForm.Controls)
        // {
        //     Console.WriteLine(control.Name);
        // }
        // Console.WriteLine(sourceForm.Controls.Count);
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

// In GameLoop method
// for using skills (Version 1)

// string rightMonsterOwner = Battle.LeftPlayer.CurrentMonster == Battle.RightPlayer.CurrentMonster ? $"Summoner {Battle.RightPlayer.Name}'s " : "";

// int leftPlayerMonsterSpeed = Battle.LeftPlayer.Monsters[Battle.LeftPlayer.CurrentMonster].Speed;
// foreach (var buff in Battle.LeftPlayer.Monsters[Battle.LeftPlayer.CurrentMonster].Buffs)
// {
//     if (buff.Property == "Speed")
//     {
//         leftPlayerMonsterSpeed += buff.Value;
//     }
// }

// int rightPlayerMonsterSpeed = Battle.RightPlayer.Monsters[Battle.RightPlayer.CurrentMonster].Speed;
// foreach (var buff in Battle.RightPlayer.Monsters[Battle.RightPlayer.CurrentMonster].Buffs)
// {
//     if (buff.Property == "Speed")
//     {
//         rightPlayerMonsterSpeed += buff.Value;
//     }
// }
//
// if (leftPlayerMonsterSpeed == rightPlayerMonsterSpeed)
// {
//     Random random = new Random();
//     int randomValue = random.Next(0, 2);
//     if (randomValue == 0)
//     {
//         leftPlayerMonsterSpeed++;
//     }
//     else
//     {
//         rightPlayerMonsterSpeed++;
//     }
// }
//
// Monster leftPlayerMonster = Battle.LeftPlayer.Monsters[Battle.LeftPlayer.CurrentMonster];
// Monster rightPlayerMonster = Battle.RightPlayer.Monsters[Battle.RightPlayer.CurrentMonster];
//
// string leftPlayerMonsterSkillName = leftPlayerCommand.Split('#')[1];
// string rightPlayerMonsterSkillName = rightPlayerCommand.Split('#')[1];
//
// Skill leftPlayerMonsterSkill = leftPlayerMonster.Skills[leftPlayerMonsterSkillName];
// Skill rightPlayerMonsterSkill = rightPlayerMonster.Skills[rightPlayerMonsterSkillName];
//
// int leftPlayerMonsterTempDefenseFromDefenseSkill = 0;
// int rightPlayerMonsterTempDefenseFromDefenseSkill = 0;
//
// if (leftPlayerMonsterSkill is DefenseSkill leftPlayerMonsterDefenseSkill)
// {
//     await BattleMessageBox.AutoShow($"{leftPlayerMonster.Name} uses {leftPlayerMonsterSkillName}.");
//     
//     Random random = new Random();
//     int randomValue = random.Next(0, 100);
//     if (randomValue < leftPlayerMonsterSkill.HitRate)
//     {
//         leftPlayerMonsterTempDefenseFromDefenseSkill = leftPlayerMonsterDefenseSkill.Defense;
//         await BattleMessageBox.AutoShow($"{leftPlayerMonster.Name}'s defense increased in this turn.");
//     }
//     else
//     {
//         await BattleMessageBox.AutoShow($"{leftPlayerMonster.Name} failed to use {leftPlayerMonsterSkillName}.");
//     }
//
//     leftPlayerMonsterSkill.Limit--;
// }
//
// if (rightPlayerMonsterSkill is DefenseSkill rightPlayerMonsterDefenseSkill)
// {
//     await BattleMessageBox.AutoShow($"{rightMonsterOwner}{rightPlayerMonster.Name} uses {rightPlayerMonsterSkillName}.");
//     
//     Random random = new Random();
//     int randomValue = random.Next(0, 100);
//     if (randomValue < rightPlayerMonsterSkill.HitRate)
//     {
//         rightPlayerMonsterTempDefenseFromDefenseSkill = rightPlayerMonsterDefenseSkill.Defense;
//         await BattleMessageBox.AutoShow($"{rightMonsterOwner}{rightPlayerMonster.Name}'s defense increased in this turn.");
//     }
//     else
//     {
//         await BattleMessageBox.AutoShow($"{rightMonsterOwner}{rightPlayerMonster.Name} failed to use {rightPlayerMonsterSkillName}.");
//     }
//     
//     rightPlayerMonsterSkill.Limit--;
// }
//
// if (leftPlayerMonsterSpeed > rightPlayerMonsterSpeed)
// {
//     if (leftPlayerMonsterSkill is AttackAndBuffSkill leftPlayerMonsterAttackAndBuffSkill)
//     {
//         await BattleMessageBox.AutoShow($"{leftPlayerMonster.Name} uses {leftPlayerMonsterSkillName}.");
//         
//     }
//     
// }
// else if (rightPlayerMonsterSpeed > leftPlayerMonsterSpeed)
// {
//     
// }

