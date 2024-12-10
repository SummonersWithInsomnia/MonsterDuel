using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class BattleResult : UserControl
{
    private Form sourceFrom;
    private string result;
    private Battle battleForRetry;
    
    public BattleResult(Form source, string result, Battle battleForRetry)
    {
        InitializeComponent();

        sourceFrom = source;
        this.result = result;
        this.battleForRetry = battleForRetry;

        lbRetry.MouseEnter += TextEffect.LabelButton_MouseEnter;
        lbBackToGameTitle.MouseEnter += TextEffect.LabelButton_MouseEnter;
        
        lbRetry.MouseLeave += TextEffect.LabelButton_MouseLeave;
        lbBackToGameTitle.MouseLeave += TextEffect.LabelButton_MouseLeave;

        if (this.result == "Victory")
        {
            // lbRetry.Visible = false;
            lbResult.ForeColor = Color.PaleGreen;
        }
        else if(this.result == "Defeat")
        {
            lbResult.ForeColor = Color.PaleVioletRed;
        }

        lbTitle.Visible = false;
        lbResult.Visible = false;
        lbRetry.Visible = false;
        lbBackToGameTitle.Visible = false;
    }

    public async Task Show()
    {
        
    }

    private async void lbRetry_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            
        }
    }

    private async void lbBackToGameTitle_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            
        }
    }
}