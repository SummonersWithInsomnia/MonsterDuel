using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel
{
    // Game Title
    public class GameTitle
    {
        private Form sourceForm;
        private AudioPlayer audioPlayer;

        public GameTitle(Form source, AudioPlayer player)
        {
            sourceForm = source;
            audioPlayer = player;
            
            lbExitGame.MouseClick += new MouseEventHandler(ExitGameMenu);
            lbExitGameYes.MouseClick += new MouseEventHandler(ExitGame);
            lbExitGameNo.MouseClick += new MouseEventHandler(NoExitGame);
            lbStartGame.MouseClick += new MouseEventHandler(StartGame);
        }

        public async Task Start()
        {
            // audioPlayer.PlayBGM("data/bgm/test.mp3");
            PictureBox pb = await SceneEffect.CutInFromLeft(sourceForm, "data/effect/scene/black.png", 500, 20);
            
            sourceForm.Controls.Add(lbLogo);
            sourceForm.Controls.Add(lbStartGame);
            sourceForm.Controls.Add(lbExitGame);
            sourceForm.Controls.Add(lbCopyright);
            sourceForm.Controls.Add(lbExitGameYes);
            sourceForm.Controls.Add(lbExitGameNo);
            
            sourceForm.Controls.Add(pbGameTitleBackground);
            
            SceneEffect.CutOutFromRight(sourceForm, pb, 500, 20);
            
            // Console.WriteLine("lbLogo.Width: " + lbLogo.Width);
            // Console.WriteLine("lbLogo.Height: " + lbLogo.Height);
            // Console.WriteLine("lbStartGame.Width: " + lbStartGame.Width);
            // Console.WriteLine("lbStartGame.Height: " + lbStartGame.Height);
            // Console.WriteLine("lbCopyright.Width: " + lbCopyright.Width);
            // Console.WriteLine("lbCopyright.Height: " + lbCopyright.Height);
        }

        public async Task Stop()
        {
            
        }
        
        
        private PictureBox pbGameTitleBackground = new PictureBox
        {
            Size = new Size(1440, 900),
            Location = new Point(0, 0),
            BackColor = Color.Orange,
            BorderStyle = BorderStyle.None
        };
        
        private Label lbCopyright = new Label
        {
            AutoSize = true,
            Location = new System.Drawing.Point(462, 820),
            Text = "\u00a9 2024 Summoners with Insomnia",
            Font = new System.Drawing.Font("Courier New", 26f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.Snow
        };

        private Label lbStartGame = new Label
        {
            AutoSize = true,
            Location = new System.Drawing.Point(980, 500),
            Text = "Start Game",
            Font = new System.Drawing.Font("Courier New", 50f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.Snow
        };
        
        private Label lbExitGame = new Label
        {
            AutoSize = true,
            Location = new System.Drawing.Point(980, 600),
            Text = "Exit",
            Font = new System.Drawing.Font("Courier New", 50f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.Snow
        };
        
        private Label lbExitGameYes = new Label
        {
            AutoSize = true,
            Location = new System.Drawing.Point(980, 500),
            Text = "Yes",
            Font = new System.Drawing.Font("Courier New", 50f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.Snow,
            Visible = false
        };
        
        private Label lbExitGameNo = new Label
        {
            AutoSize = true,
            Location = new System.Drawing.Point(980, 600),
            Text = "No",
            Font = new System.Drawing.Font("Courier New", 50f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.Snow,
            Visible = false
        };
        
        private Label lbLogo = new Label
        {
            AutoSize = true,
            Location = new System.Drawing.Point(80, 130),
            Text = "Monster Duel",
            Font = new System.Drawing.Font("Courier New", 110f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.Snow
        };
        
        private void ExitGameMenu(object source, MouseEventArgs e)
        {
            // audioPlayer.PlaySE("data/se/test.wav");
            if (e.Button == MouseButtons.Left)
            {
                lbStartGame.Visible = false;
                lbExitGame.Visible = false;
                lbExitGameYes.Visible = true;
                lbExitGameNo.Visible = true;
                
                sourceForm.Refresh();
            }
        }
        
        private void StartGame(object source, MouseEventArgs e)
        {
            // audioPlayer.PlaySE("data/se/test.wav");
            if (e.Button == MouseButtons.Left)
            {
                Stop();
            }
        }

        private void ExitGame(object source, MouseEventArgs e)
        {
            // audioPlayer.PlaySE("data/se/test.wav");
            if (e.Button == MouseButtons.Left)
            {
                sourceForm.Close();
            }
        }
        
        private void NoExitGame(object source, MouseEventArgs e)
        {
            // audioPlayer.PlaySE("data/se/test.wav");
            if (e.Button == MouseButtons.Left)
            {
                lbExitGameYes.Visible = false;
                lbExitGameNo.Visible = false;
                lbStartGame.Visible = true;
                lbExitGame.Visible = true;
                
                sourceForm.Refresh();
            }
        }
    }
}