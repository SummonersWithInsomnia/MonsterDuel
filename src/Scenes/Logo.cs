using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel
{
    // Logo
    public class Logo
    {
        private Form sourceForm;

        public Logo(Form source)
        {
            sourceForm = source;
        }

        public async Task Start()
        {
            string teamName = "Summoners with Insomnia";
            string present = "Present";
            
            await Task.Delay(2000);
            
            sourceForm.Controls.Add(lbTeamName);
            sourceForm.Controls.Add(lbPresent);

            int tnDuration = 2000;
            int tnStep = teamName.Length;
            int pDuration = 500;
            int pStep = present.Length;

            await TextEffect.Typewriter(lbTeamName, teamName, tnDuration, tnStep);
            await Task.Delay(200);
            await TextEffect.Typewriter(lbPresent, present, pDuration, pStep);
            await Task.Delay(500);
            
            // Get the sizes of the labels
            // Console.WriteLine("lbTeamName.Width: " + lbTeamName.Width);
            // Console.WriteLine("lbTeamName.Height: " + lbTeamName.Height);
            // Console.WriteLine("lbPresent.Width: " + lbPresent.Width);
            // Console.WriteLine("lbPresent.Height: " + lbPresent.Height);
            
            await TextEffect.TypewriterEaseOut(lbTeamName, tnDuration / 3, tnStep);
            await Task.Delay(200);
            await TextEffect.TypewriterEaseOut(lbPresent, pDuration / 4, pStep);
            
            sourceForm.Controls.Remove(lbTeamName);
            sourceForm.Controls.Remove(lbPresent);
            
            GameTitle gameTitle = new GameTitle(sourceForm);
            await gameTitle.Start();
        }
        
        private Label lbTeamName = new Label
        {
            AutoSize = true,
            Location = new Point(268, 280),
            Text = "",
            Font = new Font("Courier New", 52f, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.White
        };
        
        private Label lbPresent = new Label
        {
            AutoSize = true,
            Location = new Point(543, 360),
            Text = "",
            Font = new Font("Courier New", 40f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.White
        };
    }
}