using System;
using System.Drawing;
using System.Windows.Forms;

namespace MonsterDuel;

public class HPBar : ProgressBar
{
    public Color BarColor { get; set; } = Color.LawnGreen;
    public event EventHandler ValueChanged;

    public HPBar()
    {
        SetStyle(ControlStyles.UserPaint, true);
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rect = this.ClientRectangle;
        Graphics g = e.Graphics;

        ProgressBarRenderer.DrawHorizontalBar(g, rect);
        rect.Inflate(-3, -3);

        if (Value > 0)
        {
            Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round((float)rect.Width * ((float)this.Value / this.Maximum)), rect.Height);
            using (SolidBrush brush = new SolidBrush(BarColor))
            {
                g.FillRectangle(brush, clip);
            }
        }
    }
    
    public new int Value
    {
        get => base.Value;
        set
        {
            if (base.Value != value)
            {
                base.Value = value;
                OnValueChanged(EventArgs.Empty);
            }
        }
    }

    protected virtual void OnValueChanged(EventArgs e)
    {
        ValueChanged?.Invoke(this, e);
    }
}