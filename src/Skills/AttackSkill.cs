namespace MonsterDuel
{
    public class AttackSkill : ISkill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        public int HitRate { get; set; }
        public string Element { get; set; }
        public string Type { get; } = "Attack";
        public int Damage { get; set; }
    }
}