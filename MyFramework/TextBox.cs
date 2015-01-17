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
        class TextBox : GUIElement
        {

            public TextBox(string content, Vector2 size)
                : base(size)
            {
                Vector2 cursor = new Vector2(0, 0);
                int maxCharHeight = 0;

                for (int i = 0; i < content.Length; i++)
                {

                    if (content[i] == '\n')
                    {
                        cursor.y += maxCharHeight + 1;
                        maxCharHeight = 0;
                        cursor.x = 0;

                        continue;
                    }

                    Graphic character = ASCII.charToImage(content[i]);
                    maxCharHeight = (character.getHeight() > maxCharHeight ? character.getHeight() : maxCharHeight);

                    if (cursor.x + character.getWidth() > getWidth())
                    {
                        cursor.y += maxCharHeight + 1;
                        maxCharHeight = 0;
                        cursor.x = 0;
                    }

                    add(character, cursor);

                    cursor.x += character.getWidth() + 1;
                }
            }

            protected TextBox(Vector2 size)
                : base(size)
            {

            }


        }
    }
}
