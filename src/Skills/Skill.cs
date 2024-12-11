using System;

namespace MonsterDuel
{
    public abstract class Skill
    {
        public abstract String Name { get; set; }
        public abstract String Description { get; set; }
        public abstract int Limit { get; set; }
        public abstract int HitRate { get; set; }
        public abstract String Element { get; set; }
        public abstract String Type { get; }
    }
}