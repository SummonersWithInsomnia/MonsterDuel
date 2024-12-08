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
            VSBarIconPath = "MonsterDuel_Data/opponents/Ai/Ai_vs_bar_icon.png",
            FullFrontImagePath = "MonsterDuel_Data/opponents/Ai/Ai_full_front.png",
            FullBackImagePath = ""
        }
    ];
    
    public static readonly List<AI> Sepcial =
    [
        new AI // Player Image Type 1
        {
            Name = "Noah",
            IconPath = PlayerImageList.All["Type 1"].IconPath,
            VSBarIconPath = PlayerImageList.All["Type 1"].VSBarIconPath,
            FullFrontImagePath = PlayerImageList.All["Type 1"].FullFrontImagePath,
            FullBackImagePath = PlayerImageList.All["Type 1"].FullBackImagePath
        },
        new AI // Player Image Type 2
        {
            Name = "Sula",
            IconPath = PlayerImageList.All["Type 2"].IconPath,
            VSBarIconPath = PlayerImageList.All["Type 2"].VSBarIconPath,
            FullFrontImagePath = PlayerImageList.All["Type 2"].FullFrontImagePath,
            FullBackImagePath = PlayerImageList.All["Type 2"].FullBackImagePath
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

    public static AI GetAIFromSepcial(string name)
    {
        return Sepcial.Find(ai => ai.Name == name);
    }
}