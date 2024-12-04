using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonsterDuel
{
    public interface IPlayer
    {
        string Name { get; set; }
        Dictionary<string, Monster> Monsters { get; set; }
        Dictionary<int, string> MonsterOrder { get; set; }
        string CurrentMonster { get; set; }
        string IconPath { get; set; }
        string VSBarIconPath { get; set; }
        string FullFrontImagePath { get; set; }
        string FullBackImagePath { get; set; }
        
        Task CommandMonster();
        Task SwitchMonster();

        Task Surrender();
    }
}