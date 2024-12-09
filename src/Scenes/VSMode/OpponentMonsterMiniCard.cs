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
        
        pbMonsterIcon.Image = ImageList.GetImage(this.monster.IconPath);
        lbMonsterName.Text = monster.Name;
    }
}