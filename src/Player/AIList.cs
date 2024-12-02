using System;
using System.Collections.Generic;

namespace MonsterDuel;

public static class AIList
{
    public static readonly List<AI> All =
    [
        new AI
        {
            Name = "Ai",
            IconPath = "",
            FrontImagePath = "",
            BackImagePath = "",
        }
    ];
    
    public static AI GetRandomAI()
    {
        Random random = new Random();
        return All[random.Next(All.Count)];
    }
    
    public static AI GetAI(string name)
    {
        return All.Find(ai => ai.Name == name);
    }
}