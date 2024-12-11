using System.Collections.Generic;

namespace MonsterDuel
{
    public class BuffSkill : Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        public int HitRate { get; set; }
        public string Element { get; set; }
        public string Type { get; } = "Buff";

        public List<Buff> Buffs { get; set; }
    }
}