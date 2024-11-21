using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace MonsterDuel
{
    public class VSMode
    {
        private Form sourceForm;
        private AudioPlayer audioPlayer;
        
        private LibVLC libVLC;
        private MediaPlayer mediaPlayer;
        private Media mLoopBackground;
        
        public VSMode(Form source, AudioPlayer player)
        {
            sourceForm = source;
            audioPlayer = player;
        }
        
        public async Task Start()
        {
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
            mLoopBackground = new Media(libVLC, "MonsterDuel_Data/video/vs_mode_60.mp4");
            vvBackground.MediaPlayer = mediaPlayer;
            
            // Loop range
            mediaPlayer.PositionChanged += (sender, e) =>
            {
                if (mediaPlayer.Position > 0.3968697821f)
                {
                    mediaPlayer.Position = 0.0f;
                }
            };
            
            audioPlayer.PlayBGM("MonsterDuel_Data/bgm/vs_mode.mp3");
            await Task.Delay(1700);
            
            List<PictureBox> pbList = await SceneEffect.CuttingInLikeClosingDoor(sourceForm,
                "MonsterDuel_Data/effect/scene/vs_left.png", 
                "MonsterDuel_Data/effect/scene/vs_right.png", 50, 5);
            
            
            // Topmost of layer
            
            
            sourceForm.Controls.Add(vvBackground);
            // Bottommost of layer
            
            mediaPlayer.Play(mLoopBackground);
            
            await Task.Delay(6000);
            
            await SceneEffect.CuttingOutLikeOpeningDoor(sourceForm, pbList, 50, 2);
        }
        
        private VideoView vvBackground = new VideoView
        {
            Size = new Size(1280, 720),
            Location = new Point(0, 0)
        };
    }
}