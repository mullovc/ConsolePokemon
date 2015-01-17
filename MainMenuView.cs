using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMath;
using MyFramework;
using MyFramework.GUI;

namespace Game
{
    namespace View
    {
        class MainMenuView : Window
        {
            public SelectionTextBox[] menuSelections { get; set; }


            public MainMenuView(Vector2 size)
                : base(size)
            {
                initialize();
            }

            protected override void initialize()
            {
                menuSelections = new SelectionTextBox[3];

                menuSelections[0] = new SelectionTextBox("Continue", new Vector2(50, 7),
                    SelectionTextBox.CursorPosition.LEFT, Cursor.CursorType.ARROW);
                menuSelections[1] = new SelectionTextBox("New Game", new Vector2(50, 7),
                    SelectionTextBox.CursorPosition.LEFT, Cursor.CursorType.ARROW);
                menuSelections[2] = new SelectionTextBox("Quit", new Vector2(50, 7),
                    SelectionTextBox.CursorPosition.LEFT, Cursor.CursorType.ARROW);

                addElement(menuSelections[0], new Vector2(1, 1));
                addElement(menuSelections[1], new Vector2(1, 9));
                addElement(menuSelections[2], new Vector2(1, 17));
            }

        }
    }
}
