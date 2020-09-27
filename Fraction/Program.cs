using System;
using System.Globalization;
using moriyaki.fraction;

namespace FractionTest
{
	class Program
	{
		public static void Main(string[] args)
		{
			/*
						var a = new Fraction(5, 4);
						var b = new Fraction(2, 3);

						FractionOperationTest(a, b);
						FractionIntOperationTest(a, 2);
						FractionIntOperationTest(b, 3);
			*/
			var a_str = "392.437";
			var a = new Fraction(a_str);
			var b = new Fraction(2, 3);

			Console.WriteLine($"a_string is {a_str}");
			FractionOperationTest(a, b);
			
		}

		public static void FractionOperationTest(Fraction a, Fraction b)
		{
			Console.WriteLine("-------------------");
			Console.WriteLine("FractionOperation");
			Console.WriteLine($"a = {a}");
			Console.WriteLine($"b = {b}");
			Console.WriteLine();
			Console.WriteLine("-a =  " + -a);
			Console.WriteLine("a+b = " + (a + b));
			Console.WriteLine("a-b = " + (a - b));
			Console.WriteLine("a*b = " + (a * b));
			Console.WriteLine("a/b = " + (a / b));
			Console.WriteLine("++a : " + ++a);
			Console.WriteLine("--a : " + --a);

			int k;
			Fraction p;

			(k, p) = a.GetProperFraction();
			Console.WriteLine("a = " + k + " + (" + p + ")");
			(k, p) = b.GetProperFraction();
			Console.WriteLine("b = " + k + " + (" + p + ")");
			Console.WriteLine("a = " + a.Double);
			Console.WriteLine("b = " + b.Double);
		}

		public static void FractionIntOperationTest(Fraction a, int b)
		{
			Console.WriteLine("-------------------");
			Console.WriteLine("FractionIntOperation");
			Console.WriteLine($"a = {a}");
			Console.WriteLine($"b = {b}");
			Console.WriteLine("");
			Console.WriteLine("-a = " + -a);
			Console.WriteLine("a+b = " + (a + b));
			Console.WriteLine("a-b = " + (a - b));
			Console.WriteLine("a*b = " + (a * b));
			Console.WriteLine("a/b = " + (a / b));

		}
	}
}
