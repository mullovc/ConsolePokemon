using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework;
using MyFramework.GUI;
using Game.Controller;

namespace Game
{
    class Game
    {
        public static void Main()
        {
            Program program = new Program();
            program.run(new MainMenuScene());
        }
    }
}
