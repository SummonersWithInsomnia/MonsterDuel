using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public partial class VSBar : UserControl
{
    private Form sourceForm;
    
    private IPlayer leftPlayer;
    private IPlayer rightPlayer;
    
    private PictureBox leftPlayerIcon;
    private PictureBox rightPlayerIcon;

    private int duration = 500;
    private int step = 3;
    
    public VSBar(Form source, IPlayer left, IPlayer right)
    {
        InitializeComponent();
        
        sourceForm = source;
        leftPlayer = left;
        rightPlayer = right;
    }
    
    public VSBar()
    {
        InitializeComponent();
        
        Controls.Add(leftBar);
        Controls.Add(rightBar);
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
    
    private PictureBox vsLogo = new PictureBox { };
}