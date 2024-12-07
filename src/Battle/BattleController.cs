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

    private BattleMessageBox messageBox;
    public bool IsMessageBoxOpened = false;
    public TaskCompletionSource<bool> MessageBoxTcs;

    private IPlayer winner;
    private bool hasWinner = false;
    
    public BattleController(Form source, Battle battle, List<PictureBox> gates)
    {
        sourceForm = source;
        Battle = battle;
        Gates = gates;
        
        messageBox = new BattleMessageBox(this);
    }
    
    public async Task Start()
    {
        sourceForm.Controls.Add(messageBox);
        messageBox.Visible = false;
        sourceForm.Controls.Add(Battle);
        
        await Battle.Start(sourceForm, Gates);
        await Task.Delay(1000);
        
        MessageBoxTcs = new TaskCompletionSource<bool>();
        await messageBox.Show($"You are challenged by Summoner {Battle.RightPlayer.Name}!");
        await MessageBoxTcs.Task;

        await SendMonstersAtStart();
        
        // GameLoop();
    }

    public async Task GameLoop()
    {
        while (!hasWinner)
        {
            
        }
    }

    public async Task SendMonstersAtStart()
    {
        await messageBox.AutoShow("Summoner " + Battle.RightPlayer.Name + " summons " + Battle.RightPlayer.MonsterOrder[0] + ".");
        Battle.RightPlayer.CurrentMonster = Battle.RightPlayer.MonsterOrder[0];
        await Battle.MoveRightPlayerOut();
        //await Battle.RightPlayerSummonsMonster(Battle.RightPlayer.MonsterOrder[0]);

        await messageBox.AutoShow($"You summon {Battle.LeftPlayer.MonsterOrder[0]}.");
        Battle.LeftPlayer.CurrentMonster = Battle.LeftPlayer.MonsterOrder[0];
        await Battle.MoveLeftPlayerOut();
        //await Battle.LeftPlayerSummonsMonster(Battle.LeftPlayer.MonsterOrder[0]);
    }
}