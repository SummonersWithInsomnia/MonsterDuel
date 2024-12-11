namespace MonsterDuel
{
    public class MultipleHitAttackSkill : Skill
    {
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int Limit { get; set; }
        public override int HitRate { get; set; }
        public override string Element { get; set; }
        public override string Type { get; } = "Multiple Hit Attack";
        public int DamagePerHit { get; set; }
        public int MinHit { get; set; }
        public int MaxHit { get; set; }
        public int HitRatePerHit { get; set; }
        
        public MultipleHitAttackSkill()
        {
        }
    }
}