using System;
using System.Collections.Generic;

namespace MonsterDuel
{
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public String Description { get; set; }
        public String Element { get; set; }
        public List<Buff> Buffs { get; set; }
        public bool Available { get; set; }
        public String IconPath { get; set; }
        public String FrontImagePath { get; set; }
        public String BackImagePath { get; set; }
        public Dictionary<string, ISkill> Skills { get; set; }
    }
}