﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonsterDuel;

public class Player : IPlayer
{
    public string Name { get; set; }
    public Dictionary<string, Monster> Monsters { get; set; }
    public Dictionary<int, string> MonsterOrder { get; set; }
    public string CurrentMonster { get; set; }
    public string IconPath { get; set; }
    public string FrontImagePath { get; set; }
    public string BackImagePath { get; set; }
    
    public Task CommandMonster()
    {
        throw new System.NotImplementedException();
    }

    public Task SwitchMonster()
    {
        throw new System.NotImplementedException();
    }

    public Task Surrender()
    {
        throw new System.NotImplementedException();
    }
}