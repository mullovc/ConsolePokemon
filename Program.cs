using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMath;
using MyFramework.GUI;
using Game.Controller;

namespace MyFramework
{
    class Program
    {
        private Stack<Scene> scenes;
        private Scene currentScene;
        private Window currentWindow;

        private bool running;
        private bool changed;

        public Program()
        {
            configure();

            Output.display = new Display(Config.windowSize);
            scenes = new Stack<Scene>();

            addScene(this, new MainMenuScene());
        }

        public void configure()
        {
            Config.windowSize = new Vector2(150, 60);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(Config.windowSize.x + 1, Config.windowSize.y + 1);
            Console.SetBufferSize(Config.windowSize.x + 1, Config.windowSize.y + 1);
            Console.Title = "Game";
            Console.CursorVisible = false;
            Console.Clear();
        }

        void run()
        {
            running = true;

            while(running)
            {
                if(Input.keyPressed())
                {
                    //currentScene.inputHandler(Input.getInput());
                    currentScene.onKeyDown(Input.getInput());
                }

                if (changed)
                {
                    Output.addGraphic(currentWindow, new Vector2(0, 0));
                    Output.print();

                    changed = false;
                }
            }
        }

        private void windowChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void closeScene(object sender, EventArgs e)
        {
            if(sender == scenes.Peek())
            {
                Scene s = scenes.Pop();

                s.changed -= new MyFramework.EventHandler(windowChanged);
                s.closeScene -= new MyFramework.EventHandler(closeScene);

                Stack<Scene>.Enumerator en = scenes.GetEnumerator();

                if(en.MoveNext())
                {
                    currentScene = en.Current;
                    currentWindow = en.Current.window;
                }
                else
                {
                    running = false;
                }

                changed = true;
            }
        }

        private void addScene(object sender, Scene s)
        {
            scenes.Push(s);
            currentScene = s;
            currentWindow = s.window;

            s.changed += new EventHandler(windowChanged);
            s.closeScene += new EventHandler(closeScene);
            s.addScene += new SceneEventHandler(addScene);

            changed = true;
        }


        static void Main(string[] args)
        {
            Program program = new Program();
            program.run();
        }

    }
}
