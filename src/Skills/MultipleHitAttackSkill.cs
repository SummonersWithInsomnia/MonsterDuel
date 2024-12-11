namespace MonsterDuel
{
    public class MultipleHitAttackSkill : Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        public int HitRate { get; set; }
        public string Element { get; set; }
        public string Type { get; } = "Multiple Hit Attack";
        public int DamagePerHit { get; set; }
        public int MinHit { get; set; }
        public int MaxHit { get; set; }
        public int HitRatePerHit { get; set; }
    }
}