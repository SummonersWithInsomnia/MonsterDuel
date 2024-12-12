using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace MonsterDuel;

public class BattleResult
{
    private Form sourceForm;
    private string result;
    private Battle battleForRetry;
    
    private LibVLC libVLC;
    private MediaPlayer mediaPlayer;
    private Media mLoopBackground;

    private List<PictureBox> gates;

    public BattleResult(Form source, string result, Battle battleForRetry, List<PictureBox> gates)
    {
        sourceForm = source;
        this.result = result;
        this.battleForRetry = battleForRetry;

        this.gates = gates;
        
        if (this.result == "Victory")
        {
            lbResult.ForeColor = Color.LightGreen;
        }
        else if(this.result == "Defeat")
        {
            lbResult.ForeColor = Color.LightCoral;
        }
        
        lbRetry.MouseClick += lbRetry_MouseClick;
        lbBackToGameTitle.MouseClick += lbBackToGameTitle_MouseClick;
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
            
        // https://videolan.videolan.me/vlc/group__libvlc__core.html#gaa3f8e90ec55de9bb63408c6c3680fb2e
        libVLC.SetUserAgent("Monster Duel", "Monster Duel");

        mediaPlayer = new MediaPlayer(libVLC);
        mediaPlayer.EnableMouseInput = false;
        mLoopBackground = new Media(libVLC, "MonsterDuel_Data/video/battle_result.mp4");
        vvBackground.MediaPlayer = mediaPlayer;
            
        // Loop range
        mediaPlayer.PositionChanged += (sender, e) =>
        {
            if (mediaPlayer.Position > 0.5f)
            {
                mediaPlayer.Position = 0.1f;
            }
        };
        
        sourceForm.Controls.Add(lbTitle);
        sourceForm.Controls.Add(lbResult);
        sourceForm.Controls.Add(lbRetry);
        sourceForm.Controls.Add(lbBackToGameTitle);
        sourceForm.Controls.Add(vvBackground);

        lbTitle.Visible = false;
        lbResult.Visible = false;
        lbRetry.Visible = false;
        lbBackToGameTitle.Visible = false;
        
        mediaPlayer.Play(mLoopBackground);
        
        await Task.Delay(2000);
        
        await SceneEffect.CuttingOutLikeOpeningGate(sourceForm, gates, 200, 10);
        
        await Task.Delay(1000);
        
        lbTitle.Visible = true;
        
        await Task.Delay(1000);

        lbResult.Text = " ";
        lbResult.Visible = true;
        
        await Task.Delay(200);
        if (result == "Victory")
        {
            await TextEffect.Typewriter(lbResult, "VICTORY", 500, 20);
        }
        else if (result == "Defeat")
        {
            await TextEffect.Typewriter(lbResult, "DEFEAT", 500, 20);
        }
        else
        {
            await TextEffect.Typewriter(lbResult, "DRAW", 500, 20);
        }
        
        await Task.Delay(1000);
        if (result == "Defeat" || result == "Draw")
        {
            // lbRetry.Visible = true;
            await Task.Delay(200);
            lbBackToGameTitle.Visible = true;
        }
        else
        {
            lbBackToGameTitle.Visible = true;
        }
        
        // Console.WriteLine("lbTitle.Width: " + lbTitle.Width);
        // Console.WriteLine("lbTitle.Height: " + lbTitle.Height);
        // Console.WriteLine("lbResult.Width: " + lbResult.Width);
        // Console.WriteLine("lbResult.Height: " + lbResult.Height);
        // Console.WriteLine("lbRetry.Width: " + lbRetry.Width);
        // Console.WriteLine("lbRetry.Height: " + lbRetry.Height);
        // Console.WriteLine("lbBackToGameTitle.Width: " + lbBackToGameTitle.Width);
        // Console.WriteLine("lbBackToGameTitle.Height: " + lbBackToGameTitle.Height);
    }
    
