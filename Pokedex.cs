using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework;
using Game.Model;

namespace Game
{
    namespace Model
    {
        namespace Database
        {
            class Data
            {
                public static Stats pokedex(int index)
                {
                    Stats stats;

                    switch (index)
                    {
                        case 4:
                            stats = new Stats(4, "Glumanda", 39, 52, 43, 60, 50, 65, 62, 0, 0, 0, 0, 0, 1, Stats.Type.Fire, Stats.Type.None,
                                              Stats.LevelingSpeed.MediumSlow);
                            break;
                        default:
                            stats = new Stats();
                            break;

                    }

                    return stats;
                }


                public static Move movedex(int index)
                {
                    Move move;

                    switch (index)
                    {
                        case 1:
                            move = new Move(1, "Kratzer", 40, 100, Stats.Type.Normal, Move.MoveCategory.Physical, Pokemon.Status.None);
                            break;
                        default:
                            move = new Move();
                            break;
                    }

                    return move;
                }

                public static Player loadGame()
                {
                    return null;
                }

                public static void saveGame(Player player)
                {

                }
            }
        }
    }
}
