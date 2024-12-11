using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonsterDuel;

public class Player : IPlayer
{
    public string Name { get; set; }
    public Dictionary<string, Monster> Monsters { get; set; }
    public Dictionary<int, string> MonsterOrder { get; set; }
    public string CurrentMonster { get; set; }
    public string IconPath { get; set; }
    public string VSBarIconPath { get; set; }
    public string FullFrontImagePath { get; set; }
    public string FullBackImagePath { get; set; }
    public string SummoningColorRGB { get; set; }

    public Player(Player player)
    {
        this.Name = player.Name;
        this.Monsters = new Dictionary<string, Monster>(player.Monsters);
        this.MonsterOrder = new Dictionary<int, string>(player.MonsterOrder);
        this.CurrentMonster = player.CurrentMonster;
        this.IconPath = player.IconPath;
        this.VSBarIconPath = player.VSBarIconPath;
        this.FullFrontImagePath = player.FullFrontImagePath;
        this.FullBackImagePath = player.FullBackImagePath;
        this.SummoningColorRGB = player.SummoningColorRGB;
    }

    public Player()
    {
    }

    public async Task<string> GetCommandString(BattleController battleController)
    {
        string command = await battleController.DisplayBattleMenu();
        Console.WriteLine($"Player {this.Name} Command: {command}");
        return command;
    }
}