using System.Collections.Generic;

namespace MonsterDuel;

public static class MonsterList
{
    // Maximum: 16 monsters
    public static Dictionary<string, Monster> All = new();

    public static void Init()
    {
        All.Add("V", new Monster
        {
            Name = "V",
            Health = 105,
            CurrentHealth = 105,
            Attack = 70,
            Defense = 55,
            Speed = 60,
            Description = "",
            Element = "Steel",
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
                        Description = "Deals 30 damage to an opponent monster",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Steel",
                        Damage = 30
                    }
                },
                {
                    "Iron Will", new BuffSkill
                    {
                        Name = "Iron Will",
                        Description = "Increases Defence by 20 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Steel",
                        Buffs = new List<Buff>
                        {
                            new()
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
                        Description = "Deals 25 damage and increases Speed by 10 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Steel",
                        Damage = 25,
                        Buffs = new List<Buff>
                        {
                            new()
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
                        Description = "Absorbs up to 40 damage in this turn",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Steel",
                        Defense = 40
                    }
                }
            }
        });

        All.Add("Jin", new Monster
        {
            Name = "Jin",
            Health = 110,
            CurrentHealth = 110,
            Attack = 60,
            Defense = 50,
            Speed = 65,
            Description = "",
            Element = "Fighting",
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
                        Description = "Deals 20 damage and hits twice",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
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
                        Description = "Restores 30 HP",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Heal = 30
                    }
                },
                {
                    "Deflection", new BuffSkill
                    {
                        Name = "Deflection",
                        Description = "Reduces incoming damage by 25 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Buffs = new List<Buff>
                        {
                            new()
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
                        Description = "Ignores all defenses and shields on the target and deals 35 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        FixedDamage = 35
                    }
                }
            }
        });

        All.Add("Suga", new Monster
        {
            Name = "Suga",
            Health = 1200,
            CurrentHealth = 1200,
            Attack = 75,
            Defense = 50,
            Speed = 70,
            Description = "",
            Element = "Electric",
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
                        Description = "Deals 60 damage with a 50% chance to paralyze the target",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Electric",
                        Damage = 60,
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Thunderbolt",
                                Property = "TurnSkip",
                                Value = 70, // 70% chance to skip turn
                                Duration = 3
                            }
                        },
                        DebuffHitRate = 50 // 50% chance to apply debuff
                    }
                },
                {
                    "Lightning Shield", new BuffSkill
                    {
                        Name = "Lightning Shield",
                        Description = "Absorbs 30 damage for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Eclectic",
                        Buffs = new List<Buff>
                        {
                            new()
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
                        Description = "Deals 30 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Electric",
                        Damage = 30
                    }
                },
                {
                    "Static Charge", new DebuffSkill
                    {
                        Name = "Static Charge",
                        Description = "Stuns the target for 1 turn",
                        Limit = 40,
                        HitRate = 50, // 50% chance to hit
                        Element = "Electric",
                        Debuffs = new List<Buff>
                        {
                            new()
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
            CurrentHealth = 105,
            Attack = 80,
            Defense = 45,
            Speed = 75,
            Description = "",
            Element = "Fighting",
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
                        Description = "Deals 30 damage and increases Speed by 15 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 30,
                        Buffs = new List<Buff>
                        {
                            new()
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
                        Description = "Increases both Defense and Speed by 10 for 4 turn",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Buffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Steadfast",
                                Property = "Defense",
                                Value = 10,
                                Duration = 4
                            },
                            new()
                            {
                                Name = "Steadfast",
                                Property = "Speed",
                                Value = 10,
                                Duration = 4
                            }
                        }
                    }
                },
                {
                    "Flash Step", new AttackAndDebuffSkill
                    {
                        Name = "Flash Step",
                        Description = "Deals 20 damage and stuns the target for 1 turn",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 20,
                        Debuffs = new List<Buff>
                        {
                            new()
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
                        Description = "Absorbs 20 damage for 3 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Buffs = new List<Buff>
                        {
                            new()
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
            CurrentHealth = 115,
            Attack = 65,
            Defense = 60,
            Speed = 55,
            Description = "",
            Element = "Rock",
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
                        Description = "Deals 30 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 30
                    }
                },
                {
                    "Second Wind", new HealingSkill
                    {
                        Name = "Second Wind",
                        Description = "Restores 25 HP",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Normal",
                        Heal = 25
                    }
                },
                {
                    "Rock Wall", new BuffSkill
                    {
                        Name = "Rock Wall",
                        Description = "Absorbs 50 damage for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Rock",
                        Buffs = new List<Buff>
                        {
                            new()
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
                        Description = "Deals 35 damage and reduces the opponent's Speed by 10 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Rock",
                        Damage = 35,
                        Debuffs = new List<Buff>
                        {
                            new()
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
            CurrentHealth = 105,
            Attack = 60,
            Defense = 70,
            Speed = 60,
            Description = "",
            Element = "Water",
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
                        Description = "Restores 45 HP",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Water",
                        Heal = 45
                    }
                },
                {
                    "Light Strike", new AttackSkill
                    {
                        Name = "Light Strike",
                        Description = "Deals 25 damage to an opponent",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Normal",
                        Damage = 25
                    }
                },
                {
                    "Defensive Spin", new BuffSkill
                    {
                        Name = "Defensive Spin",
                        Description = "Increases Defense by 20 for 3 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Water",
                        Buffs = new List<Buff>
                        {
                            new()
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
                    "Water Shield", new BuffSkill
                    {
                        Name = "Water Shield",
                        Description = "Reduces incoming damage by 20 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Water",
                        Buffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Aura Shield",
                                Property = "Defense",
                                Value = 20,
                                Duration = 2
                            }
                        }
                    }
                }
            }
        });

        All.Add("Jimin", new Monster
        {
            Name = "Jimin",
            Health = 125,
            CurrentHealth = 125,
            Attack = 85,
            Defense = 55,
            Speed = 50,
            Description = "",
            Element = "Fighting",
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
                        Description = "Deals 20 damage with 2 hits",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        DamagePerHit = 20,
                        MinHit = 2,
                        MaxHit = 2,
                        HitRatePerHit = 100
                    }
                },
                {
                    "Armor Up", new BuffSkill
                    {
                        Name = "Armor Up",
                        Description = "Increases Defense by 25 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Buffs = new List<Buff>
                        {
                            new()
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
                        Description = "Increases Attack and Speed by 10 for 3 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 10,
                        Buffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Courageous Roar",
                                Property = "Attack",
                                Value = 10,
                                Duration = 3
                            },
                            new()
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
                        Description = "Ignores all defenses and shields on the target and deals 35 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        FixedDamage = 35
                    }
                }
            }
        });

        All.Add("Rhaegal", new Monster
        {
            Name = "Rhaegal",
            Health = 115,
            CurrentHealth = 115,
            Attack = 80,
            Defense = 60,
            Speed = 60,
            Description = "",
            Element = "Fire",
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
                        Description = "Deals 40 damage to a single target",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fire",
                        Damage = 40
                    }
                },
                {
                    "Wing Shield", new DefenseSkill
                    {
                        Name = "Wing Shield",
                        Description = "Absorbs up to 35 damage in this turn",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dragon",
                        Defense = 35
                    }
                },
                {
                    "Tail Spin", new DebuffSkill
                    {
                        Name = "Tail Spin",
                        Description = "Stuns the target for 1 turn",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dragon",
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Tail Spin",
                                Property = "TurnSkip",
                                Value = 100,
                                Duration = 1
                            }
                        }
                    }
                },
                {
                    "Fiery Roar", new AttackAndBuffSkill
                    {
                        Name = "Fiery Roar",
                        Description = "Deals 25 damage and increases Attack by 15 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dragon",
                        Damage = 25,
                        Buffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Fiery Roar",
                                Property = "Attack",
                                Value = 15,
                                Duration = 2
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
            CurrentHealth = 110,
            Attack = 75,
            Defense = 65,
            Speed = 65,
            Description = "",
            Element = "Ice",
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
                        Description = "Deals 35 damage and reduces the opponent’s Speed by 15 for 1 turn in 65% chance",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Ice",
                        Damage = 35,
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Frost Breath",
                                Property = "Speed",
                                Value = -15,
                                Duration = 1
                            }
                        },
                        DebuffHitRate = 65 // 65% chance to apply debuff
                    }
                },
                {
                    "Ice Shield", new DefenseSkill
                    {
                        Name = "Ice Shield",
                        Description = "Absorbs 30 damage in this turn",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Ice",
                        Defense = 30
                    }
                },
                {
                    "Frozen Claw", new AttackAndDebuffSkill
                    {
                        Name = "Frozen Claw",
                        Description = "Deals 20 damage and freezes the opponent for 3 turn in 45% chance",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Ice",
                        Damage = 20,
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Frozen Claw",
                                Property = "TurnSkip",
                                Value = 100, // 100% chance to skip turn
                                Duration = 3
                            }
                        },
                        DebuffHitRate = 45 // 45% chance to apply debuff
                    }
                },
                {
                    "Winter's Bite", new AttackAndDebuffSkill
                    {
                        Name = "Winter's Bite",
                        Description =
                            "Deals 25 damage with a chance to decrease Defense of the opponent by 10 for 3 turn in 50% chance",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Ice",
                        Damage = 25,
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Winter's Bite",
                                Property = "Defense",
                                Value = -10,
                                Duration = 3
                            }
                        },
                        DebuffHitRate = 50 // 50% chance to apply debuff
                    }
                }
            }
        });

        All.Add("Kylo", new Monster
        {
            Name = "Kylo",
            Health = 110,
            CurrentHealth = 110,
            Attack = 80,
            Defense = 60,
            Speed = 65,
            Description = "",
            Element = "Fighting",
            Buffs = new List<Buff>(),
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Kylo.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Kylo_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Kylo_back.png",
            Skills = new Dictionary<string, ISkill>
            {
                {
                    "Crushing Blow", new AttackSkill
                    {
                        Name = "Crushing Blow",
                        Description = "Deals 35 damage to an opponent",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 35
                    }
                },
                {
                    "Barrier of Resolve", new DefenseSkill
                    {
                        Name = "Barrier of Resolve",
                        Description = "Absorbs 40 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Defense = 40
                    }
                },
                {
                    "Thunderous Strike", new AttackAndDebuffSkill
                    {
                        Name = "Thunderous Strike",
                        Description = "Deals 25 damage and stuns the opponent for 1 turn in 65% chance",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 25,
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Thunderous Strike",
                                Property = "TurnSkip",
                                Value = 100,
                                Duration = 1
                            }
                        },
                        DebuffHitRate = 65 // 65% chance to apply debuff
                    }
                },
                {
                    "Fury's Awakening", new BuffSkill
                    {
                        Name = "Fury's Awakening",
                        Description = "Increases Attack by 20 for 3 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Buffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Fury's Awakening",
                                Property = "Attack",
                                Value = 20,
                                Duration = 3
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
            CurrentHealth = 115,
            Attack = 60,
            Defense = 70,
            Speed = 55,
            Description = "",
            Element = "Dark",
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
                        Description = "Deals 25 damage and increases Speed",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dark",
                        Damage = 25,
                        Buffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Lunar Strike",
                                Property = "Speed",
                                Value = 15,
                                Duration = 2
                            }
                        }
                    }
                },
                {
                    "Moonlight Heal", new HealingSkill
                    {
                        Name = "Moonlight Heal",
                        Description = "Restores 30 HP",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dark",
                        Heal = 30,
                    }
                },
                {
                    "Howl of Defense", new BuffSkill
                    {
                        Name = "Howl of Defense",
                        Description = "Increases Defense and Speed by 10 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Normal",
                        Buffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Howl of Defense",
                                Property = "Defense",
                                Value = 10,
                                Duration = 2
                            },
                            new()
                            {
                                Name = "Howl of Defense",
                                Property = "Speed",
                                Value = 10,
                                Duration = 2
                            }
                        }
                    }
                },
                {
                    "Shield of Night", new BuffSkill
                    {
                        Name = "Shield of Night",
                        Description = "Reduces incoming damage by 20 for 2 turn",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dark",
                        Buffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Shield of Night",
                                Property = "Defense",
                                Value = 20,
                                Duration = 2
                            }
                        }
                    }
                }
            }
        });

        All.Add("Tinker", new Monster
        {
            Name = "Tinker",
            Health = 105,
            CurrentHealth = 105,
            Attack = 65,
            Defense = 60,
            Speed = 90,
            Description = "",
            Element = "Steel",
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
                        Description = "Deals 30 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Steel",
                        Damage = 30
                    }
                },
                {
                    "Speed Tune", new BuffSkill
                    {
                        Name = "Speed Tune",
                        Description = "Increases Speed by 25",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Steel",
                        Buffs = new List<Buff>
                        {
                            new()
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
                        Description = "Increases Defense by 20 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Steel",
                        Buffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Metal Armor",
                                Property = "Defense",
                                Value = 20,
                                Duration = 2
                            }
                        }
                    }
                },
                {
                    "Reflective Shield", new DefenseSkill
                    {
                        Name = "Reflective Shield",
                        Description = "Absorbs 35 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Steel",
                        Defense = 35
                    }
                }
            }
        });

        All.Add("Vader", new Monster
        {
            Name = "Vader",
            Health = 125,
            CurrentHealth = 125,
            Attack = 85,
            Defense = 70,
            Speed = 45,
            Description = "",
            Element = "Dark",
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
                        Description = "Deals 40 damage to an opponent",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dark",
                        Damage = 40
                    }
                },
                {
                    "Force Shield", new DefenseSkill
                    {
                        Name = "Force Shield",
                        Description = "Absorbs 30 damage in this turn",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dark",
                        Defense = 30
                    }
                },
                {
                    "Power Strike", new AttackAndDebuffSkill
                    {
                        Name = "Power Strike",
                        Description = "Deals 35 damage and reduces the opponent’s Speed by 15 for 1 turn in 75% chance",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 35,
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Power Strike",
                                Property = "Speed",
                                Value = -15,
                                Duration = 1
                            }
                        },
                        DebuffHitRate = 75 // 75% chance to apply debuff
                    }
                },
                {
                    "Intimidate", new DebuffSkill
                    {
                        Name = "Intimidate",
                        Description = "Reduces the opponent’s Attack by 20 for 2 turns",
                        Limit = 40,
                        HitRate = 75,
                        Element = "Dark",
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Intimidate",
                                Property = "Attack",
                                Value = -20,
                                Duration = 2
                            }
                        }
                    }
                }
            }
        });

        All.Add("Luke", new Monster
        {
            Name = "Luke",
            Health = 105,
            CurrentHealth = 105,
            Attack = 75,
            Defense = 65,
            Speed = 70,
            Description = "",
            Element = "Fighting",
            Buffs = new List<Buff>(),
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Luke.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Luke_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Luke_back.png",
            Skills = new Dictionary<string, ISkill>
            {
                {
                    "Force Push", new AttackAndDebuffSkill
                    {
                        Name = "Force Push",
                        Description = "Deals 25 damage and stuns the opponent for 1 turn in 60% chance",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 25,
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Force Push",
                                Property = "TurnSkip",
                                Value = 100, // 100% chance to skip turn
                                Duration = 1
                            }
                        },
                        DebuffHitRate = 60 // 60% chance to apply debuff
                    }
                },
                {
                    "Piercing Strike", new AttackSkill
                    {
                        Name = "Piercing Strike",
                        Description = "Deals 35 damage to an opponent",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 35
                    }
                },
                {
                    "Iron Bastion", new DefenseSkill
                    {
                        Name = "Iron Bastion",
                        Description = "Absorbs 40 damage in this turn",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Defense = 40
                    }
                },
                {
                    "Blazing Momentum", new AttackAndBuffSkill
                    {
                        Name = "Blazing Momentum",
                        Description = "Deals 30 damage and increases Speed by 15 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 30,
                        Buffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Blazing Momentum",
                                Property = "Speed",
                                Value = 15,
                                Duration = 2
                            }
                        }
                    }
                }
            }
        });

        All.Add("Frodo", new Monster
        {
            Name = "Frodo",
            Health = 100,
            CurrentHealth = 100,
            Attack = 55,
            Defense = 50,
            Speed = 80,
            Description = "",
            Element = "Normal",
            Buffs = new List<Buff>(),
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Frodo.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Frodo_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Frodo_back.png",
            Skills = new Dictionary<string, ISkill>
            {
                //skills
                //Sword Jab / Attack / 
                //Ring Shield / Defense / 
                //Stealth Step / Stun / Evades attacks and 
                //Hopeful Heal / Heal /  to an ally 

                {
                    "Jab", new AttackSkill
                    {
                        Name = "Jab",
                        Description = "Deals 25 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Normal",
                        Damage = 25
                    }
                },
                {
                    "Ring Shield", new BuffSkill
                    {
                        Name = "Ring Shield",
                        Description = "Increases Defense by 20 for 2 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Normal",
                        Buffs = new List<Buff>
                        {
                            new()
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
                    "Stealth Step", new DebuffSkill
                    {
                        Name = "Stealth Step",
                        Description = "Stuns the opponent for 1 turn in 70% chance",
                        Limit = 40,
                        HitRate = 70,
                        Element = "Normal",
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Stealth Step",
                                Property = "TurnSkip",
                                Value = 100,
                                Duration = 1
                            }
                        }
                    }
                },
                {
                    "Hopeful Heal", new HealingSkill
                    {
                        Name = "Hopeful Heal",
                        Description = "Restores 20 HP",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Normal",
                        Heal = 20
                    }
                }
            }
        });

        All.Add("Smaug", new Monster
        {
            Name = "Smaug",
            Health = 105,
            CurrentHealth = 105,
            Attack = 60,
            Defense = 65,
            Speed = 70,
            Description = "",
            Element = "Fire",
            Buffs = new List<Buff>(),
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Smaug.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Smaug_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Smaug_back.png",
            Skills = new Dictionary<string, ISkill>
            {
                {
                    "Dragon Flame", new AttackAndDebuffSkill
                    {
                        Name = "Dragon Flame",
                        Description = "Deals 35 damage and has a 20% chance to burn the target",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fire",
                        Damage = 35,
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Dragon Flame",
                                Property = "Health",
                                Value = -15,
                                Duration = 2
                            }
                        },
                        DebuffHitRate = 20 // 20% chance to apply debuff
                    }
                },
                {
                    "Fire Shield", new DefenseSkill
                    {
                        Name = "Fire Shield",
                        Description = "Absorbs 40 damage in this turn",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fire",
                        Defense = 40
                    }
                },
                {
                    "Tail Whip", new AttackAndDebuffSkill
                    {
                        Name = "Tail Whip",
                        Description =
                            "Deals 25 damage and reduces the opponent’s Speed by 15 for 2 turns in 80% chance",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dragon",
                        Damage = 25,
                        Debuffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Tail Whip",
                                Property = "Speed",
                                Value = -15,
                                Duration = 2
                            }
                        },
                        DebuffHitRate = 80 // 80% chance to apply debuff
                    }
                },
                {
                    "Roar", new BuffSkill
                    {
                        Name = "Roar",
                        Description = "Increases Attack by 20 for 3 turns",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dragon",
                        Buffs = new List<Buff>
                        {
                            new()
                            {
                                Name = "Roar",
                                Property = "Attack",
                                Value = 20,
                                Duration = 3
                            }
                        }
                    }
                }
            }
        });

        All.Add("Phantom", new Monster
        {
            Name = "Phantom",
            Health = 120,
            CurrentHealth = 120,
            Attack = 75,
            Defense = 80,
            Speed = 45,
            Description = "",
            Element = "Dark",
            Buffs = new List<Buff>(),
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Phantom.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Phantom_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Phantom_back.png",
            Skills = new Dictionary<string, ISkill>
            {
                //skills
                //Shadow Sneak / Stun / 
                //Ghost Strike / Attack /  and ignores Defense 
                //Ethereal Shield / Shield / Absorbs 30 damage and makes the user immune to status conditions for 1 turn
                //Haunting Aura / Attack / Deals 25 damage
                {
                    "Shadow Sneak", new DebuffSkill
                    {
                        Name = "Shadow Sneak",
                        Description = "Stuns the opponent for 1 turn in 70% chance",
                        Limit = 40,
                        HitRate = 70,
                        Element = "Dark",
                        Debuffs = new List<Buff>
                        {
                            new()
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
                    "Ghost Strike", new FixedDamageSkill
                    {
                        Name = "Ghost Strike",
                        Description = "Ignores all defenses and shields on the target and deals 30 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dark",
                        FixedDamage = 30
                    }
                },

                {
                    "Ethereal Shield", new DefenseSkill
                    {
                        Name = "Ethereal Shield",
                        Description = "Absorbs 30 damage in this turn",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Normal",
                        Defense = 30
                    }
                },
                {
                    "Haunting Aura", new AttackSkill
                    {
                        Name = "Haunting Aura",
                        Description = "Deals 25 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dark",
                        Damage = 25
                    }
                }
            }
        });
    }
}