using System;

namespace AlgorithmsApplication
{
    public class Matri
    {
        /* 算法（第四版） 1.1.33 */
        public static double Dot(double[] x, double[] y)
        {
            //向量点乘
            if (x.Length != y.Length)
            {
                Console.WriteLine("输入参数错误！");
                return 0;
            }
            double sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sum += x[i] * y[i];
            }
            return sum;
        }

        public static double[,] mult(double[,] a, double[,] b)
        {
            //矩阵和矩阵之积
            if (a.GetLength(1) != b.GetLength(0))
            {
                Console.WriteLine("输入参数错误！");
                return null;
            }
            double[,] c = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return c;
        }

        public static double [,] transpose(double[,] a)
        {
            //转置矩阵
            double [,] b = new double [a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(1); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    b[i, j] = a[j, i];
                }
            }
            return b;
        }

        public static double [] mult(double[,] a, double[] x)
        {
            //矩阵和向量之积
            if (a.GetLength(1) != x.Length)
            {
                Console.WriteLine("输入参数错误！");
                return null;
            }
            double [] c = new double [a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    c[i] += a[i, j] * x[j];
                }
            }
            return c;
        }

        public static double [] mult(double[] y, double[,] a)
        {
            //向量和矩阵之积
            if (a.GetLength(0) != y.Length)
            {
                Console.WriteLine("输入参数错误！");
                return null;
            }
            double [] c = new double [a.GetLength(1)];
            for (int i = 0; i < a.GetLength(1); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    c[i] += y[j] * a[j, i];
                }
            }
            return c;
        }

        public static void printc(double[] a)
        {
            //输出向量
            Console.Write("result= ");
            for (int i=0;i<a.Length;i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine();
        }

        public static void printc(double[,] a)
        {
            //输出矩阵
            Console.WriteLine("result=");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for(int j=0;j < a.GetLength(1);j++)
                {
                    Console.Write($"{a[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

