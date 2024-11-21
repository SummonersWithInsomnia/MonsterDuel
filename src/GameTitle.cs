using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace MonsterDuel
{
    // Game Title
    public class GameTitle
    {
        private Form sourceForm;
        private AudioPlayer audioPlayer;
        
        private LibVLC libVLC;
        private MediaPlayer mediaPlayer;
        private Media mGameTitleLoopBackground;

        private bool menuOpened;
        private Timer lbStartGameColorTimer;
        private bool increaseColorRGB;

        public GameTitle(Form source, AudioPlayer player)
        {
            sourceForm = source;
            audioPlayer = player;

            lbStartGameColorTimer = new Timer();
            lbStartGameColorTimer.Interval = 50;
            lbStartGameColorTimer.Tick += lbStartGameColorTimerTick;
            
            // Game Title Background Video Player
            // Options
            // https://wiki.videolan.org/VLC_command-line_help/
            // - Stop hiding the mouse cursor
            // - No audio
            var options = new string[]
            {
                "--mouse-hide-timeout=2147483647",
                "--no-audio",
                //"--rmtosd-mouse-events",
                //"--mouse-events"
            };
            libVLC = new LibVLC(options); 
            mediaPlayer = new MediaPlayer(libVLC);
            mediaPlayer.EnableMouseInput = false;
            mGameTitleLoopBackground = new Media(libVLC, "MonsterDuel_Data/video/title.mp4", FromType.FromPath);
            vvGameTitleBackground.MediaPlayer = mediaPlayer;
            
            // Loop range
            mediaPlayer.PositionChanged += (sender, e) =>
            {
                if (mediaPlayer.Position > 0.7f)
                {
                    mediaPlayer.Position = 0.4f;
                }
            };

            // Fixed a bug that cannot get MouseClick events
            // https://code.videolan.org/videolan/LibVLCSharp/-/issues/323
            mediaPlayer.Playing += OnPlaying;
            
            // Events
        }

        private void OnPlaying(object source, EventArgs args)
        {
            // Fixed a bug that cannot get MouseClick events
            // https://code.videolan.org/videolan/LibVLCSharp/-/issues/323
            mediaPlayer.EnableMouseInput = false;
            mediaPlayer.EnableKeyInput = false;
        }

        public async Task Start()
        {
            audioPlayer.PlayBGM("MonsterDuel_Data/bgm/title.mp3");
            PictureBox pb = await SceneEffect.CutInFromLeft(sourceForm, "MonsterDuel_Data/effect/scene/black.png", 500, 20);
            
            sourceForm.Controls.Add(lbStartGame);
            sourceForm.Controls.Add(lbCopyright);
            
            sourceForm.Controls.Add(vvGameTitleBackground);
            mediaPlayer.Play(mGameTitleLoopBackground);
            
            SceneEffect.CutOutFromRight(sourceForm, pb, 500, 20);

            lbStartGame.Visible = false;
            
            await Task.Delay(2700);
            
            lbStartGame.Visible = true;
            lbStartGameColorTimer.Start();
            
            lbStartGame.MouseClick += PressToStartGame;
            lbCopyright.MouseClick += PressToStartGame;
            vvGameTitleBackground.MouseClick += PressToStartGame;
            
            // double loopVideoStartPoint = mediaPlayer.Position;
            // Console.WriteLine("loopVideoStartPoint: " + loopVideoStartPoint);

            Console.WriteLine("lbStartGame.Width: " + lbStartGame.Width);
            Console.WriteLine("lbStartGame.Height: " + lbStartGame.Height);
            Console.WriteLine("lbCopyright.Width: " + lbCopyright.Width);
            Console.WriteLine("lbCopyright.Height: " + lbCopyright.Height);
        }

        public async Task Stop()
        {
            // Reset the status
            menuOpened = false;
            increaseColorRGB = false;
            lbStartGame.Visible = true;
            lbStartGame.ForeColor = Color.FromArgb(255, 255, 255);
            lbCopyright.Visible = true;
            lbStartGame.MouseClick -= PressToStartGame;
            lbCopyright.MouseClick -= PressToStartGame;
            vvGameTitleBackground.MouseClick -= PressToStartGame;
        }

        private VideoView vvGameTitleBackground = new VideoView
        {
            Size = new Size(1280, 720),
            Location = new Point(0, 0)
        };
        
        private Label lbCopyright = new Label
        {
            AutoSize = true,
            Location = new Point(421, 651),
            Text = "\u00a9 2024 Summoners with Insomnia",
            Font = new Font("Courier New", 24f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.White,
            Visible = true
        };

        private Label lbStartGame = new Label
        {
            AutoSize = true,
            Location = new Point(474, 460),
            Text = "Press to Start",
            Font = new Font("Courier New", 36f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.FromArgb(255, 255, 255),
            Visible = true
        };

        private void lbStartGameColorTimerTick(object source, EventArgs args)
        {
            Color current = lbStartGame.ForeColor;
            int r = current.R;
            int g = current.G;
            int b = current.B;

            if (increaseColorRGB)
            {
                if (r < 255) r+=10;
                if (g < 255) g+=10;
                if (b < 255) b+=10;
            }
            else
            {
                if (r > 0) r-=10;
                if (g > 0) g-=10;
                if (b > 0) b-=10;
            }

            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;
            
            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;
            
            if (r == 255 && g == 255 && b == 255)
            {
                increaseColorRGB = false;
            }
            else if (r == 0 && g == 0 && b == 0)
            {
                increaseColorRGB = true;
            }
            
            lbStartGame.ForeColor = Color.FromArgb(r, g, b);
        }

        private void PressToStartGame(object source, MouseEventArgs args)
        {
            if (args.Button == MouseButtons.Left)
            {
                menuOpened = true;
                Console.WriteLine("Got it");
            }
        }
    }
}