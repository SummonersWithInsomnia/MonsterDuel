namespace MonsterDuel
{
    public class DefenseSkill : Skill
    {
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int Limit { get; set; }
        public override int HitRate { get; set; }
        public override string Element { get; set; }
        public override string Type { get; } = "Defense";
        public int Defense { get; set; }
        
        public DefenseSkill()
        {
        }
    }
}