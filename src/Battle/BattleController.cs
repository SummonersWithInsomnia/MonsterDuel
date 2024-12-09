﻿using System;
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
                string monsterName = leftPlayerCommand.Split('#')[1];
                Battle.LeftPlayer.CurrentMonster = monsterName;
                await Battle.LeftPlayerSummonsMonster(monsterName, 500, 50);
            }
            
            if (rightPlayerCommand.Contains("Switch#"))
            {
                await BattleMessageBox.AutoShow($"Summoner {Battle.RightPlayer.Name} calls back {Battle.RightPlayer.CurrentMonster}!");
                await BattleMessageBox.AutoShow($"Summoner {Battle.RightPlayer.Name} summons {rightPlayerCommand.Split('#')[1]}!");
                string monsterName = rightPlayerCommand.Split('#')[1];
                Battle.RightPlayer.CurrentMonster = monsterName;
                await Battle.RightPlayerSummonsMonster(monsterName, 500, 50);
            }
            
            // for using skills (Version 2)
            
            // If the left monster name is the same as the right monster name, the right monster ownership text will be displayed.
            string rightMonsterOwnership = Battle.LeftPlayer.CurrentMonster == Battle.RightPlayer.CurrentMonster ? $"Summoner {Battle.RightPlayer.Name}'s " : "";
            
            
            
            
            
            
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