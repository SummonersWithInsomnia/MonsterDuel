using System.Collections.Generic;

namespace MonsterDuel
{
    public static class MonsterList
    {
        // Maximum: 16 monsters
        public static Dictionary<string, Monster> All = new Dictionary<string, Monster>();

        public static void Init()
        {
            All.Add("V", new Monster
            {
                Name = "V",
                Health = 500,
                Attack = 200,
                Defense = 200,
                Speed = 120,
                Element = "Normal",
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/V.png",
                FrontImagePath = "MonsterDuel_Data/monsters/V_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/V_back.png",
                Skills = new Dictionary<string, ISkill>
                {
                    {
                        "Super Impact", new AttackSkill
                        {
                            Name = "Super Impact",
                            Description = "V impacts the enemy at high speed, causing massive damage.",
                            HitRate = 100, Limit = 30, Element = "Normal", Damage = 100
                        }
                    },
                    {
                        "V Charge", new BuffSkill
                        {
                            Name = "V Charge",
                            Description =
                                "V uses his charging device to increase his attack power and speed next turn.",
                            HitRate = 100, Limit = 30, Element = "Normal", Buffs =
                            {
                                new Buff { Name = "V Power", Duration = 1, Property = "Attack", Value = 250 },
                                new Buff { Name = "V Speed", Duration = 1, Property = "Speed", Value = 100 }
                            }
                        }
                    }
                }
            });

            All.Add("Jin", new Monster
            {
                Name = "Jin",
                Health = 600,
                Attack = 180,
                Defense = 150,
                Speed = 150,
                Element = "Warrior",
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Jin.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Jin_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Jin_back.png",
                Skills = new Dictionary<string, ISkill>
                {
                    {
                        "Quick Jab", new AttackSkill
                        {
                            Name = "Quick Jab",
                            Description = "Cause the enemy damage and hits twice.",
                            HitRate = 100, Limit = 30, Element = "Normal", Damage = 20
                        },
                          "Barrier Break", new AttackSkill
                        {
                            Name = "Barrier Break",
                            Description = "Cause the enemy damage and breaks any shield on the target .",
                            HitRate = 100, Limit = 30, Element = "Normal", Damage = 20
                        }
                       
                    },
                    {
                        "Meditate", new BuffSkill
                        {
                            Name = "Meditate",
                            Description =
                                "Restores HP to the user.",
                            HitRate = 100, Limit = 30, Element = "Normal", Buffs =
                            {
                                new Buff { Name = "Jin Heal", Duration = 1, Property = "Heal", Value = 250 },
                            }
                        },
                         "Deflection", new BuffSkill
                        {   
                            Name = "Deflection",
                            Description =
                                "Reduces incoming damage.",
                            HitRate = 100, Limit = 30, Element = "Normal", Buffs =
                            {                
                                new Buff { Name = "Jin Defense", Duration = 2, Property = "Defense", Value = 25% * Health }
                            }
                        }
                    }
                }
            });
        }
    }
}