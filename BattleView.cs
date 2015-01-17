using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.GUI;
using MyFramework;
using MyMath;
using Game.Model;
using Game.View.Data;

namespace Game
{
    namespace View
    {
        class BattleView : Window
        {
            Player player;
            Opponent opponent;

            Pokemon playerPokemon;
            Pokemon opponentPokemon;

            Graphic opponentPokemonImage;
            Graphic playerPokemonImage;

            FramedTextBox opponentStats;
            FramedTextBox playerStats;

            FramedTextBox message;

            public BattleView(Player player, Opponent opponent)
                : base(Config.windowSize)
            {
                this.player = player;
                this.opponent = opponent;

                playerPokemon = player.getFighter();
                opponentPokemon = opponent.getFighter();

                initialize();
            }

            protected override void initialize()
            {
                message = new FramedTextBox("Ein wildes ... ist aufgetaucht", new Vector2(Config.windowSize.x - 2, 17));

                opponentPokemonImage = new Graphic(Data.Data.getPokemonFrontTexture(opponentPokemon));
                playerPokemonImage = new Graphic(Data.Data.getPokemonBackTexture(playerPokemon));

                playerStats = new FramedTextBox(playerPokemon.getName() + " L" + playerPokemon.level + "\n" + playerPokemon.hp 
                    + "/" + playerPokemon.maxHp + " " + (playerPokemon.xp - playerPokemon.getXpForLvlUp(playerPokemon.level)) + "/" +
                    (playerPokemon.getXpForLvlUp(playerPokemon.level + 1) - playerPokemon.getXpForLvlUp(playerPokemon.level)),
                    new Vector2(80, 17));

                opponentStats = new FramedTextBox(opponentPokemon.getName() + " L" + opponentPokemon.level 
                    + "\n" + opponentPokemon.hp + "/" + opponentPokemon.maxHp, new Vector2(80, 17));


                addElement(message, new Vector2(0, Config.windowSize.y - 17));

                addElement(opponentStats, new Vector2(1, 1));
                addElement(playerStats, new Vector2(Config.windowSize.x - 81, Config.windowSize.y - 35));
                
                addElement(playerPokemonImage, new Vector2(1, 24));
                addElement(opponentPokemonImage, new Vector2(100, 1));
            }

            public void changeMessage(string content)
            {
                message.changeText(content);
                onChanged(EventArgs.Empty);
            }

        }
    }
}
