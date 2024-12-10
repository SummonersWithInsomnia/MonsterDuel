using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonsterDuel;

public class AI : IPlayer
{
    public string Name { get; set; }
    public Dictionary<string, Monster> Monsters { get; set; }
    public Dictionary<int, string> MonsterOrder { get; set; }
    public string CurrentMonster { get; set; }
    public string IconPath { get; set; }
    public string VSBarIconPath { get; set; }
    public string FullFrontImagePath { get; set; }
    public string FullBackImagePath { get; set; }
    public string SummoningColorRGB { get; set; }

    public async Task<string> GetCommandString(BattleController battleController)
    {
        string command = "";
        battleController.BattleMessageBox.ShowWaiting("Communicating...");
        
        Dictionary<string, Monster> monsterList = new Dictionary<string, Monster>(this.Monsters);
        string currentMonsterName = this.CurrentMonster;
        Monster currentMonster = this.Monsters[currentMonsterName];
        Dictionary<string, ISkill> currentMonsterSkills = currentMonster.Skills;
        
        // command = "Switch#MonsterName"
        if (currentMonster.CurrentHealth <= 0)
        {
            foreach (var monsterPair in monsterList)
            {
                if (monsterPair.Value.CurrentHealth > 0)
                {
                    command = $"Switch#{monsterPair.Key}";
                    break;
                }
            }
            
            await Task.Delay(2000);
            battleController.BattleMessageBox.CloseWaiting();
        
            Console.WriteLine($"AI {this.Name} Command: {command}");
            return command;
        }

        // command = "Command#SkillName"
        Random random = new Random();
        List<ISkill> availableSkills = new List<ISkill>();

        foreach (var skillPair in currentMonsterSkills)
        {
            if (skillPair.Value.Limit > 0)
            {
                availableSkills.Add(skillPair.Value);
            }
        }
        
        ISkill randomSkill = availableSkills[random.Next(availableSkills.Count)];
        command = $"Command# + {randomSkill.Name}";
        
        await Task.Delay(2000);
        battleController.BattleMessageBox.CloseWaiting();
        
        Console.WriteLine($"AI {this.Name} Command: {command}");
        return command;
    }
}