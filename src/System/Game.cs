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
using LibVLCSharp.Shared;

namespace MonsterDuel
{
    public partial class Game : Form
    {
        private Logo logo;
        
        public Game()
        {
            // Init
            InitializeComponent();
            Core.Initialize(); // LibVLC
            
            logo = new Logo(this);

            Start();
        }

        private async Task Start()
        {
            await logo.Start();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Focus();
            Activate();
        }
    }
}