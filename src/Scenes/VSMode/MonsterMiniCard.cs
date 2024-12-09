using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel
{
    public partial class MonsterMiniCard : UserControl
    {
        private VSMode vsMode;
        private Monster monster;

        public bool Selected { get; set; } = false;
        
        public MonsterMiniCard(VSMode vsMode, Monster monster)
        {
            InitializeComponent();
            this.vsMode = vsMode;
            this.monster = monster;
            
            lbMonsterName.Text = this.monster.Name;
            pbMonsterIcon.Image = ImageList.GetImage(this.monster.IconPath);
        }

        private void MonsterMiniCard_MouseEnter(object sender, EventArgs e)
        {
            if (!Selected)
            {
                BackColor = Color.FromArgb(173, 216, 230);
            }
        }

        private void MonsterMiniCard_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
            {
                BackColor = Color.Black;
            }
        }

        private void MonsterMiniCard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!Selected && vsMode.SelectedMonsterCounter < 6)
                {
                    Selected = true;
                    AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
                    vsMode.AddMonster(monster);
                }
                else if (Selected)
                {
                    Selected = false;
                    AudioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
                    vsMode.RemoveMonster(monster);
                }
                else
                {
                    AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                vsMode.ShowDetailsOfMonster(monster);
            }
        }
    }
}