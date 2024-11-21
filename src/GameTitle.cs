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
        private Timer lbPressToStartGameColorChangerTimer;
        private bool increaseColorRGB;

        public GameTitle(Form source, AudioPlayer player)
        {
            sourceForm = source;
            audioPlayer = player;
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
            lbPressToStartGameColorChangerTimer = new Timer();
            lbPressToStartGameColorChangerTimer.Interval = 50;
            lbPressToStartGameColorChangerTimer.Tick += lbPressToStartGameColorChangerTimerTick;
            
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
            mGameTitleLoopBackground = new Media(libVLC, "MonsterDuel_Data/video/title.mp4");
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
            
            audioPlayer.PlayBGM("MonsterDuel_Data/bgm/title.mp3");
            PictureBox pb = await SceneEffect.CutInFromLeft(sourceForm, "MonsterDuel_Data/effect/scene/black.png", 500, 20);
            
            // Topmost of layer
            sourceForm.Controls.Add(lbGameMenuVSMode);
            sourceForm.Controls.Add(lbGameMenuStoryMode);
            sourceForm.Controls.Add(lbGameMenuExitGame);
            
            sourceForm.Controls.Add(lbPressToStartGame);
            sourceForm.Controls.Add(lbCopyright);
            
            sourceForm.Controls.Add(vvGameTitleBackground);
            // Bottommost of layer
            
            mediaPlayer.Play(mGameTitleLoopBackground);
            
            await SceneEffect.CutOutFromRight(sourceForm, pb, 500, 20);
            
            await Task.Delay(2700);
            
            lbPressToStartGame.Visible = true;
            lbPressToStartGameColorChangerTimer.Start();
            
            // Events
            lbPressToStartGame.MouseClick += HandleGameTitleBackGroundEvent;
            lbCopyright.MouseClick += HandleGameTitleBackGroundEvent;
            vvGameTitleBackground.MouseClick += HandleGameTitleBackGroundEvent;
            
            lbGameMenuVSMode.MouseEnter += TextEffect.LabelButton_MouseEnter;
            // lbGameMenuStoryMode.MouseEnter += TextEffect.LabelButton_MouseEnter;
            lbGameMenuExitGame.MouseEnter += TextEffect.LabelButton_MouseEnter;
            
            lbGameMenuVSMode.MouseLeave += TextEffect.LabelButton_MouseLeave;
            // lbGameMenuStoryMode.MouseLeave += TextEffect.LabelButton_MouseLeave;
            lbGameMenuExitGame.MouseLeave += TextEffect.LabelButton_MouseLeave;
            
            lbGameMenuVSMode.MouseClick += GameMenuItem_VSMode_MouseClick;
            lbGameMenuStoryMode.MouseClick += GameMenuItem_StoryMode_MouseClick;
            lbGameMenuExitGame.MouseClick += GameMenuItem_ExitGame_MouseClick;
            
            // double loopVideoStartPoint = mediaPlayer.Position;
            // Console.WriteLine("loopVideoStartPoint: " + loopVideoStartPoint);

            // Console.WriteLine("lbPressToStartGame.Width: " + lbPressToStartGame.Width);
            // Console.WriteLine("lbPressToStartGame.Height: " + lbPressToStartGame.Height);
            // Console.WriteLine("lbCopyright.Width: " + lbCopyright.Width);
            // Console.WriteLine("lbCopyright.Height: " + lbCopyright.Height);
            
            // Console.WriteLine("lbGameMenuStoryMode.Width: " + lbGameMenuStoryMode.Width);
            // Console.WriteLine("lbGameMenuStoryMode.Height: " + lbGameMenuStoryMode.Height);
        }

        private VideoView vvGameTitleBackground = new VideoView
        {
            Size = new Size(1280, 720),
            Location = new Point(0, 0)
        };
        
        private Label lbCopyright = new Label
        {
            AutoSize = true,
            Location = new Point(467, 651),
            Text = "\u00a9 2024 Summoners with Insomnia",
            Font = new Font("Courier New", 18f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.White,
            Visible = true
        };

        private Label lbPressToStartGame = new Label
        {
            AutoSize = true,
            Location = new Point(474, 460),
            Text = "Press to Start",
            Font = new Font("Courier New", 36f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.FromArgb(255, 255, 255),
            Visible = false
        };

        private void lbPressToStartGameColorChangerTimerTick(object source, EventArgs args)
        {
            Color current = lbPressToStartGame.ForeColor;
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
            
            lbPressToStartGame.ForeColor = Color.FromArgb(r, g, b);
        }

        private void HandleGameTitleBackGroundEvent(object source, MouseEventArgs args)
        {
            if (args.Button == MouseButtons.Left && menuOpened == false)
            {
                audioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
                lbPressToStartGame.Visible = false;
                
                openGameMenu();
            }
            else if (args.Button == MouseButtons.Right && menuOpened == true)
            {
                audioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
                lbPressToStartGame.Visible = true;
                
                closeGameMenu();
            }
            
        }

        private async void openGameMenu()
        {
            menuOpened = true;
            
            lbPressToStartGame.MouseClick -= HandleGameTitleBackGroundEvent;
            lbCopyright.MouseClick -= HandleGameTitleBackGroundEvent;
            vvGameTitleBackground.MouseClick -= HandleGameTitleBackGroundEvent;
            
            lbGameMenuVSMode.Visible = true;
            await Task.Delay(100);
            lbGameMenuStoryMode.Visible = true;
            await Task.Delay(100);
            lbGameMenuExitGame.Visible = true;
            
            lbPressToStartGame.MouseClick += HandleGameTitleBackGroundEvent;
            lbCopyright.MouseClick += HandleGameTitleBackGroundEvent;
            vvGameTitleBackground.MouseClick += HandleGameTitleBackGroundEvent;
        }

        private void closeGameMenu()
        {
            menuOpened = false;
            
            lbGameMenuVSMode.Visible = false;
            lbGameMenuStoryMode.Visible = false;
            lbGameMenuExitGame.Visible = false;
        }

        private Label lbGameMenuVSMode = new Label
        {
            AutoSize = false,
            Location = new Point(964, 389),
            Size = new Size(238, 41),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "VS Mode",
            Font = new Font("Courier New", 36f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.FromArgb(255, 255, 255),
            Visible = false
        };

        private Label lbGameMenuStoryMode = new Label
        {
            AutoSize = false,
            Location = new Point(964, 460),
            Size = new Size(238, 41),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Story Mode",
            Font = new Font("Courier New", 36f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.FromArgb(128, 128, 128),
            Visible = false
        };

        private Label lbGameMenuExitGame = new Label
        {
            AutoSize = false,
            Location = new Point(964, 531),
            Size = new Size(238, 41),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Exit Game",
            Font = new Font("Courier New", 36f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.FromArgb(255, 255, 255),
            Visible = false
        };
        
        private async void GameMenuItem_VSMode_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                audioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
                
                PictureBox pb = await SceneEffect.CutInFromLeft(sourceForm, "MonsterDuel_Data/effect/scene/black.png", 500, 20);
                audioPlayer.StopBGM();
                await Dispose();
                await SceneEffect.CutOutFromRight(sourceForm, pb, 500, 20);
                
                VSMode vsMode = new VSMode(sourceForm, audioPlayer);
                await vsMode.Start();
            }
            else if (e.Button == MouseButtons.Right)
            {
                audioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
                lbPressToStartGame.Visible = true;
                
                closeGameMenu();
            }
        }
        
        private async void GameMenuItem_StoryMode_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                audioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
            }
            else if (e.Button == MouseButtons.Right)
            {
                audioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
                lbPressToStartGame.Visible = true;
                
                closeGameMenu();
            }
        }
        
        private async void GameMenuItem_ExitGame_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lbPressToStartGame.MouseClick -= HandleGameTitleBackGroundEvent;
                lbCopyright.MouseClick -= HandleGameTitleBackGroundEvent;
                vvGameTitleBackground.MouseClick -= HandleGameTitleBackGroundEvent;
                audioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
                closeGameMenu();
                
                PictureBox pb = await SceneEffect.CutInFromRight(sourceForm, "MonsterDuel_Data/effect/scene/black.png", 500, 20);
                audioPlayer.StopBGM();
                await Dispose();
                await SceneEffect.CutOutFromLeft(sourceForm, pb, 500, 20);
                
                Application.Exit();
            }
            else if (e.Button == MouseButtons.Right)
            {
                closeGameMenu();
                
                audioPlayer.PlaySE("MonsterDuel_Data/se/no.wav");
                lbPressToStartGame.Visible = true;
            }
        }

        public async Task Dispose()
        {
            lbPressToStartGameColorChangerTimer.Stop();
            lbPressToStartGameColorChangerTimer.Dispose();
            mediaPlayer.Stop();
            mediaPlayer.Dispose();
            libVLC.Dispose();
            mGameTitleLoopBackground.Dispose();
            
            sourceForm.Controls.Remove(lbCopyright);
            sourceForm.Controls.Remove(lbPressToStartGame);
            sourceForm.Controls.Remove(lbGameMenuVSMode);
            sourceForm.Controls.Remove(lbGameMenuStoryMode);
            sourceForm.Controls.Remove(lbGameMenuExitGame);
            sourceForm.Controls.Remove(vvGameTitleBackground);
        }
    }
}