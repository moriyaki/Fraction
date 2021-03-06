﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace moriyaki.fraction
{
	public  struct Fraction
	{
		private  int num;
		private  int den;

		public Fraction(int numerator, int denominator = 1)
		{
			if (denominator == 0)
			{
				throw new ArgumentException("Denominator cannot be zero", nameof(denominator));
			}
			num = numerator;
			den = denominator;
		}

		/// <summary>
		/// 小数文字で受け取り
		/// </summary>
		/// <param name="decString"></param>
		public Fraction(string decString)
		{
			var numbers = decString.Split('.');
			if (numbers.Length > 2) throw new InvalidOperationException();

			int numbase, dec;

			if (!Int32.TryParse(numbers[0], out numbase))
			{
				throw new InvalidOperationException();
			}
			if (!Int32.TryParse(numbers[1], out dec))
			{
				throw new InvalidOperationException();
			}
			den = (int)(Math.Pow(10, numbers[1].Length));
			num = numbase * den + dec;
		}

		// 正の数
		public static Fraction operator +(Fraction value) => value;

		// 負の数
		public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);


		public static implicit operator int(Fraction a) => a.num;

		// 加算
		// a/b + c/d = (a*c + b*d) / b*d な公式 
		public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);

		// a/b + c = (a/b + bc/b) = (a+bc / b)
		public static Fraction operator +(Fraction a, int b) => new Fraction(a.num + b * a.den, a.den);

		// 減算
		// a/b - c = (a-bc / b)
		public static Fraction operator -(Fraction a, int b) => new Fraction(a.num - b * a.den, a.den);

		// 乗算
		public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.num * b.num, a.den * b.den);

		// a/b * c = ac / b
		public static Fraction operator *(Fraction a, int c) => new Fraction(a.num * c, a.den);

		// インクリメント
		public static Fraction operator ++(Fraction a) => new Fraction(a.num + a.den, a.den);

		// デクリメント
		public static Fraction operator --(Fraction a) => new Fraction(a.num - a.den, a.den);


		// 除算
		// a/b / cd = ad/bc
		public static Fraction operator /(Fraction a, Fraction b)
		{
			if (b.num == 0)
			{
				throw new DivideByZeroException();
			}
			return new Fraction(a.num * b.den, a.den * b.num);
		}

		// a/b / c = a / bc
		public static Fraction operator /(Fraction a, int c) => new Fraction(a.num, a.den * c);


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
				// 分母1なら整数表示
				return $"{numerator}";
			}
			else
			{
				return $"{numerator} / {denominator}";
			}
		}

		/// <summary>
		/// 整数＋真分数にする
		/// </summary>
		/// <returns>整数と真分数のタプル</returns>
		public (int, Fraction) GetProperFraction()
		{
			if (num < den)
			{
				return (0, new Fraction(num, den));
			}
			else
			{
				int k = num / den;
				int n = num % den;
				return (k, new Fraction(n, den));
			}
		}

		/// <summary>
		/// 小数点で取得
		/// </summary>
		public double Double { get { return (double)num / den; } }
	}

}
