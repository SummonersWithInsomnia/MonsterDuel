using System.Collections.Generic;

namespace MonsterDuel
{
    public class AttackAndDebuffSkill : Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        public int HitRate { get; set; }
        public string Element { get; set; }
        public string Type { get; } = "Attack And Debuff";
        public int Damage { get; set; }
        public List<Buff> Debuffs { get; set; }
        public int DebuffHitRate { get; set; }
    }
}