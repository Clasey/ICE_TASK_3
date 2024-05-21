using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        Func<int, bool> isEven = num => num % 2 == 0;

        var evenNumbers = numbers.Where(isEven);
        
        foreach(var number in evenNumbers)
        {
            Console.WriteLine(number);
        }
        Console.ReadLine();

        Func<int, int, int> add = (x, y) => x + y;

        int result = add(3, 5);
        Console.WriteLine(result);
        Console.ReadLine();

        Func<int, int, int> multiply = (int x, int y) => x * y;

        Func<int, int, int> subtract = (x, y) =>
        {
            return x - y;
        }

        /*
        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double sum = AddNumbers(num1, num2);
        Console.WriteLine($"Sum of {num1} and {num2} is: {sum}");

        double product = MultiplyNumbers(num1, num2);
        Console.WriteLine($"Product of {num1} and {num2} is: {product}");

        Console.ReadLine(); */
    }

    /*
    static double AddNumbers(double num1, double num2)
    {
        return num1 + num2;
    }

    static double MultiplyNumbers(double num1, double num2)
    {
        return num1 * num2;
    }
    */
}
