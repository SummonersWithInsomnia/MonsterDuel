using System.Collections.Generic;
using System.Windows.Forms;
using MonsterDuel;

namespace MonsterDuel
{
    public class Battle
    {
        public IPlayer LeftPlayer { get; set; }
        public IPlayer RightPlayer { get; set; }
        
        public BattleMap BattleMap { get; set; }
        public string BGMPath { get; set; }
        
        public Battle(IPlayer leftPlayer, IPlayer rightPlayer, BattleMap battleMap, string bgmPath)
        {
            LeftPlayer = leftPlayer;
            RightPlayer = rightPlayer;
            BattleMap = battleMap;
            BGMPath = bgmPath;
        }
    }
}