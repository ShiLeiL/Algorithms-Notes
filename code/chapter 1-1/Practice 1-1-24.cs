using System;
namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.24 */
        public static int gcd(int p, int q)
        {
            Console.WriteLine($"p={p}  q={q}");
            if (q == 0) return p;
            int r = p % q;
            return gcd(q, r);
        }

        public static void Main(String[] args)
        {
            //计算105和24的最大公约数
            int a = 105;
            int b = 24;
            Console.WriteLine($"{a}和{b}的最大公约数为：{gcd(a, b)}");

            //从命令行接受两个参数
            Console.WriteLine();
            Console.WriteLine("请输入要计算的数字1：");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入要计算的数字2：");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"{num1}和{num2}的最大公约数为：{gcd(num1, num2)}");
            Console.ReadKey();
        }
    }
}