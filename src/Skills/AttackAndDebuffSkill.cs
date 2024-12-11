using System.Collections.Generic;

namespace MonsterDuel
{
    public class AttackAndDebuffSkill : Skill
    {
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int Limit { get; set; }
        public override int HitRate { get; set; }
        public override string Element { get; set; }
        public override string Type { get; } = "Attack And Debuff";
        public int Damage { get; set; }
        public List<Buff> Debuffs { get; set; }
        public int DebuffHitRate { get; set; }
        
        public AttackAndDebuffSkill()
        {
        }
    }
}