using System;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.3.10 */
            //规则：从左到右遍历中缀表达式的每个数字和符号
            /* 1.若是数字就输出
             * 2.若是符号则判断：
             *   a.若符号栈为空或符号为左括号，则压入栈
             *   b.若为运算符号，当前符号与栈顶符号优先级相同则输出栈顶符号并把当前符号压入栈
             *                   当前符号优先级比栈顶符号低时，输出栈中或括号中的所有符号后，再把当前符号压入栈
             *   c.若符号为右括号，则输出栈中元素直到遇到左括号                
             */
            //感觉应该有更简便的方法
            string inP = Console.ReadLine();
            InfixToPostfix(inP);
            Console.ReadKey();
        }

        public static void InfixToPostfix(string inP)
        {
            Stack<string> a = new Stack<string>();
            Console.WriteLine();
            Console.Write(inP.Substring(0, 1));
            for (int i = 1; i<inP.Length; i++)
            {
                string temp = inP.Substring(i, 1);
                if (a.Count == 0 || temp == "(")
                {
                    a.Push(temp);
                    continue;
                }
                else if (temp == "+" || temp == "-")
                {
                    if (a.Peek() == "+" || a.Peek() == "-")
                    {
                        Console.Write(a.Pop());
                    }
                    if (a.Peek() == "*" || a.Peek() == "/")
                    {
                        while (a.Count > 0)
                        {
                            if (a.Peek() == "(")
                                break;
                            Console.Write(a.Pop());
                        }                           
                    }
                    a.Push(temp);
                    continue;
                }
                else if (temp == "*" || temp == "/")
                {
                    if (a.Peek() == "*" || a.Peek() == "/")
                    {
                        Console.Write(a.Pop());
                    }
                    a.Push(temp);
                    continue;
                }
                else if (temp == ")")
                {
                    while (a.Peek() != "(")
                        Console.Write(a.Pop());
                    a.Pop();
                    continue;
                }
                Console.Write(temp);
            }
            while (a.Count > 0)
                Console.Write(a.Pop());
        }
    }
}