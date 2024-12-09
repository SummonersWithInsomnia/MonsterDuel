using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class BattleMenu : UserControl
{
    private Battle battle;

    public string Command = "";
    
    public BattleMenu(Battle battle)
    {
        InitializeComponent();

        this.battle = battle;

        pnSkills.Visible = false;

        lbCommand.MouseEnter += TextEffect.LabelButton_MouseEnter;
        lbSwitch.MouseEnter += TextEffect.LabelButton_MouseEnter;
        lbSurrender.MouseEnter += TextEffect.LabelButton_MouseEnter;
        lbSkill_1.MouseEnter += TextEffect.LabelButton_MouseEnter;
        lbSkill_2.MouseEnter += TextEffect.LabelButton_MouseEnter;
        lbSkill_3.MouseEnter += TextEffect.LabelButton_MouseEnter;
        lbSkill_4.MouseEnter += TextEffect.LabelButton_MouseEnter;
        
        lbCommand.MouseLeave += TextEffect.LabelButton_MouseLeave;
        lbSwitch.MouseLeave += TextEffect.LabelButton_MouseLeave;
        lbSurrender.MouseLeave += TextEffect.LabelButton_MouseLeave;
        lbSkill_1.MouseLeave += TextEffect.LabelButton_MouseLeave;
        lbSkill_2.MouseLeave += TextEffect.LabelButton_MouseLeave;
        lbSkill_3.MouseLeave += TextEffect.LabelButton_MouseLeave;
        lbSkill_4.MouseLeave += TextEffect.LabelButton_MouseLeave;
    }

    public async Task Show()
    {
        Visible = true;
        UpdateSkillsFromLeftPlayerCurrentMonster();
    }

    public void UpdateSkillsFromLeftPlayerCurrentMonster()
    {
        Dictionary<string, ISkill> skills = battle.LeftPlayer.Monsters[battle.LeftPlayer.CurrentMonster].Skills;
        
        List<string> skillNames = new List<string>();

        foreach (var skill in skills)
        {
            skillNames.Add(skill.Key);
        }
        
        lbSkill_1.Text = skillNames[0];
        lbSkill_2.Text = skillNames[1];
        lbSkill_3.Text = skillNames[2];
        lbSkill_4.Text = skillNames[3];
    }

    private void lbCommand_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            pnSkills.Visible = true;
        }
    }
    
    private void lbSkill_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            Command = "Command#" + ((Label)sender).Text;
            Visible = false;
        }
        else if(e.Button == MouseButtons.Right)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
            pnSkills.Visible = false;
        }
    }
    
    private void pnSkills_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
            pnSkills.Visible = false;
        }
    }
    
    private async void lbSwitch_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            await battle.DisplaySwitchMonsterMenu();
            if (battle.SwitchMonsterMenu.Result != "")
            {
                Command = battle.SwitchMonsterMenu.Result;
                battle.SwitchMonsterMenu.Result = "";
                Visible = false;
            }
        }
    }
    
    private async void lbSurrender_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            await battle.DisplaySurrenderMenu();
            if (battle.SurrenderMenu.Result != "")
            {
                Command = battle.SurrenderMenu.Result;
                battle.SurrenderMenu.Result = "";
                Visible = false;
            }
        }
    }

    private void BattleMenu_VisibleChanged(object sender, EventArgs e)
    {
        if (!Visible)
        {
            battle.BattleMenuTcs?.TrySetResult(true);
        }
    }
}