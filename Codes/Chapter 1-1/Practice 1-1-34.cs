using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.33 */  
        static void Main(string[] args)
        {
            Console.WriteLine("请输入要计算的数组（用逗号隔开）：");
            string[] strSplit = Console.ReadLine().Split(',');
            double[] d = new double[strSplit.Length];
            for(int i=0;i<d.Length;i++)
            {
                d[i] = Convert.ToDouble(strSplit[i]);
            }

            //测试
            MaxMin(d);
            Median(d);
            Kmin(d,3);
            SumOfSquares(d);
            Average(d);
            OverAverage(d);
            Asc(d);
            Ramdom(d);
            Console.ReadKey();
        }

        static void MaxMin(double[] a)
        {
            //打印出最大和最小的数
            //不需要保存所有值
            double max = 0;
            double min = 1;
            for(int i=0;i<a.Length;i++)
            {
                if (max < a[i]) max = a[i];
                if (min > a[i]) min = a[i];
            }
            Console.WriteLine($"max={max}");
            Console.WriteLine($"min={min}");
            Console.WriteLine();
        }

        static void Median(double[] a)
        {
            //打印出所有数的中位数
            //不需要保存所有值
            double me = 0;
            int len = a.Length;
            if (len % 2 == 0) me = (a[len / 2] + a[len / 2 - 1]) / 2;
            else me = a[(len - 1) / 2];
            Console.WriteLine($"median={me}");
            Console.WriteLine();
        }

        static void Kmin(double[] a,int k)
        {
            //打印出第k小的数，k小于100
            //可以不需要保存所有值
            for(int i=0;i<a.Length;i++)
            {
                int record=0;
                int counts = 0;
                for (int j=0;j<a.Length;j++)
                {
                    if (a[i] < a[j]) counts++;                   
                    if (counts > k + 1) break;
                }
                if (counts == k)
                {
                    record = i;
                    Console.WriteLine($"kmin={a[record]}");
                    break;
                }
            }
            
            Console.WriteLine();
        }

        static void SumOfSquares(double[] a)
        {
            //打印出所有数的平方和
            //不需要保存所有值
            double sum = 0;
            for(int i=0;i<a.Length;i++)
            {
                sum += Math.Pow(a[i], 2);
            }
            Console.WriteLine($"The sum of squares is {sum}");
            Console.WriteLine();
        }

        static void Average(double[] a)
        {
            //打印出N个数的平均值
            //不需要保存所有值
            double sum = 0;
            int len = a.Length;
            foreach (double i in a) sum += i;
            double aver = sum / len;
            Console.WriteLine($"average={aver}");
            Console.WriteLine();
        }

        static void OverAverage(double[] a)
        {
            //打印出大于平均值的数的百分比
            //不需要保存所有值

            //求平均值
            double sum = 0;
            int len = a.Length;
            foreach (double i in a) sum += i;
            double aver = sum / len;

            //求百分比
            int counts = 0;
            foreach(double i in a)
            {
                if (i > aver) counts++;
            }
            double per = counts * 1.00d / a.Length;
            Console.WriteLine($"average={per:P}");
            Console.WriteLine();
        }

        static void Asc(double[] a)
        {
            //将N个数按照升序打印
            //可以不需要保存所有值
            //假设数组长度不是很大，这里使用直接插入排序
            int i, j;
            double k;
            for(i=1;i<a.Length;i++)
            {
                if(a[i]<a[i-1])
                {
                    k = a[i];
                    for(j=i-1;j>=0 && a[j]>k;j--)
                    {
                        a[j + 1] = a[j];
                        a[j] = k;
                    }
                }
            }

            //打印
            Console.Write("result=");
            for (i = 0; i < a.Length; i++)
                Console.Write($"{a[i]} ");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Ramdom(double[] a)
        {
            //将N个数按照随机顺序打印
            //可以不需要保存所有值
            //随机处参考了https://zhidao.baidu.com/question/418334526.html
            Console.Write("result=");
            string temp = ""; //临时容器
            int n = 0;
            Random rd = new Random();
            while (n < a.Length)
            {
                int num = rd.Next(a.Length);
                if (temp.IndexOf(num.ToString()) >= 0) //判断容器里面有没有刚产生的数
                {
                    continue; // 已经有了就重新执行循环
                }
                else
                {
                    temp += num.ToString();//没有将新产生的数装进容器
                    Console.Write($"{a[num]} ");//输出数
                    n++;
                }
            }
            Console.WriteLine();
        }
    }
}
