using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel
{
    public partial class WarningMessageBox : UserControl
    {
        private Form sourceForm;
        public bool Result = false;
        
        public WarningMessageBox(Form source)
        {
            InitializeComponent();
            
            sourceForm = source;
            
            Visible = false;

            Image imgWarningBar = ImageList.GetImage("MonsterDuel_Data/system/warning_bar.png");
            pbWarningBarTop.Image = new Bitmap(imgWarningBar);
            pbWarningBarBottom.Image = new Bitmap(imgWarningBar);
            imgWarningBar.Dispose();

            lbYes.MouseEnter += TextEffect.LabelButton_MouseEnter;
            lbYes.MouseLeave += TextEffect.LabelButton_MouseLeave;
            lbNo.MouseEnter += TextEffect.LabelButton_MouseEnter;
            lbNo.MouseLeave += TextEffect.LabelButton_MouseLeave;
        }

        public async void Show(string message, string header)
        {
            lbMessage.Text = message;
            lbHeader.Text = header;
            Result = false;
            
            Visible = true;
            Location = new Point(0, 360);
            Size = new Size(1280, 0);

            int stepSize = 620 / 10;

            for (int i = 0; i < 10; i++)
            {
                int tempY = Location.Y;
                Location = new Point(0,  tempY - stepSize / 2);
                int tempHeight = Size.Height;
                Size = new Size(1280, tempHeight += stepSize);
                await Task.Delay(10);
            }
        }
        
        public void Hide()
        {
            Visible = false;
        }

        private void lbYes_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
                Result = true;
                Hide();
            }
            else if (e.Button == MouseButtons.Right)
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
            }
        }

        private void lbNo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/yes.wav");
                Result = false;
                Hide();
            }
            else if (e.Button == MouseButtons.Right)
            {
                AudioPlayer.PlaySE("MonsterDuel_Data/se/not_available.wav");
            }
        }
    }
}