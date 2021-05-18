using System;

namespace LR7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var a = new RationalNumber(15, 0);
                var b = new RationalNumber(7, 14);
                Console.WriteLine(a);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Console.WriteLine(RationalNumber.GetNOD(37542, 56820));
            //var c = a - b;
            //Console.WriteLine((--a).ToString());
            //int n = (int)a;
            //int n = (int)a;
            
        }
    }
}
