using System;
using System.Collections;

namespace AlgorithmsApplication
{
    class Josephus
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.3.37 */
            Console.WriteLine("请输入人的个数N：");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入报数M：");
            int M = Convert.ToInt32(Console.ReadLine());
            Queue josephus = new Queue();
            Console.WriteLine();

            //以下为官方解答改编
            for (int i = 0; i < N ; i++)
                josephus.Enqueue(i);

            while (josephus.Count!=0)
            {
                for (int i = 0; i < M - 1; i++)
                    josephus.Enqueue(josephus.Dequeue());
                Console.Write(josephus.Dequeue() + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //以下为自己的想法，做一个记录
            //自己的思路并不算利用队列进行计算，没有官方解答那么巧妙
            josephus = new Queue();
            for (int i = 1, temp = 0; josephus.Count != N; i++, temp++)
            {
                if (josephus.Contains(temp))
                    i--;
                if (i == M && (!josephus.Contains(temp)))
                {
                    josephus.Enqueue(temp);
                    i = 0;
                }
                if (temp == N - 1)
                    temp = -1;
            }
            foreach (int i in josephus)
                Console.Write(i+" ");
            Console.ReadKey();
        }
    }
}