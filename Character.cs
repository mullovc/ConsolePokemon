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
        class Character
        {
            public Vector2 position { get; set; }

            public Character()
            {

            }

            public Character(Vector2 position)
            {
                this.position = position;
            }

            public void move(Vector2 direction)
            {
                position.add(direction);
            }
        }
    }
}
