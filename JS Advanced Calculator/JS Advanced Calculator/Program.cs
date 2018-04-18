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

            string realKey;

            string[] realNrs = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };        //Real numbers that can be used

            bool isRealNumber;



            Console.WriteLine("Welcome to the JS-Calc 3000, believed to be the most powerful calculator in the world!");
            Console.WriteLine("To perform a calculation, simply enter the first number followed by ENTER, then an arithmetic operator, then the second number, followed by ENTER. To quit, press ESCAPE. We take no responsibility for the consequences of deviating from these instructions.");

            do
            {
                //Continuous loop, until Escape is pressed

                List<string> firstNum = new List<string>();
                List<string> secondNum = new List<string>();
                string[] equation = new string[3];


                //if(realKey == ("0", "1", "2"...)




                do
                {
                    //Input first value, by entering keys until pressing Enter
                    keyPressed = Console.ReadKey(true);
                    realKey = keyPressed.KeyChar.ToString();

                    if (keyPressed.Key == ConsoleKey.Escape)        //Checks if you pressed Escape
                    { AutoQuit(); }

                    isRealNumber = false;               //Resets the bool


                    for (int i = 0; i < 10; i++)        //Checks if the input is on the list of legitimate numbers; if so, flags it as true
                    {
                        if (realKey == realNrs[i])
                        {
                            isRealNumber = true;
                        }
                    }

                    if (isRealNumber)
                    {
                        firstNum.Add(realKey);     //Adds the pressed key to the firstNum list
                    }




                } while (isRealNumber);

                equation[0] = String.Join(String.Empty, firstNum);   //Adds the first number to the equation

                Console.WriteLine(equation[1]);







                keyPressed = Console.ReadKey(true);
                if (keyPressed.Key != ConsoleKey.Escape)
                { AutoQuit(); }
                else
                { equation[1] = keyPressed.KeyChar.ToString(); }     //Adds the operator





                do
                {
                    //Input first value, by entering keys until pressing Enter
                    keyPressed = Console.ReadKey(true);
                    realKey = keyPressed.KeyChar.ToString();

                    if (keyPressed.Key == ConsoleKey.Escape)
                    { AutoQuit(); }
                    else if (keyPressed.Key != ConsoleKey.Enter)
                    {
                        secondNum.Add(keyPressed.KeyChar.ToString());     //Adds the pressed key to the secondNum list
                    }

                } while (keyPressed.Key != ConsoleKey.Enter);

                equation[2] = String.Join(String.Empty, secondNum);   //Adds the second number to the equation



                double result = CompleteEquation(equation);

                Console.WriteLine($"Result: {result}");

            } while (keyPressed.Key != ConsoleKey.Escape);




            Console.ReadLine();
        }

        static double CompleteEquation(string[] equation)         //This takes an equation and produces the result
        {
            bool firstLegit = true;     //Tracks whether first input is legitimate or not.
            bool secondLegit = true;
            double firstNum;
            double secondNum;
            double result;


            firstLegit = double.TryParse(equation[0], out firstNum);        //Converts the inputs to doubles, if legitimate
            secondLegit = double.TryParse(equation[2], out secondNum);

            switch (equation[1])
            {
                case "+":
                    result = firstNum + secondNum;
                    break;
                case "-":
                    result = firstNum - secondNum;
                    break;
                case "*":
                    result = firstNum * secondNum;
                    break;
                case "/":
                    result = firstNum / secondNum;
                    break;
                case "%":
                    result = firstNum % secondNum;
                    break;

                default:
                    result = 0;
                    break;
            }

            return result;
        }
        static void AutoQuit()
        {
            Console.WriteLine("The calculator will now shut down.");
            Console.ReadLine();
            Environment.Exit(0);
        }


    }
}
