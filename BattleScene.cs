using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework;
using Game.Model;
using MyMath;
using Game.View;

namespace Game
{
    namespace Controller
    {
        class BattleScene : Scene
        {
            new BattleView window;

            Player player;
            Opponent opponent;

            Pokemon playerPokemon;
            Pokemon opponentPokemon;

            Model.Action playerAction;
            Model.Action opponentAction;

            public BattleScene(Player player, Opponent opponent)
                : base(new BattleView(player, opponent))
            {
                window = (BattleView)base.window;

                this.player = player;
                this.opponent = opponent;

                playerPokemon = player.getFighter();
                opponentPokemon = opponent.getFighter();

                initialize();
            }

            protected override void initialize()
            {
                KeyEventHandler handler = null;
                handler = delegate(object sender, string key)
                {
                    if(key == "Enter")
                    {
                        keyDown -= handler;
                        keyDown += chooseAction;
                        window.changeMessage("1: Kampf    2: Pokemon\n3: Beutel   4: Flucht");
                    }
                };

                keyDown += handler;

                //keyDown += new KeyEventHandler(chooseAction);
            }


            /*
             * TODO: do some output
             */
            /*
            public void battleLoop()
            {
                //Output.printBattleUI(secondFighter.getName() + " L" + secondFighter.level + " has engaged your " + firstFighter.getName() + " in battle!",
                //    firstFighter, secondFighter);

                //Input.get();

                //Output.printBattleUI("1: Kampf    2: Pokemon\n3: Beutel   4: Flucht", firstFighter, secondFighter);

                Model.Action firstAction = chooseAction(playerPokemon, opponentPokemon);
                //TODO: improve
                Model.Action secondAction = opponent.getRoundAction(opponentPokemon);

                takeTurn(playerPokemon, firstAction, opponentPokemon, secondAction);

                //Output.addText("The battle is over!");

                //Output.print();
                //Input.get();
            }
            */

            /**
             * returns whether the battle has ended
             */
            public static bool takeTurn(Pokemon firstPokemon, Model.Action firstAction, Pokemon secondPokemon, Model.Action secondAction)
            {
                if (firstAction.priority <= secondAction.priority)
                {

                    firstAction.takeAction(secondPokemon);

                    //Output.printBattleUI(firstAction.log, firstPokemon, secondPokemon);
                    //Input.get();

                    if (battleEnded(firstPokemon, secondPokemon))
                    {
                        return true;
                    }

                    secondAction.takeAction(firstPokemon);

                    //Output.printBattleUI(secondAction.log, firstPokemon, secondPokemon);
                    //Input.get();

                    if (battleEnded(secondPokemon, firstPokemon))
                    {
                        return true;
                    }

                    return false;
                }
                else
                {
                    return takeTurn(secondPokemon, secondAction, firstPokemon, firstAction);
                }
            }


            static bool battleEnded(Pokemon attacker, Pokemon defender)
            {
                if (defender.hp <= 0)
                {
                    //Output.printBattleUI(attacker.getName() + " has fainted!", attacker, defender);
                    //Input.get();

                    defender.faint();
                    attacker.win(defender);

                    return true;
                }
                else if (defender.primaryStatus == Pokemon.Status.Fainted)
                {
                    return true;
                }
                else if (attacker.secondaryStatus == Pokemon.Status.Fleeing)
                {
                    attacker.secondaryStatus = Pokemon.Status.None;
                    return true;
                }
                else
                {
                    return false;
                }
            }


            /*
            public void inputHandler(object sender, string key)
            {

            }*/

            /**
             * TODO: finish method
             */
            public void chooseAction(object sender, string key)
            {
                window.changeMessage("1: Kampf    2: Pokemon\n3: Beutel   4: Flucht");
                Model.Action action = null;

                int input = -1;

                do
                {
                    try
                    {
                        input = Convert.ToInt32(key);
                    }
                    catch
                    {
                        input = -1;
                    }

                    switch (input)
                    {
                        case 1:
                            keyDown -= new KeyEventHandler(chooseAction);
                            keyDown += new KeyEventHandler(chooseAttack);
                            //action = chooseAttack(playerPokemon);
                            //do output, choose move and create AttackAction
                            break;
                        case 2:
                            //do output, choose pokemon and create SwitchPokemonAction
                            break;
                        case 3:
                            //do output, choose item and create ItemAction
                            break;
                        case 4:
                            action = new FleeAction(playerPokemon);
                            //create flee action if possible
                            break;
                        default:
                            input = -1;
                            break;
                    }

                    if (action == null)
                    {
                        input = -1;
                    }
                }
                while (input == -1);
            }



            public void chooseAttack(object sender, string key)
            {
                String moveList = "";
                for (int i = 0; i < 4; i++)
                {
                    if (playerPokemon.moves[i] != null)
                    {
                        moveList += (i + 1) + ": " + playerPokemon.moves[i].name;

                        if (i == 1)
                        {
                            moveList += "\n";
                        }
                        else
                        {
                            moveList += " ";
                        }
                    }
                }

                window.changeMessage(moveList);

                //Output.addText(moveList);
                //Output.print();

                int input = -1;

                do
                {
                    try
                    {
                        input = Convert.ToInt32(Input.getInput()) - 1;
                    }
                    catch
                    {
                        input = -1;
                    }

                    if (input > 3 || input < 0 || playerPokemon.moves[input] == null)
                    {
                        input = -1;
                    }

                }
                while (input == -1);

                playerAction = new AttackAction(playerPokemon.moves[input], playerPokemon);
            }
        }
    }
}
