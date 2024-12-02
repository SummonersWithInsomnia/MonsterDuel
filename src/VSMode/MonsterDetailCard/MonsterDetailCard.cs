using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MonsterDuel
{
    public partial class MonsterDetailCard : UserControl
    {
        private VSMode vsMode;
        bool isAttributes = true;
        private Monster currentMonster;

        public MonsterDetailCard(VSMode vsMode)
        {
            InitializeComponent();

            this.vsMode = vsMode;
            Visible = false;

            //hide skill bar first
            skillBar1.Visible = false;
            skillBar2.Visible = false;
            skillBar3.Visible = false;
            skillBar4.Visible = false;
        }

        public async void Show(Monster monster)
        {
            currentMonster = monster;
            lbMonsterName.Text = monster.Name;
            skillsMonsterPhoto.Image = Image.FromFile(monster.FrontImagePath);


            statBarELE.UpdateStatBar("Element", monster.Element);
            statBarHP.UpdateStatBar("Health", monster.Health);
            statBarATK.UpdateStatBar("Attack", monster.Attack);
            statBarDEF.UpdateStatBar("Defense", monster.Defense);
            statBarSPD.UpdateStatBar("Speed", monster.Speed);

            
            Visible = true;
            Location = new Point(0, 360);
            Size = new Size(1280, 0);

            int stepSize = 620 / 10;

            for (int i = 0; i < 10; i++)
            {
                int tempY = Location.Y;
                Location = new Point(0,  tempY - stepSize / 2);
                int tempHeight = Size.Height;
                Size = new Size(1280, tempHeight += stepSize);
                await Task.Delay(10);
            }
        }

        public void Hide()
        {
            Visible = false;

            lbMonsterName.Text = "";
           
            
            vsMode.CloseDetailsOfMonster();
        }

        private void MonsterDetailCard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Hide();
            }
        }

        private void arrowRight_Click(object sender, EventArgs e)
        {
            isAttributes = !isAttributes;
            lblAttributes.Text = isAttributes ? "Attributes" : "Skills";
            UpdateView();
        }

        private void arrowLeft_Click(object sender, EventArgs e)
        {
            isAttributes = !isAttributes;
            lblAttributes.Text = isAttributes ? "Attributes" : "Skills";
            UpdateView();
        }

        private void UpdateView()
        {
            if (currentMonster == null) return;
            if (isAttributes)
            {
                statBarELE.Visible = true;
                statBarHP.Visible = true;
                statBarATK.Visible = true;
                statBarDEF.Visible = true;
                statBarSPD.Visible = true;

                skillBar1.Visible = false;
                skillBar2.Visible = false;
                skillBar3.Visible = false;
                skillBar4.Visible = false;
            }
            else
            {
                statBarELE.Visible = false;
                statBarHP.Visible = false;
                statBarATK.Visible = false;
                statBarDEF.Visible = false;
                statBarSPD.Visible = false;

                var skills = currentMonster.Skills.Values.ToList();
                if (skills.Count > 0) skillBar1.UpdateSkillBar(skills[0].Name, skills[0].Limit.ToString(), skills[0].Type);
                if (skills.Count > 1) skillBar2.UpdateSkillBar(skills[1].Name, skills[1].Limit.ToString(), skills[1].Type);
                if (skills.Count > 2) skillBar3.UpdateSkillBar(skills[2].Name, skills[2].Limit.ToString(), skills[2].Type);
                if (skills.Count > 3) skillBar4.UpdateSkillBar(skills[3].Name, skills[3].Limit.ToString(), skills[3].Type);


                skillBar1.Visible = true;
                skillBar2.Visible = true;
                skillBar3.Visible = true;
                skillBar4.Visible = true;
            }
        }

    }
}