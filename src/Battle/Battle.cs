using System.Windows.Forms;

namespace MonsterDuel;

public partial class Battle : UserControl
{
    public IPlayer LeftPlayer { get; set; }
    public IPlayer RightPlayer { get; set; }
        
    public BattleMap BattleMap { get; set; }
    public string BGMPath { get; set; }
    
    public Battle(IPlayer leftPlayer, IPlayer rightPlayer, BattleMap battleMap, string bgmPath)
    {
        InitializeComponent();
        
        LeftPlayer = leftPlayer;
        RightPlayer = rightPlayer;
        BattleMap = battleMap;
        BGMPath = bgmPath;
    }
}