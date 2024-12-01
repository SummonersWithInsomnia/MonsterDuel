using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class MonsterMiniCardWithOrder : UserControl
{
    private VSMode vsMode;
    public Monster Monster;
    public int Order;
    
    public bool Selected { get; set; } = false;
    
    public MonsterMiniCardWithOrder(VSMode vsMode, Monster monster, int order)
    {
        InitializeComponent();
        this.vsMode = vsMode;
        this.Monster = monster;
        this.Order = order;
        
        lbMonsterName.Text = Monster.Name;
        pbMonsterIcon.Image = File.Exists(Monster.IconPath) ? Image.FromFile(Monster.IconPath) : null;
    }
}