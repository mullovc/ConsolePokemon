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
        class FramedTextBox : Frame
        {
            TextBox text;

            public FramedTextBox(String content, Vector2 size)
                : base(size)
            {
                text = new TextBox(content, 
                    Vector2.add(size, new Vector2(-(frameWidth * 2 + 2), -(frameHeight * 2 + 2))));
            }

            public void changeText(string content)
            {
                text.changeText(content);
            }

            public override Image getGraphic()
            {
                Image img = graphic.getCopy();
                img.add(text.getGraphic(), new Vector2(frameWidth + 1, frameHeight + 1));

                return img;
            }
        }
    }
}
