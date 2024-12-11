using System.Collections.Generic;

namespace MonsterDuel
{
    public class DebuffSkill : Skill
    {
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int Limit { get; set; }
        public override int HitRate { get; set; }
        public override string Element { get; set; }
        public override string Type { get; } = "Debuff";

        public List<Buff> Debuffs { get; set; }
        
        public DebuffSkill()
        {
        }
    }
}