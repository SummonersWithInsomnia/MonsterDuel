using System.Collections.Generic;

namespace MonsterDuel;

public static class Element
{
    // string: Attacker, skill element
    // string: Defender, monster element
    // double: Damage Rate
    public static readonly Dictionary<string, Dictionary<string, double>> List;
}