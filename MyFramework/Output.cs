using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework;
using MyFramework.GUI;
using MyMath;

namespace MyFramework
{
    class Output
    {
        public static Display display;


        public static void addGraphic(Graphic img, Vector2 pos)
        {
            display.add(img, pos);
        }

        public static void addGraphic(GUIElement gui, Vector2 pos)
        {
            display.add(gui.getGraphic(), pos);
        }

        public static void addGraphic(Graphic img)
        {
            display.add(img, new Vector2(0, 0));
        }


        public static void addText(string text)
        {
            FramedTextBox textBox =
                new FramedTextBox(text, new Vector2(Config.windowSize.x - 1, 17));
            addGraphic(textBox, new Vector2(0, Config.windowSize.x - 18));
        }

        public static void clear()
        {
            display.clear();
        }

        public static void print()
        {
            display.print();
        }
    }
}
