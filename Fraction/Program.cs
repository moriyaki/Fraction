using System;

public readonly struct Fraction
{
    private readonly int num;
    private readonly int den;

    public Fraction(int numerator, int denominator = 1)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero", nameof(denominator));
        }
        num = numerator;
        den = denominator;
    }


    public static Fraction operator +(Fraction a) => a;

    // 負の数にする
    public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);


    public static implicit operator int(Fraction a) => a.num;
    public static explicit operator Fraction(int i) => new Fraction(i);

    // 加算
    // a/b + c/d = ac+bd/bd
    public static Fraction operator +(Fraction a, Fraction b)
        => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);

    // 減算
    public static Fraction operator -(Fraction a, Fraction b)
        => a + (-b);

    // 乗算
    public static Fraction operator *(Fraction a, Fraction b)
        => new Fraction(a.num * b.num, a.den * b.den);

    // 除算
    // a/b / c/d = a/b * d/c = ad/bc
    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.num == 0)
        {
            throw new DivideByZeroException();
        }
        return new Fraction(a.num * b.den, a.den * b.num);
    }

    // 最大公約数の獲得(ユークリッド互除法)
    public static int Gcd(int a, int b)
    {
        int abs_a = (a > 0) ? a : -a;
        int abs_b = (b > 0) ? b : -b;

        if (abs_a < abs_b)
            return Gcd(b, a);

        while (abs_b != 0)
        {
            var remainder = abs_a % abs_b;
            abs_a = abs_b;
            abs_b = remainder;
        }
        return abs_a;
    }

    public override string ToString()
    {
        int numerator = num;
        int denominator = den;

        int gcd = Gcd(num, den);
        if (gcd != 0)
        {
            numerator /= gcd;
            denominator /= gcd;
        }

        if (denominator == 1)
        {
            return $"{numerator}";
        }
        else
        {
            return $"{numerator} / {denominator}";
        }
    }
}

namespace FractionTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);

            Console.WriteLine(" -a = " + -a);
            Console.WriteLine("a+b = " + (a + b));
            Console.WriteLine("a-b = " + (a - b));
            Console.WriteLine("a*b = " + (a * b));
            Console.WriteLine("a/b = " + (a / b));

            var c = new Fraction(1, 3) * (Fraction)3;
            Console.WriteLine("  c = " + c);
        }
    }
}
