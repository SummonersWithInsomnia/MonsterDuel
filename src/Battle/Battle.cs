using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class Battle : UserControl
{
    public IPlayer LeftPlayer { get; set; }
    public IPlayer RightPlayer { get; set; }
        
    public BattleMap Map { get; set; }
    public string BGMPath { get; set; }
    
    public Battle(IPlayer left, IPlayer right, BattleMap map, string bgmPath)
    {
        InitializeComponent();

        LeftPlayer = left;
        RightPlayer = right;
        Map = map;
        BGMPath = bgmPath;
    }

    public async Task Start()
    {
        AudioPlayer.PlayBGM(BGMPath);
        
        
        
        Controls.Add(Map);
    }
    
    
}