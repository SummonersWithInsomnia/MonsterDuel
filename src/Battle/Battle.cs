using System.Collections.Generic;
using MonsterDuel.Player;

namespace MonsterDuel.Battle
{
    public class Battle
    {
        public List<IPlayer> LeftPlayers { get; set; }
        public List<IPlayer> RightPlayers { get; set; }
        
        public BattleMap BattleMap { get; set; }
    }
}