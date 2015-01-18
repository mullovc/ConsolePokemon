using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.GUI;
using Game.Model;

namespace Game
{
    namespace View
    {
        namespace Data
        {
            class Data
            {
                private static Image[] pokemonFrontTextures = new Image[151];

                private static Image[] pokemonBackTextures = new Image[151];

                private static Image[] tileTextures = new Image[10];


                public static Image getPokemonFrontTexture(Pokemon pokemon)
                {
                    if (pokemonFrontTextures[pokemon.stats.index] == null)
                    {
                        pokemonFrontTextures[pokemon.stats.index] = 
                            Image.fileToImage("Textures\\Pokemon\\Front\\" + pokemon.getName() + ".txt");
                    }

                    return pokemonFrontTextures[pokemon.stats.index];
                }

                public static Image getPokemonBackTexture(Pokemon pokemon)
                {
                    if (pokemonBackTextures[pokemon.stats.index] == null)
                    {
                        pokemonBackTextures[pokemon.stats.index] =
                            Image.fileToImage("Textures\\Pokemon\\Back\\" + pokemon.getName() + ".txt");
                    }

                    return pokemonBackTextures[pokemon.stats.index];
                }

                public static Image getTileTexture(Tile.TileType type)
                {
                    if (tileTextures[(int)type] == null)
                    {
                        tileTextures[(int)type] = Image.fileToImage("Textures\\Tiles\\" + type.ToString() + ".txt");
                    }

                    return tileTextures[(int)type];
                }

            }
        }
    }
}
