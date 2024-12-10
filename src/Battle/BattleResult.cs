using System.Drawing;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace MonsterDuel;

public class BattleResult
{
    private Form sourceFrom;
    private string result;
    private Battle battleForRetry;
    
    private LibVLC libVLC;
    private MediaPlayer mediaPlayer;
    private Media mLoopBackground;

    public BattleResult(Form source, string result, Battle battleForRetry)
    {
        sourceFrom = source;
        this.result = result;
        this.battleForRetry = battleForRetry;
        
        if (this.result == "Victory")
        {
            lbResult.ForeColor = Color.PaleGreen;
        }
        else if(this.result == "Defeat")
        {
            lbResult.ForeColor = Color.PaleVioletRed;
        }
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

    private Label lbResult = new Label
    {
        Font = new Font("Microsoft Sans Serif", 64.2F, 
            FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        ForeColor = Color.White,
        BackColor = Color.Transparent,
        Location = new Point(0, 130),
        Margin = new Padding(0),
        Name = "lbResult",
        Size = new Size(1280, 160),
        Text = "RESULT",
        TextAlign = ContentAlignment.MiddleCenter
    };

    private Label lbRetry = new Label
    {
        Font = new Font("Courier New", 28.2F, 
            FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        ForeColor = Color.White,
        BackColor = Color.Transparent,
        Location = new Point(0, 420),
        Margin = new Padding(0),
        Name = "lbRetry",
        Size = new Size(1280, 80),
        Text = "Retry",
        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    };

    private Label lbBackToGameTitle = new Label
    {
        Font = new Font("Courier New", 28.2F, 
                FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        ForeColor = Color.White,
        BackColor = Color.Transparent,
        Location = new Point(0, 520),
        Margin = new Padding(0),
        Name = "lbBackToGameTitle",
        Size = new Size(1280, 80),
        Text = "Back to Title",
        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    };

    private Label lbTitle = new Label
    {
        Font = new Font("Microsoft Sans Serif", 36F, 
            FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        ForeColor = Color.White,
        BackColor = Color.Transparent,
        Location = new Point(0, 30),
        Margin = new Padding(0),
        Name = "lbTitle",
        Size = new Size(1280, 80),
        Text = "- BATTLE RESULT -",
        TextAlign = ContentAlignment.MiddleCenter
    };
}