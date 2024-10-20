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

        public async Task<PictureBox> Start()
        {
            string teamName = "Summoners with Insomnia";
            string present = "Present";
            
            await Task.Delay(1000);
            
            sourceForm.Controls.Add(lbTeamName);
            sourceForm.Controls.Add(lbPresent);

            int tnDuration = 2000;
            int tnStep = teamName.Length;
            int pDuration = 500;
            int pStep = present.Length;

            await TextEffect.Typewriter(lbTeamName, teamName, tnDuration, tnStep);
            await Task.Delay(200);
            await TextEffect.Typewriter(lbPresent, present, pDuration, pStep);
            
            // Console.WriteLine("lbTeamName.Width: " + lbTeamName.Width);
            // Console.WriteLine("lbTeamName.Height: " + lbTeamName.Height);
            
            await Task.Delay(500);
            
            // Console.WriteLine("lbPresent.Width: " + lbPresent.Width);
            // Console.WriteLine("lbPresent.Height: " + lbPresent.Height);
            
            await TextEffect.TypewriterEaseOut(lbTeamName, tnDuration / 3, tnStep);
            await Task.Delay(200);
            await TextEffect.TypewriterEaseOut(lbPresent, pDuration / 4, pStep);
            
            sourceForm.Controls.Remove(lbTeamName);
            sourceForm.Controls.Remove(lbPresent);

            return await SceneEffect.CutInFromLeft(sourceForm, "data/effect/scene/orange.png", 500, 20);
        }
        
        private Label lbTeamName = new Label
        {
            AutoSize = true,
            Location = new System.Drawing.Point(222, 345),
            Text = "",
            Font = new System.Drawing.Font("Courier New", 68f, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.Snow
        };
        
        private Label lbPresent = new Label
        {
            AutoSize = true,
            Location = new System.Drawing.Point(590, 465),
            Text = "",
            Font = new System.Drawing.Font("Courier New", 46f, FontStyle.Bold, GraphicsUnit.Pixel),
            ForeColor = Color.Snow
        };
    }
}