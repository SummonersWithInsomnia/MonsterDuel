using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            Logo logo = new Logo(this);
            logo.Start();
        }
        
        // private PictureBox pbTeamLogo = new PictureBox
        // {
        //     Size = new Size(50, 50),
        //     Location = new Point(10, 50),
        //     BackColor = Color.Coral,
        //     BorderStyle = BorderStyle.None
        // };
    }
}