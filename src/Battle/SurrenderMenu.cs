using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class SurrenderMenu : UserControl
{
    private Battle battle;
    public string Result = "";
    public bool surrenderConfirm = false;
    
    public SurrenderMenu(Battle battle)
    {
        InitializeComponent();
        
        this.battle = battle;

        lbNo.MouseEnter += SurrenderMenuOptionNo_MouseEnter;
        lbYes.MouseEnter += SurrenderMenuOptionYes_MouseEnter;

        lbNo.MouseLeave += SurrenderMenuOption_MouseLeave;
        lbYes.MouseLeave += SurrenderMenuOption_MouseLeave;

        lbNo.MouseClick += SurrenderMenuOptionNo_MouseClick;
        lbYes.MouseClick += SurrenderMenuOptionYes_MouseClick;

        MouseClick += SurrenderMenu_MouseClick;
        lbTitle.MouseClick += SurrenderMenu_MouseClick;
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

    private void SurrenderMenuOptionNo_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
            Visible = false;
            surrenderConfirm = false;
        }
        else if(e.Button == MouseButtons.Left)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            Visible = false;
            surrenderConfirm = false;
        }
    }
    
    private void SurrenderMenu_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
            Visible = false;
            surrenderConfirm = false;
        }
    }

    private void SurrenderMenuOptionYes_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && surrenderConfirm == false)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            lbYes.Text = "Confirm";
            surrenderConfirm = true;
        }
        else if (e.Button == MouseButtons.Left && surrenderConfirm == true)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            Result = "Surrender";
            Visible = false;
        }
        else if (e.Button == MouseButtons.Right)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
            Visible = false;
            lbYes.Text = "Yes";
            surrenderConfirm = false;
        }
    }

    private void SurrenderMenuOptionNo_MouseEnter(object sender, EventArgs e)
    {
        ((Label)sender).BackColor = Color.FromArgb(173, 216, 230);
    }
    
    private void SurrenderMenuOptionYes_MouseEnter(object sender, EventArgs e)
    {
        ((Label)sender).BackColor = Color.FromArgb(173, 216, 230);
    }

    private void SurrenderMenuOption_MouseLeave(object sender, EventArgs e)
    {
        ((Label)sender).BackColor = Color.Black;
        lbYes.Text = "Yes";
        surrenderConfirm = false;
    }
}