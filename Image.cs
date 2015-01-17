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
        class Image
        {
            protected Char[,] image;
            protected Vector2 size;

            public Image(char[,] img)
            {
                image = img;
                setSize();
            }

            public Image(Vector2 size)
            {
                this.size = size;
                image = new Char[size.y, size.x];
            }

            public void add(Image content, Vector2 position)
            {
                for (int i = 0; i < content.getHeight(); i++)
                {
                    for (int j = 0; j < content.getWidth(); j++)
                    {
                        if (i + position.y < getHeight() && j + position.x < getWidth())
                        {
                            image[i + position.y, j + position.x] = content.getImage()[i, j];
                        }
                    }
                }
            }

            public void clear()
            {
                for (int i = 0; i < getHeight(); i++)
                {
                    for (int j = 0; j < getWidth(); j++)
                    {
                        image[i, j] = ' ';
                    }
                }
            }

            public void clear(Vector2 v1, Vector2 v2)
            {
                Vector2 pos1 = null;
                Vector2 pos2 = null;

                pos1 = new Vector2(CMath.min(v1.x, v2.x), CMath.min(v1.y, v2.y));
                pos2 = new Vector2(CMath.max(v1.x, v2.x), CMath.max(v1.y, v2.y));

                for (int i = pos1.y; i < pos2.y; i++)
                {
                    for (int j = pos1.x; j < pos2.x; j++)
                    {
                        if (i > 0 && i < size.y && j > 0 && j < size.x)
                        {
                            image[i, j] = ' ';
                        }
                    }
                }
            }

            public static Image fileToImage(string path)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(path);

                LinkedList<String> imageList = new LinkedList<string>();

                string line = reader.ReadLine();
                int maxWidth = 0;

                while (line != null)
                {
                    imageList.AddLast(line);

                    if (line.Length > maxWidth)
                    {
                        maxWidth = line.Length;
                    }

                    line = reader.ReadLine();
                }
                reader.Close();

                string[] imageLines = imageList.ToArray<string>();

                Char[,] img = new Char[imageLines.Length, maxWidth];

                for (int i = 0; i < imageLines.Length; i++)
                {
                    for (int j = 0; j < maxWidth; j++)
                    {
                        if (j < imageLines[i].Length)
                        {
                            img[i, j] = imageLines[i][j];
                        }
                    }
                }
                return new Image(img);
            }


            protected void setSize()
            {
                size = new Vector2(image.GetLength(1), image.GetLength(0));
            }

            public int getWidth()
            {
                return size.x;
            }

            public int getHeight()
            {
                return size.y;
            }

            public char[,] getImage()
            {
                return image;
            }

            public Image getCopy()
            {
                Image img = new Image(size);

                img.add(this, new Vector2(0, 0));
                return img;
            }
        }
    }
}
