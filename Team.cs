using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    namespace Model
    {
        class Team
        {
            public Pokemon[] team = new Pokemon[6];

            public Team()
            {

            }

            public Team(Pokemon[] team)
            {
                this.team = team;
            }

            public Pokemon getFighter()
            {
                for (int i = 0; i < team.Length; i++)
                {
                    if (team[i] != null && team[i].ableToFight())
                    {
                        return team[i];
                    }
                }

                return null;
            }

            public void heal()
            {
                for (int i = 0; i < team.Length; i++)
                {
                    if (team[i] != null)
                    {
                        team[i].heal();
                    }
                }
            }

            public Pokemon getTeammate(int number)
            {
                if (number >= 0 && number < 6)
                {
                    return team[number];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
