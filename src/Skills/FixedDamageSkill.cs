namespace MonsterDuel
{
    public class FixedDamageSkill : Skill
    {
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int Limit { get; set; }
        public override int HitRate { get; set; }
        public override string Element { get; set; }
        public override string Type { get; } = "Fixed Damage";
        public int FixedDamage { get; set; }
        
        public FixedDamageSkill()
        {
        }
    }
}