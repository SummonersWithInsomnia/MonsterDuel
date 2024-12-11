namespace MonsterDuel
{
    public class FixedDamageSkill : Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        public int HitRate { get; set; }
        public string Element { get; set; }
        public string Type { get; } = "Fixed Damage";
        public int FixedDamage { get; set; }
    }
}