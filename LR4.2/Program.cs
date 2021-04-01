using System;
using System.Runtime.InteropServices;

namespace LR4._2
{
    class Program
    {
        [DllImport("MyLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int add(int a, int b);
        [DllImport("MyLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int substract(int a, int b);
        [DllImport("MyLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int multiply(int a, int b);
        [DllImport("MyLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int divide(int a, int b);

        static void Main(string[] args)
        {
            Console.WriteLine(add(4, 3));
            Console.WriteLine(substract(5, 7));
            Console.WriteLine(multiply(2, 3));
            Console.WriteLine(divide(4, 6));
        }
    }
}
