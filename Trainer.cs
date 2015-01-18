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
        class Trainer : Character
        {
            public Team team { get; set; }

            public Trainer(Team team, Vector2 position)
                : base(position)
            {
                this.team = team;
            }

            public Trainer(Team team)
            {
                this.team = team;
            }

            public Pokemon getFighter()
            {
                return team.getFighter();
            }

            public bool ableToFight()
            {
                return team.getFighter() != null;
            }
        }
    }
}
