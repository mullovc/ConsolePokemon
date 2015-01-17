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
        class Cursor
        {
            public Image texture { get; private set; }
            public Vector2 position { get; set; }

            public enum CursorType
            {
                SQUARE = 0,
                TRIANGLE = 1,
                ARROW = 2
            }

            public Cursor(CursorType type)
            {
                texture = Image.fileToImage("Textures\\Cursor\\" + (int)type + ".txt");
            }

            public void move(Vector2 direction)
            {
                position.add(direction);
            }

            public void moveTo(Vector2 pos)
            {
                position = pos;
            }

            public int getWidth()
            {
                return texture.getWidth();
            }
            public int getHeight()
            {
                return texture.getHeight();
            }

            public Vector2 getSize()
            {
                return new Vector2(texture.getWidth(), texture.getHeight());
            }
        }
    }
}
