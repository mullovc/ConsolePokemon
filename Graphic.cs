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
        class Graphic : GUIElement
        {
            public Graphic(Vector2 size)
                : base(size)
            {

            }

            public Graphic(Image image)
                : base(image)
            {

            }
        }
    }
}
