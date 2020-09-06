using System;
using moriyaki.fraction;

namespace FractionTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            var a = new Fraction(5, 4);
            var b = new Fraction(2, 3);

            FractionOperationTest(a, b);
            FractionIntOperationTest(a, 2);
            FractionIntOperationTest(b, 3);
        }

        public static void FractionOperationTest(Fraction a, Fraction b)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("FractionOperation");
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("");
            Console.WriteLine("-a = " + -a);
            Console.WriteLine("a+b = " + (a + b));
            Console.WriteLine("a-b = " + (a - b));
            Console.WriteLine("a*b = " + (a * b));
            Console.WriteLine("a/b = " + (a / b));
        }

        public static void FractionIntOperationTest(Fraction a, int b)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("FractionIntOperation");
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("");
            Console.WriteLine("-a = " + -a);
            Console.WriteLine("a+b = " + (a + b));
            Console.WriteLine("a-b = " + (a - b));
            Console.WriteLine("a*b = " + (a * b));
            Console.WriteLine("a/b = " + (a / b));

        }
    }
}
