using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDuel
{
    public static class SceneEffect
    {
        public static async Task<PictureBox> CutInFromLeft(Form source, string filepath, int duration, int step)
        {
            PictureBox pb = new PictureBox
            {
                Size = new Size(1280, 720),
                Location = new Point(-1280, 0),
                ImageLocation = filepath,
                BorderStyle = BorderStyle.None
            };
            
            source.Controls.Add(pb);
            pb.BringToFront();
            
            int waitTime = duration / step;
            int move = 1280 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point((pb.Location.X + move), pb.Location.Y);
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(0, 0);
            pb.Location = final;

            return pb;
        }
        
        public static async Task<PictureBox> CutInFromRight(Form source, string filepath, int duration, int step)
        {
            PictureBox pb = new PictureBox
            {
                Size = new Size(1280, 720),
                Location = new Point(1280, 0),
                ImageLocation = filepath,
                BorderStyle = BorderStyle.None
            };
            
            source.Controls.Add(pb);
            pb.BringToFront();
            
            int waitTime = duration / step;
            int move = 1280 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point((pb.Location.X - move), pb.Location.Y);
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(0, 0);
            pb.Location = final;

            return pb;
        }

        public static async Task CutOutFromRight(Form source, PictureBox pb, int duration, int step)
        {
            int waitTime = duration / step;
            int move = 1280 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point((pb.Location.X + move), pb.Location.Y);
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(1280, 0);
            pb.Location = final;
            
            source.Controls.Remove(pb);
            source.Refresh();
        }
        
        public static async Task CutOutFromLeft(Form source, PictureBox pb, int duration, int step)
        {
            int waitTime = duration / step;
            int move = 1280 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point((pb.Location.X - move), pb.Location.Y);
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(-1280, 0);
            pb.Location = final;
            
            source.Controls.Remove(pb);
            source.Refresh();
        }
        
        public static async Task<PictureBox> CutInFromTop(Form source, string filepath, int duration, int step)
        {
            PictureBox pb = new PictureBox
            {
                Size = new Size(1280, 720),
                Location = new Point(0, -720),
                ImageLocation = filepath,
                BorderStyle = BorderStyle.None
            };
            
            source.Controls.Add(pb);
            pb.BringToFront();
            
            int waitTime = duration / step;
            int move = 720 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point(pb.Location.X, (pb.Location.Y + move));
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(0, 0);
            pb.Location = final;

            return pb;
        }
        
        public static async Task<PictureBox> CutInFromBottom(Form source, string filepath, int duration, int step)
        {
            PictureBox pb = new PictureBox
            {
                Size = new Size(1280, 720),
                Location = new Point(0, 720),
                ImageLocation = filepath,
                BorderStyle = BorderStyle.None
            };
            
            source.Controls.Add(pb);
            pb.BringToFront();
            
            int waitTime = duration / step;
            int move = 720 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point(pb.Location.X, (pb.Location.Y - move));
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(0, 0);
            pb.Location = final;

            return pb;
        }
        
        public static async Task CutOutFromTop(Form source, PictureBox pb, int duration, int step)
        {
            int waitTime = duration / step;
            int move = 720 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point(pb.Location.X, (pb.Location.Y - move));
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(0, -720);
            pb.Location = final;
            
            source.Controls.Remove(pb);
            source.Refresh();
        }
        
        public static async Task CutOutFromBottom(Form source, PictureBox pb, int duration, int step)
        {
            int waitTime = duration / step;
            int move = 720 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point(pb.Location.X, (pb.Location.Y + move));
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(0, 720);
            pb.Location = final;
            
            source.Controls.Remove(pb);
            source.Refresh();
        }
        
        public static async Task<List<PictureBox>> CuttingInLikeClosingDoor(Form source, string leftFilepath, string rightFilepath, int duration, int step)
        {
            PictureBox left = new PictureBox
            {
                Size = new Size(640, 720),
                Location = new Point(-640, 0),
                ImageLocation = leftFilepath,
                BorderStyle = BorderStyle.None
            };
            
            PictureBox right = new PictureBox
            {
                Size = new Size(640, 720),
                Location = new Point(1280, 0),
                ImageLocation = rightFilepath,
                BorderStyle = BorderStyle.None
            };
            
            source.Controls.Add(left);
            source.Controls.Add(right);
            left.BringToFront();
            right.BringToFront();
            
            int waitTime = duration / step;
            int move = 640 / step;
            
            for (int i = 0; i < step; i++)
            {
                Point leftNext = new Point((left.Location.X + move), left.Location.Y);
                Point rightNext = new Point((right.Location.X - move), right.Location.Y);
                left.Location = leftNext;
                right.Location = rightNext;
                await Task.Delay(waitTime);
            }
            
            Point leftFinal = new Point(0, 0);
            Point rightFinal = new Point(640, 0);
            left.Location = leftFinal;
            right.Location = rightFinal;
            
            return new List<PictureBox> {left, right};
        }
        
        public static async Task CuttingOutLikeOpeningDoor(Form source, List<PictureBox> pbList, int duration, int step)
        {
            PictureBox left = pbList[0];
            PictureBox right = pbList[1];
            
            int waitTime = duration / step;
            int move = 640 / step;
            
            for (int i = 0; i < step; i++)
            {
                Point leftNext = new Point((left.Location.X - move), left.Location.Y);
                Point rightNext = new Point((right.Location.X + move), right.Location.Y);
                left.Location = leftNext;
                right.Location = rightNext;
                await Task.Delay(waitTime);
            }
            
            Point leftFinal = new Point(-640, 0);
            Point rightFinal = new Point(1280, 0);
            left.Location = leftFinal;
            right.Location = rightFinal;
            
            source.Controls.Remove(left);
            source.Controls.Remove(right);
            source.Refresh();
        }
    }
}