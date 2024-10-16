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
        public Form SourceForm;

        public Logo(Form source)
        {
            SourceForm = source;
        }

        public async Task Start()
        {
            string teamName = "Summoners with Insomnia";
            string present = "Present";
            
            await Task.Delay(1000);
            
            SourceForm.Controls.Add(lbTeamName);
            SourceForm.Controls.Add(lbPresent);

            int tnDuration = 2000;
            int tnStep = teamName.Length;
            int pDuration = 500;
            int pStep = present.Length;

            await Effect.Typewriter(lbTeamName, teamName, tnDuration, tnStep);
            await Task.Delay(200);
            await Effect.Typewriter(lbPresent, present, pDuration, pStep);
            
            // Console.WriteLine("lbTeamName.Width: " + lbTeamName.Width);
            // Console.WriteLine("lbTeamName.Height: " + lbTeamName.Height);
            
            await Task.Delay(500);
            
            // Console.WriteLine("lbPresent.Width: " + lbPresent.Width);
            // Console.WriteLine("lbPresent.Height: " + lbPresent.Height);
            
            await Effect.TypewriterEaseOut(lbTeamName, tnDuration / 3, tnStep);
            await Task.Delay(200);
            await Effect.TypewriterEaseOut(lbPresent, pDuration / 4, pStep);
            
            SourceForm.Controls.Remove(lbTeamName);
            SourceForm.Controls.Remove(lbPresent);
        }
        
        private Label lbTeamName = new Label
        {
            AutoSize = true,
            Location = new System.Drawing.Point(222, 335),
            Text = "",
            Font = new System.Drawing.Font("Courier New", 68f, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.Snow
        };
        
        private Label lbPresent = new Label
        {
            AutoSize = true,
            Location = new System.Drawing.Point(590, 455),
            Text = "",
            Font = new System.Drawing.Font("Courier New", 46f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.Snow
        };
    }
}