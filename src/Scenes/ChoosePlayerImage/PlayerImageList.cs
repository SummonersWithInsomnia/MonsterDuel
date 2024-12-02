using System.Collections.Generic;

namespace MonsterDuel;

public static class PlayerImageList
{
    public static string CurrentPlayerName = "";
    public static string CurrentPlayerImageName = "";
    
    public static Dictionary<string, PlayerImage> All = new Dictionary<string, PlayerImage>
    {
        {
            "Type 1", new PlayerImage
            {
                Name = "Type 1",
                ChoosingImagePath = "MonsterDuel_Data/players/Type1/Type1_choosing.jpg",
                ChoosingImagePathDark = "MonsterDuel_Data/players/Type1/Type1_choosing_dark.jpg"
            }
        },
        {
            "Type 2", new PlayerImage
            {
                Name = "Type 2",
                ChoosingImagePath = "MonsterDuel_Data/players/Type2/Type2_choosing.jpg",
                ChoosingImagePathDark = "MonsterDuel_Data/players/Type2/Type2_choosing_dark.jpg"
            }
        }
    };
}