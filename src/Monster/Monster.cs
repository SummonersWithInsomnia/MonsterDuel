using System;
using System.Collections.Generic;

namespace MonsterDuel
{
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public int CurrentHealth { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public string Description { get; set; }
        public string Element { get; set; }
        public List<Buff> Buffs { get; set; }
        public bool Available { get; set; }
        public string IconPath { get; set; }
        public string FrontImagePath { get; set; }
        public string BackImagePath { get; set; }
        public Dictionary<string, ISkill> Skills { get; set; }
    }
}