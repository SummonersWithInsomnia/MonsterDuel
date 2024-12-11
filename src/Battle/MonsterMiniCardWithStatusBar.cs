using System;
using System.Drawing;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class MonsterMiniCardWithStatusBar : UserControl
{
    private SwitchMonsterMenu smm;
    
    private Monster monster;
    private bool currentMonster;
    
    public MonsterMiniCardWithStatusBar(SwitchMonsterMenu smm, Monster monster, bool current)
    {
        InitializeComponent();

        this.smm = smm;
        this.monster = monster;
        currentMonster = current;

        hpBar.Maximum = this.monster.Health;
        hpBar.ValueChanged += HPBar_ValueChanged;
        hpBar.Value = this.monster.CurrentHealth;

        lbName.Text = this.monster.Name;
        lbHPValue.Text = $"{this.monster.CurrentHealth} / {this.monster.Health}";

        if (!currentMonster)
        {
            if (this.monster.CurrentHealth > 0)
            {
                lbStatus.Text = "Ready";
                lbStatus.ForeColor = Color.LawnGreen;
            }
            else
            {
                lbStatus.Text = "Fainted";
                lbStatus.ForeColor = Color.PaleVioletRed;
            }
        }
        else
        {
            if (this.monster.CurrentHealth > 0)
            {
                lbStatus.Text = "Current";
                lbStatus.ForeColor = Color.White;
            }
            else
            {
                lbStatus.Text = "Fainted";
                lbStatus.ForeColor = Color.PaleVioletRed;
            }
        }
    }

    public void Update(Monster monster, bool current)
    {
        this.monster = monster;
        currentMonster = current;

        hpBar.Maximum = this.monster.Health;
        hpBar.Value = this.monster.CurrentHealth;

        lbName.Text = this.monster.Name;
        lbHPValue.Text = $"{this.monster.CurrentHealth} / {this.monster.Health}";

        if (!currentMonster)
        {
            if (this.monster.CurrentHealth > 0)
            {
                lbStatus.Text = "Ready";
                lbStatus.ForeColor = Color.LawnGreen;
            }
            else
            {
                lbStatus.Text = "Fainted";
                lbStatus.ForeColor = Color.PaleVioletRed;
            }
        }
        else
        {
            if (this.monster.CurrentHealth > 0)
            {
                lbStatus.Text = "Current";
                lbStatus.ForeColor = Color.White;
            }
            else
            {
                lbStatus.Text = "Fainted";
                lbStatus.ForeColor = Color.PaleVioletRed;
            }
        }
    }

    private void HPBar_ValueChanged(object sender, EventArgs e)
    {
        double hpPercentage = (double)hpBar.Value / hpBar.Maximum * 100;
        if (hpPercentage < 40)
        {
            hpBar.BarColor = Color.PaleVioletRed;
        }
        else
        {
            hpBar.BarColor = Color.LawnGreen;
        }
    }

    private void MonsterMiniCardWithStatusBar_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && lbStatus.Text == "Ready")
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            smm.Result = "Switch#" + monster.Name;
            smm.Visible = false;
        }
        else if (e.Button == MouseButtons.Right)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
            smm.Visible = false;
        }
    }

    private void MonsterMiniCardWithStatusBar_MouseEnter(object sender, EventArgs e)
    {
        BackColor = Color.FromArgb(173, 216, 230);
    }

    private void MonsterMiniCardWithStatusBar_MouseLeave(object sender, EventArgs e)
    {
        BackColor = Color.Black;
    }
}