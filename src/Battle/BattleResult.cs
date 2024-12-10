using System.Collections.Generic;
using System.Drawing;
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

        if (this.result == "Victory")
        {
            lbRetry.Visible = false;
            lbResult.ForeColor = Color.PaleGreen;
        }
        else if(this.result == "Defeat")
        {
            lbResult.ForeColor = Color.PaleVioletRed;
        }
    }
}