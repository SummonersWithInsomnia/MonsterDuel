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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/V.png",
            FrontImagePath = "MonsterDuel_Data/monsters/V_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/V_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Blade Fury", new AttackSkill
                    {
                        Name = "Blade Fury",
                        Description = "Deals 30 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Steel",
                        Damage = 30
                    }
                },
                {
                    "Iron Blade", new AttackSkill
                    {
                        Name = "Iron Blade",
                        Description = "Deals 40 damage in 75% chance",
                        Limit = 40,
                        HitRate = 75,
                        Element = "Steel",
                        Damage = 40
                    }
                },
                {
                    "Swift Strike", new FixedDamageSkill
                    {
                        Name = "Swift Strike",
                        Description = "Ignores all defenses and shields and deals 30 damage in 80% chance",
                        Limit = 40,
                        HitRate = 80,
                        Element = "Steel",
                        FixedDamage = 30,
                    }
                },
                {
                    "Steel Shield", new DefenseSkill
                    {
                        Name = "Steel Shield",
                        Description = "Increases defense by 40",
                        Limit = 5,
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Jin.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Jin_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Jin_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Quick Jab", new AttackSkill
                    {
                        Name = "Quick Jab",
                        Description = "Deals 40 damage in 85% chance",
                        Limit = 40,
                        HitRate = 85,
                        Element = "Fighting",
                        Damage = 40,
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
                    "Deflection", new DefenseSkill
                    {
                        Name = "Deflection",
                        Description = "Increases defense by 30",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Defense = 30
                    }
                },
                {
                    "Barrier Break", new FixedDamageSkill
                    {
                        Name = "Barrier Break",
                        Description = "Ignores all defenses and shields and deals 35 damage in 75% chance",
                        Limit = 40,
                        HitRate = 75,
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
            Available = false, // only available for bosses
            IconPath = "MonsterDuel_Data/monsters/icons/Suga.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Suga_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Suga_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Thunderbolt", new AttackSkill
                    {
                        Name = "Thunderbolt",
                        Description = "Deals 60 damage",
                        Limit = 60,
                        HitRate = 100,
                        Element = "Electric",
                        Damage = 60
                    }
                },
                {
                    "Lightning Shield", new DefenseSkill
                    {
                        Name = "Lightning Shield",
                        Description = "Increases defense by 45",
                        Limit = 10,
                        HitRate = 100,
                        Element = "Electric",
                        Defense = 45
                    }
                },
                {
                    "Electric Surge", new AttackSkill
                    {
                        Name = "Electric Surge",
                        Description = "Deals 140 damage in 30% chance",
                        Limit = 40,
                        HitRate = 30,
                        Element = "Electric",
                        Damage = 140
                    }
                },
                {
                    "Static Charge", new HealingSkill
                    {
                        Name = "Static Charge",
                        Description = "Restores 100 HP",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Electric",
                        Heal = 100
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Jungkook.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Jungkook_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Jungkook_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Blade Dance", new AttackSkill
                    {
                        Name = "Blade Dance",
                        Description = "Deals 30 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 30
                    }
                },
                {
                    "Steadfast", new DefenseSkill
                    {
                        Name = "Steadfast",
                        Description = "Increases defense by 30",
                        Limit = 10,
                        HitRate = 100,
                        Element = "Fighting",
                        Defense = 30,
                    }
                },
                {
                    "Flash Step", new FixedDamageSkill
                    {
                        Name = "Flash Step",
                        Description = "Ignores all defenses and shields and deals 40 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        FixedDamage = 40,
                    }
                },
                {
                    "Counter Shield", new AttackSkill
                    {
                        Name = "Counter Shield",
                        Description = "Deals 45 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 45
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/RapMonster.png",
            FrontImagePath = "MonsterDuel_Data/monsters/RapMonster_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/RapMonster_back.png",
            Skills = new Dictionary<string, Skill>
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
                    "Rock Wall", new DefenseSkill
                    {
                        Name = "Rock Wall",
                        Description = "Increases defense by 50",
                        Limit = 5,
                        HitRate = 100,
                        Element = "Rock",
                        Defense = 50
                    }
                },
                {
                    "Ground Slam", new AttackSkill
                    {
                        Name = "Ground Slam",
                        Description = "Deals 35 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Rock",
                        Damage = 35
                    }
                }
            }
        });

        All.Add("J-Hope", new Monster
        {
            Name = "J-Hope",
            Health = 105,
            CurrentHealth = 105,
            Attack = 60,
            Defense = 70,
            Speed = 60,
            Description = "",
            Element = "Water",
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/J-Hope.png",
            FrontImagePath = "MonsterDuel_Data/monsters/J-Hope_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/J-Hope_back.png",
            Skills = new Dictionary<string, Skill>
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
                        Description = "Deals 25 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Normal",
                        Damage = 25
                    }
                },
                {
                    "Defensive Spin", new DefenseSkill
                    {
                        Name = "Defensive Spin",
                        Description = "Increases defense by 40",
                        Limit = 5,
                        HitRate = 100,
                        Element = "Water",
                        Defense = 20
                    }
                },
                {
                    "Water Shield", new DefenseSkill()
                    {
                        Name = "Water Shield",
                        Description = "Increases defense by 20",
                        Limit = 10,
                        HitRate = 100,
                        Element = "Water",
                        Defense = 10
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Jimin.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Jimin_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Jimin_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Double Slash", new FixedDamageSkill
                    {
                        Name = "Double Slash",
                        Description = "Ignores all defenses and shields and deals 40 damage",
                        Limit = 15,
                        HitRate = 100,
                        Element = "Fighting",
                        FixedDamage = 40
                    }
                },
                {
                    "Armor Up", new DefenseSkill
                    {
                        Name = "Armor Up",
                        Description = "Increases defense by 30",
                        Limit = 5,
                        HitRate = 100,
                        Element = "Fighting",
                        Defense = 30
                    }
                },
                {
                    "Courageous Roar", new AttackSkill
                    {
                        Name = "Courageous Roar",
                        Description = "Deals 50 damage",
                        Limit = 10,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 50
                    }
                },
                {
                    "Charge Strike", new FixedDamageSkill
                    {
                        Name = "Charge Strike",
                        Description = "Ignores all defenses and shields and deals 20 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        FixedDamage = 20
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Rhaegal.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Rhaegal_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Rhaegal_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Dragon's Fury", new AttackSkill
                    {
                        Name = "Dragon's Fury",
                        Description = "Deals 40 damage",
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
                        Description = "Increases defense by 35",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dragon",
                        Defense = 35
                    }
                },
                {
                    "Tail Spin", new AttackSkill
                    {
                        Name = "Tail Spin",
                        Description = "Deals 30 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dragon",
                        Damage = 30
                    }
                },
                {
                    "Fiery Roar", new FixedDamageSkill
                    {
                        Name = "Fiery Roar",
                        Description = "Ignores all defenses and shields and deals 25 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dragon", 
                        FixedDamage= 25
                    }
                }
            }
        });

        All.Add("Viserion", new Monster
        {
            Name = "Viserion",
            Health = 110,
            CurrentHealth = 110,
            Attack = 75,
            Defense = 65,
            Speed = 65,
            Description = "",
            Element = "Ice",
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Viserion.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Viserion_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Viserion_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Frost Breath", new AttackSkill
                    {
                        Name = "Frost Breath",
                        Description = "Deals 35 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Ice",
                        Damage = 35
                    }
                },
                {
                    "Ice Shield", new DefenseSkill
                    {
                        Name = "Ice Shield",
                        Description = "Increases defense by 30",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Ice",
                        Defense = 30
                    }
                },
                {
                    "Frozen Claw", new FixedDamageSkill
                    {
                        Name = "Frozen Claw",
                        Description = "Deals 20 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Ice",
                        FixedDamage = 20
                    }
                },
                {
                    "Winter Bite", new HealingSkill
                    {
                        Name = "Winter Bite",
                        Description = "Restores 50 HP",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Ice",
                        Heal = 50
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Kylo.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Kylo_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Kylo_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Crushing Blow", new AttackSkill
                    {
                        Name = "Crushing Blow",
                        Description = "Deals 35 damage in 80% chance",
                        Limit = 40,
                        HitRate = 80,
                        Element = "Fighting",
                        Damage = 35
                    }
                },
                {
                    "Barrier of Resolve", new DefenseSkill
                    {
                        Name = "Barrier of Resolve",
                        Description = "Increases defense by 40",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Defense = 40
                    }
                },
                {
                    "Thunderous Strike", new AttackSkill
                    {
                        Name = "Thunderous Strike",
                        Description = "Deals 25 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 25,
                        
                    }
                },
                {
                    "Awakening", new HealingSkill
                    {
                        Name = "Awakening",
                        Description = "Restores 30 HP",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Heal = 30
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Moonfang.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Moonfang_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Moonfang_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Lunar Strike", new AttackSkill
                    {
                        Name = "Lunar Strike",
                        Description = "Deals 25 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dark",
                        Damage = 25
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
                    "Howl of Defense", new DefenseSkill
                    {
                        Name = "Howl of Defense",
                        Description = "Increases defense by 35",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Normal",
                        Defense = 35,
                    }
                },
                {
                    "Wind of Night", new HealingSkill
                    {
                        Name = "Wind of Night",
                        Description = "Restores 50 HP",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dark",
                        Heal = 50
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Tinker.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Tinker_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Tinker_back.png",
            Skills = new Dictionary<string, Skill>
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
                    "Defense Tune", new DefenseSkill
                    {
                        Name = "Defense Tune",
                        Description = "Increases Speed by 25",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Steel",
                        Defense = 25
                    }
                },
                {
                    "Metal Armor", new FixedDamageSkill
                    {
                        Name = "Metal Armor",
                        Description = "Ignores all defenses and shields and deals 40 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Steel",
                        FixedDamage = 40
                    }
                },
                {
                    "Reflective Shield", new DefenseSkill
                    {
                        Name = "Reflective Shield",
                        Description = "Increases defense by 40",
                        Limit = 10,
                        HitRate = 100,
                        Element = "Steel",
                        Defense = 40
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Vader.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Vader_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Vader_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Dark Saber", new AttackSkill
                    {
                        Name = "Dark Saber",
                        Description = "Deals 40 damage",
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
                        Description = "Increases defense by 30",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dark",
                        Defense = 30
                    }
                },
                {
                    "Power Strike", new AttackSkill
                    {
                        Name = "Power Strike",
                        Description = "Deals 50 damage",
                        Limit = 20,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 50
                    }
                },
                {
                    "Intimidate", new AttackSkill
                    {
                        Name = "Intimidate",
                        Description = "Deals 30 damage in 55% chance",
                        Limit = 40,
                        HitRate = 55,
                        Element = "Dark",
                        Damage = 60
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Luke.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Luke_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Luke_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Force Push", new AttackSkill
                    {
                        Name = "Force Push",
                        Description = "Deals 25 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Damage = 25
                    }
                },
                {
                    "Piercing Strike", new AttackSkill
                    {
                        Name = "Piercing Strike",
                        Description = "Deals 35 damage",
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
                        Description = "Increases defense by 40",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fighting",
                        Defense = 40
                    }
                },
                {
                    "Blazing Momentum", new AttackSkill
                    {
                        Name = "Blazing Momentum",
                        Description = "Deals 50 damage in 50% chance",
                        Limit = 40,
                        HitRate = 50,
                        Element = "Fighting",
                        Damage = 50
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Frodo.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Frodo_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Frodo_back.png",
            Skills = new Dictionary<string, Skill>
            {
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
                    "Ring Shield", new DefenseSkill
                    {
                        Name = "Ring Shield",
                        Description = "Increases defense by 30",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Normal",
                        Defense = 30
                    }
                },
                {
                    "Stealth Step", new FixedDamageSkill
                    {
                        Name = "Stealth Step",
                        Description = "Ignores all defenses and shields and deals 50 damage in 70% chance",
                        Limit = 40,
                        HitRate = 70,
                        Element = "Normal",
                        FixedDamage = 50
                    }
                },
                {
                    "Hopeful Heal", new HealingSkill
                    {
                        Name = "Hopeful Heal",
                        Description = "Restores 40 HP",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Normal",
                        Heal = 40
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Smaug.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Smaug_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Smaug_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Dragon Flame", new AttackSkill
                    {
                        Name = "Dragon Flame",
                        Description = "Deals 35 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fire",
                        Damage = 35
                    }
                },
                {
                    "Fire Shield", new DefenseSkill
                    {
                        Name = "Fire Shield",
                        Description = "Increases defense by 40",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Fire",
                        Defense = 40
                    }
                },
                {
                    "Tail Whip", new AttackSkill()
                    {
                        Name = "Tail Whip",
                        Description = "Deals 30 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dragon",
                        Damage = 30
                    }
                },
                {
                    "Roar", new AttackSkill()
                    {
                        Name = "Roar",
                        Description = "Deals 55 damage in 80% chance",
                        Limit = 40,
                        HitRate = 80,
                        Element = "Dragon",
                        Damage = 55
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
            Available = true,
            IconPath = "MonsterDuel_Data/monsters/icons/Phantom.png",
            FrontImagePath = "MonsterDuel_Data/monsters/Phantom_front.png",
            BackImagePath = "MonsterDuel_Data/monsters/Phantom_back.png",
            Skills = new Dictionary<string, Skill>
            {
                {
                    "Shadow Sneak", new AttackSkill()
                    {
                        Name = "Shadow Sneak",
                        Description = "Deals 50 damage in 70% chance",
                        Limit = 40,
                        HitRate = 70,
                        Element = "Dark",
                        Damage = 50
                    }
                },
                {
                    "Ghost Strike", new FixedDamageSkill
                    {
                        Name = "Ghost Strike",
                        Description = "Ignores all defenses and shields and deals 40 damage",
                        Limit = 40,
                        HitRate = 100,
                        Element = "Dark",
                        FixedDamage = 40
                    }
                },
                {
                    "Ethereal Shield", new DefenseSkill
                    {
                        Name = "Ethereal Shield",
                        Description = "Increases defense by 30",
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