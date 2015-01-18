using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model;

namespace Game
{
    namespace Model
    {
        class Battle
        {

            static float checkWeakness(Stats.Type Type1, Stats.Type Type2)
            {
                if (Type1 == Stats.Type.Fire && Type2 == Stats.Type.Grass
                || Type1 == Stats.Type.Fire && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Fire && Type2 == Stats.Type.Bug
                || Type1 == Stats.Type.Fire && Type2 == Stats.Type.Ice
                || Type1 == Stats.Type.Water && Type2 == Stats.Type.Fire
                || Type1 == Stats.Type.Water && Type2 == Stats.Type.Rock
                || Type1 == Stats.Type.Water && Type2 == Stats.Type.Ground
                || Type1 == Stats.Type.Grass && Type2 == Stats.Type.Rock
                || Type1 == Stats.Type.Grass && Type2 == Stats.Type.Ground
                || Type1 == Stats.Type.Grass && Type2 == Stats.Type.Water
                || Type1 == Stats.Type.Electric && Type2 == Stats.Type.Water
                || Type1 == Stats.Type.Electric && Type2 == Stats.Type.Flying
                || Type1 == Stats.Type.Ice && Type2 == Stats.Type.Ground
                || Type1 == Stats.Type.Ice && Type2 == Stats.Type.Grass
                || Type1 == Stats.Type.Ice && Type2 == Stats.Type.Flying
                || Type1 == Stats.Type.Ice && Type2 == Stats.Type.Dragon
                || Type1 == Stats.Type.Fighting && Type2 == Stats.Type.Normal
                || Type1 == Stats.Type.Fighting && Type2 == Stats.Type.Ice
                || Type1 == Stats.Type.Fighting && Type2 == Stats.Type.Rock
                || Type1 == Stats.Type.Fighting && Type2 == Stats.Type.Dark
                || Type1 == Stats.Type.Fighting && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Poison && Type2 == Stats.Type.Grass
                || Type1 == Stats.Type.Ground && Type2 == Stats.Type.Fire
                || Type1 == Stats.Type.Ground && Type2 == Stats.Type.Electric
                || Type1 == Stats.Type.Ground && Type2 == Stats.Type.Poison
                || Type1 == Stats.Type.Ground && Type2 == Stats.Type.Rock
                || Type1 == Stats.Type.Ground && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Flying && Type2 == Stats.Type.Grass
                || Type1 == Stats.Type.Flying && Type2 == Stats.Type.Fighting
                || Type1 == Stats.Type.Flying && Type2 == Stats.Type.Bug
                || Type1 == Stats.Type.Psychic && Type2 == Stats.Type.Fighting
                || Type1 == Stats.Type.Psychic && Type2 == Stats.Type.Poison
                || Type1 == Stats.Type.Bug && Type2 == Stats.Type.Grass
                || Type1 == Stats.Type.Bug && Type2 == Stats.Type.Psychic
                || Type1 == Stats.Type.Bug && Type2 == Stats.Type.Dark
                || Type1 == Stats.Type.Rock && Type2 == Stats.Type.Fire
                || Type1 == Stats.Type.Rock && Type2 == Stats.Type.Ice
                || Type1 == Stats.Type.Rock && Type2 == Stats.Type.Fighting
                || Type1 == Stats.Type.Rock && Type2 == Stats.Type.Bug
                || Type1 == Stats.Type.Ghost && Type2 == Stats.Type.Psychic
                || Type1 == Stats.Type.Ghost && Type2 == Stats.Type.Ghost
                || Type1 == Stats.Type.Dragon && Type2 == Stats.Type.Dragon
                || Type1 == Stats.Type.Dark && Type2 == Stats.Type.Psychic
                || Type1 == Stats.Type.Dark && Type2 == Stats.Type.Ghost
                || Type1 == Stats.Type.Steel && Type2 == Stats.Type.Ice
                || Type1 == Stats.Type.Steel && Type2 == Stats.Type.Rock)
                    return 2;
                else if (Type1 == Stats.Type.Normal && Type2 == Stats.Type.Rock
                || Type1 == Stats.Type.Normal && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Fire && Type2 == Stats.Type.Fire
                || Type1 == Stats.Type.Fire && Type2 == Stats.Type.Water
                || Type1 == Stats.Type.Fire && Type2 == Stats.Type.Rock
                || Type1 == Stats.Type.Fire && Type2 == Stats.Type.Dragon
                || Type1 == Stats.Type.Water && Type2 == Stats.Type.Water
                || Type1 == Stats.Type.Water && Type2 == Stats.Type.Grass
                || Type1 == Stats.Type.Water && Type2 == Stats.Type.Dragon
                || Type1 == Stats.Type.Grass && Type2 == Stats.Type.Fire
                || Type1 == Stats.Type.Grass && Type2 == Stats.Type.Grass
                || Type1 == Stats.Type.Grass && Type2 == Stats.Type.Bug
                || Type1 == Stats.Type.Grass && Type2 == Stats.Type.Poison
                || Type1 == Stats.Type.Grass && Type2 == Stats.Type.Flying
                || Type1 == Stats.Type.Grass && Type2 == Stats.Type.Dragon
                || Type1 == Stats.Type.Grass && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Electric && Type2 == Stats.Type.Grass
                || Type1 == Stats.Type.Electric && Type2 == Stats.Type.Electric
                || Type1 == Stats.Type.Electric && Type2 == Stats.Type.Dragon
                || Type1 == Stats.Type.Ice && Type2 == Stats.Type.Fire
                || Type1 == Stats.Type.Ice && Type2 == Stats.Type.Water
                || Type1 == Stats.Type.Ice && Type2 == Stats.Type.Ice
                || Type1 == Stats.Type.Ice && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Fighting && Type2 == Stats.Type.Poison
                || Type1 == Stats.Type.Fighting && Type2 == Stats.Type.Flying
                || Type1 == Stats.Type.Fighting && Type2 == Stats.Type.Psychic
                || Type1 == Stats.Type.Fighting && Type2 == Stats.Type.Bug
                || Type1 == Stats.Type.Poison && Type2 == Stats.Type.Poison
                || Type1 == Stats.Type.Poison && Type2 == Stats.Type.Ground
                || Type1 == Stats.Type.Poison && Type2 == Stats.Type.Rock
                || Type1 == Stats.Type.Poison && Type2 == Stats.Type.Ghost
                || Type1 == Stats.Type.Ground && Type2 == Stats.Type.Grass
                || Type1 == Stats.Type.Ground && Type2 == Stats.Type.Bug
                || Type1 == Stats.Type.Flying && Type2 == Stats.Type.Electric
                || Type1 == Stats.Type.Flying && Type2 == Stats.Type.Rock
                || Type1 == Stats.Type.Flying && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Psychic && Type2 == Stats.Type.Psychic
                || Type1 == Stats.Type.Psychic && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Bug && Type2 == Stats.Type.Fire
                || Type1 == Stats.Type.Bug && Type2 == Stats.Type.Fighting
                || Type1 == Stats.Type.Bug && Type2 == Stats.Type.Poison
                || Type1 == Stats.Type.Bug && Type2 == Stats.Type.Flying
                || Type1 == Stats.Type.Bug && Type2 == Stats.Type.Ghost
                || Type1 == Stats.Type.Bug && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Rock && Type2 == Stats.Type.Fire
                || Type1 == Stats.Type.Rock && Type2 == Stats.Type.Ice
                || Type1 == Stats.Type.Rock && Type2 == Stats.Type.Flying
                || Type1 == Stats.Type.Rock && Type2 == Stats.Type.Bug
                || Type1 == Stats.Type.Ghost && Type2 == Stats.Type.Dark
                || Type1 == Stats.Type.Ghost && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Dragon && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Dark && Type2 == Stats.Type.Fighting
                || Type1 == Stats.Type.Dark && Type2 == Stats.Type.Dark
                || Type1 == Stats.Type.Dark && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Steel && Type2 == Stats.Type.Fire
                || Type1 == Stats.Type.Steel && Type2 == Stats.Type.Water
                || Type1 == Stats.Type.Steel && Type2 == Stats.Type.Electric
                || Type1 == Stats.Type.Steel && Type2 == Stats.Type.Steel)
                    return 0.5f;
                else if (Type1 == Stats.Type.Normal && Type2 == Stats.Type.Ghost
                || Type1 == Stats.Type.Electric && Type2 == Stats.Type.Ground
                || Type1 == Stats.Type.Fighting && Type2 == Stats.Type.Ghost
                || Type1 == Stats.Type.Poison && Type2 == Stats.Type.Steel
                || Type1 == Stats.Type.Ground && Type2 == Stats.Type.Flying
                || Type1 == Stats.Type.Psychic && Type2 == Stats.Type.Dark
                || Type1 == Stats.Type.Ghost && Type2 == Stats.Type.Normal)
                    return 0;
                else
                    return 1;
            }


            public static float checkEffectiveness(Move move, Pokemon target)
            {
                return checkWeakness(move.type, target.stats.type1) * checkWeakness(move.type, target.stats.type2);
            }

            public static float checkForSTAB(Move move, Pokemon attacker)
            {
                if (move.type == attacker.stats.type1 || move.type == attacker.stats.type2)
                {
                    return 1.5f;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
