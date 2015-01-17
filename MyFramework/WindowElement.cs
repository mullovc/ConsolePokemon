using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMath;

namespace MyFramework
{
    namespace GUI
    {
        class WindowElement
        {
            public Vector2 windowPosition { get; set; }
            public int priority { get; set; }
            public GUIElement gui { get; set; }

            public WindowElement(GUIElement el, Vector2 pos)
            {
                gui = el;
                windowPosition = pos;
                priority = 0;
            }

            public WindowElement(GUIElement el, Vector2 pos, int priority)
            {
                gui = el;
                windowPosition = pos;
                this.priority = priority;
            }
        }
    }
}
