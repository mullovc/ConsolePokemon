using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    namespace Model
    {
        class Opponent : Trainer
        {
            public Opponent(Team team)
                : base(team)
            {

            }

            /**
             * TODO: properly implement method
             */
            public Action getRoundAction(Pokemon opponentFighter)
            {
                return new AttackAction(opponentFighter.moves[0], opponentFighter);
            }
        }
    }
}
