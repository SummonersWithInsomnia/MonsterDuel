using System.Collections.Generic;
using MonsterDuel.Player;

namespace MonsterDuel.Battle
{
    public class Battle
    {
        public IPlayer LeftPlayer { get; set; }
        public IPlayer RightPlayer { get; set; }
        
        public BattleMap BattleMap { get; set; }
    }
}