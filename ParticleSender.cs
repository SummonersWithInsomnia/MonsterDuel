using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MonsterDuel
{
    public class ParticleSender : Control
    {
        private Form sourceForm;
        public List<Particle> Particles;
        private Timer timer;
        private Random random;
        private Point senderZoneTopLeft;
        private Point senderZoneBottomRight;
        private bool enable = true;
        private int generateParticleRatePercentage;
        private Particle particleSample;
        private ParticleGenerator generator;
        private int particleSpeedRatePercentage = 0;

        public ParticleSender(Form source, Point zoneTopLeft, Point zoneBottomRight, int ratePercentage,
            Particle sample, int speedRatePercentage)
        {
            sourceForm = source;
            
            Particles = new List<Particle>();
            timer = new Timer();
            random = new Random();
            generator = new ParticleGenerator();
            
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            //SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            
            BackColor = Color.Transparent;
            Size = new Size(sourceForm.ClientSize.Width, sourceForm.ClientSize.Height);
            Location = new Point(0, 0);
            
            senderZoneTopLeft = zoneTopLeft;
            senderZoneBottomRight = zoneBottomRight;
            generateParticleRatePercentage = ratePercentage;
            particleSample = sample;
            particleSpeedRatePercentage = speedRatePercentage;
            
            if (senderZoneTopLeft.X > senderZoneBottomRight.X || senderZoneTopLeft.Y > senderZoneBottomRight.Y)
            {
                throw new Exception("Init particle sender zone failed due to the wrong size of the sender zone");
            }
            
            generator.ParticleGenerated += OnParticleGenerated;
            
            timer.Interval = 10;
            timer.Tick += OnTimerTick;
        }

        public async void Start()
        {
            timer.Start();
        }
        
        // protected override CreateParams CreateParams
        // {
        //     get
        //     {
        //         CreateParams cp = base.CreateParams;
        //         cp.ExStyle = cp.ExStyle | 0x20; // WS_EX_TRANSPARENT
        //         return cp;
        //     }
        // }
        
        protected override void OnPaintBackground(PaintEventArgs args)
        {
        }

        public void OnParticleGenerated(object source, ParticleEventArgs args)
        {
            Particles.Add(args.CreatedParticle);
        }

        private void OnTimerTick(object source, EventArgs args)
        {
            if (enable)
            {
                if (random.Next(0, 101) > generateParticleRatePercentage)
                {
                    Point p = new Point();
                    p.X = random.Next(senderZoneTopLeft.X, senderZoneBottomRight.X + 1);
                    p.Y = random.Next(senderZoneTopLeft.Y, senderZoneBottomRight.Y + 1);

                    Point v = new Point();
                    v.X = random.Next(particleSample.Velocity.X,
                        (particleSample.Velocity.X * particleSpeedRatePercentage / 100 + 1));
                    v.Y = random.Next(particleSample.Velocity.Y,
                        (particleSample.Velocity.Y * particleSpeedRatePercentage / 100 + 1));

                    generator.Generate(p, v, particleSample.Size, particleSample.Color, particleSample.Life);
                }
            }

            for (int i = Particles.Count - 1; i >= 0; i--)
            {
                Particle p = Particles[i];
                Point nextPos = new Point();
                nextPos.X = p.Position.X + p.Velocity.X;
                nextPos.Y = p.Position.Y + p.Velocity.Y;
                p.Position = nextPos;
                p.Life--;

                if (p.Life <= 0 || p.Position.X < 0 || p.Position.X > sourceForm.ClientSize.Width ||
                    p.Position.Y < 0 || p.Position.Y > sourceForm.ClientSize.Height)
                {
                    Particles.RemoveAt(i);
                }
            }
            
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs args)
        {
            Graphics g = args.Graphics;
            g.CompositingMode = CompositingMode.SourceOver;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            foreach (var particle in Particles)
            {
                using (var brush = new SolidBrush(particle.Color))
                {
                    g.FillEllipse(brush, particle.Position.X, particle.Position.Y, particle.Size, particle.Size);
                }
            }
        }
        
        public void Stop()
        {
            enable = false;
        }
    }
}