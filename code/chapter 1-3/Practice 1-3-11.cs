using System;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.3.11 */
            string[] inP = Console.ReadLine().Split(' ');
            Console.WriteLine();
            EvaluatePostfix(inP);
            Console.ReadKey();
        }

        public static void EvaluatePostfix(string[] inP)
        {
            Stack<int> a = new Stack<int>();
            int temp = 0;
            for (int i = 0; i < inP.Length; i++)
            {
                switch (inP[i])
                {
                    case "+":                        
                        a.Push(a.Pop() + a.Pop());
                        continue;
                    case "-":
                        temp = a.Pop();
                        a.Push(a.Pop() - temp);
                        continue;
                    case "*":
                        a.Push(a.Pop() * a.Pop());
                        continue;
                    case "/":
                        temp = a.Pop();
                        a.Push(a.Pop() / temp);
                        continue;
                }
                a.Push(Convert.ToInt32(inP[i]));
            }
            Console.WriteLine(a.Pop());
        }
    }
}