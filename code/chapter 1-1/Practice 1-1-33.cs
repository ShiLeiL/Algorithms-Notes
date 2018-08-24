using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.33 */      
        static void Main(string[] args)
        {
            double[] x = { 1, 2, 3, 4, 5 };
            double[] y = { 5, 6, 7, 8, 9 };
            double  r1 = Matri.Dot(x, y);
            Console.WriteLine($"result={r1}");
            Console.WriteLine();

            double[,] a = new double[3, 4];
            for(int i=0;i<a.GetLength(0);i++)
            {
                for(int j=0;j<a.GetLength(1);j++)
                {
                    a[i, j] = i + j;
                }
            }
            double[,] b = new double[4, 5];
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j] = i - j;
                }
            }
            double[,] r2 = Matri.mult(a, b);
            Matri.printc(r2);

            double[,] r3 = Matri.transpose(b);
            Matri.printc(r3);

            double [] r4 = Matri.mult(b,x);
            Matri.printc(r4);
            Console.WriteLine();

            double[] z = { 2, 3, 4 };
            double [] r5 = Matri.mult(z, a);
            Matri.printc(r5);

            Console.ReadKey();
        }
    }
}