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

            string[] realOperators = { "+", "-", "*", "/", "%" };

            bool isReal;



            Console.WriteLine("Welcome to the JS-Calc 3000, believed to be the most powerful calculator in the world!");

            Console.WriteLine("Enter the first number, followed by an arithmetic operator, then the second number. Finish with ENTER. \nIllegal operators will return zero. To quit, press ESCAPE.");
            Console.WriteLine();

            do
            {
                //Continuous loop, until Escape is pressed

                List<string> firstNum = new List<string>();
                List<string> secondNum = new List<string>();
                string[] equation = new string[3];






                do
                {
                    //Input first value, by entering keys until pressing a non-number
                    keyPressed = Console.ReadKey(true);
                    realKey = keyPressed.KeyChar.ToString();

                    if (keyPressed.Key == ConsoleKey.Escape)        //Checks if you pressed Escape
                    { AutoQuit(); }

                    isReal = false;               //Resets the bool

                    for (int i = 0; i < 10; i++)        //Checks if the input is on the list of legitimate numbers; if so, flags it as true
                    {
                        if (realKey == realNrs[i])
                        { isReal = true; }
                    }

                    if (isReal)
                    { firstNum.Add(realKey); }   //Adds the pressed key to the firstNum list


                } while (isReal);

                equation[0] = String.Join(String.Empty, firstNum);   //Adds the first number to the equation
                Console.Write($"{equation[0]} ");







                isReal = false;
                for (int i = 0; i < realOperators.Length; i++)        //Checks if the input is on the list of legitimate operators; if so, flags it as true
                {
                    if (realKey == realOperators[i])
                    { isReal = true; }
                }

                if (isReal)
                { equation[1] = realKey; }     //Adds the operator, if legit

                Console.Write($"{realKey} ");




                do
                {
                    //Input first value, by entering keys until pressing Enter
                    keyPressed = Console.ReadKey(true);
                    realKey = keyPressed.KeyChar.ToString();

                    if (keyPressed.Key == ConsoleKey.Escape)        //Checks if you pressed Escape
                    { AutoQuit(); }

                    isReal = false;               //Resets the bool

                    for (int i = 0; i < 10; i++)        //Checks if the input is on the list of legitimate numbers; if so, flags it as true
                    {
                        if (realKey == realNrs[i])
                        {                            isReal = true;                        }
                    }

                    if (isReal)
                    { secondNum.Add(realKey); }   //Adds the pressed key to the firstNum list
                    
                } while (isReal);

                equation[2] = String.Join(String.Empty, secondNum);   //Adds the second number to the equation

                Console.Write($"{equation[2]} = ");



                double result = CompleteEquation(equation);

                Console.WriteLine($"{result}");

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
            Console.WriteLine();
            Console.WriteLine("The calculator will now shut down.");
            Console.ReadLine();
            Environment.Exit(0);
        }


    }
}
