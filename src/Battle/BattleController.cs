using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public class BattleController
{
    private readonly Form sourceForm;

    public Battle Battle { get; set; }
    public List<PictureBox> Gates = new List<PictureBox>();

    public BattleMessageBox BattleMessageBox;
    public TaskCompletionSource<bool> MessageBoxTcs;

    private int turn = 0;
    private string battleResult;
    private IPlayer winner;
    private bool hasWinner = false;
    private bool isDraw = false;

    private Battle battleForRetry;
    
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
            string leftPlayerCommand = await Battle.LeftPlayer.GetCommandString(this); // Player

            Battle.Refresh();

            string rightPlayerCommand = await Battle.RightPlayer.GetCommandString(this); // AI

            // for surrendering
            if (leftPlayerCommand == "Surrender" && rightPlayerCommand == "Surrender")
            {
                isDraw = true;
                battleResult = "Draw";
                continue;
            }

            if (leftPlayerCommand == "Surrender" && rightPlayerCommand != "Surrender")
            {
                hasWinner = true;
                battleResult = "Defeat";
                winner = Battle.RightPlayer;

                await BattleMessageBox.AutoShow($"Summoner {Battle.LeftPlayer.Name} surrenders!");
                continue;
            }

            if (leftPlayerCommand != "Surrender" && rightPlayerCommand == "Surrender")
            {
                hasWinner = true;
                battleResult = "Victory";
                winner = Battle.LeftPlayer;

                await BattleMessageBox.AutoShow($"Summoner {Battle.RightPlayer.Name} surrenders!");
                continue;
            }

            // for switching monster
            if (leftPlayerCommand.Contains("Switch#"))
            {
                await BattleMessageBox.AutoShow($"Come back, {Battle.LeftPlayer.CurrentMonster}!");
                await BattleMessageBox.AutoShow($"Summoning magic! {leftPlayerCommand.Split('#')[1]}!");

                Battle.LeftPlayer.Monsters[Battle.LeftPlayer.CurrentMonster].Buffs.Clear();

                string monsterName = leftPlayerCommand.Split('#')[1];
                Battle.LeftPlayer.CurrentMonster = monsterName;
                await Battle.LeftPlayerSummonsMonster(monsterName, 500, 50);
            }

            if (rightPlayerCommand.Contains("Switch#"))
            {
                await BattleMessageBox.AutoShow(
                    $"Summoner {Battle.RightPlayer.Name} calls back {Battle.RightPlayer.CurrentMonster}!");
                await BattleMessageBox.AutoShow(
                    $"Summoner {Battle.RightPlayer.Name} summons {rightPlayerCommand.Split('#')[1]}!");

                Battle.RightPlayer.Monsters[Battle.RightPlayer.CurrentMonster].Buffs.Clear();

                string monsterName = rightPlayerCommand.Split('#')[1];
                Battle.RightPlayer.CurrentMonster = monsterName;
                await Battle.RightPlayerSummonsMonster(monsterName, 500, 50);
            }

            // Preparing for applying buffs/debuffs and using skills

            // If the left monster name is the same as the right monster name, the right monster ownership text will be displayed.
            string rightMonsterOwnership = Battle.LeftPlayer.CurrentMonster == Battle.RightPlayer.CurrentMonster
                ? $"Summoner {Battle.RightPlayer.Name}'s "
                : "";

            Monster leftMonster = Battle.LeftPlayer.Monsters[Battle.LeftPlayer.CurrentMonster];
            Monster rightMonster = Battle.RightPlayer.Monsters[Battle.RightPlayer.CurrentMonster];

            MonsterStatusBar leftMonsterStatusBar = Battle.LeftPlayerMonsterStatusBar;
            MonsterStatusBar rightMonsterStatusBar = Battle.RightPlayerMonsterStatusBar;

            Skill leftSkill = leftMonster.Skills[leftPlayerCommand.Split('#')[1]];
            Skill rightSkill = rightMonster.Skills[rightPlayerCommand.Split('#')[1]];

            List<Buff> leftBuffs = leftMonster.Buffs;
            List<Buff> rightBuffs = rightMonster.Buffs;

            Random leftRandom = new Random();
            bool leftCriticalHit = leftRandom.Next(0, 100) < CriticalHitRate ? true : false;
            bool leftSkillHit = leftRandom.Next(0, 100) < leftSkill.HitRate ? true : false;

            Random rightRandom = new Random();
            bool rightCriticalHit = rightRandom.Next(0, 100) < CriticalHitRate ? true : false;
            bool rightSkillHit = rightRandom.Next(0, 100) < rightSkill.HitRate ? true : false;


            // Applying and updating buffs/debuffs
            BuffEffect leftBuffEffect = new BuffEffect();
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
                else
                {
                    continue;
                }

                buff.Duration--;
            }

            foreach (var buff in leftBuffs)
            {
                if (buff.Duration < 0)
                {
                    leftBuffs.Remove(buff);
                }
            }

            BuffEffect rightBuffEffect = new BuffEffect();
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
            {
                if (buff.Duration < 0)
                {
                    rightBuffs.Remove(buff);
                }
            }

            if (leftBuffEffect.TurnSkip || rightBuffEffect.TurnSkip)
            {
                await BattleMessageBox.AutoShow($"{leftMonster.Name} cannot move!");
                await BattleMessageBox.AutoShow($"{rightMonsterOwnership}{rightMonster.Name} cannot move!");
                continue;
            }

            // Using skills

            if (leftSkill is DefenseSkill leftDefenseSkill && leftBuffEffect.TurnSkip == false)
            {
                if (leftSkillHit)
                {
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                    leftBuffEffect.Defense += leftDefenseSkill.Defense;
                    await BattleMessageBox.AutoShow($"{leftMonster.Name}'s defense increased in this turn.");
                }
                else
                {
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} failed to use {leftSkill.Name}.");
                }
            }

            if (rightSkill is DefenseSkill rightDefenseSkill && rightBuffEffect.TurnSkip == false)
            {
                if (rightSkillHit)
                {
                    await BattleMessageBox.AutoShow(
                        $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name}.");
                    rightBuffEffect.Defense += rightDefenseSkill.Defense;
                    await BattleMessageBox.AutoShow(
                        $"{rightMonsterOwnership}{rightMonster.Name}'s defense increased in this turn.");
                }
                else
                {
                    await BattleMessageBox.AutoShow(
                        $"{rightMonsterOwnership}{rightMonster.Name} failed to use {rightSkill.Name}.");
                }
            }


            int leftMonsterSpeed = leftMonster.Speed + leftBuffEffect.Speed;
            int rightMonsterSpeed = rightMonster.Speed + rightBuffEffect.Speed;

            if (leftMonsterSpeed == rightMonsterSpeed)
            {
                Random random = new Random();
                int randomValue = random.Next(0, 2);
                if (randomValue == 0)
                {
                    leftMonsterSpeed++;
                }
                else
                {
                    rightMonsterSpeed++;
                }
            }

            if (leftMonsterSpeed > rightMonsterSpeed)
            {
                // AttackAndBuffSkill
                if (leftSkill is AttackAndBuffSkill leftAttackAndBuffSkill && leftBuffEffect.TurnSkip == false)
                {
                    leftSkill.Limit--;
                    if (leftSkillHit)
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        int damage = leftMonster.Attack + leftAttackAndBuffSkill.Damage + leftBuffEffect.Attack;
                        if (leftCriticalHit)
                        {
                            damage *= 2;
                            await BattleMessageBox.AutoShow($"{leftMonster.Name} lands a critical hit!");
                        }

                        damage -= rightBuffEffect.Defense + rightMonster.Defense;

                        await BattleMessageBox.AutoShow(
                            $"{leftMonster.Name} deals {damage} damage to {rightMonsterOwnership}{rightMonster.Name}.");
                        rightMonster.CurrentHealth -= damage;
                        await rightMonsterStatusBar.ApplyValue(-damage);

                        foreach (var buff in leftAttackAndBuffSkill.Buffs)
                        {
                            leftBuffs.Add(buff);
                            await BattleMessageBox.AutoShow(
                                $"{leftMonster.Name} gets the buff '{buff.Name}' from the skill.");

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
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        await BattleMessageBox.AutoShow(
                            $"However, {leftMonster.Name} failed to hit {rightMonsterOwnership}{rightMonster.Name}.");
                    }
                }

                // AttackAndDebuffSkill
                if (leftSkill is AttackAndDebuffSkill leftAttackAndDebuffSkill && leftBuffEffect.TurnSkip == false)
                {
                    leftSkill.Limit--;
                    if (leftSkillHit)
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        int damage = leftMonster.Attack + leftAttackAndDebuffSkill.Damage + leftBuffEffect.Attack;
                        if (leftCriticalHit)
                        {
                            damage *= 2;
                            await BattleMessageBox.AutoShow($"{leftMonster.Name} lands a critical hit!");
                        }

                        damage -= rightBuffEffect.Defense + rightMonster.Defense;

                        await BattleMessageBox.AutoShow(
                            $"{leftMonster.Name} deals {damage} damage to {rightMonsterOwnership}{rightMonster.Name}.");
                        rightMonster.CurrentHealth -= damage;
                        await rightMonsterStatusBar.ApplyValue(-damage);

                        if (leftRandom.Next(0, 100) < leftAttackAndDebuffSkill.DebuffHitRate)
                            foreach (var debuff in leftAttackAndDebuffSkill.Debuffs)
                            {
                                rightBuffs.Add(debuff);
                                await BattleMessageBox.AutoShow(
                                    $"{rightMonsterOwnership}{rightMonster.Name} gets the debuff '{debuff.Name}' from the skill.");

                                if (debuff.Property == "Health")
                                {
                                    if (debuff.Value < 0)
                                    {
                                        await BattleMessageBox.AutoShow(
                                            $"{rightMonsterOwnership}{rightMonster.Name} gets {debuff.Name}'s damage.");
                                        rightMonster.CurrentHealth += debuff.Value;
                                        await rightMonsterStatusBar.ApplyValue(debuff.Value);
                                    }
                                    else
                                    {
                                        await BattleMessageBox.AutoShow(
                                            $"{rightMonsterOwnership}{rightMonster.Name} gets {debuff.Name}'s healing.");
                                        rightMonster.CurrentHealth += debuff.Value;
                                        await rightMonsterStatusBar.ApplyValue(debuff.Value);
                                    }
                                }
                                else if (debuff.Property == "Attack")
                                {
                                    rightBuffEffect.Attack += debuff.Value;
                                }
                                else if (debuff.Property == "Defense")
                                {
                                    rightBuffEffect.Defense += debuff.Value;
                                }
                                else if (debuff.Property == "Speed")
                                {
                                    rightBuffEffect.Speed += debuff.Value;
                                }
                                else if (debuff.Property == "TurnSkip")
                                {
                                    rightBuffEffect.TurnSkip = rightRandom.Next(0, 100) < debuff.Value;
                                }

                                debuff.Duration--;
                            }
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        await BattleMessageBox.AutoShow(
                            $"However, {leftMonster.Name} failed to hit {rightMonsterOwnership}{rightMonster.Name}.");
                    }
                }

                // AttackSkill
                if (leftSkill is AttackSkill leftAttackSkill && leftBuffEffect.TurnSkip == false)
                {
                    leftSkill.Limit--;
                    if (leftSkillHit)
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        int damage = leftMonster.Attack + leftAttackSkill.Damage + leftBuffEffect.Attack;
                        if (leftCriticalHit)
                        {
                            damage *= 2;
                            await BattleMessageBox.AutoShow($"{leftMonster.Name} lands a critical hit!");
                        }

                        damage -= rightBuffEffect.Defense + rightMonster.Defense;

                        await BattleMessageBox.AutoShow(
                            $"{leftMonster.Name} deals {damage} damage to {rightMonsterOwnership}{rightMonster.Name}.");
                        rightMonster.CurrentHealth -= damage;
                        await rightMonsterStatusBar.ApplyValue(-damage);
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        await BattleMessageBox.AutoShow(
                            $"However, {leftMonster.Name} failed to hit {rightMonsterOwnership}{rightMonster.Name}.");
                    }
                }

                // BuffSkill
                if (leftSkill is BuffSkill leftBuffSkill && leftBuffEffect.TurnSkip == false)
                {
                    leftSkill.Limit--;
                    if (leftSkillHit)
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        foreach (var buff in leftBuffSkill.Buffs)
                        {
                            leftBuffs.Add(buff);
                            await BattleMessageBox.AutoShow(
                                $"{leftMonster.Name} gets the buff '{buff.Name}' from the skill.");

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
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        await BattleMessageBox.AutoShow($"However, {leftMonster.Name} failed to use {leftSkill.Name}.");
                    }
                }

                // DebuffSkill
                if (leftSkill is DebuffSkill leftDebuffSkill && leftBuffEffect.TurnSkip == false)
                {
                    leftSkill.Limit--;
                    if (leftSkillHit)
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        foreach (var debuff in leftDebuffSkill.Debuffs)
                        {
                            rightBuffs.Add(debuff);
                            await BattleMessageBox.AutoShow(
                                $"{rightMonsterOwnership}{rightMonster.Name} gets the debuff '{debuff.Name}' from the skill.");

                            if (debuff.Property == "Health")
                            {
                                if (debuff.Value < 0)
                                {
                                    await BattleMessageBox.AutoShow(
                                        $"{rightMonsterOwnership}{rightMonster.Name} gets {debuff.Name}'s damage.");
                                    rightMonster.CurrentHealth += debuff.Value;
                                    await rightMonsterStatusBar.ApplyValue(debuff.Value);
                                }
                                else
                                {
                                    await BattleMessageBox.AutoShow(
                                        $"{rightMonsterOwnership}{rightMonster.Name} gets {debuff.Name}'s healing.");
                                    rightMonster.CurrentHealth += debuff.Value;
                                    await rightMonsterStatusBar.ApplyValue(debuff.Value);
                                }
                            }
                            else if (debuff.Property == "Attack")
                            {
                                rightBuffEffect.Attack += debuff.Value;
                            }
                            else if (debuff.Property == "Defense")
                            {
                                rightBuffEffect.Defense += debuff.Value;
                            }
                            else if (debuff.Property == "Speed")
                            {
                                rightBuffEffect.Speed += debuff.Value;
                            }
                            else if (debuff.Property == "TurnSkip")
                            {
                                rightBuffEffect.TurnSkip = rightRandom.Next(0, 100) < debuff.Value;
                            }

                            debuff.Duration--;
                        }
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        await BattleMessageBox.AutoShow($"However, {leftMonster.Name} failed to use {leftSkill.Name}.");
                    }
                }

                // FixedDamageSkill
                if (leftSkill is FixedDamageSkill leftFixedDamageSkill && leftBuffEffect.TurnSkip == false)
                {
                    leftSkill.Limit--;
                    if (leftSkillHit)
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        int damage = leftFixedDamageSkill.FixedDamage;
                        if (leftCriticalHit)
                        {
                            damage *= 2;
                            await BattleMessageBox.AutoShow($"{leftMonster.Name} lands a critical hit!");
                        }

                        await BattleMessageBox.AutoShow(
                            $"{leftMonster.Name} deals {damage} damage to {rightMonsterOwnership}{rightMonster.Name}.");
                        rightMonster.CurrentHealth -= damage;
                        await rightMonsterStatusBar.ApplyValue(-damage);
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        await BattleMessageBox.AutoShow($"However, {leftMonster.Name} failed to use {leftSkill.Name}.");
                    }
                }

                // HealingSkill
                if (leftSkill is HealingSkill leftHealingSkill && leftBuffEffect.TurnSkip == false)
                {
                    leftSkill.Limit--;
                    if (leftSkillHit)
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        int heal = leftHealingSkill.Heal;
                        if (leftCriticalHit)
                        {
                            heal *= 2;
                            await BattleMessageBox.AutoShow($"{leftMonster.Name} lands a critical heal!");
                        }

                        await BattleMessageBox.AutoShow($"{leftMonster.Name} heals {heal} health.");
                        leftMonster.CurrentHealth += heal;
                        await leftMonsterStatusBar.ApplyValue(heal);
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        await BattleMessageBox.AutoShow($"However, {leftMonster.Name} failed to use {leftSkill.Name}.");
                    }
                }

                // MultipleHitAttackSkill
                if (leftSkill is MultipleHitAttackSkill leftMultipleHitAttackSkill && leftBuffEffect.TurnSkip == false)
                {
                    leftSkill.Limit--;
                    if (leftSkillHit)
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        int totalDamage = 0;
                        int hitCount = leftRandom.Next(leftMultipleHitAttackSkill.MinHit,
                            leftMultipleHitAttackSkill.MaxHit + 1);
                        for (int i = 0; i < hitCount; i++)
                        {
                            int damage = leftMonster.Attack + leftMultipleHitAttackSkill.DamagePerHit +
                                         leftBuffEffect.Attack;
                            if (leftCriticalHit)
                            {
                                damage *= 2;
                                await BattleMessageBox.AutoShow($"{leftMonster.Name} lands a critical hit!");
                                leftCriticalHit = leftRandom.Next(0, 100) < CriticalHitRate ? true : false;
                            }

                            damage -= rightBuffEffect.Defense + rightMonster.Defense;

                            await BattleMessageBox.AutoShow(
                                $"{leftMonster.Name} deals {damage} damage to {rightMonsterOwnership}{rightMonster.Name}.");
                            rightMonster.CurrentHealth -= damage;
                            await rightMonsterStatusBar.ApplyValue(-damage);

                            totalDamage += damage;
                        }

                        string hitCountText = hitCount > 1 ? "s" : "";
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} hit {hitCount} time{hitCountText}.");
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} deals {totalDamage} damage in total.");
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow($"{leftMonster.Name} uses {leftSkill.Name}.");
                        await BattleMessageBox.AutoShow($"However, {leftMonster.Name} failed to use {leftSkill.Name}.");
                    }
                }

                if (leftBuffEffect.TurnSkip)
                {
                    await BattleMessageBox.AutoShow($"{leftMonster.Name} cannot move!");
                }

                if (rightMonster.CurrentHealth <= 0)
                {
                    rightMonster.CurrentHealth = 0;
                    await BattleMessageBox.AutoShow($"{rightMonsterOwnership}{rightMonster.Name} fainted!");
                    await Battle.RightPlayerSummonsMonster(string.Empty, 500, 50);
                    continue;
                }

                // Right monster's turn
                // AttackAndBuffSkill
                if (rightSkill is AttackAndBuffSkill rightAttackAndBuffSkill && rightBuffEffect.TurnSkip == false)
                {
                    rightSkill.Limit--;
                    if (rightSkillHit)
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name}.");
                        int damage = rightMonster.Attack + rightAttackAndBuffSkill.Damage + rightBuffEffect.Attack;
                        if (rightCriticalHit)
                        {
                            damage *= 2;
                            await BattleMessageBox.AutoShow(
                                $"{rightMonsterOwnership}{rightMonster.Name} lands a critical hit!");
                        }

                        damage -= leftBuffEffect.Defense + leftMonster.Defense;

                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} deals {damage} damage to {leftMonster.Name}.");
                        leftMonster.CurrentHealth -= damage;
                        await leftMonsterStatusBar.ApplyValue(-damage);

                        foreach (var buff in rightAttackAndBuffSkill.Buffs)
                        {
                            rightBuffs.Add(buff);
                            await BattleMessageBox.AutoShow(
                                $"{rightMonsterOwnership}{rightMonster.Name} gets the buff '{buff.Name}' from the skill.");

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
                    }
                    else
                    {
                        await BattleMessageBox.AutoShow(
                            $"{rightMonsterOwnership}{rightMonster.Name} uses {rightSkill.Name}.");
                        await BattleMessageBox.AutoShow(
                            $"However, {rightMonsterOwnership}{rightMonster.Name} failed to hit {leftMonster.Name}.");
                    }
                }

                // AttackAndDebuffSkill



                
            }
            else if (rightMonsterSpeed > leftMonsterSpeed)
            {
            }

            turn++;
        }

        MessageBoxTcs = new TaskCompletionSource<bool>();
        await BattleMessageBox.Show($"Duel over!");
        await MessageBoxTcs.Task;
        
        if (isDraw)
        {
            await BattleMessageBox.ShowWaiting($"Both summoners were surrendered!");
        }
        else
        {
            await BattleMessageBox.ShowWaiting($"The winner is Summoner {winner.Name}!");
        }
        
        await Task.Delay(3000);
        
        List<PictureBox> gates = await SceneEffect.CuttingInLikeClosingGate(sourceForm,
            "MonsterDuel_Data/effects/scenes/battle_opening_top.png", 
            "MonsterDuel_Data/effects/scenes/battle_opening_bottom.png", 200, 10);
        
        BattleMessageBox.CloseWaiting();
        await Dispose();

        BattleResult result = new BattleResult(sourceForm, battleResult, battleForRetry, gates);
        await result.Start();

        // foreach (Control control in sourceForm.Controls)
        // {
        //     Console.WriteLine(control.Name);
        // }
        // Console.WriteLine(sourceForm.Controls.Count);
    }

    public async Task SendMonstersAtStart()
    {
        await BattleMessageBox.AutoShow("Summoner " + Battle.RightPlayer.Name + " summons " + Battle.RightPlayer.MonsterOrder[0] + ".");
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

        string commandFromBattleMenu = Battle.BattleMenu.Command;
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