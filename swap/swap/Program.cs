using System;

namespace swap
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10; int b = 20;
            int c = a; //c=10
             a = b; //a=20
             b = c; //b=10
            Console.WriteLine("a:"+ a);
            Console.WriteLine();
            Console.WriteLine("b:"+b);
        }
    }
}