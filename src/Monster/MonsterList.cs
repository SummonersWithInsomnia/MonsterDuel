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
                Health = 105,
                Attack = 70,
                Defense = 55,
                Speed = 60,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/V.png",
                FrontImagePath = "MonsterDuel_Data/monsters/V_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/V_back.png",
                Skills = new Dictionary<string, ISkill>
                {
                    {
                        "Blade Fury", new AttackSkill
                        {
                            Name = "Blade Fury",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 30
                        }
                    },
                    {
                        "Iron Will", new BuffSkill
                        {
                            Name = "Iron Will",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Iron Will",
                                    Property = "Defense",
                                    Value = 20,
                                    Duration = 2
                                }
                            }
                        }
                    },
                    {
                        "Swift Strike", new AttackAndBuffSkill
                        {
                            Name = "Swift Strike",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 20,
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Swift Strike",
                                    Property = "Speed",
                                    Value = 20,
                                    Duration = 2
                                }
                            }
                        }
                    },
                    {
                        "Steel Shield", new DefenseSkill
                        {
                            Name = "Steel Shield",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Defense = 40
                        }
                    }
                }
            });

            All.Add("Jin", new Monster
            {
                Name = "Jin",
                Health = 110,
                Attack = 60,
                Defense = 50,
                Speed = 65,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Jin.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Jin_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Jin_back.png",
                Skills = new Dictionary<string, ISkill>
                {
                    {
                        "Quick Jab", new MultipleHitAttackSkill
                        {
                            Name = "Quick Jab",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            DamagePerHit = 20,
                            MinHit = 2,
                            MaxHit = 2,
                            HitRatePerHit = 100
                        }
                    },
                    {
                        "Meditate", new HealingSkill
                        {
                            Name = "Meditate",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Heal = 30
                        }
                    },
                    {
                        "Deflection", new BuffSkill
                        {
                            Name = "Deflection",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Deflection",
                                    Property = "Defense",
                                    Value = 25,
                                    Duration = 2
                                }
                            }
                        }
                    },
                    {
                        "Barrier Break", new FixedDamageSkill
                        {
                            Name = "Barrier Break",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            FixedDamage = 35
                        }
                    }
                }
            });

            All.Add("Suga", new Monster
            {
                Name = "Suga",
                Health = 100,
                Attack = 75,
                Defense = 50,
                Speed = 70,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = false, // only available for bosses
                IconPath = "MonsterDuel_Data/monsters/icons/Suga.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Suga_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Suga_back.png",
                Skills = new Dictionary<string, ISkill>
                {
                    {
                        "Thunderbolt", new AttackAndDebuffSkill
                        {
                            Name = "Thunderbolt",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 35,
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Thunderbolt",
                                    Property = "TurnSkip",
                                    Value = 70, // 70% chance to skip turn
                                    Duration = 3
                                }
                            },
                            DebuffHitRate = 15 // 15% chance to apply debuff
                        }
                    },
                    {
                        "Lightning Shield", new BuffSkill
                        {
                            Name = "Lightning Shield",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Lightning Shield",
                                    Property = "Defense",
                                    Value = 30,
                                    Duration = 2
                                }
                            }
                        }
                    },
                    {
                        "Electric Surge", new AttackSkill
                        {
                            Name = "Electric Surge",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 30,
                            MultipleTargets = true
                        }
                    },
                    {
                        "Static Charge", new DebuffSkill
                        {
                            Name = "Static Charge",
                            Description = "",
                            Limit = 40,
                            HitRate = 50, // 50% chance to hit
                            Element = "",
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Static Charge",
                                    Property = "TurnSkip",
                                    Value = 100,
                                    Duration = 1
                                }
                            }
                        }
                    }
                }
            });

            All.Add("Jungkook", new Monster
            {
                Name = "Jungkook",
                Health = 105,
                Attack = 80,
                Defense = 45,
                Speed = 75,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Jungkook.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Jungkook_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Jungkook_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Rap Monster", new Monster
            {
                Name = "Rap Monster",
                Health = 115,
                Attack = 65,
                Defense = 60,
                Speed = 55,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/RapMonster.png",
                FrontImagePath = "MonsterDuel_Data/monsters/RapMonster_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/RapMonster_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("J-hope", new Monster
            {
                Name = "J-hope",
                Health = 105,
                Attack = 60,
                Defense = 70,
                Speed = 60,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/J-hope.png",
                FrontImagePath = "MonsterDuel_Data/monsters/J-hope_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/J-hope_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Jimin", new Monster
            {
                Name = "Jimin",
                Health = 125,
                Attack = 85,
                Defense = 55,
                Speed = 50,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Jimin.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Jimin_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Jimin_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Rhaegal", new Monster
            {
                Name = "Rhaegal",
                Health = 115,
                Attack = 80,
                Defense = 60,
                Speed = 60,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Rhaegal.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Rhaegal_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Rhaegal_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Visereon", new Monster
            {
                Name = "Visereon",
                Health = 110,
                Attack = 75,
                Defense = 65,
                Speed = 65,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Visereon.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Visereon_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Visereon_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Kylo", new Monster
            {
                Name = "Kylo",
                Health = 110,
                Attack = 80,
                Defense = 60,
                Speed = 65,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Kylo.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Kylo_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Kylo_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Moonfang", new Monster
            {
                Name = "Moonfang",
                Health = 115,
                Attack = 60,
                Defense = 70,
                Speed = 55,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Moonfang.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Moonfang_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Moonfang_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Tinker", new Monster
            {
                Name = "Tinker",
                Health = 105,
                Attack = 65,
                Defense = 60,
                Speed = 90,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Tinker.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Tinker_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Tinker_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Vader", new Monster
            {
                Name = "Vader",
                Health = 125,
                Attack = 85,
                Defense = 70,
                Speed = 45,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Vader.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Vader_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Vader_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Luke", new Monster
            {
                Name = "Luke",
                Health = 105,
                Attack = 75,
                Defense = 65,
                Speed = 70,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Luke.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Luke_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Luke_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Frodo", new Monster
            {
                Name = "Frodo",
                Health = 100,
                Attack = 55,
                Defense = 50,
                Speed = 80,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Frodo.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Frodo_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Frodo_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Smaug", new Monster
            {
                Name = "Smaug",
                Health = 105,
                Attack = 60,
                Defense = 65,
                Speed = 70,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Smaug.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Smaug_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Smaug_back.png",
                Skills = new Dictionary<string, ISkill>()
            });

            All.Add("Phantom", new Monster
            {
                Name = "Phantom",
                Health = 120,
                Attack = 75,
                Defense = 80,
                Speed = 45,
                Description = "",
                Element = "",
                Buffs = new List<Buff>(),
                Available = true,
                IconPath = "MonsterDuel_Data/monsters/icons/Phantom.png",
                FrontImagePath = "MonsterDuel_Data/monsters/Phantom_front.png",
                BackImagePath = "MonsterDuel_Data/monsters/Phantom_back.png",
                Skills = new Dictionary<string, ISkill>()
            });
        }
    }
}