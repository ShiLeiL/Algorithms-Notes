using System;

namespace AlgorithmsApplication
{
    public class Rational
    {
        /* 算法（第四版） 1.2.16 */
        private int num;
        private int deno;

        Rational(int numerator, int denominator)
        { num = numerator; deno = denominator; }

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

        Rational Plus(Rational b)
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

        Rational Minus(Rational b)
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

        Rational Times(Rational b)
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

        Rational Divides(Rational b)
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

        bool Equals(Rational that)
        {
            if (this == that) return true;
            if (that == null) return false;
            if (this.num != that.num) return false;
            if (this.deno != that.deno) return false;
            return true;
        }

        string toString()
        { return num + "/" + deno; }
    }
}