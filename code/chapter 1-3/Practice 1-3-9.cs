using System;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.3.9 */
            //此处我直接利用了C#里的stack类，也可以直接使用1-3-4里的自己写的stack类
            string[] inP = Console.ReadLine().Split(' ');
            Stack<string> a = new Stack<string>();
            for (int i = 0; i < inP.Length; i++)
            {
                if (inP[i] == ")")
                {
                    string temp3 = a.Pop();
                    string temp2 = a.Pop();
                    string temp = "( " + a.Pop() + " " + temp2 + " " + temp3 + " )";
                    a.Push(temp);
                    continue;
                }
                a.Push(inP[i]);
            }
            Console.WriteLine();
            Console.WriteLine(a.Pop());
            Console.ReadKey();
        }
    }
}