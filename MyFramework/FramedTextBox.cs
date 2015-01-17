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
        class FramedTextBox : TextBox
        {
            public FramedTextBox(String content, Vector2 size)
                : base(size)
            {
                add(new TextBox(content, new Vector2(size.x - 4, size.y - 4)).getGraphic(), new Vector2(2, 2));

                for (int i = 1; i < size.x - 1; i++)
                {
                    graphic.getImage()[0, i] = '_';
                    graphic.getImage()[size.y - 1, i] = '_';
                    //image[0, i] = '_';
                    //image[size.y - 1, i] = '_';
                }

                for (int i = 1; i < size.y; i++)
                {
                    graphic.getImage()[i, 0] = '|';
                    graphic.getImage()[i, size.x - 1] = '|';
                    //image[i, 0] = '|';
                    //image[i, size.x - 1] = '|';
                }
            }
        }
    }
}
