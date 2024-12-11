namespace MonsterDuel
{
    public class DefenseSkill : Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        public int HitRate { get; set; }
        public string Element { get; set; }
        public string Type { get; } = "Defense";
        public int Defense { get; set; }
    }
}