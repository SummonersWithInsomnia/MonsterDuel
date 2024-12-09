using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class SurrenderMenu : UserControl
{
    private Battle battle;
    public string Result = "";
    
    public SurrenderMenu(Battle battle)
    {
        InitializeComponent();
        
        this.battle = battle;
    }
    
    public async Task Show()
    {
        Visible = true;
    }
    
    private void SurrenderMenu_VisibleChanged(object sender, EventArgs e)
    {
        if (!Visible)
        {
            battle.SurrenderMenuTcs?.TrySetResult(true);
        }
    }
}