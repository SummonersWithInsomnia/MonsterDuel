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
        
        public static void LabelButton_MouseEnter(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            lb.ForeColor = Color.Red;
        }
        
        public static void LabelButton_MouseLeave(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            lb.ForeColor = Color.White;
        }
    }
}