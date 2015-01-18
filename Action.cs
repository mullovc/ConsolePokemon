using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    namespace Model
    {
        abstract class Action
        {
            public String log { get; set; }

            public double priority { get; set; }

            public abstract void takeAction(Pokemon target);

        }
    }
}
