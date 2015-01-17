using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMath;

namespace Game
{
    
    namespace Model
    {
        class Player : Trainer
        {

            public Player(Team team, Vector2 position)
                : base(team, position)
            {

            }
        }
    }
}
