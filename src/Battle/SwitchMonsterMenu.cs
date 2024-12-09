using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class SwitchMonsterMenu : UserControl
{
    private Battle battle;
    public string Result = "";
    
    public SwitchMonsterMenu(Battle battle)
    {
        InitializeComponent();
        
        this.battle = battle;
    }
    
    public async Task Show()
    {
        Visible = true;
    }
    
    private void SwitchMonsterMenu_VisibleChanged(object sender, EventArgs e)
    {
        if (!Visible)
        {
            battle.SwitchMonsterMenuTcs?.TrySetResult(true);
        }
    }
}