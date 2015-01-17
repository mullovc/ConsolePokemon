using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework
{
    /**
     * This is the Controller in the MVC-model. This class knows the current state of the 
     * programm and it's handleInput()-function(s) is(are) called once per game loop, to modify the
     * model, appropriately to the user input.
     * 
     * Questions: 
     * - In what form does this class know the current state of the programm?
     * - does it have one handleInput()-method for handling all the inputs, or
     *   does it have an appropriate method for every situation and state of the current programm?
     */
    abstract class InputHandler
    {

        abstract public void handleInput();

    }
}
