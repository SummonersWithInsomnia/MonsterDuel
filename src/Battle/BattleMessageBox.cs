using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class BattleMessageBox : UserControl
{
    // Each message is not longer than 80 characters
    private List<string> textList = new List<string>();
    public BattleMessageBox()
    {
        InitializeComponent();
        
        BackgroundImage = Image.FromFile("MonsterDuel_Data/effects/scenes/battle_message_box.png");
    }

    public void Show(List<string> texts)
    {
        textList.Clear();
        textList = texts;
        
        Visible = true;
        
        if (textList.Count > 0)
        {
            lbText.Text = textList[0];
            textList.RemoveAt(0);
        }
    }
    
    public void Show(string text)
    {
        textList.Clear();
        textList.Add(text);
        
        Visible = true;
        
        if (textList.Count > 0)
        {
            lbText.Text = textList[0];
            textList.RemoveAt(0);
        }
    }
    
    public void Next(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            if (textList.Count > 0)
            {
                lbText.Text = textList[0];
                textList.RemoveAt(0);
            }
            else
            {
                Visible = false;
            }
        }
        
    }
}