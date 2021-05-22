using System;

namespace LR7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var a = new RationalNumber(15, 2);
                var b = new RationalNumber(7, 14);
                Console.WriteLine(a);
                //var c = a - b;
                Console.WriteLine((--a).ToString());
                int n = (int)a;
                double m = (double)a;
                Console.WriteLine($"{n}; {m}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
