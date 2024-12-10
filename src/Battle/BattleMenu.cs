using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class BattleMenu : UserControl
{
    private Battle battle;

    public string Command = "";

    private Dictionary<string, int> skillList;
    private List<string> skillNames;
    
    public BattleMenu(Battle battle)
    {
        InitializeComponent();

        this.battle = battle;

        pnSkills.Visible = false;

        lbCommand.MouseEnter += BattleMenuOption_MouseEnter;
        lbSwitch.MouseEnter += BattleMenuOption_MouseEnter;
        lbSurrender.MouseEnter += BattleMenuOption_MouseEnter;
        lbSkill_1.MouseEnter += BattleMenuOption_MouseEnter;
        lbSkill_2.MouseEnter += BattleMenuOption_MouseEnter;
        lbSkill_3.MouseEnter += BattleMenuOption_MouseEnter;
        lbSkill_4.MouseEnter += BattleMenuOption_MouseEnter;
        
        lbCommand.MouseLeave += BattleMenuOption_MouseLeave;
        lbSwitch.MouseLeave += BattleMenuOption_MouseLeave;
        lbSurrender.MouseLeave += BattleMenuOption_MouseLeave;
        lbSkill_1.MouseLeave += BattleMenuOption_MouseLeave;
        lbSkill_2.MouseLeave += BattleMenuOption_MouseLeave;
        lbSkill_3.MouseLeave += BattleMenuOption_MouseLeave;
        lbSkill_4.MouseLeave += BattleMenuOption_MouseLeave;
    }

    public async Task Show()
    {
        Visible = true;
        UpdateSkillsFromLeftPlayerCurrentMonster();
    }

    public void UpdateSkillsFromLeftPlayerCurrentMonster()
    {
        Dictionary<string, ISkill> skills = battle.LeftPlayer.Monsters[battle.LeftPlayer.CurrentMonster].Skills;
        
        skillList = new Dictionary<string, int>();
        skillNames = new List<string>();

        foreach (var skill in skills)
        {
            skillList.Add(skill.Key, skill.Value.Limit);
            skillNames.Add(skill.Key);
        }
        
        lbSkill_1.Text = skillNames[0];
        lbSkill_2.Text = skillNames[1];
        lbSkill_3.Text = skillNames[2];
        lbSkill_4.Text = skillNames[3];

        List<Label> labels = new List<Label>();
        labels.Add(lbSkill_1);
        labels.Add(lbSkill_2);
        labels.Add(lbSkill_3);
        labels.Add(lbSkill_4);

        foreach (var skill in skillList)
        {
            foreach (var label in labels)
            {
                if (label.Text == skill.Key)
                {
                    if (skill.Value <= 0)
                    {
                        label.ForeColor = Color.FromArgb(128, 128, 128);
                    }
                    else if (skill.Value <= 10 && skill.Value > 5)
                    {
                        label.ForeColor = Color.Orange;
                    }
                    else if (skill.Value <= 5 && skill.Value > 0)
                    {
                        label.ForeColor = Color.PaleVioletRed;
                    }
                    else
                    {
                        label.ForeColor = Color.White;
                    }
                }
            }
        }
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
            if (skillList[((Label)sender).Text] > 0)
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
                Command = "Command#" + ((Label)sender).Text;
                Visible = false;
            }
            else
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
            }
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

    private void BattleMenuOption_MouseEnter(object sender, EventArgs e)
    {
        ((Label)sender).BackColor = Color.FromArgb(173, 216, 230);
    }

    private void BattleMenuOption_MouseLeave(object sender, EventArgs e)
    {
        ((Label)sender).BackColor = Color.Black;
    }
}