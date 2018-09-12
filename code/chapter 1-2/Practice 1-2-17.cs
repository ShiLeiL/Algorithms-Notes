using System;
using System.Diagnostics;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.2.16 */
            //测试用例
            int c = 5000000, d = 123125123;//制作溢出数据
            Rational a = new Rational(c*d, 6);
            Rational b = new Rational(3, 8);
            Console.WriteLine($"plus:\t{a.Plus(b).toString()}");
            Console.WriteLine();
            Console.WriteLine($"minus:\t{a.Minus(b).toString()}");
            Console.WriteLine();
            Console.WriteLine($"times:\t{a.Times(b).toString()}");
            Console.WriteLine();
            Console.WriteLine($"divides:\t{a.Divides(b).toString()}");
            Console.WriteLine();
            Console.WriteLine($"boolean:\t{a.Equals(b)}");
            Console.ReadKey();
        }
    }

    public class Rational
    {
        /* 算法（第四版） 1.2.16 */
        private int num;
        private int deno;

        public Rational(int numerator, int denominator)
        {
            //添加断言
            Debug.Assert(numerator > int.MaxValue || denominator > int.MaxValue, "The value has exceeded the maximum value!");
            if (denominator==0)
            { throw new ArgumentException("Denominator cannot be 0!"); }
            num = numerator; deno = denominator;
            int temp = gcd(numerator , denominator );
            if (temp > 1)
            {
                //约分
                num = numerator / temp;
                deno = denominator / temp;
            }
            if((num < 0 && deno < 0) || (deno < 0 && num > 0))
            { num *= -1;deno *= -1; }
        }

        int gcd(int a, int b)
        {
            //求最大公约数，不使用递归
            int temp;
            if (a < b)
            { temp = a; a = b; b = temp; }
            while (b != 0)
            {
                temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        public Rational Plus(Rational b)
        {
            int denoPlus = deno * b.deno / gcd(deno, b.deno);
            int numPlus = num * denoPlus / deno + b.num * denoPlus / b.deno;
            int temp = gcd(denoPlus, numPlus);
            if (temp > 1)
            {
                //约分
                denoPlus /= temp;
                numPlus /= temp;
            }
            Rational a = new Rational(numPlus, denoPlus);
            return a;
        }

        public Rational Minus(Rational b)
        {
            int denoMinus = deno * b.deno / gcd(deno, b.deno);
            int numMinus = num * denoMinus / deno - b.num * denoMinus / b.deno;
            int temp = gcd(denoMinus, numMinus);
            if (temp > 1)
            {
                //约分
                denoMinus /= temp;
                denoMinus /= temp;
            }
            Rational a = new Rational(numMinus, denoMinus);
            return a;
        }

        public Rational Times(Rational b)
        {
            int numTimes = num * b.num;
            int denoTimes = deno * b.deno;
            int temp = gcd(denoTimes, numTimes);
            if (temp > 1)
            {
                //约分
                denoTimes /= temp;
                numTimes /= temp;
            }
            Rational a = new Rational(numTimes, denoTimes);
            return a;
        }

        public Rational Divides(Rational b)
        {
            int numDivides = num * b.deno;
            int denoDivides = deno * b.num;
            int temp = gcd(denoDivides, numDivides);
            if (temp > 1)
            {
                //约分
                numDivides /= temp;
                denoDivides /= temp;
            }
            Rational a = new Rational(numDivides, denoDivides);
            return a;
        }

        public bool Equals(Rational that)
        {
            if (this == that) return true;
            if (that == null) return false;
            if (this.num != that.num) return false;
            if (this.deno != that.deno) return false;
            return true;
        }

        public string toString()
        { return num + "/" + deno; }
    }
}