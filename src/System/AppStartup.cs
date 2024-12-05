using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class AppStartup : Form
{
    private string basePath = Environment.CurrentDirectory;
    
    public AppStartup()
    {
        InitializeComponent();

        if (!File.Exists($"{basePath}/MonsterDuel_Data/system/app_startup.bmp"))
        {
            MessageBox.Show("Missing game files.\nPlease reinstall the game.", "Monster Duel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
        
        BackgroundImage = Image.FromFile("MonsterDuel_Data/system/app_startup.bmp");
        TransparencyKey = Color.White;
        
        SetWindowRegion();
        
        StartCheckingFiles();
    }
    
    private async Task StartCheckingFiles()
    {
        await Task.Delay(6000);
        
        bool allFilesExist = true;
        
        foreach (var filepath in fileList)
        {
            string fullPath = $"{basePath}/{filepath}";
            if (!File.Exists(fullPath))
            {
                allFilesExist = false;
                break;
            }
        }
        
        if (allFilesExist)
        {
            Thread th = new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Game());
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            
            Close();
        }
        else
        {
            MessageBox.Show("Missing game files.\nPlease reinstall the game.", "Monster Duel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
    
    private void SetWindowRegion()
    {
        if (BackgroundImage != null)
        {
            using GraphicsPath path = new GraphicsPath();
            Bitmap bmp = new Bitmap(BackgroundImage);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (bmp.GetPixel(x, y) != TransparencyKey)
                    {
                        path.AddRectangle(new Rectangle(x, y, 1, 1));
                    }
                }
            }
            
            Region = new Region(path);
        }
    }
    
    private List<string> fileList = new List<string>
    {
        "Interop.WMPLib.dll",
        "AxInterop.WMPLib.dll",
        "libvlc/win-x86/libvlc.dll",
        "libvlc/win-x86/libvlccore.dll",
        "libvlc/win-x64/libvlc.dll",
        "libvlc/win-x64/libvlccore.dll",
        "MonsterDuel_Data/bgm/battle_0.mp3",
        "MonsterDuel_Data/bgm/title.mp3",
        "MonsterDuel_Data/bgm/vs_mode.mp3",
        "MonsterDuel_Data/effects/scenes/black.png",
        "MonsterDuel_Data/effects/scenes/vs_bar_left.png",
        "MonsterDuel_Data/effects/scenes/vs_bar_logo_left.png",
        "MonsterDuel_Data/effects/scenes/vs_bar_logo_right.png",
        "MonsterDuel_Data/effects/scenes/vs_bar_right.png",
        "MonsterDuel_Data/effects/scenes/vs_left.png",
        "MonsterDuel_Data/effects/scenes/vs_right.png",
        "MonsterDuel_Data/monsters/icons/Frodo.png",
        "MonsterDuel_Data/monsters/icons/J-Hope.png",
        "MonsterDuel_Data/monsters/icons/Jimin.png",
        "MonsterDuel_Data/monsters/icons/Jin.png",
        "MonsterDuel_Data/monsters/icons/Jungkook.png",
        "MonsterDuel_Data/monsters/icons/Kylo.png",
        "MonsterDuel_Data/monsters/icons/Luke.png",
        "MonsterDuel_Data/monsters/icons/Moonfang.png",
        "MonsterDuel_Data/monsters/icons/Phantom.png",
        "MonsterDuel_Data/monsters/icons/RapMonster.png",
        "MonsterDuel_Data/monsters/icons/Rhaegal.png",
        "MonsterDuel_Data/monsters/icons/Smaug.png",
        "MonsterDuel_Data/monsters/icons/Suga.png",
        "MonsterDuel_Data/monsters/icons/Tinker.png",
        "MonsterDuel_Data/monsters/icons/V.png",
        "MonsterDuel_Data/monsters/icons/Vader.png",
        "MonsterDuel_Data/monsters/icons/Visereon.png",
        "MonsterDuel_Data/monsters/Frodo_back.png",
        "MonsterDuel_Data/monsters/Frodo_front.png",
        "MonsterDuel_Data/monsters/J-hope_back.png",
        "MonsterDuel_Data/monsters/J-hope_front.png",
        "MonsterDuel_Data/monsters/Jimin_back.png",
        "MonsterDuel_Data/monsters/Jimin_front.png",
        "MonsterDuel_Data/monsters/Jin_back.png",
        "MonsterDuel_Data/monsters/Jin_front.png",
        "MonsterDuel_Data/monsters/Jungkook_back.png",
        "MonsterDuel_Data/monsters/Jungkook_front.png",
        "MonsterDuel_Data/monsters/Kylo_back.png",
        "MonsterDuel_Data/monsters/Kylo_front.png",
        "MonsterDuel_Data/monsters/Luke_back.png",
        "MonsterDuel_Data/monsters/Luke_front.png",
        "MonsterDuel_Data/monsters/Moonfang_back.png",
        "MonsterDuel_Data/monsters/Moonfang_front.png",
        "MonsterDuel_Data/monsters/Phantom_back.png",
        "MonsterDuel_Data/monsters/Phantom_front.png",
        "MonsterDuel_Data/monsters/RapMonster_back.png",
        "MonsterDuel_Data/monsters/RapMonster_front.png",
        "MonsterDuel_Data/monsters/Rhaegal_back.png",
        "MonsterDuel_Data/monsters/Rhaegal_front.png",
        "MonsterDuel_Data/monsters/Smaug_back.png",
        "MonsterDuel_Data/monsters/Smaug_front.png",
        "MonsterDuel_Data/monsters/Suga_back.png",
        "MonsterDuel_Data/monsters/Suga_front.png",
        "MonsterDuel_Data/monsters/Tinker_back.png",
        "MonsterDuel_Data/monsters/Tinker_front.png",
        "MonsterDuel_Data/monsters/V_back.png",
        "MonsterDuel_Data/monsters/V_front.png",
        "MonsterDuel_Data/monsters/Vader_back.png",
        "MonsterDuel_Data/monsters/Vader_front.png",
        "MonsterDuel_Data/monsters/Viserion_back.png",
        "MonsterDuel_Data/monsters/Viserion_front.png",
        "MonsterDuel_Data/players/Type1/Type1_choosing.png",
        "MonsterDuel_Data/players/Type1/Type1_choosing_dark.png",
        "MonsterDuel_Data/players/Type1/Type1_full_back.png",
        "MonsterDuel_Data/players/Type1/Type1_full_front.png",
        "MonsterDuel_Data/players/Type1/Type1_vs_bar_icon.png",
        "MonsterDuel_Data/players/Type2/Type2_choosing.png",
        "MonsterDuel_Data/players/Type2/Type2_choosing_dark.png",
        "MonsterDuel_Data/se/no.wav",
        "MonsterDuel_Data/se/not_available.wav",
        "MonsterDuel_Data/se/yes.wav",
        "MonsterDuel_Data/system/app_startup.bmp",
        "MonsterDuel_Data/system/warning_bar.png",
        "MonsterDuel_Data/video/title.mp4",
        "MonsterDuel_Data/video/vs_mode_60.mp4",
        "MonsterDuel_Data/opponents/Ai/Ai_full_front.png",
        "MonsterDuel_Data/opponents/Ai/Ai_vs_bar_icon.png",
        "MonsterDuel_Data/players/Type2/Type2_full_front.png",
        "MonsterDuel_Data/players/Type2/Type2_vs_bar_icon.png",
        "MonsterDuel_Data/se/vs_bar.wav",
        "MonsterDuel_Data/players/Type2/Type2_full_back.png"
    };

    private void AppStartup_Load(object sender, EventArgs e)
    {
        Focus();
        Activate();
    }
}