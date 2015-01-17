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
        /*
         * TODO: add changeText method
         */
        class TextBox : GUIElement
        {

            public TextBox(string content, Vector2 size)
                : base(size)
            {
                changeText(content);
            }

            protected TextBox(Vector2 size)
                : base(size)
            {

            }

            public virtual void changeText(string content)
            {
                graphic.clear();

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

                    Image character = ASCII.charToImage(content[i]);
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

            public virtual void changeText(string content, Vector2 pos)
            {
                graphic.clear();

                Vector2 cursor = pos;
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

                    Image character = ASCII.charToImage(content[i]);
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
        }
    }
}
