using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMath;
using MyFramework.GUI;

namespace MyFramework
{
    class Display : Graphic
    {

        public Display(Vector2 size) 
            : base(size)
        {

        }

        public void print()
        {
            char[] output = new char[size.x * size.y + size.y];

            for (int i = 0; i < getHeight(); i++)
            {
                for (int j = 0; j < getWidth(); j++)
                {
                    output[i * size.x + j + i] = image[i, j];
                }
                output[(i + 1) * size.x + i] = '\n';
            }

            Console.Clear();
            Console.Write(output);
        }
    }
}
