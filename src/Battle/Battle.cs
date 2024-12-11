using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class Battle : UserControl
{
    public Player LeftPlayer { get; set; }
    public AI RightPlayer { get; set; }
        
    public BattleMap Map { get; set; }
    public string BGMPath { get; set; }
    
    private PictureBox leftPlayerImage = new PictureBox
    {
        SizeMode = PictureBoxSizeMode.StretchImage,
        BorderStyle = BorderStyle.None,
        BackColor = Color.Transparent,
        Size = new Size(790, 1186),
        Location = new Point(1280, 233)
    };
    
    private PictureBox rightPlayerImage = new PictureBox
    {
        SizeMode = PictureBoxSizeMode.StretchImage,
        BorderStyle = BorderStyle.None,
        BackColor = Color.Transparent,
        Size = new Size(233, 360),
        Location = new Point(-233, 0)
    };
    
    public MonsterStatusBar LeftPlayerMonsterStatusBar = new MonsterStatusBar("Left Player's Monster",
        1000, 1000, "Left");
    
    public MonsterStatusBar RightPlayerMonsterStatusBar = new MonsterStatusBar("Right Player's Monster",
        1000, 1000, "Right");

    public BattleMenu BattleMenu;
    public TaskCompletionSource<bool> BattleMenuTcs;
    public SwitchMonsterMenu SwitchMonsterMenu;
    public TaskCompletionSource<bool> SwitchMonsterMenuTcs;
    public SurrenderMenu SurrenderMenu;
    public TaskCompletionSource<bool> SurrenderMenuTcs;

    public Battle(Battle battle)
    {
        InitializeComponent();

        this.LeftPlayer = new Player(battle.LeftPlayer);
        this.RightPlayer = new AI(battle.RightPlayer);
        this.Map = new BattleMap(battle.Map);
        this.BGMPath = battle.BGMPath;
        
        leftPlayerImage.Image = ImageList.GetImage(LeftPlayer.FullBackImagePath);
        rightPlayerImage.Image = ImageList.GetImage(RightPlayer.FullFrontImagePath);
        
        leftPlayerSummoningMagic.BackColor = ColorTranslator.FromHtml(LeftPlayer.SummoningColorRGB);
        rightPlayerSummoningMagic.BackColor = ColorTranslator.FromHtml(RightPlayer.SummoningColorRGB);

        BattleMenu = new BattleMenu(this);
        SwitchMonsterMenu = new SwitchMonsterMenu(this);
        SurrenderMenu = new SurrenderMenu(this);
    }

    public Battle(Player left, AI right, BattleMap map, string bgmPath)
    {
        InitializeComponent();

        LeftPlayer = left;
        RightPlayer = right;
        Map = map;
        BGMPath = bgmPath;
        
        leftPlayerImage.Image = ImageList.GetImage(LeftPlayer.FullBackImagePath);
        rightPlayerImage.Image = ImageList.GetImage(RightPlayer.FullFrontImagePath);
        
        leftPlayerSummoningMagic.BackColor = ColorTranslator.FromHtml(LeftPlayer.SummoningColorRGB);
        rightPlayerSummoningMagic.BackColor = ColorTranslator.FromHtml(RightPlayer.SummoningColorRGB);

        BattleMenu = new BattleMenu(this);
        SwitchMonsterMenu = new SwitchMonsterMenu(this);
        SurrenderMenu = new SurrenderMenu(this);
    }

    public async Task Start(Form source, List<PictureBox> gates)
    {
        LeftPlayerMonsterStatusBar.Location = new Point(780, 390);
        RightPlayerMonsterStatusBar.Location = new Point(30, 30);
        
        AudioPlayer.PlayBGM(BGMPath);
        
        Map.Controls.Add(SurrenderMenu);
        Map.Controls.Add(SwitchMonsterMenu);
        Map.Controls.Add(BattleMenu);
        
        Map.Controls.Add(leftPlayerSummoningMagic);
        Map.Controls.Add(rightPlayerSummoningMagic);
        
        Map.Controls.Add(LeftPlayerMonsterStatusBar);
        Map.Controls.Add(RightPlayerMonsterStatusBar);
        
        Map.Controls.Add(leftPlayerMonster);
        Map.Controls.Add(rightPlayerMonster);
        
        Map.Controls.Add(leftPlayerImage);
        Map.Controls.Add(rightPlayerImage);
        Controls.Add(Map);
        
        SurrenderMenu.Visible = false;
        SwitchMonsterMenu.Visible = false;
        BattleMenu.Visible = false;
        
        leftPlayerSummoningMagic.Visible = false;
        rightPlayerSummoningMagic.Visible = false;
        LeftPlayerMonsterStatusBar.Visible = false;
        RightPlayerMonsterStatusBar.Visible = false;
        leftPlayerMonster.Visible = false;
        rightPlayerMonster.Visible = false;
        
        await Opening(source, gates,300, 30);
    }
    
    private async Task Opening(Form source, List<PictureBox> gates, int duration, int step)
    {
        PictureBox topGate = gates[0];
        PictureBox bottomGate = gates[1];
        
        int waitTime = duration / step;
        int leftMove = 1280 + 123;
        int rightMove = 233 + 997;
        int gateMove = 360 / step;
        int leftStep = leftMove / step;
        int rightStep = rightMove / step;
        Point topFinal = new Point(0, -360);
        Point bottomFinal = new Point(0, 720);
        Point leftFinalLocation = new Point(-123, 233);
        Point rightFinalLocation = new Point(997, 0);
        
        for (int i = 0; i < step; i++)
        {
            Point topNext = new Point(topGate.Location.X, (topGate.Location.Y - gateMove));
            Point bottomNext = new Point(bottomGate.Location.X, (bottomGate.Location.Y + gateMove));
            topGate.Location = topNext;
            bottomGate.Location = bottomNext;
            
            leftPlayerImage.Location = new Point(leftPlayerImage.Location.X - leftStep, leftPlayerImage.Location.Y);
            rightPlayerImage.Location = new Point(rightPlayerImage.Location.X + rightStep, rightPlayerImage.Location.Y);
            
            await Task.Delay(waitTime);
        }
        
        topGate.Location = topFinal;
        bottomGate.Location = bottomFinal;
        leftPlayerImage.Location = leftFinalLocation;
        rightPlayerImage.Location = rightFinalLocation;
        
        source.Controls.Remove(topGate);
        source.Controls.Remove(bottomGate);
        Map.Refresh();
        source.Refresh();
    }

    public async Task MoveRightPlayerOut(int duration, int step)
    {
        int waitTime = duration / step;
        int move = (1280 - 997) / step;
        Point finalLocation = new Point(1280,0);

        for (int i = 0; i < step; i++)
        {
            rightPlayerImage.Location = new Point((rightPlayerImage.Location.X + move), rightPlayerImage.Location.Y);
            await Task.Delay(waitTime);
        }

        rightPlayerImage.Location = finalLocation;
        Map.Refresh();
    }
    
    public async Task MoveLeftPlayerOut(int duration, int step)
    {
        int waitTime = duration / step;
        int move = (790 - 123) / step;
        Point finalLocation = new Point(-790, 233);

        for (int i = 0; i < step; i++)
        {
            leftPlayerImage.Location = new Point((leftPlayerImage.Location.X - move), leftPlayerImage.Location.Y);
            await Task.Delay(waitTime);
        }

        leftPlayerImage.Location = finalLocation;
        Map.Refresh();
    }

    private PictureBox rightPlayerMonster = new PictureBox
    {
        SizeMode = PictureBoxSizeMode.StretchImage,
        BorderStyle = BorderStyle.None,
        BackColor = Color.Transparent,
        Size = new Size(360, 360),
        Location = new Point(870, 0)
    };

    private PictureBox rightPlayerSummoningMagic = new PictureBox
    {
        BorderStyle = BorderStyle.None,
        Size = new Size(360, 360),
        Location = new Point(870, 0)
    };

    private async Task rightPlayerSummoning(int duration, int step)
    {
        Size originalSize = rightPlayerSummoningMagic.Size;
        Point originalLocation = rightPlayerSummoningMagic.Location;
        
        int changingSizeW = 360 / step;
        int changingLocationX = 180 / step;
        int waitTime = duration / step;

        rightPlayerSummoningMagic.Size = new Size(0, 360);
        rightPlayerSummoningMagic.Location = new Point(originalLocation.X + 180, originalLocation.Y);

        rightPlayerSummoningMagic.Visible = true;

        for (int i = 0; i < step; i++)
        {
            rightPlayerSummoningMagic.Size = new((rightPlayerSummoningMagic.Size.Width + changingSizeW),
                rightPlayerSummoningMagic.Height);
            rightPlayerSummoningMagic.Location = new Point((rightPlayerSummoningMagic.Location.X - changingLocationX),
                rightPlayerSummoningMagic.Location.Y);
            await Task.Delay(waitTime);
        }

        rightPlayerSummoningMagic.Size = originalSize;
        rightPlayerSummoningMagic.Location = originalLocation;
        
        Map.Refresh();
    }

    private async Task rightPlayerEndSummoning(int duration, int step)
    {
        Size originalSize = rightPlayerSummoningMagic.Size;
        Point originalLocation = rightPlayerSummoningMagic.Location;
        
        int changingSizeW = 360 / step;
        int changingLocationX = 180 / step;
        int waitTime = duration / step;
        
        for (int i = 0; i < step; i++)
        {
            rightPlayerSummoningMagic.Size = new((rightPlayerSummoningMagic.Size.Width - changingSizeW),
                rightPlayerSummoningMagic.Height);
            rightPlayerSummoningMagic.Location = new Point((rightPlayerSummoningMagic.Location.X + changingLocationX),
                rightPlayerSummoningMagic.Location.Y);
            await Task.Delay(waitTime);
        }

        rightPlayerSummoningMagic.Size = new Size(0, 360);
        rightPlayerSummoningMagic.Location = new Point(originalLocation.X + 180, originalLocation.Y);

        rightPlayerSummoningMagic.Visible = false;

        rightPlayerSummoningMagic.Size = originalSize;
        rightPlayerSummoningMagic.Location = originalLocation;
        
        Map.Refresh();
    }

    public async Task RightPlayerSummonsMonster(string monsterName, int duration, int step)
    {
        await rightPlayerSummoning((duration / 2), (step / 2));
        await Task.Delay(200);

        if (monsterName == string.Empty)
        {
            rightPlayerMonster.Image = null;
            rightPlayerMonster.Visible = false;
            RightPlayerMonsterStatusBar.Visible = false;
        }
        else
        {
            rightPlayerMonster.Image = ImageList.GetImage(RightPlayer.Monsters[monsterName].FrontImagePath);
            rightPlayerMonster.Visible = true;
            RightPlayerMonsterStatusBar.Visible = false;
        }
        
        await Task.Delay(200);
        await rightPlayerEndSummoning((duration / 2), (step / 2));
        Map.Refresh();
        
        if (monsterName == string.Empty) return;
        
        RightPlayerMonsterStatusBar.Switch(RightPlayer.Monsters[monsterName].Name, RightPlayer.Monsters[monsterName].Health, RightPlayer.Monsters[monsterName].CurrentHealth, "Right");
        RightPlayerMonsterStatusBar.Visible = true;
    }
    
    private PictureBox leftPlayerMonster = new PictureBox
    {
        SizeMode = PictureBoxSizeMode.StretchImage,
        BorderStyle = BorderStyle.None,
        BackColor = Color.Transparent,
        Size = new Size(842, 842),
        Location = new Point(-150, 100)
    };
    
    private PictureBox leftPlayerSummoningMagic = new PictureBox
    {
        BorderStyle = BorderStyle.None,
        Size = new Size(842, 720),
        Location = new Point(-150, 0)
    };
    
    private async Task leftPlayerSummoning(int duration, int step)
    {
        Size originalSize = leftPlayerSummoningMagic.Size;
        Point originalLocation = leftPlayerSummoningMagic.Location;
        
        int changingSizeW = 842 / step;
        int changingLocationX = 421 / step;
        int waitTime = duration / step;

        leftPlayerSummoningMagic.Size = new Size(0, 720);
        leftPlayerSummoningMagic.Location = new Point(originalLocation.X + 421, originalLocation.Y);

        leftPlayerSummoningMagic.Visible = true;

        for (int i = 0; i < step; i++)
        {
            leftPlayerSummoningMagic.Size = new((leftPlayerSummoningMagic.Size.Width + changingSizeW),
                leftPlayerSummoningMagic.Height);
            leftPlayerSummoningMagic.Location = new Point((leftPlayerSummoningMagic.Location.X - changingLocationX),
                leftPlayerSummoningMagic.Location.Y);
            await Task.Delay(waitTime);
        }

        leftPlayerSummoningMagic.Size = originalSize;
        leftPlayerSummoningMagic.Location = originalLocation;
        
        Map.Refresh();
    }

    private async Task leftPlayerEndSummoning(int duration, int step)
    {
        Size originalSize = leftPlayerSummoningMagic.Size;
        Point originalLocation = leftPlayerSummoningMagic.Location;
        
        int changingSizeW = 842 / step;
        int changingLocationX = 421 / step;
        int waitTime = duration / step;
        
        for (int i = 0; i < step; i++)
        {
            leftPlayerSummoningMagic.Size = new((leftPlayerSummoningMagic.Size.Width - changingSizeW),
                leftPlayerSummoningMagic.Height);
            leftPlayerSummoningMagic.Location = new Point((leftPlayerSummoningMagic.Location.X + changingLocationX),
                leftPlayerSummoningMagic.Location.Y);
            await Task.Delay(waitTime);
        }

        leftPlayerSummoningMagic.Size = new Size(0, 720);
        leftPlayerSummoningMagic.Location = new Point(originalLocation.X + 421, originalLocation.Y);

        leftPlayerSummoningMagic.Visible = false;

        leftPlayerSummoningMagic.Size = originalSize;
        leftPlayerSummoningMagic.Location = originalLocation;
        
        Map.Refresh();
    }

    public async Task LeftPlayerSummonsMonster(string monsterName, int duration, int step)
    {
        await leftPlayerSummoning((duration / 2), (step / 2));
        await Task.Delay(200);
        
        if (monsterName == string.Empty)
        {
            leftPlayerMonster.Image = null;
            leftPlayerMonster.Visible = false;
            LeftPlayerMonsterStatusBar.Visible = false;
        }
        else
        {
            leftPlayerMonster.Image = ImageList.GetImage(LeftPlayer.Monsters[monsterName].BackImagePath);
            leftPlayerMonster.Visible = true;
            LeftPlayerMonsterStatusBar.Visible = false;
        }
        
        await Task.Delay(200);
        await leftPlayerEndSummoning((duration / 2), (step / 2));
        Map.Refresh();
        
        if (monsterName == string.Empty) return;
        
        LeftPlayerMonsterStatusBar.Switch(LeftPlayer.Monsters[monsterName].Name, LeftPlayer.Monsters[monsterName].Health, LeftPlayer.Monsters[monsterName].CurrentHealth, "Left");
        LeftPlayerMonsterStatusBar.Visible = true;
    }

    public async Task DisplayMenu()
    {
        BattleMenuTcs = new TaskCompletionSource<bool>();
        await BattleMenu.Show();
        await BattleMenuTcs.Task;
    }
    
    public async Task DisplaySwitchMonsterMenu()
    {
        SwitchMonsterMenuTcs = new TaskCompletionSource<bool>();
        await SwitchMonsterMenu.Show();
        await SwitchMonsterMenuTcs.Task;
    }
    
    public async Task DisplaySurrenderMenu()
    {
        SurrenderMenuTcs = new TaskCompletionSource<bool>();
        await SurrenderMenu.Show();
        await SurrenderMenuTcs.Task;
    }
}