    public async Task Dispose()
    {
        mediaPlayer.Stop();
        mediaPlayer.Dispose();
        libVLC.Dispose();
        sourceForm.Controls.Remove(vvBackground);
        vvBackground.Dispose();
        
        sourceForm.Controls.Remove(lbTitle);
        sourceForm.Controls.Remove(lbResult);
        sourceForm.Controls.Remove(lbRetry);
        sourceForm.Controls.Remove(lbBackToGameTitle);
    }

    private async void lbRetry_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");

            List<PictureBox> gates = await SceneEffect.CuttingInLikeClosingGate(sourceForm,
                "MonsterDuel_Data/effects/scenes/battle_opening_top.png", 
                "MonsterDuel_Data/effects/scenes/battle_opening_bottom.png", 200, 10);
            await Task.Delay(2000);
            await Dispose();
            await SceneEffect.CuttingOutLikeOpeningGate(sourceForm, gates, 200, 10);
            
            VSBar vsBar = new VSBar(battleForRetry.LeftPlayer, battleForRetry.RightPlayer);
            sourceForm.Controls.Add(vsBar);
            await vsBar.Start();
            
            List<PictureBox> gates2 = await SceneEffect.CuttingInLikeClosingGate(sourceForm,
                "MonsterDuel_Data/effects/scenes/battle_opening_top.png", 
                "MonsterDuel_Data/effects/scenes/battle_opening_bottom.png", 200, 10);
            
            sourceForm.Controls.Remove(vsBar);
            await Task.Delay(2000);
            
            BattleController battleController = new BattleController(sourceForm, battleForRetry, gates2);
            await battleController.Start();
        }
        else
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
        }
    }

    private async void lbBackToGameTitle_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            
            List<PictureBox> gates = await SceneEffect.CuttingInLikeClosingGate(sourceForm,
                "MonsterDuel_Data/effects/scenes/battle_opening_top.png", 
                "MonsterDuel_Data/effects/scenes/battle_opening_bottom.png", 200, 10);
            await Task.Delay(2000);
            await Dispose();
            await SceneEffect.CuttingOutLikeOpeningGate(sourceForm, gates, 200, 10);
            
            GameTitle gameTitle = new GameTitle(sourceForm);
            await gameTitle.Start();
        }
        else
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
        }
    }
    
    private VideoView vvBackground = new VideoView
    {
        Size = new Size(1280, 720),
        Location = new Point(0, 0)
    };

    private Label lbResult = new Label
    {
        Font = new Font("Microsoft Sans Serif", 64.2F, 
            FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        ForeColor = Color.White,
        BackColor = Color.Transparent,
        Location = new Point(332, 160),
        Margin = new Padding(0),
        Name = "lbResult",
        Size = new Size(616, 97),
        Text = "RESULT",
        TextAlign = ContentAlignment.MiddleCenter
    };

    private Label lbRetry = new Label
    {
        Font = new Font("Courier New", 28.2F, 
            FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        ForeColor = Color.White,
        BackColor = Color.Transparent,
        Location = new Point(481, 510),
        Margin = new Padding(0),
        Name = "lbRetry",
        Size = new Size(318, 50),
        Text = "Retry",
        TextAlign = ContentAlignment.MiddleCenter
    };

    private Label lbBackToGameTitle = new Label
    {
        Font = new Font("Courier New", 28.2F, 
                FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        ForeColor = Color.White,
        BackColor = Color.Transparent,
        Location = new Point(481, 610),
        Margin = new Padding(0),
        Name = "lbBackToGameTitle",
        Size = new Size(318, 50),
        Text = "Back to Title",
        TextAlign = ContentAlignment.MiddleCenter
    };

    private Label lbTitle = new Label
    {
        Font = new Font("Microsoft Sans Serif", 36F, 
            FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
        ForeColor = Color.White,
        BackColor = Color.Transparent,
        Location = new Point(398, 60),
        Margin = new Padding(0),
        Name = "lbTitle",
        AutoSize = true,
        Text = "- BATTLE RESULT -",
        TextAlign = ContentAlignment.MiddleCenter
    };
}