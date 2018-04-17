using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS_Advanced_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleKeyInfo keyPressed;


            Console.WriteLine("Welcome to the JS-Calc 3000, believed to be the most powerful calculator in the world!");
            Console.WriteLine("To perform a calculation, simply enter the first number followed by ENTER, then an arithmetic operator, then the second number, followed by ENTER. To quit, press ESCAPE. We take no responsibility for the consequences of deviating from these instructions.");

            do
            {
                //Continuous loop, until Escape is pressed

                List<string> firstNum = new List<string>();
                List<string> secondNum = new List<string>();
                Dictionary<int, string> equation = new Dictionary<int, string>();








                do
                {
                    //Input first value, by entering keys until pressing Enter
                    keyPressed = Console.ReadKey(true);

                    if (keyPressed.Key == ConsoleKey.Escape)
                    { AutoQuit(); }
                    else if (keyPressed.Key != ConsoleKey.Enter)
                    {
                        firstNum.Add(keyPressed.KeyChar.ToString());     //Adds the pressed key to the firstNum list
                    }

                } while (keyPressed.Key != ConsoleKey.Enter);

                equation.Add(1, String.Join(String.Empty, firstNum));   //Adds the first number to the equation

                Console.WriteLine(equation[1]);







                keyPressed = Console.ReadKey(true);
                if (keyPressed.Key != ConsoleKey.Escape)
                { AutoQuit(); }
                else
                { equation.Add(2, keyPressed.KeyChar.ToString()); }     //Adds the operator





                do
                {
                    //Input first value, by entering keys until pressing Enter
                    keyPressed = Console.ReadKey(true);

                    if (keyPressed.Key == ConsoleKey.Escape)
                    { AutoQuit(); }
                    else if (keyPressed.Key != ConsoleKey.Enter)
                    {
                        secondNum.Add(keyPressed.KeyChar.ToString());     //Adds the pressed key to the secondNum list
                    }

                } while (keyPressed.Key != ConsoleKey.Enter);

                equation.Add(3, String.Join(String.Empty, secondNum));   //Adds the second number to the equation



                double result = CompleteEquation(equation);

                Console.WriteLine($"Result: {result}");

            } while (keyPressed.Key != ConsoleKey.Escape);




            Console.ReadLine();
        }

        static double CompleteEquation(Dictionary<int, string> equation)         //This takes an equation and produces the result
        {
            return 5;
        }

        static void AutoQuit()
        {
            Console.WriteLine("The calculator will now shut down.");
            Console.ReadLine();
            Environment.Exit(0);
        }


    }
}
