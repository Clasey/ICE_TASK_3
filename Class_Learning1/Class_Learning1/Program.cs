using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Learning1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<int, string> numberNames = new Dictionary<int, string>();
            numberNames.Add(1, "One");
            numberNames.Add(3, "Two");
            numberNames.Add(2, "Three");

            foreach (KeyValuePair<int, string> kvp in numberNames)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);

            var cities = new Dictionary<string, string>()
            {
                {"UK", "London, Manchester, Birmingham" },
                {"USA", "Chicago, New York, Washington" },
                {"India", "Mumbai, New Delhi, Pune" }
            };

            foreach (var kvp in cities)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            Console.ReadLine();

            /*
            Queue<string> strQ = new Queue<string>();
            strQ.Enqueue("Rodney");
            strQ.Enqueue("Joy");
            strQ.Enqueue("Robert");
            strQ.Enqueue("Lewis");
            strQ.Enqueue("Stack");
            strQ.Enqueue("May");

            Console.WriteLine("Total elements: {0}", strQ.Count);

            while (strQ.Count > 0)
                Console.WriteLine(strQ.Dequeue());

            Console.WriteLine("Total elements: {0}", strQ.Count);
            Console.ReadLine();
            /*
            Stack<int> numbers = new Stack<int>();
            numbers.Push(1);
            numbers.Push(2);
            numbers.Push(3);
            numbers.Push(4);

            foreach (var item in numbers)
                Console.Write(item + ",");
            

            Stack<string> cities = new Stack<string>();
            cities.Push("Johannesburg");
            cities.Push("Pretoria");
            cities.Push("Bloemfontein");
            cities.Push("Cape Town");
            cities.Push("Nelpruit");
            cities.Push("Burgersfort");
            cities.Push("Port Elizabeth");
            cities.Push("East London");

            foreach (var item in cities)
                Console.Write(item + ",");
            Console.ReadLine(); 


            int[] arr = new int[] { 1, 2, 3, 4 };
            Stack<int> myStack = new Stack<int>(arr);

            foreach (var itm in myStack)
                Console.Write(itm + ",");
            Console.ReadLine();
            */
        }

    }
}
