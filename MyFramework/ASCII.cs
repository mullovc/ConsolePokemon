using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework
{
    namespace GUI
    {
        class ASCII
        {
            static Graphic[] ascii = new Graphic[128];

            public static Graphic charToImage(char c)
            {
                int i = (int)c;

                if (ascii[i] == null)
                {
                    ascii[i] = Graphic.fileToImage("ASCII\\" + i + ".txt");
                }

                return ascii[i];
            }

        }
    }
}
