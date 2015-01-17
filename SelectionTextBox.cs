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
        /**
         * TODO: create class that accepts any image as content,
         *       and let this class inherit from it.
         */
        class SelectionTextBox : GUIElement
        {
            public Cursor cursor { get; set; }
            public CursorPosition position { get; set; }
            public bool active { get; protected set; }

            public event EventHandler select;

            public enum CursorPosition
            {
                LEFT,
                RIGHT,
                ABOVE,
                BENEATH
            }


            public SelectionTextBox(String content, Vector2 size, CursorPosition position, Cursor.CursorType type)
                : base(size)
            {
                this.position = position;
                cursor = new Cursor(type);

                setUp(content);
            }

            void setUp(String content)
            {
                Vector2 textBoxSize = null;
                Vector2 pos = null;

                switch (position)
                {
                    case CursorPosition.LEFT:
                        textBoxSize = new Vector2(size.x - cursor.getWidth(), size.y);
                        pos = new Vector2(cursor.getWidth(), 0);
                        cursor.position = new Vector2(0, size.y / 2 - cursor.getHeight() / 2);
                        break;
                    //TODO: implement rest
                }

                //improve
                graphic.add(new TextBox(content, textBoxSize).getGraphic(), pos);
            }

            public override Image getGraphic()
            {
                Image img = graphic.getCopy();

                if (active)
                {
                    img.add(cursor.texture, cursor.position);
                }

                return img;
            }

            public void activate()
            {
                active = true;
            }

            public void deactivate()
            {
                active = false;
            }

            public void onSelect()
            {
                if (select != null)
                {
                    select(this, EventArgs.Empty);
                }
            }
        }
    }
}
