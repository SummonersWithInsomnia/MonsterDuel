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

        public Monster()
        {
        }

        public Monster(Monster monster)
        {
            this.Name = monster.Name;
            this.Health = monster.Health;
            this.CurrentHealth = monster.CurrentHealth;
            this.Attack = monster.Attack;
            this.Defense = monster.Defense;
            this.Speed = monster.Speed;
            this.Description = monster.Description;
            this.Element = monster.Element;
            this.Buffs = new List<Buff>(monster.Buffs);
            this.Available = monster.Available;
            this.IconPath = monster.IconPath;
            this.FrontImagePath = monster.FrontImagePath;
            this.BackImagePath = monster.BackImagePath;
            this.Skills = new Dictionary<string, ISkill>(monster.Skills);
        }
    }
}