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
            protected Graphic graphic;

            public bool visible { get; protected set; }

            public GUIElement(Vector2 size)
            {
                this.size = size;
                graphic = new Graphic(size);
                visible = true;
            }

            public GUIElement(Graphic image)
            {
                graphic = image;
                visible = true;
            }
            public void add(Graphic content, Vector2 position)
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

            public virtual Graphic getGraphic()
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
