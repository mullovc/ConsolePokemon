using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    namespace Model
    {
        class FleeAction : PokemonAction
        {
            /**
             * TODO: add status 'Fleeing' to Pokemon. Then on takeAction() change status to Fleeing
             */

            public FleeAction(Pokemon attacker)
                : base(attacker)
            {
                priority = 0;
            }

            public override void takeAction(Pokemon target)
            {
                Random rand = new Random();

                if (rand.Next((int)target.init) < (int)attacker.init)
                {
                    attacker.secondaryStatus = Pokemon.Status.Fleeing;

                    log = "You have escaped.";
                }
                else
                {
                    log = "You cannot flee!";
                }
            }
        }
    }
}
