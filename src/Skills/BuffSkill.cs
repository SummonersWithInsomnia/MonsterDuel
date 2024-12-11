using System.Collections.Generic;

namespace MonsterDuel
{
    public class BuffSkill : Skill
    {
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int Limit { get; set; }
        public override int HitRate { get; set; }
        public override string Element { get; set; }
        public override string Type { get; } = "Buff";

        public List<Buff> Buffs { get; set; }
        
        public BuffSkill()
        {
        }
    }
}