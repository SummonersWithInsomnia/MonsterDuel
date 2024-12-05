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
                Skills = new Dictionary<string, ISkill>
                {
                     {
                        "Blade Dance", new AttackAndBuffSkill
                        {
                            Name = "Blade Dance",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 30,
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Blade Dance",
                                    Property = "Speed",
                                    Value = 15,
                                    Duration = 2
                                }
                            }
                        }
                    },
                      {
                        "Steadfast", new BuffSkill
                        {
                            Name = "Steadfast",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Steadfast",
                                    Property = "Defense",
                                    Value = 10,
                                    Duration = 1
                                },
                                 new Buff
                                {
                                    Name = "Steadfast",
                                    Property = "Speed",
                                    Value = 10,
                                    Duration = 1
                                }
                            }
                        }
                      },
                       {
                        "Flash Step", new AttackAndDebuffSkill
                        {
                            Name = "Flash Step",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 20,
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Flash Step",
                                    Property = "TurnSkip",
                                    Value = 100, // 100% chance to skip turn
                                    Duration = 1
                                }
                            },
                            DebuffHitRate = 100 // 100% chance to apply debuff
                        }
                       },
                        {
                        "Counter Shield", new BuffSkill
                        {
                            Name = "Counter Shield",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Counter Shield",
                                    Property = "Defense",
                                    Value = 20,
                                    Duration = 3
                                }
                            }
                        }
                    }
                }
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
                Skills = new Dictionary<string, ISkill>
                {
                     {
                        "Energy Punch", new AttackSkill
                        {
                            Name = "Energy Punch",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 30
                        }
                    },
                     {
                        "Second Wind", new HealingSkill
                        {
                            Name = "Second Wind",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Heal = 25
                        }
                    },
                      {
                        "Rock Wall", new BuffSkill
                        {
                            Name = "Rock Wall",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Rock Wall",
                                    Property = "Defense",
                                    Value = 50,
                                    Duration = 2
                                }
                            }
                        }
                    },
                       {
                        "Ground Slam", new AttackAndDebuffSkill
                        {
                            Name = "Ground Slam",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 35,
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Ground Slam",
                                    Property = "Speed",
                                    Value = -10,
                                    Duration = 2
                                }
                            },
                            DebuffHitRate = 100 // 100% chance to apply debuff
                        }
                    }


                }
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
                Skills = new Dictionary<string, ISkill>
                {
                     {
                        "Healing Dance", new HealingSkill
                        {
                            Name = "Healing Dance",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Heal = 15,
                            MultipleTargets = true
                        }
                    },
                      {
                        "Light Strike", new AttackSkill
                        {
                            Name = "Light Strike",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 25
                        }
                    },
                      {
                        "Defensive Spin", new BuffSkill
                        {
                            Name = "Defensive Spin",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Defensive Spin",
                                    Property = "Defense",
                                    Value = 20,
                                    Duration = 3
                                }
                            }
                        }
                    },
                      {
                        "Aura Shield", new BuffSkill
                        {
                            Name = "Aura Shield",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Aura Shield",
                                    Property = "Defense",
                                    Value = 15,
                                    Duration = 2
                                }
                            },
                            MultipleTargets = true
                        }
                    },
                }
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
                Skills = new Dictionary<string, ISkill>
                {

                    {
                        "Double Slash", new MultipleHitAttackSkill
                        {
                            Name = "Double Slash",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            DamagePerHit = 40,
                            MinHit = 2,
                            MaxHit = 2,
                            HitRatePerHit = 100
                        }
                    },
                     {
                        "Armor Up", new BuffSkill
                        {
                            Name = "Armor Up",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Armor Up",
                                    Property = "Defense",
                                    Value = 25,
                                    Duration = 2
                                }
                            }
                        }
                    },
                      {
                        "Courageous Roar", new AttackAndBuffSkill
                        {
                            Name = "Courageous Roar",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 10,
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Courageous Roar",
                                    Property = "Speed",
                                    Value = 10,
                                    Duration = 3
                                }
                            }
                        }
                    },
                       {
                        "Charge Strike", new FixedDamageSkill
                        {
                            Name = "Charge Strike",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            FixedDamage = 35
                        }
                    }
                }
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
                Skills = new Dictionary<string, ISkill>
                {
                     {
                        "Dragon's Fury", new AttackSkill
                        {
                            Name = "Dragon's Fury",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 40
                        }
                     },
                     {"Tail Spin", new DebuffSkill
                        {
                            Name = "Tail Spin",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Tail Spin",
                                    Property = "TurnSkip",
                                    Value = 100,
                                    Duration = 1
                                }
                            }
                        }
                     }
                }
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
                Skills = new Dictionary<string, ISkill>
                {
                     {
                        "Frost Breath", new AttackAndDebuffSkill
                        {
                            Name = "Frost Breath",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 35,
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Frost Breath",
                                    Property = "Speed",
                                    Value = -10,
                                    Duration = 1
                                }
                            },
                            DebuffHitRate = 100 // 100% chance to apply debuff
                        }
                     },
                     {
                        "Frozen Claw", new AttackAndDebuffSkill
                        {
                            Name = "Frozen Claw",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 20,
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Frozen Claw",
                                    Property = "TurnSkip",
                                    Value = 100, // 100% chance to skip turn
                                    Duration = 1
                                }
                            },
                            DebuffHitRate = 100 // 100% chance to apply debuff
                        }
                     }
                }
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
                Skills = new Dictionary<string, ISkill>
                {
                    //skills name:Crushing Blow/Barrier of Resolve/Thunderous Strike/Fury's Awakening
                     {
                        "Crushing Blow", new AttackSkill
                        {
                            Name = "Crushing Blow",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 35
                        }
                     },
                      {
                        "Thunderous Strike", new DebuffSkill
                        {
                            Name = "Thunderous Strike",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Thunderous Strike",
                                    Property = "TurnSkip",
                                    Value = 100,
                                    Duration = 1
                                }
                            }
                        }
                      }

                }
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
                Skills = new Dictionary<string, ISkill>
                {
                    {
                        "Lunar Strike", new AttackAndBuffSkill
                        {
                            Name = "Lunar Strike",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 25,
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Lunar Strike",
                                    Property = "Speed",
                                    Value = 10,
                                    Duration = 1
                                }
                            }
                        }
                    },

                    {
                        "Moonlight Heal", new HealingSkill
                        {
                            Name = "Moonlight Heal",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Heal = 30                         
                        }
                    },
                    {
                        "Howl of Defense", new BuffSkill
                        {
                            Name = "Howl of Defense",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Howl of Defense",
                                    Property = "Defense",
                                    Value = 10,
                                    Duration = 1
                                },
                                 new Buff
                                {
                                    Name = "Howl of Defense",
                                    Property = "Speed",
                                    Value = 10,
                                    Duration = 1
                                }
                            }
                        }
                    },
                     {
                        "Shield of Night", new DefenseSkill
                        {
                            Name = "Shield of Night",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Defense = 20
                        }
                     }
                }
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
                Skills = new Dictionary<string, ISkill>
                {

                    {
                        "Gear Grind", new AttackSkill
                        {
                            Name = "Gear Grind",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 30
                        }
                    },
                     {
                        "Speed Tune", new BuffSkill
                        {
                            Name = "Speed Tune",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                 new Buff
                                {
                                    Name = "Speed Tune",
                                    Property = "Speed",
                                    Value = 25,
                                    Duration = 1
                                }
                            }
                        }
                     },
                     {
                        "Metal Armor", new BuffSkill
                        {
                            Name = "Metal Armor",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Metal Armor",
                                    Property = "Defense",
                                    Value = 20,
                                    Duration = 2
                                }
                            }
                        }
                    }
                }
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
                Skills = new Dictionary<string, ISkill>
                {

                    {
                        "Dark Saber", new AttackSkill
                        {
                            Name = "Dark Saber",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 40
                        }

                    },
                      {
                        "Power Strike", new AttackAndDebuffSkill
                        {
                            Name = "Power Strike",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 35,
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Power Strike",
                                    Property = "Speed",
                                    Value = -10,
                                    Duration = 1
                                }
                            },
                            DebuffHitRate = 100 // 100% chance to apply debuff
                        }
                     }
                }
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
                Skills = new Dictionary<string, ISkill>
                {  //skill name: Force Push/Piercing Strike/Iron Bastion/Blazing Momentum
                    {
                        "Force Push", new AttackAndDebuffSkill
                        {
                            Name = "Force Push",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 20,
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Force Push",
                                    Property = "TurnSkip",
                                    Value = 100, // 100% chance to skip turn
                                    Duration = 1
                                }
                            },
                            DebuffHitRate = 100 // 100% chance to apply debuff
                        }
                       },
                    {
                        "Piercing Strike", new AttackSkill
                        {
                            Name = "Piercing Strike",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 35
                        }
                    }
                }
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
                Skills = new Dictionary<string, ISkill>
                {
                    {
                        "Sword Jab", new AttackSkill
                        {
                            Name = "Sword Jab",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 25
                        }
                    },
                    {
                        "Ring Shield", new BuffSkill
                        {
                            Name = "Ring Shield",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Ring Shield",
                                    Property = "Defense",
                                    Value = 20,
                                    Duration = 2
                                }
                            }
                        }
                    },
                     {
                        "Hopeful Heal", new HealingSkill
                        {
                            Name = "Hopeful Heal",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Heal = 20
                        }
                    },
                }
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
                Skills = new Dictionary<string, ISkill>
                {
                     {
                        "Shadow Sneak", new DebuffSkill
                        {
                            Name = "Shadow Sneak",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Shadow Sneak",
                                    Property = "TurnSkip",
                                    Value = 100,
                                    Duration = 1
                                }
                            }
                        }
                     },
                     {
                        "Ghost Strike", new AttackSkill
                        {
                            Name = "Ghost Strike",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 30
                        }
                     },
                     {
                        "Haunting Aura", new AttackSkill
                        {
                            Name = "Haunting Aura",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 25
                        }
                     }

                }
            });
        }
    }
}