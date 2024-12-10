using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class SwitchMonsterMenu : UserControl
{
    private Battle battle;
    public string Result = "";
    private Dictionary<string, MonsterMiniCardWithStatusBar> monsterMiniCardsWithStatusBar;
    
    public SwitchMonsterMenu(Battle battle)
    {
        InitializeComponent();
        
        this.battle = battle;
        monsterMiniCardsWithStatusBar = new Dictionary<string, MonsterMiniCardWithStatusBar>();

        int y = 0;
        foreach (var pair in battle.LeftPlayer.Monsters)
        {
            bool currentMonster = pair.Key == battle.LeftPlayer.CurrentMonster;

            MonsterMiniCardWithStatusBar miniCard = new MonsterMiniCardWithStatusBar(this, 
                pair.Value, currentMonster);

            miniCard.Location = new Point(0, y);
            y += miniCard.Height;
            
            Controls.Add(miniCard);
            monsterMiniCardsWithStatusBar.Add(pair.Key, miniCard);
        }
    }
    
    public async Task Show()
    {
        foreach (var pair in battle.LeftPlayer.Monsters)
        {
            bool currentMonster = pair.Key == battle.LeftPlayer.CurrentMonster;
            
            monsterMiniCardsWithStatusBar[pair.Key].Update(pair.Value, currentMonster);
        }
        
        Visible = true;
    }
    
    private void SwitchMonsterMenu_VisibleChanged(object sender, EventArgs e)
    {
        if (!Visible)
        {
            battle.SwitchMonsterMenuTcs?.TrySetResult(true);
        }
    }
}