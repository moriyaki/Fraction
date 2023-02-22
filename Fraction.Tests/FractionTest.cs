namespace moriyaki.fraction.Tests
{
    // 基本：通分と分母分子の正負
    public class FractionBaseTest
    {

        [Fact]
        public void FracReduce()
        {
            // 正しく通分されるか
            var a = new Fraction(2, 6);
            var b = new Fraction(1, 3);

            Assert.Equal(a, b);
        }

        [Fact]
        public void FracMinusPerMinus()
        {
            // 分母分子が共に負である数値が正しく通分されるか
            var a = new Fraction(2, 6);
            var b = new Fraction(-1, -3);

            Assert.Equal(a, b);
        }

        [Fact]
        public void FracMinusPerPlus()
        {
            // 負の分数がそれぞれ正しく通分されるか
            var a = new Fraction(-2, 6);
            var b = new Fraction(-1, 3);

            Assert.Equal(a, b);
        }

        [Fact]
        public void FracPlusPerMinux()
        {
            // 分母、分子に負の値がある場合、それぞれ正しく通分されるか
            var a = new Fraction(2, -6);
            var b = new Fraction(-1, 3);

            Assert.Equal(a, b);
        }

    }

    // 四則演算
    public class FourOperationTest
    {
        [Fact]
        public void AddFracFrac()
        {
            // 1/2 + 1/3 = 5/6 になるか
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 3);

            var result = a + b;
            var actual = new Fraction(5, 6);

            Assert.Equal(result, actual);
        }

        [Fact]
        public void AddFracLon()
        {
            // 1/3 + 2 = 1/3 + 6/3 = 7/3 になるか
            var a = new Fraction(1, 3);
            long b = 2;

            var result = a + b;
            var actual = new Fraction(7, 3);
            Assert.Equal(result, actual);
        }
        [Fact]
        public void SubFracFrac()
        {
            // 1/2 - 1/3 = 3/6 - 2/6 = 1/6
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 3);

            var result = a - b;
            var actual = new Fraction(1, 6);

            Assert.Equal(result, actual);
        }

        [Fact]
        public void SubFracLong()
        {
            // 5/3 - 1 = 5/3 - 3/3 = 2/3 になるか
            var a = new Fraction(5, 3);
            long b = 1;

            var result = a - b;
            var actual = new Fraction(2, 3);
            Assert.Equal(result, actual);
        }

        [Fact]
        public void MulFracFrac()
        {
            // 2/3 * 3/4 = 6/12 = 1/2 になるか
            var a = new Fraction(2, 3);
            var b = new Fraction(3, 4);

            var result = a * b;
            var actual = new Fraction(1, 2);
            Assert.Equal(result, actual);
        }

        [Fact]
        public void MulFracLong()
        {
            // 2/3 * 2 = 4/3 になるか
            var a = new Fraction(2, 3);
            var b = 2;

            var result = a * b;
            var actual = new Fraction(4, 3);
            Assert.Equal(result, actual);
        }

        [Fact]
        public void DivFracFrac()
        {
            // 2/3 / 3/4 = 2/3 * 4/3 = 8/9 になるか
            var a = new Fraction(2, 3);
            var b = new Fraction(3, 4);

            var result = a / b;
            var actual = new Fraction(8, 9);
            Assert.Equal(result, actual);
        }

        [Fact]
        public void DivFracLong()
        {
            // 4/6 / 2 = 2/6 = 1/3 になるか
            var a = new Fraction(4, 6);
            var b = 2;

            var result = a / b;
            var actual = new Fraction(1, 3);
            Assert.Equal(result, actual);
        }
    }

    // 比較
    public class CompareTest
    {
        [Fact]
        public void CompareEqual() 
        {
            var a = new Fraction(4, 6);
            var b = new Fraction(2, 3);

            var result = (a == b);
            Assert.True(result);
        }

        [Fact]
        public void CompareNotEqual()
        {
            var a = new Fraction(4, 6);
            var b = new Fraction(2, 4);

            var result = (a != b);
            Assert.True(result);
        }

        [Fact]
        public void CompareBigger()
        {
            var a = new Fraction(5, 6);
            var b = new Fraction(2, 4);

            var result = (a > b);
            Assert.True(result);
        }

        [Fact]
        public void CompareSmaller()
        {
            var a = new Fraction(2, 6);
            var b = new Fraction(2, 4);

            var result = (a < b);
            Assert.True(result);
        }
        [Fact]
        public void CompareBiggerEqual()
        {
            var a = new Fraction(5, 6);
            var b = new Fraction(1, 2);

            var result = (a >= b);
            Assert.True(result);

            a = new Fraction(2, 4);

            result = (a >= b);
            Assert.True(result);
        }
        [Fact]
        public void CompareSmallerEqual()
        {
            var a = new Fraction(2, 6);
            var b = new Fraction(1, 2);

            var result = (a <= b);
            Assert.True(result);

            a = new Fraction(2, 4);

            result = (a >= b);
            Assert.True(result);
        }
    }

    // 最大値・最小値・絶対値
    public class MaxMinAbsTest
    {
        [Fact]
        public void MaxLongPlus()
        {
            // 1/3 と 1/4 を比較したら Max 1/3 になるか
            var a = new Fraction(1, 3);
            var b = new Fraction(1, 4);

            var result = Fraction.Max(a, b);
            Assert.Equal(result, a);
        }

        [Fact]
        public void MaxLongMinus()
        {
            // 1/3 と -1/3 を比較したら Max 1/3 になるか
            var a = new Fraction(-1, 3);
            var b = new Fraction(1, 3);

            var result = Fraction.Max(a, b);
            Assert.Equal(result, b);
        }
        [Fact]
        public void MinLongPlus()
        {
            // 1/3 と 1/4 を比較したら Min 1/4 になるか
            var a = new Fraction(1, 3);
            var b = new Fraction(1, 4);

            var result = Fraction.Min(a, b);
            Assert.Equal(result, b);
        }

        [Fact]
        public void MinLongMinus()
        {
            // -1/3 と 1/4 を比較したら Min 1/3 になるか
            var a = new Fraction(-1, 3);
            var b = new Fraction(1, 4);

            var result = Fraction.Min(a, b);
            Assert.Equal(result, a);
        }
        [Fact]
        public void MinLongMinusDen()
        {
            // -1/4 と 1/3 を比較したら Min -1/4 になるか
            var a = new Fraction(1, -4);
            var b = new Fraction(1, 3);

            var result = Fraction.Min(a, b);
            Assert.Equal(result, a);
        }

        [Fact]
        public void AbsTest1()
        {
            var a = new Fraction(1, 3);
            var result = Fraction.Abs(a);
            Assert.Equal(result, a);
        }

        [Fact]
        public void AbsTest2()
        {
            var a = new Fraction(-1, 3);
            var result = Fraction.Abs(a);
            var actual = new Fraction(1, 3);
            Assert.Equal(result, actual);
        }
        [Fact]
        public void AbsTest3()
        {
            var a = new Fraction(1, -3);
            var result = Fraction.Abs(a);
            var actual = new Fraction(1, 3);
            Assert.Equal(result, actual);
        }
        [Fact]
        public void AbsTest4()
        {
            var a = new Fraction(-1, -3);
            var result = Fraction.Abs(a);
            var actual = new Fraction(1, 3);
            Assert.Equal(result, actual);
        }
    }
    // 整数の累乗
    public class FractionPowLongTest
    {
        [Fact]
        public void PowLongPlus()
        {
            // (2/3) ^8 = 256/6561 になるか
            var a = new Fraction(2, 3);
            var b = 8;

            var result = Fraction.Pow(a, b);
            var actual = new Fraction(256, 6561);
            Assert.Equal(result, actual);
        }

        [Fact]
        public void PowLongMinus()
        {
            // (2/3) ^-4 = (3/2) * (3/2) * (3/2) * (3/2) = 81/16 になるか
            var a = new Fraction(2, 3);
            var b = -4;

            var result = Fraction.Pow(a, b);
            var actual = new Fraction(81, 16);
            Assert.Equal(result, actual);

        }

        [Fact]
        public void PowLongZero()
        {
            // (2/3) ^0 = 1 になるか
            var a = new Fraction(2, 3);
            var b = 0;

            var result = Fraction.Pow(a, b);
            var actual = new Fraction(1);
            Assert.Equal(result, actual);
        }
    }
}