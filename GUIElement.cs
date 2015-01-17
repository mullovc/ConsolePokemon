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
        abstract class GUIElement
        {
            protected Vector2 size;
            protected Image graphic;

            public bool visible { get; protected set; }

            public GUIElement(Vector2 size)
            {
                this.size = size;
                graphic = new Image(size);
                visible = true;
            }

            public GUIElement(Image image)
            {
                graphic = image;
                visible = true;
            }
            public void add(Image content, Vector2 position)
            {
                graphic.add(content, position);
            }

            public int getWidth()
            {
                return size.x;
            }
            public int getHeight()
            {
                return size.y;
            }

            public virtual Image getGraphic()
            {
                return graphic;
            }

            public void show()
            {
                visible = true;
            }

            public void hide()
            {
                visible = false;
            }
        }
    }
}
