using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    namespace Model
    {
        class PokemonAction : Action
        {
            protected Pokemon attacker;

            public PokemonAction(Pokemon attacker)
            {
                this.attacker = attacker;
            }

            public override void takeAction(Pokemon target)
            {

            }
        }
    }
}
