using System;
using System.Collections.Generic;

namespace MonsterDuel;

public static class BattleMapList
{
    public static readonly List<BattleMap> All =
    [
        new BattleMap
        {
            Name = "Colosseum",
            IconPath = "",
            BackgroundImagePath = ""
        }
    ];
    
    public static BattleMap GetRandom()
    {
        Random random = new Random();
        return All[random.Next(All.Count)];
    }
    
    public static BattleMap Get(string name)
    {
        return All.Find(battleMap => battleMap.Name == name);
    }
}