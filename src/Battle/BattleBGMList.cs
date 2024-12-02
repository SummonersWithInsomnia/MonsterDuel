using System;
using System.Collections.Generic;

namespace MonsterDuel;

public static class BattleBGMList
{
    public static readonly List<string> All = [
        "MonsterDuel_Data/bgm/battle_0.mp3"
    ];
    
    public static string GetRandom()
    {
        Random random = new Random();
        return All[random.Next(All.Count)];
    }
}