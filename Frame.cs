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
        class Frame : GUIElement
        {
            protected int frameWidth;
            protected int frameHeight;

            public Frame(Vector2 size)
                : base(size)
            {
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

                frameHeight = 1;
                frameWidth = 1;
            }
        }
    }
}
