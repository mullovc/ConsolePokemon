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
        abstract class Window : GUIElement
        {
            protected List<WindowElement> elements;

            public event EventHandler changed;

            public Window(Vector2 size)
                : base(size)
            {
                elements = new List<WindowElement>();
            }

            abstract protected void initialize();

            public void addElement(GUIElement element, Vector2 pos)
            {
                elements.Add(new WindowElement(element, pos));

                onChanged(EventArgs.Empty);
            }

            public void addElement(GUIElement element, Vector2 pos, int priority)
            {
                IEnumerator<WindowElement> en = elements.GetEnumerator();

                en.MoveNext();
                int cursor = 0;

                while(en.Current != null)
                {
                    if(priority < en.Current.priority)
                    {
                        break;
                    }

                    en.MoveNext();
                    cursor++;
                }
                elements.Insert(cursor, new WindowElement(element, pos));

                onChanged(EventArgs.Empty);
            }

            /**
             * tells listeners that the window has changed
             */
            protected void onChanged(EventArgs e)
            {
                if (changed != null)
                {
                    changed(this, EventArgs.Empty);
                }
            }

            public override Graphic getGraphic()
            {
                Graphic screen = new Graphic(size);

                IEnumerator<WindowElement> en = elements.GetEnumerator();

                en.MoveNext();
                while (en.Current != null)
                {
                    if (en.Current.gui.visible)
                    {
                        screen.add(en.Current.gui.getGraphic(), en.Current.windowPosition);
                        en.MoveNext();
                    }
                }

                return screen;
            }
        }
    }
}
