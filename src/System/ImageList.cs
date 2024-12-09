using System;
using System.Collections.Generic;
using System.Drawing;

namespace MonsterDuel;

public static class ImageList
{
    public static Bitmap GetImage(string path)
    {
        // Console.WriteLine("ImageList.GetImage(string path): " + path);
        if (All[path] == null) return null;
        
        return new Bitmap(All[path]);
    }
    
    public static readonly Dictionary<string, Image> All = new Dictionary<string, Image>
    {
        {
            "MonsterDuel_Data/system/app_startup.bmp",
            new Bitmap("MonsterDuel_Data/system/app_startup.bmp")
        },
        {
            "MonsterDuel_Data/system/warning_bar.png",
            new Bitmap("MonsterDuel_Data/system/warning_bar.png")
        },
        {
            "MonsterDuel_Data/battle_maps/Blank.png",
            new Bitmap("MonsterDuel_Data/battle_maps/Blank.png")
        },
        {
            "MonsterDuel_Data/effects/scenes/battle_message_box.png",
            new Bitmap("MonsterDuel_Data/effects/scenes/battle_message_box.png")
        },
        {
            "MonsterDuel_Data/effects/scenes/battle_opening_bottom.png",
            new Bitmap("MonsterDuel_Data/effects/scenes/battle_opening_bottom.png")
        },
        {
            "MonsterDuel_Data/effects/scenes/battle_opening_top.png",
            new Bitmap("MonsterDuel_Data/effects/scenes/battle_opening_top.png")
        },
        {
            "MonsterDuel_Data/effects/scenes/black.png",
            new Bitmap("MonsterDuel_Data/effects/scenes/black.png")
        },
        {
            "MonsterDuel_Data/effects/scenes/vs_bar_left.png",
            new Bitmap("MonsterDuel_Data/effects/scenes/vs_bar_left.png")
        },
        {
            "MonsterDuel_Data/effects/scenes/vs_bar_logo_left.png",
            new Bitmap("MonsterDuel_Data/effects/scenes/vs_bar_logo_left.png")
        },
        {
            "MonsterDuel_Data/effects/scenes/vs_bar_logo_right.png",
            new Bitmap("MonsterDuel_Data/effects/scenes/vs_bar_logo_right.png")
        },
        {
            "MonsterDuel_Data/effects/scenes/vs_bar_right.png",
            new Bitmap("MonsterDuel_Data/effects/scenes/vs_bar_right.png")
        },
        {
            "MonsterDuel_Data/effects/scenes/vs_left.png",
            new Bitmap("MonsterDuel_Data/effects/scenes/vs_left.png")
        },
        {
            "MonsterDuel_Data/effects/scenes/vs_right.png",
            new Bitmap("MonsterDuel_Data/effects/scenes/vs_right.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Frodo.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Frodo.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/J-Hope.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/J-Hope.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Jimin.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Jimin.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Jin.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Jin.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Jungkook.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Jungkook.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Kylo.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Kylo.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Luke.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Luke.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Moonfang.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Moonfang.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Phantom.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Phantom.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/RapMonster.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/RapMonster.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Rhaegal.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Rhaegal.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Smaug.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Smaug.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Suga.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Suga.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Tinker.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Tinker.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/V.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/V.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Vader.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Vader.png")
        },
        {
            "MonsterDuel_Data/monsters/icons/Visereon.png",
            new Bitmap("MonsterDuel_Data/monsters/icons/Visereon.png")
        },
        {
            "MonsterDuel_Data/monsters/Frodo_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Frodo_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Frodo_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Frodo_front.png")
        },
        {
            "MonsterDuel_Data/monsters/J-hope_back.png",
            new Bitmap("MonsterDuel_Data/monsters/J-hope_back.png")
        },
        {
            "MonsterDuel_Data/monsters/J-hope_front.png",
            new Bitmap("MonsterDuel_Data/monsters/J-hope_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Jimin_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Jimin_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Jimin_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Jimin_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Jin_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Jin_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Jin_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Jin_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Jungkook_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Jungkook_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Jungkook_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Jungkook_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Kylo_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Kylo_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Kylo_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Kylo_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Luke_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Luke_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Luke_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Luke_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Moonfang_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Moonfang_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Moonfang_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Moonfang_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Phantom_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Phantom_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Phantom_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Phantom_front.png")
        },
        {
            "MonsterDuel_Data/monsters/RapMonster_back.png",
            new Bitmap("MonsterDuel_Data/monsters/RapMonster_back.png")
        },
        {
            "MonsterDuel_Data/monsters/RapMonster_front.png",
            new Bitmap("MonsterDuel_Data/monsters/RapMonster_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Rhaegal_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Rhaegal_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Rhaegal_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Rhaegal_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Smaug_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Smaug_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Smaug_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Smaug_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Suga_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Suga_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Suga_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Suga_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Tinker_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Tinker_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Tinker_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Tinker_front.png")
        },
        {
            "MonsterDuel_Data/monsters/V_back.png",
            new Bitmap("MonsterDuel_Data/monsters/V_back.png")
        },
        {
            "MonsterDuel_Data/monsters/V_front.png",
            new Bitmap("MonsterDuel_Data/monsters/V_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Vader_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Vader_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Vader_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Vader_front.png")
        },
        {
            "MonsterDuel_Data/monsters/Viserion_back.png",
            new Bitmap("MonsterDuel_Data/monsters/Viserion_back.png")
        },
        {
            "MonsterDuel_Data/monsters/Viserion_front.png",
            new Bitmap("MonsterDuel_Data/monsters/Viserion_front.png")
        },
        {
            "MonsterDuel_Data/opponents/Ai/Ai_full_front.png",
            new Bitmap("MonsterDuel_Data/opponents/Ai/Ai_full_front.png")
        },
        {
            "MonsterDuel_Data/opponents/Ai/Ai_vs_bar_icon.png",
            new Bitmap("MonsterDuel_Data/opponents/Ai/Ai_vs_bar_icon.png")
        },
        {
            "MonsterDuel_Data/players/Type1/Type1_choosing.png",
            new Bitmap("MonsterDuel_Data/players/Type1/Type1_choosing.png")
        },
        {
            "MonsterDuel_Data/players/Type1/Type1_choosing_dark.png",
            new Bitmap("MonsterDuel_Data/players/Type1/Type1_choosing_dark.png")
        },
        {
            "MonsterDuel_Data/players/Type1/Type1_full_back.png",
            new Bitmap("MonsterDuel_Data/players/Type1/Type1_full_back.png")
        },
        {
            "MonsterDuel_Data/players/Type1/Type1_full_front.png",
            new Bitmap("MonsterDuel_Data/players/Type1/Type1_full_front.png")
        },
        {
            "MonsterDuel_Data/players/Type1/Type1_vs_bar_icon.png",
            new Bitmap("MonsterDuel_Data/players/Type1/Type1_vs_bar_icon.png")
        },
        {
            "MonsterDuel_Data/players/Type2/Type2_choosing.png",
            new Bitmap("MonsterDuel_Data/players/Type2/Type2_choosing.png")
        },
        {
            "MonsterDuel_Data/players/Type2/Type2_choosing_dark.png",
            new Bitmap("MonsterDuel_Data/players/Type2/Type2_choosing_dark.png")
        },
        {
            "MonsterDuel_Data/players/Type2/Type2_full_back.png",
            new Bitmap("MonsterDuel_Data/players/Type2/Type2_full_back.png")
        },
        {
            "MonsterDuel_Data/players/Type2/Type2_full_front.png",
            new Bitmap("MonsterDuel_Data/players/Type2/Type2_full_front.png")
        },
        {
            "MonsterDuel_Data/players/Type2/Type2_vs_bar_icon.png",
            new Bitmap("MonsterDuel_Data/players/Type2/Type2_vs_bar_icon.png")
        }
    };
}