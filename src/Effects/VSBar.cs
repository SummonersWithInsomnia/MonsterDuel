using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class VSBar : UserControl
{
    private IPlayer leftPlayer;
    private IPlayer rightPlayer;

    private int duration = 50;
    private int step = 5;
    
    public VSBar(IPlayer left, IPlayer right)
    {
        InitializeComponent();
        
        leftPlayer = left;
        rightPlayer = right;
        
        leftPlayerIcon.ImageLocation = leftPlayer.VSBarIconPath;
        rightPlayerIcon.ImageLocation = rightPlayer.VSBarIconPath;
        
        leftBar.Controls.Add(leftPlayerIcon);
        rightBar.Controls.Add(rightPlayerIcon);
        leftBar.Controls.Add(vsLogoLeft);
        rightBar.Controls.Add(vsLogoRight);
        
        Controls.Add(leftBar);
        Controls.Add(rightBar);

        leftPlayerIcon.Visible = false;
        rightPlayerIcon.Visible = false;
        vsLogoLeft.Visible = false;
        vsLogoRight.Visible = false;
    }

    public async Task Start()
    {
        int move = 640 / step;
        int waitTime = duration / step;
        
        for (int i = 0; i < step; i++)
        {
            Point leftBarNext = new Point((leftBar.Location.X + move), leftBar.Location.Y);
            leftBar.Location = leftBarNext;
            Point rightBarNext = new Point((rightBar.Location.X - move), rightBar.Location.Y);
            rightBar.Location = rightBarNext;
            await Task.Delay(waitTime);
        }
        
        Point leftBarFinal = new Point(0, 0);
        leftBar.Location = leftBarFinal;
        Point rightBarFinal = new Point(640, 0);
        rightBar.Location = rightBarFinal;
        
        leftPlayerIcon.Visible = true;
        rightPlayerIcon.Visible = true;
        vsLogoLeft.Visible = true;
        vsLogoRight.Visible = true;
        
        AudioPlayer.PlaySE("MonsterDuel_Data/se/vs_bar.wav");

        TextEffect.Typewriter(lbLeftPlayerName, leftPlayer.Name, 200, 5);
        TextEffect.Typewriter(lbRightPlayerName, rightPlayer.Name, 200, 5);
        
        await Task.Delay(6000);
        
        Parent.Controls.Remove(this);
    }

    private PictureBox leftBar = new PictureBox
    {
        Size = new Size(640, 260),
        Location = new Point(-640, 0),
        ImageLocation = "MonsterDuel_Data/effects/scenes/vs_bar_left.png",
        BorderStyle = BorderStyle.None
    };
    
    private PictureBox rightBar = new PictureBox
    {
        Size = new Size(640, 260),
        Location = new Point(1280, 0),
        ImageLocation = "MonsterDuel_Data/effects/scenes/vs_bar_right.png",
        BorderStyle = BorderStyle.None
    };
    
    private PictureBox vsLogoLeft = new PictureBox
    {
        Size = new Size(120, 240),
        Location = new Point(520, 10),
        ImageLocation = "MonsterDuel_Data/effects/scenes/vs_bar_logo_left.png",
        BackColor = Color.Transparent,
        BorderStyle = BorderStyle.None
    };
    
    private PictureBox vsLogoRight = new PictureBox
    {
        Size = new Size(120, 240),
        Location = new Point(0, 10),
        ImageLocation = "MonsterDuel_Data/effects/scenes/vs_bar_logo_right.png",
        BackColor = Color.Transparent,
        BorderStyle = BorderStyle.None
    };
    
    private PictureBox leftPlayerIcon = new PictureBox
    {
        Size = new Size(520, 240),
        Location = new Point(0, 10),
        ImageLocation = "",
        BackColor = Color.Transparent,
        BorderStyle = BorderStyle.None
    };
    
    private PictureBox rightPlayerIcon = new PictureBox
    {
        Size = new Size(520, 240),
        Location = new Point(120, 10),
        ImageLocation = "",
        BackColor = Color.Transparent,
        BorderStyle = BorderStyle.None
    };
}