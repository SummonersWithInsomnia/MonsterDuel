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
                    //skills: 
                    //Blade Fury /Attack /Deals 30 damage to an opponent monster 
                    //Iron Will /Defence /Increases Defence by 20 for 2 turns 
                    //Swift Strike /Attack /Deals 25 damage and increases Speed by 10
                    //Steel Shield /Shield /Absorbs up to 40 damage for 1 turn 
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
                            Damage = 25,
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Swift Strike",
                                    Property = "Speed",
                                    Value = 10,
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
                    //skills                
                    //Quick Jab /Attack /Deals 20 damage and hits twice
                    //Meditate /Heal /Restores 30 HP to the user 
                    //Deflection /Defence /Reduces incoming damage by 25% for 2 turns
                    //Barrier Break /Attack /Deals 35 damage and breaks any shield on the target 
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
                    //skills
                    //Thunderbolt /Attack /Deals 35 damage with a 15% chance to stun
                    //Lightning Shield /Shield /Absorbs 30 damage and reduces Attack skills’ damage by 50%
                    //Electric Surge /Attack / Deals 30 damage to all opposing monsters 
                    //Static Charge /Stun / Stuns the target for 1 turn
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
                   //skills
                   //Blade Dance /Attack /Deals 30 damage and increases Speed by 15 
                   //Steadfast /Defense /Increases both Defense and Speed by 10
                   //Flash Step / Stun / Deals 20 damage and stuns the target for 1 turn 
                   //Counter Shield /Shield / Absorbs 20 damage and reflects 25% back to the attacker 
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
                   //skills
                   //Energy Punch / Attack / Deals 30 damage to an opponent 
                   //Second Wind  / Heal / Heals 25 HP to the user
                   //Rock Wall / Shield / Absorbs 50 damage for 2 turns
                   //Ground Slam / Attack / Deals 35 damage and reduces the opponent's Speed by 10
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
                    //skills
                    //Healing Dance / Heal / Heals all allies for 15 HP each
                    //Light Strike / Attack / Deals 25 damage
                    //Defensive Spin / Defense / Increases Defense by 20 for 3 turns
                    //Aura Shield / Shield / Reduces incoming damage for all allies by 15 for 2 turns
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
                      }
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
                    //skills
                    //Double Slash / Attack / Deals 40 damage with 2 hits
                    //Armor Up / Defense / Increases Defense by 25 for 2 turns
                    //Courageous Roar / Attack /Increases Attack and Speed by 10 for 3 turns 
                    //Charge Strike / Attack / Deals 35 damage and breaks through shields 

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
                            //To Do
                           /*
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
                           */
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
                    //skills
                    //Dragon's Fury / Attack / Deals 40 damage to a single target. 
                    //Wing Shield / Shield / Absorbs up to 35 damage and reduces Stun effects
                    //Tail Spin / Stun / Stuns the target for 1 turn
                    //Fiery Roar / Attack / Deals 25 damage and increases Attack by 15
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
 
                     {
                        "Wing Shield", new DefenseSkill
                        {

                            Name = "Wing Shield",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Wing Shield",
                                    Property = "Defense",
                                    Value = 35,
                                    Duration = 1
                                },
                                new Buff
                                {
                                    //To Do
                                }
                            }
                        }

                     }

                     {
                        "Tail Spin", new DebuffSkill
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
                    {
                        "Fiery Roar", new AttackSkill
                        {
                            //To Do
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
                    //skills
                    //Frost Breath / Attack / Deals 35 damage and reduces the opponent’s Speed 
                    //Ice Shield / Shield / Absorbs 30 damage and blocks Stun effects for 1 turn
                    //Frozen Claw / Stun / Deals 20 damage and freezes the opponent for 1 turn
                    //Winter’s Bite / Attack / Deals 25 damage with a chance to decrease Defense
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
                        "Ice Shield", new DefenseSkill
                        {

                            Name = "Ice Shield",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Ice Shield",
                                    Property = "Defense",
                                    Value = 30,
                                    Duration = 1
                                },
                                new Buff
                                {
                                    //To Do
                                }
                            }
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
                     },
                    {
                        "Winter's Bite", new AttackAndDebuffSkill
                        {
                             Name = "Winter's Bite",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 25,
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Winter's Bite",
                                    Property = "Defense",
                                    Value = -10,
                                    Duration = 1
                                }
                            },
                            DebuffHitRate = 50 // 100% chance to apply debuff
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
                    //skills 
                    //Crushing Blow / Attack / Deals 35 damage to an opponent 
                    //Barrier of Resolve / Shield / Absorbs 40 damage and blocks Stun effects for 1 turn
                    //Thunderous Strike / Stun / Stuns the opponent for 1 turn
                    //Fury's Awakening / Attack / Increases Attack by 20 for 3 turns 
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
                        "Barrier of Resolve", new DefenseSkill
                        {

                            Name = "Barrier of Resolve",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Barrier of Resolve",
                                    Property = "Defense",
                                    Value = 40,
                                    Duration = 1
                                },
                                new Buff
                                {
                                    //To Do
                                }
                            }
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
                      },
                    {
                        "Fury's Awakening", new AttackSkill
                        {
                           // To Do
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
                    //skills
                    //Lunar Strike /Attack / Deals 25 damage and increases Speed
                    //Moonlight Heal / Heal / Restores 30 HP to an ally
                    //Howl of Defense / Defense / Increases Defense and Speed by 10 
                    //Shield of Night / Shield / Reduces incoming damage by 20 for 1 turn
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
                    //skills
                    //Gear Grind / Attack / Deals 30 damage 
                    //Speed Tune / Attack / Increases Speed by 25
                    //Metal Armor / Defense / Increases Defense by 20 for 2 turns 
                    //Reflective Shield / Shield / Absorbs 25 damage and reflects 10 damage back to the attacker 
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
                    {
                         "Reflective Shield", new AttackAndBuffSkill
                        {
                            Name = "Reflective Shield",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 10,
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Reflective Shield",
                                    Property = "Defense",
                                    Value = 25,
                                    Duration = 1
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
                    //skills
                    //Dark Saber / Attack / Deals 40 damage to an opponent
                    //Force Shield / Shield / Absorbs 30 damage and blocks status conditions for 1 turn
                    //Power Strike / Attack / Deals 35 damage and reduces the opponent’s Speed
                    //Intimidate / Attack / Reduces the opponent’s Attack by 15 for 2 turns. 
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
                        "Force Shield", new DefenseSkill
                        {

                            Name = "Force Shield",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Force Shield",
                                    Property = "Defense",
                                    Value = 30,
                                    Duration = 1
                                },
                                new Buff
                                {
                                    //To Do
                                }
                            }
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
                     },
                    {
                        "Intimidate", new DefenseSkill
                        {
                            //To Do
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
                {  
                    //skills
                    //Force Push / Stun / Deals 20 damage and stuns the opponent for 1 turn 
                    //Piercing Strike / Shield / Deals 35 damage to an opponent
                    //Iron Bastion / Attack / Absorbs 30 damage and increases Defense for 1 turn
                    //Blazing Momentum / Attack / Increases Attack by 20 and Speed by 10 for 3 turns 
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
                    },
                    {
                        "Iron Bastion", new DefenseSkill
                        {
                            //To Do
                        }
                    },
                    {
                        "Blazing Momentum", new AttackAndBuffSkill
                        {
                            //To Do
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
                    //skills
                    //Sword Jab / Attack / Deals 25 damage
                    //Ring Shield / Defense / Increases Defense by 20 for 2 turns
                    //Stealth Step / Stun / Evades attacks and stuns the opponent for 1 turn
                    //Hopeful Heal / Heal / Restores 20 HP to an ally 

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
                        "Stealth Step", new DefenseAndDebuffSkill
                     {
                         //To Do
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
                Skills = new Dictionary<string, ISkill>
                {
                    //skills
                    //Dragon Flame / Attack / Deals 35 damage and has a 15% chance to burn the target
                    //Scale Shield  / Shield / Absorbs 40 damage and reduces Fire damage by 50% for 2 turns
                    //Tail Whip / Attack / Evades attacks and stuns the opponent for 1 turn
                    //Roar / Stun / Increases Attack by 25 for 2 turns
                    {
                        "Dragon Flame", new AttackAndDebuffSkill
                        {

                            Name = "Dragon Flame",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 35,
                            Debuffs = new List<Buff>
                            {
                                new Buff
                                {
                                   //To Do
                                }
                            },
                            DebuffHitRate = 15 // 100% chance to apply debuff
                        }
                    },
                    {
                        "Scale Shield", new DefenseSkill
                        {

                            Name = "Scale Shield",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Scale Shield",
                                    Property = "Defense",
                                    Value = 40,
                                    Duration = 1
                                },
                                new Buff
                                {
                                    //To Do
                                }
                            }
                        }
                    },
                    {
                        "Tail Whip", new DefenseAndDebuffSkill
                        {
                            //To Do
                        }
                    },
                    {
                        "Roar", new AttackSkill
                        {
                            //To Do
                        }
                    }
                }
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
                    //skills
                    //Shadow Sneak / Stun / Stuns the opponent for 1 turn
                    //Ghost Strike / Attack / Deals 30 damage and ignores Defense 
                    //Ethereal Shield / Shield / Absorbs 30 damage and makes the user immune to status conditions for 1 turn
                    //Haunting Aura / Attack / Deals 25 damage
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
                        "Ghost Strike", new AttackAndBuffSkill
                        {
                            Name = "Ghost Strike",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Damage = 30
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Ghost Strike",
                                    Property = "Defense",
                                    Value = 15,
                                    Duration = 1
                                }
                            }
                        }
                     },
                     {
                        "Ethereal Shield", new DefenseSkill
                        {

                            Name = "Ethereal Shield",
                            Description = "",
                            Limit = 40,
                            HitRate = 100,
                            Element = "",
                            Buffs = new List<Buff>
                            {
                                new Buff
                                {
                                    Name = "Ethereal Shield",
                                    Property = "Defense",
                                    Value = 30,
                                    Duration = 1
                                },
                                new Buff
                                {
                                    //To Do
                                }
                            }
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