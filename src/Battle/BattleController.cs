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