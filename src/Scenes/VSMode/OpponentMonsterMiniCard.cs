using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class OpponentMonsterMiniCard : UserControl
{
    private VSMode vsMode;
    private Monster monster;
    
    public OpponentMonsterMiniCard(VSMode vsMode, Monster monster)
    {
        InitializeComponent();
        this.vsMode = vsMode;
        this.monster = monster;
        
        pbMonsterIcon.Image = File.Exists(this.monster.IconPath) ? Image.FromFile(this.monster.IconPath) : null;
        lbMonsterName.Text = monster.Name;
    }
}