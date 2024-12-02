using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public class ChoosePlayerImage
{
    private Form sourceForm;
    private string gameMode;
    
    private PlayerImageCard playerImageType1;
    private PlayerImageCard playerImageType2;
    public string SelectedPlayerImageName;
    private Timer selectedPlayerImageTimer;
    
    private Timer focusOnPlayerNameTimer;
    
    public ChoosePlayerImage(Form source, string mode)
    {
        sourceForm = source;
        gameMode = mode;
    }

    public async Task Start()
    {
        playerImageType1 = new PlayerImageCard(this, PlayerImageList.All["Type 1"]);
        playerImageType2 = new PlayerImageCard(this, PlayerImageList.All["Type 2"]);
        SelectedPlayerImageName = "";
        
        selectedPlayerImageTimer = new Timer();
        selectedPlayerImageTimer.Interval = 50;
        selectedPlayerImageTimer.Tick += selectedPlayerImageTimerTick;
        
        tbPlayerName.KeyPress += tbPlayerName_KeyPress;
        lbContinue.MouseEnter += lbContinue_MouseEnter;
        lbContinue.MouseLeave += lbContinue_MouseLeave;
        lbContinue.MouseDown += lbContinue_MouseDown;
        
        focusOnPlayerNameTimer = new Timer();
        focusOnPlayerNameTimer.Interval = 50;
        focusOnPlayerNameTimer.Tick += focusOnPlayerNameTimerTick;
        
        playerImageType1.Location = new Point(284, 104);
        playerImageType2.Location = new Point(711, 104);
        
        PictureBox pb = await SceneEffect.CutInFromLeft(sourceForm, "MonsterDuel_Data/effect/scene/black.png", 100, 10);
        
        // Topmost of layer
        
        sourceForm.Controls.Add(lbTitle);
        
        sourceForm.Controls.Add(playerImageType1);
        sourceForm.Controls.Add(playerImageType2);
        
        sourceForm.Controls.Add(tbPlayerName);
        sourceForm.Controls.Add(lbContinue);
        
        sourceForm.Controls.Add(pbBackground);
        // Bottommost of layer
        
        tbPlayerName.Visible = false;
        lbContinue.Visible = false;
        
        await SceneEffect.CutOutFromRight(sourceForm, pb, 100, 10);
        
        selectedPlayerImageTimer.Start();
        
        // Console.WriteLine("lbTitle.Width: " + lbTitle.Width);
        // Console.WriteLine("lbTitle.Height: " + lbTitle.Height);
    }
    
    private Label lbTitle = new Label
    {
        AutoSize = true,
        Location = new Point(30, 30),
        Text = "Choose Player Image",
        Font = new Font("Courier New", 52f, FontStyle.Bold, GraphicsUnit.Pixel),
        ForeColor = Color.White
    };
    
    private PictureBox pbBackground = new PictureBox
    {
        Size = new Size(1280, 720),
        Location = new Point(0, 0),
        BackColor = Color.Black,
        BorderStyle = BorderStyle.None
    };

    private async void selectedPlayerImageTimerTick(object sender, EventArgs e)
    {
        if (SelectedPlayerImageName != "")
        {
            selectedPlayerImageTimer.Stop();
            PictureBox pb = await SceneEffect.CutInFromLeft(sourceForm, "MonsterDuel_Data/effect/scene/black.png", 200, 10);
            
            lbTitle.Text = "Input Player Name";
            playerImageType1.Visible = false;
            playerImageType2.Visible = false;
            
            tbPlayerName.Visible = true;
            tbPlayerName.Focus();
            
            lbContinue.Visible = true;
            
            await SceneEffect.CutOutFromRight(sourceForm, pb, 200, 10);
            
            focusOnPlayerNameTimer.Start();
            
            // Console.WriteLine("tbPlayerName.Width: " + tbPlayerName.Width);
            // Console.WriteLine("tbPlayerName.Height: " + tbPlayerName.Height);
            // Console.WriteLine("lbContinue.Width: " + lbContinue.Width);
            // Console.WriteLine("lbContinue.Height: " + lbContinue.Height);
        }
    }
    
    private TextBox tbPlayerName = new TextBox
    {
        Location = new Point(0, 280),
        Size = new Size(1280, 82),
        Font = new Font("Courier New", 72f, FontStyle.Bold, GraphicsUnit.Pixel),
        TextAlign = HorizontalAlignment.Center,
        BackColor = Color.Black,
        ForeColor = Color.White,
        BorderStyle = BorderStyle.None,
        AcceptsTab = false,
        AcceptsReturn = false,
        Multiline = false,
        MaxLength = 10,
        ImeMode = ImeMode.Disable,
        ContextMenu = new ContextMenu()
    };
    
    private void focusOnPlayerNameTimerTick(object sender, EventArgs e)
    {
        tbPlayerName.Focus();

        lbContinue.ForeColor = tbPlayerName.Text != "" ? Color.White : Color.FromArgb(128, 128, 128);
    }
    
    private void tbPlayerName_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (tbPlayerName.Text.Length >= tbPlayerName.MaxLength && e.KeyChar != (char)Keys.Back)
        {
            e.Handled = true;
        }
        else if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
        }
    }

    private Label lbContinue = new Label
    {
        AutoSize = true,
        Location = new Point(504, 550),
        Text = "Continue",
        Font = new Font("Courier New", 52f, FontStyle.Bold, GraphicsUnit.Pixel),
        ForeColor = Color.FromArgb(128, 128, 128)
    };
    
    private void lbContinue_MouseEnter(object sender, EventArgs e)
    {
        focusOnPlayerNameTimer.Stop();
        lbContinue.ForeColor = tbPlayerName.Text != "" ? Color.Red : Color.FromArgb(128, 128, 128);
    }
    
    private void lbContinue_MouseLeave(object sender, EventArgs e)
    {
        focusOnPlayerNameTimer.Start();
        lbContinue.ForeColor = tbPlayerName.Text != "" ? Color.White : Color.FromArgb(128, 128, 128);
    }
    
    private async void lbContinue_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && tbPlayerName.Text != "")
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
            
            PlayerImageList.CurrentPlayerName = tbPlayerName.Text;
            PlayerImageList.CurrentPlayerImageName = SelectedPlayerImageName;
            
            focusOnPlayerNameTimer.Stop();
            
            PictureBox pb = await SceneEffect.CutInFromLeft(sourceForm, "MonsterDuel_Data/effect/scene/black.png", 200, 10);
            await Dispose();
            await SceneEffect.CutOutFromRight(sourceForm, pb, 200, 10);
            
            // foreach (Control control in sourceForm.Controls)
            // {
            //     Console.WriteLine(control.Name);
            // }
            // Console.WriteLine(sourceForm.Controls.Count);

            if (gameMode == "VSMode")
            {
                VSMode vsMode = new VSMode(sourceForm);
                await vsMode.Start();
            }
            else
            {
                MessageBox.Show("Invalid Game Mode", "Monster Duel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        else if (e.Button == MouseButtons.Right || (e.Button == MouseButtons.Left && tbPlayerName.Text == ""))
        {
            AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
        }
    }
    
    public async Task Dispose()
    {
        sourceForm.Controls.Remove(lbTitle);
        sourceForm.Controls.Remove(lbContinue);
        sourceForm.Controls.Remove(tbPlayerName);
        sourceForm.Controls.Remove(playerImageType1);
        sourceForm.Controls.Remove(playerImageType2);
        sourceForm.Controls.Remove(pbBackground);
        
        selectedPlayerImageTimer.Dispose();
        focusOnPlayerNameTimer.Dispose();
    }
}