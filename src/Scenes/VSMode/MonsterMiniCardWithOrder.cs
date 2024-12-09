using System;
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
        pbMonsterIcon.Image = ImageList.GetImage(Monster.IconPath);
        lbOrder.Text = "";
    }

    public void Switch(Monster monster)
    {
        Monster = monster;
        lbMonsterName.Text = Monster.Name;
        pbMonsterIcon.Image = ImageList.GetImage(Monster.IconPath);
    }
    
    public void UpdateOrder()
    {
        if (Order == -1) return;
        lbOrder.Text = "#" + (Order + 1).ToString();
    }
    
    private void MonsterMiniCardWithOrder_MouseEnter(object sender, EventArgs e)
    {
        if (!Selected)
        {
            BackColor = Color.FromArgb(173, 216, 230);
        }
    }

    private void MonsterMiniCardWithOrder_MouseLeave(object sender, EventArgs e)
    {
        if (!Selected)
        {
            BackColor = Color.Black;
        }
    }
    
    private void MonsterMiniCardWithOrder_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if (!Selected && vsMode.SelectedMonsterCounterForOrdering < 3)
            {
                Selected = true;
                Order = vsMode.SelectedMonsterCounterForOrdering;
                lbOrder.Text = "#" + (Order + 1).ToString();
                AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
                vsMode.MarkMonsterOrder();
            }
            else if (Selected)
            {
                Selected = false;
                Order = -1;
                lbOrder.Text = "";
                AudioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
                vsMode.UnmarkMonsterOrder();
            }
            else
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
            }
        }
        else if (e.Button == MouseButtons.Right)
        {
            vsMode.ShowDetailsOfMonster(Monster);
        }
    }
}