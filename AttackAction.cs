using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    namespace Model
    {
        class AttackAction : PokemonAction
        {
            Move move;

            public AttackAction(Move move, Pokemon attacker)
                : base(attacker)
            {
                this.move = move;
                priority = 1 / attacker.init;
            }

            public override void takeAction(Pokemon defender)
            {
                float additionalEffects = Battle.checkEffectiveness(move, defender) * Battle.checkForSTAB(move, attacker);

                float damage = 0;

                if (move.category == Move.MoveCategory.Physical)
                {
                    damage = (((2f * attacker.level + 10f) / 250f) * (attacker.atk / defender.def) * move.baseDamage + 2f);
                }

                else if (move.category == Move.MoveCategory.Special)
                {
                    damage = (((2f * attacker.level + 10f) / 250f) * (attacker.spAtk / defender.spDef) * move.baseDamage + 2f);
                }

                damage *= additionalEffects;

                defender.damage((int)damage);


                log = attacker.getName() + " has done " + (int)damage + " damage " + defender.getName() + " using " + move.name + "!";
            }
        }
    }
}
