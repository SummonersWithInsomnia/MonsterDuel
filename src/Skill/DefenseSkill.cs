namespace MonsterDuel
{
    public class DefenseSkill : ISkill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        public int HitRate { get; set; }
        public string Element { get; set; }
        public string Type { get; set; } = "Defense";
        public int Defense { get; set; }
    }
}