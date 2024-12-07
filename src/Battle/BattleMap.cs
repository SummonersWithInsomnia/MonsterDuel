using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class BattleMap : UserControl
{
    public string Name { get; set; }
    public string IconPath { get; set; }
    public string BackgroundImagePath { get; set; }

    public BattleMap(string name, string iconPath, string backgroundImagePath)
    {
        InitializeComponent();
        
        Name = name;
        IconPath = iconPath;
        BackgroundImagePath = backgroundImagePath;

        BackgroundImage = File.Exists(BackgroundImagePath) ? Image.FromFile(BackgroundImagePath) : null;
    }
}