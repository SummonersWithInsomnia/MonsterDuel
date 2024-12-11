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
        await Battle.MoveRightPlayerOut(300, 30);
        await Battle.RightPlayerSummonsMonster(Battle.RightPlayer.MonsterOrder[0], 300, 30);

        await BattleMessageBox.AutoShow($"You summon {Battle.LeftPlayer.MonsterOrder[0]}.");
        Battle.LeftPlayer.CurrentMonster = Battle.LeftPlayer.MonsterOrder[0];
        await Battle.MoveLeftPlayerOut(300, 30);
        await Battle.LeftPlayerSummonsMonster(Battle.LeftPlayer.MonsterOrder[0], 300, 30);
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