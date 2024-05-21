using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// delegate int NumberChanger(int n);

namespace Class_Practice
{
    public delegate void DelEventHandler();

    class Program
    {
        public static event DelEventHandler add;

        static void Main(string[] args)
        {
            add += new DelEventHandler(USA);
            add += new DelEventHandler(India);
            add += new DelEventHandler(England);
            add.Invoke();

            Console.ReadLine();
        }
    }
}
    /*
    class Program
    {
        static int num = 0;

        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
        public static int getNum()
        {
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        static void Main(string[] args)
        {
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);

            nc1(25);
            Console.WriteLine("Value of Num: {0}", getNum());
            nc2(5);
            Console.WriteLine("Value of Num: {0}", getNum());
            Console.ReadLine();
        }*/

