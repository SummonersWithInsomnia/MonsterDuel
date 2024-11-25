using System;

namespace MonsterDuel
{
    public interface ISkill
    {
        String Name { get; set; }
        String Description { get; set; }
        int Limit { get; set; }
        int HitRate { get; set; }
        String Element { get; set; }
        String Type { get; set; }
    }
}