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
            
            
        }
    }
}