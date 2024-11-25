namespace MonsterDuel
{
    public class AttackAndSwitchSkill : ISkill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        public int HitRate { get; set; }
        public string Element { get; set; }
        public string Type { get; set; } = "Attack and Switch";
        public int Damage { get; set; }
    }
}