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

        public GameTitle(Form source, AudioPlayer player)
        {
            sourceForm = source;
            audioPlayer = player;
            
            // Game Title Background Video Player
            libVLC = new LibVLC();
            mediaPlayer = new MediaPlayer(libVLC);
            mGameTitleLoopBackground = new Media(libVLC, "data/video/title.mp4", FromType.FromPath);
            vvGameTitleBackground.MediaPlayer = mediaPlayer;
            
            // Loop range
            mediaPlayer.PositionChanged += (sender, e) =>
            {
                if (mediaPlayer.Position > 0.7f)
                {
                    mediaPlayer.Position = 0.4f;
                }
            };
        }

        public async Task Start()
        {
            audioPlayer.PlayBGM("data/bgm/test.mp3");
            PictureBox pb = await SceneEffect.CutInFromLeft(sourceForm, "data/effect/scene/black.png", 500, 20);
            
            sourceForm.Controls.Add(lbCopyright);
            
            sourceForm.Controls.Add(vvGameTitleBackground);
            mediaPlayer.Play(mGameTitleLoopBackground);
            
            SceneEffect.CutOutFromRight(sourceForm, pb, 500, 20);
            
            // await Task.Delay(2800);
            // double loopVideoStartPoint = mediaPlayer.Position;
            // Console.WriteLine("loopVideoStartPoint: " + loopVideoStartPoint);
            
            // Console.WriteLine("lbCopyright.Width: " + lbCopyright.Width);
            // Console.WriteLine("lbCopyright.Height: " + lbCopyright.Height);
        }

        public async Task Stop()
        {
            
        }

        private VideoView vvGameTitleBackground = new VideoView
        {
            Size = new Size(1920, 1080),
            Location = new Point(0, 0)
        };
        
        private Label lbCopyright = new Label
        {
            AutoSize = true,
            Location = new Point(713, 997),
            Text = "\u00a9 2024 Summoners with Insomnia",
            Font = new Font("Courier New", 26f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.Snow
        };
    }
}