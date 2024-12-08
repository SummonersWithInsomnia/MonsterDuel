using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class Battle : UserControl
{
    public IPlayer LeftPlayer { get; set; }
    public IPlayer RightPlayer { get; set; }
        
    public BattleMap Map { get; set; }
    public string BGMPath { get; set; }
    
    private PictureBox leftPlayerImage = new PictureBox();
    private PictureBox rightPlayerImage = new PictureBox();
    
    public Battle(IPlayer left, IPlayer right, BattleMap map, string bgmPath)
    {
        InitializeComponent();

        LeftPlayer = left;
        RightPlayer = right;
        Map = map;
        BGMPath = bgmPath;
        
        leftPlayerImage.SizeMode = PictureBoxSizeMode.StretchImage;
        rightPlayerImage.SizeMode = PictureBoxSizeMode.StretchImage;
        leftPlayerImage.BorderStyle = BorderStyle.None;
        rightPlayerImage.BorderStyle = BorderStyle.None;
        leftPlayerImage.BackColor = Color.Transparent;
        rightPlayerImage.BackColor = Color.Transparent;
        leftPlayerImage.Image = Image.FromFile(LeftPlayer.FullBackImagePath);
        rightPlayerImage.Image = Image.FromFile(RightPlayer.FullFrontImagePath);
        
        leftPlayerImage.Size = new Size(790, 1186);
        rightPlayerImage.Size = new Size(233, 360);
        
        leftPlayerImage.Location = new Point(1280, 233);
        rightPlayerImage.Location = new Point(-233, 0);
    }

    public async Task Start(Form source, List<PictureBox> gates)
    {
        AudioPlayer.PlayBGM(BGMPath);
        
        Map.Controls.Add(leftPlayerImage);
        Map.Controls.Add(rightPlayerImage);
        Controls.Add(Map);
        
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

    public async Task MoveRightPlayerOut()
    {
    }
    
    public async Task MoveLeftPlayerOut()
    {
    }
}