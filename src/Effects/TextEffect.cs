using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel
{
    public static class TextEffect
    {
        public static async Task Typewriter(Label lable, string text, int duration, int step)
        {
            int waitTime = duration / step;
            
            for (int i = 0; i < text.Length; i++)
            {
                lable.Text += text[i];
                await Task.Delay(waitTime);
            }
        }

        public static async Task TypewriterEaseOut(Label label, int duration, int step)
        {
            int waitTime = duration / step;
            string original = label.Text;
            System.Text.StringBuilder sb = new StringBuilder(original);
            for (int i = 0; i < original.Length; i++)
            {
                sb[i] = ' ';
                label.Text = sb.ToString();
                await Task.Delay(waitTime);
            }

            label.Text = "";
        }
        
        public static async Task TextColorTurnRedFromWhite(Label label, int duration, int step)
        {
            int waitTime = duration / step;
            int r = 255;
            int g = 255;
            int b = 255;
            // int rStep = r / step;
            int gStep = g / step;
            int bStep = b / step;
            
            for (int i = 0; i < step; i++)
            {
                // r -= rStep;
                g -= gStep;
                b -= bStep;

                // if (r < 0) r = 0;
                if (g < 0) g = 0;
                if (b < 0) b = 0;
                
                label.ForeColor = System.Drawing.Color.FromArgb(r, g, b);
                await Task.Delay(waitTime);
            }
        }
        
        public static async void LabelButton_MouseEnter(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            await TextColorTurnRedFromWhite(lb, 100, 10);
        }
        
        public static async void LabelButton_MouseLeave(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            await Task.Delay(100);
            lb.ForeColor = Color.FromArgb(255, 255, 255);
        }
    }
}