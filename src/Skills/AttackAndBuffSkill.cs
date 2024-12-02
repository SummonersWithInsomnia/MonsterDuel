using System.Collections.Generic;

namespace MonsterDuel
{
    public class AttackAndBuffSkill : ISkill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        public int HitRate { get; set; }
        public string Element { get; set; }
        public string Type { get; } = "Attack and Buff";
        public int Damage { get; set; }
        public List<Buff> Buffs { get; set; }
    }
}