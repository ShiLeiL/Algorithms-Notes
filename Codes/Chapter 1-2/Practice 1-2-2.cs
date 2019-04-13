using System;
using System.Diagnostics;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.2.2 */
            //记录输入
            Console.WriteLine("请输入间隔个数：");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入间隔(格式为double,double,输完一个进行回车输下一个）：");
            string[][] inP = new string[N][];
            for(int i=0;i<N;i++)
            {
                inP[i] = Console.ReadLine().Split(',');
            }

            //转换输入的数据类型
            double[][] section = new double[N][];
            for(int i=0;i<N;i++)
            {
                section[i] = new double[inP[i].Length];
                for (int j=0;j< inP[i].Length; j++)
                {
                    section[i][j] = Convert.ToDouble(inP[i][j]);
                }
            }
            Interval1D.Inter(section, N);//调用Interval1D类的方法
            Console.ReadKey();
        }       
    }

    public class Interval1D
    {
        public  static void Inter(double[][] section,int N)
        {
            //对比间隔
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (Contrast(section[i], section[j]))
                        Console.WriteLine($"({section[i][0]},{section[i][1]})\t({section[j][0]},{section[j][1]})");
                }
            }
            Console.WriteLine("以上这些间隔相交。");
        }

        static bool Contrast(double[] a, double[] b)
        {
            //间隔相交判断
            if (b[1] > a[0] && b[1] < a[1]) return true;
            if (b[0] > a[0] && b[0] < a[1]) return true;
            if (a[0] > b[0] && a[1] < b[1]) return true;
            return false;
        }
    }
}