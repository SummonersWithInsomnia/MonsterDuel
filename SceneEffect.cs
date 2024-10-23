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
                Size = new Size(1920, 1080),
                Location = new Point(-1920, 0),
                ImageLocation = filepath,
                BorderStyle = BorderStyle.None
            };
            
            source.Controls.Add(pb);
            pb.BringToFront();
            
            int waitTime = duration / step;
            int move = 1920 / step;

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
                Size = new Size(1920, 1080),
                Location = new Point(1920, 0),
                ImageLocation = filepath,
                BorderStyle = BorderStyle.None
            };
            
            source.Controls.Add(pb);
            pb.BringToFront();
            
            int waitTime = duration / step;
            int move = 1920 / step;

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
            int move = 1920 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point((pb.Location.X + move), pb.Location.Y);
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(1920, 0);
            pb.Location = final;
            
            source.Controls.Remove(pb);
            source.Refresh();
        }
        
        public static async Task CutOutFromLeft(Form source, PictureBox pb, int duration, int step)
        {
            int waitTime = duration / step;
            int move = 1920 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point((pb.Location.X - move), pb.Location.Y);
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(-1920, 0);
            pb.Location = final;
            
            source.Controls.Remove(pb);
            source.Refresh();
        }
        
        public static async Task<PictureBox> CutInFromTop(Form source, string filepath, int duration, int step)
        {
            PictureBox pb = new PictureBox
            {
                Size = new Size(1920, 1080),
                Location = new Point(0, -1080),
                ImageLocation = filepath,
                BorderStyle = BorderStyle.None
            };
            
            source.Controls.Add(pb);
            pb.BringToFront();
            
            int waitTime = duration / step;
            int move = 1080 / step;

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
                Size = new Size(1920, 1080),
                Location = new Point(0, 1080),
                ImageLocation = filepath,
                BorderStyle = BorderStyle.None
            };
            
            source.Controls.Add(pb);
            pb.BringToFront();
            
            int waitTime = duration / step;
            int move = 1080 / step;

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
            int move = 1080 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point(pb.Location.X, (pb.Location.Y - move));
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(0, -1080);
            pb.Location = final;
            
            source.Controls.Remove(pb);
            source.Refresh();
        }
        
        public static async Task CutOutFromBottom(Form source, PictureBox pb, int duration, int step)
        {
            int waitTime = duration / step;
            int move = 1080 / step;

            for (int i = 0; i < step; i++)
            {
                Point next = new Point(pb.Location.X, (pb.Location.Y + move));
                pb.Location = next;
                await Task.Delay(waitTime);
            }

            Point final = new Point(0, 1080);
            pb.Location = final;
            
            source.Controls.Remove(pb);
            source.Refresh();
        }
    }
}