using System;
using System.Drawing;

namespace MonsterDuel
{
    public class Particle
    {
        public Point Position { get; set; }
        public Point Velocity { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }
        public int Life { get; set; }
    }

    public class ParticleEventArgs : EventArgs
    {
        public Point Position { get; set; }
        public Point Velocity { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }
        public int Life { get; set; }

        public Particle CreatedParticle;
    }

    public class ParticleGenerator
    {
        public delegate void ParticleGeneratedEventHandler(object sender, ParticleEventArgs e);

        public event ParticleGeneratedEventHandler ParticleGenerated;

        public void Generate(Point pos, Point v, int size, Color c, int life)
        {
            Particle particle = new Particle() { Position = pos, Velocity = v, Size = size, Color = c, Life = life };
            OnParticleGenerated(particle);
        }

        protected virtual void OnParticleGenerated(Particle particle)
        {
            if (ParticleGenerated != null)
            {
                ParticleGenerated(this, new ParticleEventArgs() { CreatedParticle = particle });
            }
        }
    }
    
}