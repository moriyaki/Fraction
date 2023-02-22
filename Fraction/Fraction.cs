using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace moriyaki.fraction
{
    public class Fraction
    {
        /// <summary>分母</summary>
        public long Numerator { get; private set; }
        /// <summary>分子</summary>
        public long Denominator { get; private set; }

        /// <summary>コンストラクタ</summary>
        /// <exception cref="ArgumentException">分母が0</exception>
        public Fraction(long numerator = 0, long denominator = 1)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero", nameof(denominator));
            }
            // 約分する
            var gcd = Gcd(numerator, denominator);
            this.Numerator = numerator / gcd;
            this.Denominator = denominator / gcd;

            // 分母が負なら分母を正にする
            if (this.Denominator < 0)
            {
                this.Numerator = -this.Numerator;
                this.Denominator = -this.Denominator;
            }

        }

        public Fraction(Fraction frac)
        {
            var gcd = Gcd(frac.Numerator, frac.Denominator);
            this.Numerator = frac.Numerator / gcd;
            this.Denominator = frac.Denominator / gcd;
        }

        /// <summary>通分するa/c と b/d の通分は ad/cd と bc/cd</summary>
        public static (Fraction, Fraction) CommonDenominator(Fraction left, Fraction right)
        {
            var (common_left, common_right) = (new Fraction(left), new Fraction(right));
            common_left.Denominator = left.Denominator * right.Denominator;
            common_left.Numerator = left.Numerator * right.Denominator;

            common_right.Denominator = right.Denominator * left.Denominator;
            common_right.Numerator = right.Numerator * left.Denominator;

            return (common_left, common_right);
        }

        /// <summary>約分する</summary>
        public static Fraction ReduceFraction(Fraction value)
        {
            var gcd = Gcd(value.Numerator, value.Denominator);
            if (gcd != 0) { return new(value.Numerator / gcd, value.Denominator / gcd); }
            return value;
        }

        /// <summary>ユークリッド互除法により最小公倍数を得る</summary>
        public static long Gcd(long a, long b)
        {
            if (a < b)
            {
                return Gcd(b, a);
            }
            while(b!= 0)
            {
                var r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        /// <summary>通分して大小確認</summary>
        private static int Compare(Fraction left, Fraction right)
        {
            var (common_left, common_right) = CommonDenominator(left, right);

            if (common_left.Numerator < common_right.Numerator) { return -1; }
            if (common_left.Numerator > common_right.Numerator) { return 1; }
            return 0;
        }

        /// <summary>分数同士が等しいか</summary>
        public static bool operator ==(Fraction left, Fraction right)
        {
            return Compare(left, right) == 0;
        }

        /// <summary>分数同士が異なるか</summary>
        public static bool operator !=(Fraction left, Fraction right)
        {
            return Compare(left, right) != 0;
        }

        /// <summary>左辺が右辺より大きいか</summary>
        public static bool operator >(Fraction left, Fraction right)
        {
            return Compare(left, right) > 0;
        }

        /// <summary>左辺が右辺より小さいか</summary>
        public static bool operator <(Fraction left, Fraction right)
        {
            return Compare(left, right) < 0;
        }

        /// <summary>左辺が右辺以上</summary>
        public static bool operator >=(Fraction left, Fraction right)
        {
            return Compare(left, right) >= 0;
        }

        /// <summary>左辺が右辺以下</summary>
        public static bool operator <=(Fraction left, Fraction right)
        {
            return Compare(left, right) <= 0;
        }


        /// <summary>==実装に必要な、オブジェクトレベルで等しいかを確認する</summary>
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Fraction right = (Fraction)obj;
            var (common_left, common_right) = CommonDenominator(this, right);
            return common_left.Numerator == common_right.Numerator;
        }

        /// <summary>!=実装に必要な、オブジェクトのハッシュコードを生成</summary>
        public override int GetHashCode()
        {
            var value = "Fraction" + this.Numerator.ToString() + "/" + this.Denominator.ToString();
            return value.GetHashCode();
        }

        /// <summary>正の数</summary>
        public static Fraction operator +(Fraction value) => value;

        /// <summary>負の数</summary>
        public static Fraction operator -(Fraction value) => new(-value.Numerator, value.Denominator);

        /// <summary>分数同士の加算</summary>
        public static Fraction operator +(Fraction left, Fraction right)
        {
            var (common_left, common_right) = CommonDenominator(left, right);
            return new(common_left.Numerator + common_right.Numerator, common_left.Denominator);
        }

        /// <summary>分数と整数の加算 a/c + b = (a/c + bc/c) = a+bc / c </summary>
        public static Fraction operator +(Fraction left, long right) =>
            new(left.Numerator + right * left.Denominator, left.Denominator);

        /// <summary>分数同士の減算</summary>
        public static Fraction operator -(Fraction left, Fraction right)
        {
            var (common_left, common_right) = CommonDenominator(left, right);
            return new(common_left.Numerator - common_right.Numerator, common_left.Denominator);
        }

        /// <summary>分数と整数の減算 a/c + b = (a/c + bc/c) = a+bc / c </summary>
        public static Fraction operator -(Fraction left, long right) =>
            new(left.Numerator - right * left.Denominator, left.Denominator);


        /// <summary>分数同士の乗算 a/c * b/d = ab / cd </summary>
        public static Fraction operator *(Fraction left, Fraction right) =>
            new(left.Numerator * right.Numerator, left.Denominator * right.Denominator);

        /// <summary>分数と整数の乗算 a/c * b = ab / c </summary>
        public static Fraction operator *(Fraction left, long right) =>
            new(left.Numerator * right, left.Denominator);

        /// <summary>分数同士の除算 a/c / b/d = a/c * d/b = ad / cb </summary>
        public static Fraction operator /(Fraction left, Fraction right)
        {
            if (right.Numerator == 0) { throw new DivideByZeroException("Cannot divide by zero."); }
            return new(left.Numerator * right.Denominator, right.Numerator * left.Denominator);
        }

        /// <summary>分数と整数の除算 a/c / b = a / bc </summary>
        public static Fraction operator /(Fraction left, long right)
        {
            if (right == 0) { throw new DivideByZeroException("Cannot divide by zero."); }
            return new(left.Numerator, right * left.Denominator);
        }

        /// <summary>long型に最適化したべき乗処理</summary>
        /// <param name="var_base">底</param>
        /// <param name="exponent">指数</param>
        private static long Pow(long var_base, long exponent)
        {
            long odd_base = 1;
            long optimize_base = var_base;
            long optimize_exponent = exponent;

            if (exponent % 2 == 1)
            {
                odd_base = var_base;
                optimize_exponent--;
            }
            while (optimize_exponent > 1)
            {
                optimize_base *= optimize_base;
                optimize_exponent /= 2;
            }
            return optimize_base * odd_base;
        }

        /// <summary>最大値を取得</summary>
        public static Fraction Max(Fraction left, Fraction right)
        {
            var (common_left, common_right) = CommonDenominator(left, right);
            return common_left.Numerator > common_right.Numerator ? left : right;
        }

        /// <summary>最小値を取得</summary>
        public static Fraction Min(Fraction left, Fraction right)
        {
            var (common_left, common_right) = CommonDenominator(left, right);
            return common_left.Numerator < common_right.Numerator ? left : right;
        }

        /// <summary>絶対値を取得</summary>
        public static Fraction Abs(Fraction value)
        {
            if (value.Numerator >= 0 && value.Denominator < 0) { return new Fraction(value.Numerator, -value.Denominator); }
            if (value.Numerator < 0 && value.Denominator > 0) { return new Fraction(-value.Numerator, value.Denominator); }
            if (value.Numerator < 0 && value.Denominator < 0) { return new Fraction(-value.Numerator, -value.Denominator); }
            return value;
        }

        /// <summary>分数をべき乗</summary>
        /// <param name="var_base">底</param>
        /// <param name="exponent">指数</param>
        public static Fraction Pow(Fraction var_base, long exponent)
        {
            if (exponent == 0) { return new Fraction(1); }

            var result = new Fraction(var_base);
            if (exponent < 0)
            {
                result.Numerator = Pow(var_base.Denominator, -exponent);
                result.Denominator = Pow(var_base.Numerator, -exponent);
            }
            else
            {
                result.Numerator = Pow(var_base.Numerator, exponent);
                result.Denominator = Pow(var_base.Denominator, exponent);
            }
            return result;
        }

    }
}
