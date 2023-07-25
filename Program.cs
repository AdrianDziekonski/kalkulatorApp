using System;

namespace Kalkulator
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kalkulator konsolowy");
            while (true)
            {

                try
                {
                    
                    Console.WriteLine("Wprowadź liczbę");
                    var number1 = GetInput();

                    Console.WriteLine("Wprowadź działanie '+' '-' '*' '/' '^n' 'PIERWIASTEK' '%' 'N' 'B'");
                    var operation = Console.ReadLine();

                    if (operation == "^n")
                        Console.WriteLine("Wprowadź wykładnik potęgi");

                    else if (operation == "PIERWIASTEK")
                        Console.WriteLine("Wprowadź stopień pierwiastkowania");

                    else if (operation == "%") 
                        Console.WriteLine("Jakim % podanej liczby jest kolejna liczba. Wprowadź kolejną liczbę");

                    else if(operation=="N"||operation=="B")
                        Console.WriteLine("Wprowadź stawkę procentową podatku");
                     

                    else Console.WriteLine("Wprowadź kolejną liczbę");
                    var number2 = GetInput();


                    var result = Calculate(number1, number2, operation);


                    Console.WriteLine($"Wynik działania to: {Math.Round(result, 2)}");
                }


                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        private static double GetInput()
        {
            if (!double.TryParse(Console.ReadLine(), out double input))
                throw new Exception("Podana wartość nie jest liczbą");

            return input;
        }
        private static double Calculate(double number1, double number2, string operation)
        {   switch (operation)
            {
                case "+":
                    return number1 + number2;
                case "-":
                   return number1 - number2;
                case "*":
                    return number1 * number2;
                case "/":
                    if (number2 == 0)
                        throw new Exception("Nie dzieli się przez 0");
                    return number1 / number2;
                case "^n":
                    return Math.Pow(number1, number2);
                case "PIERWIASTEK.":
                    return Math.Pow(number1,1/number2);
                case "%":
                    return (number2 / number1) * 100;
                case "N":
                    return number1 / (1 + number2 / 100);
                case "B":
                    return number1 * (1+number2/100);
                default:
                    throw new Exception("Wybrana zła operacja");
            }
        }


    }
}


