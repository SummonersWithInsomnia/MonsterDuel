using System;

namespace MonsterDuel
{
    public abstract class Skill
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int Limit { get; set; }
        public int HitRate { get; set; }
        public String Element { get; set; }
        public String Type { get; }
    }
}