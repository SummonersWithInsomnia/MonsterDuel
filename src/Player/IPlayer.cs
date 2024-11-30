using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonsterDuel.Player
{
    public interface IPlayer
    {
        string Name { get; set; }
        Dictionary<string, Monster> Monsters { get; set; }
        Dictionary<int, string> MonsterOrder { get; set; }
        string CurrentMonster { get; set; }
        string IconPath { get; set; }
        string FrontImagePath { get; set; }
        string BackImagePath { get; set; }
        Task CommandMonster();
        Task SwitchMonster();

        Task Surrender();
    }
}