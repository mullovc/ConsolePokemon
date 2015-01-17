using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework;
using Game.View;
using Game.Model;
using MyMath;

namespace Game
{
    namespace Controller
    {
        class MainMenuScene : Scene
        {
            protected new MainMenuView window { get; set; }

            private int cursorPosition;

            public MainMenuScene()
                : base(new MainMenuView(Config.windowSize))
            {
                window = (MainMenuView)base.window;

                initialize();
            }

            protected override void initialize()
            {
                keyDown += new KeyEventHandler(inputHandler);

                cursorPosition = 1;
                window.menuSelections[cursorPosition].activate();
                window.menuSelections[2].select += quit;
                window.menuSelections[0].select += loadGame;
            }

            private void selectionUp()
            {
                if (cursorPosition > 0)
                {
                    window.menuSelections[cursorPosition].deactivate();
                    cursorPosition--;
                    window.menuSelections[cursorPosition].activate();

                    onChanged(this, EventArgs.Empty);
                }
            }

            private void selectionDown()
            {
                if (cursorPosition < window.menuSelections.Length - 1)
                {
                    window.menuSelections[cursorPosition].deactivate();
                    cursorPosition++;
                    window.menuSelections[cursorPosition].activate();

                    onChanged(this, EventArgs.Empty);
                }
            }

            /**
             * Provisorical
             */
            private void loadGame(object sender, EventArgs e)
            {
                Pokemon pokemon = new Pokemon(Model.Database.Data.pokedex(4));
                pokemon.initialize(5);
                Team team = new Team(new Pokemon[] { pokemon });

                WorldScene scene = new WorldScene(new Player(team, new Vector2(1, 1)), new Map("map"));

                onAddScene(scene);
            }

            private void quit(object sender, EventArgs e)
            {
                onCloseScene(e);
            }

            public void inputHandler(object sender, String key)//Key key)
            {
                /*
                switch(key)
                {
                    case Key.UP_ARROW:
                        selectionUp();
                        break;
                    case Key.DOWN_ARROW:
                        selectionDown();
                        break;
                }*/
                switch (key)
                {
                    case "UpArrow":
                        selectionUp();
                        break;
                    case "DownArrow":
                        selectionDown();
                        break;
                    case "Enter":
                        window.menuSelections[cursorPosition].onSelect();
                        break;
                }
            }
        }
    }
}
