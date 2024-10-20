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
        public AudioPlayer audioPlayer;
        private Logo logo;
        private GameTitle gameTitle;
        
        public Game()
        {
            InitializeComponent();
            audioPlayer = new AudioPlayer();
            
            logo = new Logo(this);
            gameTitle = new GameTitle(this, audioPlayer);

            Start();
        }

        private async Task Start()
        {
            PictureBox switchingScene;
            switchingScene = await logo.Start();
            await gameTitle.Start(switchingScene);
        }
    }
}