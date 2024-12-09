using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel
{
    public partial class MonsterDetailCard : UserControl
    {
        private VSMode vsMode;
        
        public MonsterDetailCard(VSMode vsMode)
        {
            InitializeComponent();

            this.vsMode = vsMode;
            Visible = false;
        }

        public async void Show(Monster monster)
        {
            lbMonsterName.Text = monster.Name;
            
            lbAttributeList.Text += "Element: " + monster.Element + Environment.NewLine; 
            lbAttributeList.Text += "HP: " + monster.Health + Environment.NewLine;
            lbAttributeList.Text += "ATK: " + monster.Attack + Environment.NewLine;
            lbAttributeList.Text += "DEF: " + monster.Defense + Environment.NewLine;
            lbAttributeList.Text += "SPD: " + monster.Speed;

            foreach (var item in monster.Skills)
            {
                lbSkillList.Text += item.Key + " (Limit: " + item.Value.Limit + ")" + Environment.NewLine;
                lbSkillList.Text += item.Value.Element + " " + item.Value.Type + Environment.NewLine;
                lbSkillList.Text += Environment.NewLine;
            }
            
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
            lbAttributeList.Text = "";
            lbSkillList.Text = "";
            
            vsMode.CloseDetailsOfMonster();
        }

        private void MonsterDetailCard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Hide();
            }
        }
    }
}