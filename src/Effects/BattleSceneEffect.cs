using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel;

public class BattleSceneEffect
{
    // public static async Task LoadingBegin(Form source, string leftFilepath, string rightFilepath, int duration, int step)
    //     {
    //         PictureBox left = new PictureBox
    //         {
    //             Size = new Size(640, 720),
    //             Location = new Point(-640, 0),
    //             ImageLocation = leftFilepath,
    //             BorderStyle = BorderStyle.None
    //         };
    //         
    //         PictureBox right = new PictureBox
    //         {
    //             Size = new Size(640, 720),
    //             Location = new Point(1280, 0),
    //             ImageLocation = rightFilepath,
    //             BorderStyle = BorderStyle.None
    //         };
    //         
    //         source.Controls.Add(left);
    //         source.Controls.Add(right);
    //         left.BringToFront();
    //         right.BringToFront();
    //         
    //         int waitTime = duration / step;
    //         int move = 640 / step;
    //         
    //         for (int i = 0; i < step; i++)
    //         {
    //             Point leftNext = new Point((left.Location.X + move), left.Location.Y);
    //             Point rightNext = new Point((right.Location.X - move), right.Location.Y);
    //             left.Location = leftNext;
    //             right.Location = rightNext;
    //             await Task.Delay(waitTime);
    //         }
    //         
    //         Point leftFinal = new Point(0, 0);
    //         Point rightFinal = new Point(640, 0);
    //         left.Location = leftFinal;
    //         right.Location = rightFinal;
    //     }
    //     
    //     public static async Task LoadingEnd(Form source, List<PictureBox> pbList, int duration, int step)
    //     {
    //         PictureBox left = pbList[0];
    //         PictureBox right = pbList[1];
    //         
    //         int waitTime = duration / step;
    //         int move = 640 / step;
    //         
    //         for (int i = 0; i < step; i++)
    //         {
    //             Point leftNext = new Point((left.Location.X - move), left.Location.Y);
    //             Point rightNext = new Point((right.Location.X + move), right.Location.Y);
    //             left.Location = leftNext;
    //             right.Location = rightNext;
    //             await Task.Delay(waitTime);
    //         }
    //         
    //         Point leftFinal = new Point(-640, 0);
    //         Point rightFinal = new Point(1280, 0);
    //         left.Location = leftFinal;
    //         right.Location = rightFinal;
    //         
    //         source.Controls.Remove(left);
    //         source.Controls.Remove(right);
    //         source.Refresh();
    //     }
}