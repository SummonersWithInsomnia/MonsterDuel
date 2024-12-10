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

    public async Task<string> GetCommandString(BattleController battleController)
    {
        string command =  await battleController.DisplayBattleMenu();
        Console.WriteLine($"Player {this.Name} Command: {command}");
        return command;
    }
}