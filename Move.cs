using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    namespace Model
    {
        class Move
        {
            public int index;
            public string name;
            public float baseDamage;
            public int accuracy;
            public MoveCategory category;
            public Pokemon.Status statusEffect;
            public Stats.Type type;


            public enum MoveCategory
            {
                Physical,
                Special,
                Status
            }


            public Move(int index, string name, float baseDamage, int accuracy, Stats.Type type, MoveCategory category,
                Pokemon.Status statusEffect)
            {
                this.index = index;
                this.name = name;
                this.baseDamage = baseDamage;
                this.accuracy = accuracy;
                this.type = type;
                this.category = category;
                this.statusEffect = statusEffect;
            }

            public Move() { }

        }
    }
}
