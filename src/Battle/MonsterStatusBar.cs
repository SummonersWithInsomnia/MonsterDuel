﻿using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class MonsterStatusBar : UserControl
{
    public string MonsterName;
    public int HP;
    public int CurrentHP;
    public int HPPercentage;
    public string Direction;

    public int duration = 200;
    public int step = 10;
    
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
            lbHPValue.Visible = false;
        }
        else
        {
            lbLeft.Visible = false;
            lbRight.Visible = false;
            lbHPValue.Visible = false;
        }

        HPPercentage = CurrentHP / HP * 100;

        hpBar.ValueChanged += HPBar_ValueChanged;
        hpBar.Value = HPPercentage;
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
            lbHPValue.Visible = false;
        }
        else
        {
            lbLeft.Visible = false;
            lbRight.Visible = false;
            lbHPValue.Visible = false;
        }

        HPPercentage = CurrentHP / HP * 100;
        hpBar.Value = HPPercentage;
    }

    public async Task ApplyValue(int value)
    {
        if (value == 0)
        {
            return;
        }

        int lastCurrentHP = CurrentHP;
        
        int temp = CurrentHP;
        temp += value;

        int hpDifference = value;
        int hpDifferencePercentage = hpDifference / HP * 100;
            
        if (temp <= 0)
        {
            CurrentHP = 0;
            HPPercentage = 0;
        }
        else if (temp >= HP)
        {
            CurrentHP = HP;
            HPPercentage = 100;
        }
        else
        {
            CurrentHP = temp;
            HPPercentage = CurrentHP / HP * 100;
        }

        int waitTime = duration / step;
        int hpPerStep = hpDifference / step;
        int hpPercentagePerStep = hpDifferencePercentage / step;
        for (int i = 0; i < step; i++)
        {
            lastCurrentHP += hpPerStep;
            lbHPValue.Text = $"{lastCurrentHP} / {HP}";
            hpBar.Value += hpPercentagePerStep;
            await Task.Delay(waitTime);
        }
        
        lbHPValue.Text = $"{CurrentHP} / {HP}";
        hpBar.Value = HPPercentage;
    }
    
    private void HPBar_ValueChanged(object sender, EventArgs e)
    {
        if (HPPercentage < 40)
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