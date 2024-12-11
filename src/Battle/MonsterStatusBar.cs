using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class MonsterStatusBar : UserControl
{
    public string MonsterName;
    public int HP;
    public int CurrentHP;
    public string Direction;
    
    public MonsterStatusBar(string monsterName, int hp, int currentHP, string direction)
    {
        InitializeComponent();

        MonsterName = monsterName;
        HP = hp;
        CurrentHP = currentHP;
        Direction = direction;

        lbName.Text = MonsterName;
        lbHPValue.Text = $"{CurrentHP} / {HP}";

        if (Direction == "Left")
        {
            lbLeft.Visible = true;
            lbRight.Visible = false;
            lbHPValue.Visible = true;
        }
        else if (Direction == "Right")
        {
            lbLeft.Visible = false;
            lbRight.Visible = true;
            lbHPValue.Visible = true;
        }
        else
        {
            lbLeft.Visible = false;
            lbRight.Visible = false;
            lbHPValue.Visible = false;
        }

        hpBar.Maximum = HP;
        hpBar.ValueChanged += HPBar_ValueChanged;
        hpBar.Value = CurrentHP;
        
        Controls.Add(hpBar);
    }

    public void Switch(string monsterName, int hp, int currentHP, string direction)
    {
        MonsterName = monsterName;
        HP = hp;
        CurrentHP = currentHP;
        Direction = direction;

        lbName.Text = MonsterName;
        lbHPValue.Text = $"{CurrentHP} / {HP}";

        if (Direction == "Left")
        {
            lbLeft.Visible = true;
            lbRight.Visible = false;
            lbHPValue.Visible = true;
        }
        else if (Direction == "Right")
        {
            lbLeft.Visible = false;
            lbRight.Visible = true;
            lbHPValue.Visible = true;
        }
        else
        {
            lbLeft.Visible = false;
            lbRight.Visible = false;
            lbHPValue.Visible = false;
        }

        hpBar.Maximum = HP;
        hpBar.Value = CurrentHP;
    }

    public async Task ApplyValue(int value)
    {
        if (value == 0)
        {
            return;
        }
        
        int temp = CurrentHP;
        temp += value;
        
        if (temp <= 0)
        {
            CurrentHP = 0;
        }
        else if (temp >= HP)
        {
            CurrentHP = HP;
        }
        else
        {
            CurrentHP = temp;
        }
        
        lbHPValue.Text = $"{CurrentHP} / {HP}";
        hpBar.Value = CurrentHP;
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

    private HPBar hpBar = new HPBar
    {
        Margin = new Padding
        {
            All = 0,
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0
        },
        Padding = new Padding
        {
            All = 0,
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0
        },
        Location = new Point(25, 50),
        Size = new Size(450, 50),
        TabIndex = 3
    };
}