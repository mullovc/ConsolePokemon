using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework
{
    class Input
    {
        public static string getInput()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            string input = key.Key.ToString();

            input = getNumberInput(input);

            return input;
        }

        public static bool keyPressed()
        {
            return Console.KeyAvailable;
        }


        static string getNumberInput(string input)
        {
            switch (input)
            {
                case "D1":
                    return "1";
                case "D2":
                    return "2";
                case "D3":
                    return "3";
                case "D4":
                    return "4";
                case "D5":
                    return "5";
                case "D6":
                    return "6";
                case "D7":
                    return "7";
                case "D8":
                    return "8";
                case "D9":
                    return "9";
                case "D0":
                    return "0";
                default:
                    return input;
            }
        }


        public static void get()
        {
            Console.ReadKey();
        }
    }
}
