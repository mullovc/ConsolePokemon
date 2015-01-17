using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework;
using MyMath;
using Game.Model;
using Game.View;
using Game.Model.Database;

namespace Game
{
    namespace Controller
    {
        class WorldScene : Scene
        {
            new WorldView window;

            Map map;
            Player player;


            public WorldScene(Player player, Map map)
                : base(new WorldView(player, map))
            {
                window = (WorldView)base.window;

                this.player = player;
                this.map = map;

                initialize();
            }

            protected override void initialize()
            {
                keyDown += new KeyEventHandler(inputHandler);
            }

            /*
            public void play()
            {
                Output.addGraphic(Output.getFieldOfView(player.position.x, player.position.y, map, Program.displayWidth, Program.displayHeight));
                Output.print();

                while (true)
                {
                    if (processInput())
                    {
                        break;
                    }

                    Output.addGraphic(Output.getFieldOfView(player.position.x, player.position.y, map, Program.displayWidth, Program.displayHeight));
                    Output.print();
                }
            }*/
            

            public static Pokemon wildBattle()
            {
                Random rand = new Random();

                Stats stats = Data.pokedex(4);

                Pokemon wildPokemon = new Pokemon(stats);

                wildPokemon.initialize(rand.Next(1, 6));  //provisorical

                wildPokemon.moves[0] = Data.movedex(1); //provisorical
                wildPokemon.moves[1] = Data.movedex(1); //provisorical
                wildPokemon.moves[2] = Data.movedex(1); //provisorical
                wildPokemon.moves[3] = Data.movedex(1); //provisorical

                wildPokemon.stats.wild = true;

                return wildPokemon;
            }

            void checkTile()
            {
                if (map.getProperty(player.position) == Tile.TilePropery.EngageBattle && player.ableToFight())
                {
                    Opponent wildTeam = new Opponent(new Team(new Pokemon[] { wildBattle() }));
                    startBattle(wildTeam);
                }

                if (map.getProperty(player.position) == Tile.TilePropery.Heal)
                {
                    player.team.heal();
                }
            }

            void move(Vector2 direction)
            {
                if (map.getProperty(Vector2.add(player.position, direction)) != Tile.TilePropery.Solid)
                {
                    player.move(direction);
                    checkTile();

                    onChanged(this, EventArgs.Empty);
                }
            }

            void startBattle(Opponent opponent)
            {
                BattleScene battle = new BattleScene(player, opponent);

                onAddScene(battle);
            }

            void showStatScreen()
            {
                //BattleScene StatScreen = new StatScreen(player, Config.windowSize);

                //onAddScene(battle);
            }


            public void inputHandler(object sender, string key)
            {
                switch (key)
                {
                    case "S":
                        Data.saveGame(player);
                        break;
                    case "Enter":
                        showStatScreen();
                        break;
                    case "UpArrow":
                        move(new Vector2(0, -1));
                        break;
                    case "DownArrow":
                        move(new Vector2(0, 1));
                        break;
                    case "LeftArrow":
                        move(new Vector2(-1, 0));
                        break;
                    case "RightArrow":
                        move(new Vector2(1, 0));
                        break;
                    case "Q":
                        onCloseScene(EventArgs.Empty);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
