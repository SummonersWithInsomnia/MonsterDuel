using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class BattleMessageBox : UserControl
{
    // Each message is not longer than 80 characters
    private List<string> textList;

    private bool autoShowLock = false;

    private BattleController battleController;
    
    public BattleMessageBox(BattleController battleController)
    {
        InitializeComponent();
        
        BackgroundImage = ImageList.GetImage("MonsterDuel_Data/effects/scenes/battle_message_box.png");

        this.battleController = battleController;
        textList = new List<string>();
    }

    public async Task Show(List<string> texts)
    {
        textList.Clear();
        textList = texts;
        
        Visible = true;
        
        await TextEffect.Typewriter(lbText, textList[0], 100, 10);
        textList.RemoveAt(0);
    }
    
    public async Task AutoShow(List<string> texts)
    {
        textList.Clear();
        textList = texts;

        autoShowLock = true;
        Visible = true;
        
        while (textList.Count > 0)
        {
            await TextEffect.Typewriter(lbText, textList[0], 100, 10);
            textList.RemoveAt(0);
            await Task.Delay(1000);
        }
        
        Visible = false;
        autoShowLock = false;
    }
    
    public async Task Show(string text)
    {
        Visible = true;
        
        await TextEffect.Typewriter(lbText, text, 100, 10);
    }

    public async Task AutoShow(string text)
    {
        autoShowLock = true;
        Visible = true;
        
        await TextEffect.Typewriter(lbText, text, 100, 10);
        await Task.Delay(1000);
        
        Visible = false;
        autoShowLock = false;
    }

    public async Task ShowWaiting(string text)
    {
        autoShowLock = true;
        Visible = true;
        
        await TextEffect.Typewriter(lbText, text, 100, 10);
    }

    public void CloseWaiting()
    {
        Visible = false;
        autoShowLock = false;
    }

    public async void Next(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && autoShowLock == false)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            if (textList.Count > 0)
            {
                await TextEffect.Typewriter(lbText, textList[0], 100, 10);
                textList.RemoveAt(0);
            }
            else
            {
                Visible = false;
            }
        }
    }
    
    private void MessageBox_VisibleChanged(object sender, EventArgs e)
    {
        if (!Visible)
        {
            battleController.MessageBoxTcs?.TrySetResult(true);
        }
    }
}