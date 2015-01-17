using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework;
using MyFramework.GUI;
using MyMath;
using Game.Model;

namespace Game
{
    namespace View
    {
        class WorldView : Window
        {
            Graphic fov;


            Map map;
            Player player;

            public WorldView(Player player, Map map)
                : base(Config.windowSize)
            {
                initialize();

                this.player = player;
                this.map = map;
            }

            protected override void initialize()
            {
                fov = new Graphic(size);

                addElement(fov, new Vector2(0, 0));
            }

            /*
            public static Image getFieldOfView(int X, int Y, Map map, int displayWidth, int displayHeight)
            {
                int horizTileCount = displayWidth / Tile.tileSize;
                int vertTileCount = displayHeight / Tile.tileSize;

                Image fov = new Image(new Vector2(displayWidth, displayHeight));

                for (int i = 0; i < vertTileCount; i++)
                {
                    for (int j = 0; j < horizTileCount; j++)
                    {
                        if (j == horizTileCount / 2 && i == vertTileCount / 2)
                        {
                            fov.add(Data.Data.getTileTexture(Tile.TileType.Player), new Vector2(displayWidth / 2, displayHeight / 2));
                        }
                        else
                        {
                            Tile tile = map.getTile(new Vector2(X - horizTileCount / 2 + j, Y - vertTileCount / 2 + i));

                            if(tile != null)
                            {
                                fov.add(Data.Data.getTileTexture(tile.type), new Vector2(j * Tile.tileSize, i * Tile.tileSize));
                            }
                            else
                            {
                                fov.add(Data.Data.getTileTexture(Tile.TileType.Air), new Vector2(j * Tile.tileSize, i * Tile.tileSize));
                            }
                            //fieldOfView.add(map.getTexture(new Vector2(X - horizTileCount / 2 + j, Y - vertTileCount / 2 + i)),
                            //    new Vector2(j * Tile.tileSize, i * Tile.tileSize));
                        }
                    }
                }

                return fov;
            }
            */

            

            public override void render()
            {
                int horizTileCount = getWidth() / Tile.tileSize;
                int vertTileCount = getHeight() / Tile.tileSize;

                int X = player.position.x;
                int Y = player.position.y;

                for (int i = 0; i < vertTileCount; i++)
                {
                    for (int j = 0; j < horizTileCount; j++)
                    {
                        if (j == horizTileCount / 2 && i == vertTileCount / 2)
                        {
                            fov.add(Data.Data.getTileTexture(Tile.TileType.Player), new Vector2(getWidth() / 2, getHeight() / 2));
                        }
                        else
                        {
                            Tile tile = map.getTile(new Vector2(X - horizTileCount / 2 + j, Y - vertTileCount / 2 + i));

                            if (tile != null)
                            {
                                fov.add(Data.Data.getTileTexture(tile.type), new Vector2(j * Tile.tileSize, i * Tile.tileSize));
                            }
                            else
                            {
                                fov.add(Data.Data.getTileTexture(Tile.TileType.Air), new Vector2(j * Tile.tileSize, i * Tile.tileSize));
                            }
                        }
                    }
                }

                base.render();
            }
        }
    }
}
