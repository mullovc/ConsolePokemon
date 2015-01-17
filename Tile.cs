using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    namespace Model
    {
        class Tile
        {
            public const int tileSize = 5;

            public TileType type;
            public TilePropery property;

            public enum TileType
            {
                Air = 0,
                Grass = 1,
                WallVert = 2,
                WallHoriz = 3,
                Healer = 4,
                Player = 5
            }

            public enum TilePropery
            {
                Solid,
                Water,
                None,
                EngageBattle,
                Heal
            }


            public Tile(TileType tileType)
            {
                type = tileType;
                property = getTileProperty(type);
            }


            public static TilePropery getTileProperty(TileType tile)
            {
                switch (tile)
                {
                    case TileType.Grass:
                        return TilePropery.EngageBattle;
                    case TileType.WallHoriz:
                        return TilePropery.Solid;
                    case TileType.WallVert:
                        return TilePropery.Solid;
                    case TileType.Healer:
                        return TilePropery.Heal;
                    default:
                        return TilePropery.None;
                }
            }
        }
    }
}
