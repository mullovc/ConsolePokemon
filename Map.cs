using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMath;
using MyFramework;

namespace Game
{
    namespace Model
    {
        class Map
        {
            public Tile[,] map;

            public Map(string name)
            {
                map = worldGen("Data\\Maps\\" + name + ".txt");
            }

            /**
             * TODO: move this to database
             */
            public static Tile[,] worldGen(string path)
            {
                Tile[,] map = new Tile[100, 100];
                System.IO.StreamReader mapReader = new System.IO.StreamReader(path);

                string line;
                int i = 0;

                while ((line = mapReader.ReadLine()) != null)
                {

                    for (int j = 0; j < 100; j++)
                    {
                        try
                        {
                            map[j, i] = new Tile((Tile.TileType)Convert.ToInt32(line[j].ToString()));
                        }
                        catch
                        {
                            break;
                        }
                    }
                    i++;
                }
                mapReader.Close();

                return map;
            }

            public Tile getTile(Vector2 position)
            {
                if (position.x >= 0 && position.x < getWidth() && position.y >= 0 && position.y < getHeight())
                {
                    return map[position.x, position.y];
                }
                else
                {
                    return null;
                }
            }


            public Tile.TilePropery getProperty(Vector2 tile)
            {
                if (tile.x >= 0 && tile.x < getWidth() && tile.y >= 0 && tile.y < getHeight())
                {
                    if (map[tile.x, tile.y] != null)
                    {
                        return map[tile.x, tile.y].property;
                    }
                    else
                    {
                        return Tile.TilePropery.None;
                    }
                }
                else
                {
                    return Tile.TilePropery.None;
                }
            }

            public int getHeight()
            {
                return map.GetLength(0);
            }

            public int getWidth()
            {
                return map.GetLength(1);
            }
        }
    }
}
