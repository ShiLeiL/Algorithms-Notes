using System;
using System.Collections.Generic;

namespace PrefixExpression
{
    class PrefixClass
    {
        static void Main(string[] args)
        {
            /*题目：前缀表达式
             * 输入：(符号 数字 数字）  
             * 用空格隔开括号中的内容，括号中数字的数量不等，都为整数
             * 符号可为add、sub、mul、div，分别对应加减乘除
             * 输入可嵌套，例如(sub (mul 2 4) (div 9 3))
             * 
             * 输出：返回对应四则运算的整数结果
             * 若除法中除数为0，则直接返回error
             */
            string inP = Console.ReadLine();
            string[] inPut = inP.Split(' ');//去掉空格

            //处理输入，隔开括号并保留括号
            string[] inPut1 = new string[inP.Length * 2 / 3];//长度可调
            for (int i = 0, j = 0; i < inPut.Length; i++)
            {
                if (inPut[i].Contains("("))
                {
                    inPut1[j] = inPut[i].Substring(0, 1);
                    inPut1[j + 1] = inPut[i].Substring(1, 3);
                    j += 2;
                    continue;
                }
                if (inPut[i].Contains(")"))
                {
                    inPut1[j] = inPut[i].Split(')')[0];
                    inPut1[j + 1] = inPut[i].Substring(inPut1[j].Length, 1);
                    j += 2;
                    continue;
                }
                inPut1[j] = inPut[i];
                j++;
            }
            Console.WriteLine(Prefix(inPut1));
            Console.ReadKey();
        }

        static string Prefix(string[] a)
        {
            Stack<string> stackString = new Stack<string>();//利用栈来进行运算
            stackString.Push(")");
            int result = 0;

            for (int i = a.Length - 1; i > -1; i--)
            {
                if (a[i] == null) continue;
                if (a[i] == "(")
                {
                    if (a[i + 1] == "add")
                    {
                        stackString.Pop();//符号出栈
                        for (; stackString.Peek() != ")";)
                        {
                            result += Convert.ToInt32(stackString.Pop());
                        }
                        stackString.Pop();//反括号出栈
                        stackString.Push(Convert.ToString(result));//结果入栈
                        result = 0;
                        continue;
                    }
                    if (a[i + 1] == "sub")
                    {
                        stackString.Pop();//符号出栈
                        for (int j = 0; stackString.Peek() != ")"; j++)
                        {
                            if (j == 0) result = Convert.ToInt32(stackString.Pop());
                            result -= Convert.ToInt32(stackString.Pop());
                        }
                        stackString.Pop();//反括号出栈
                        stackString.Push(Convert.ToString(result));//结果入栈
                        result = 0;
                        continue;
                    }
                    if (a[i + 1] == "mul")
                    {
                        stackString.Pop();//符号出栈
                        result = 1;
                        for (; stackString.Peek() != ")";)
                        {
                            result *= Convert.ToInt32(stackString.Pop());
                        }
                        stackString.Pop();//反括号出栈
                        stackString.Push(Convert.ToString(result));//结果入栈
                        result = 0;
                        continue;
                    }
                    if (a[i + 1] == "div")
                    {
                        stackString.Pop();//符号出栈
                        for (int j = 0; stackString.Peek() != ")"; j++)
                        {
                            if (j == 0) result = Convert.ToInt32(stackString.Pop());
                            if (stackString.Peek() == "0") return "error";//若除数为0，返回error
                            result /= Convert.ToInt32(stackString.Pop());
                        }
                        stackString.Pop();//反括号出栈
                        stackString.Push(Convert.ToString(result));//结果入栈
                        result = 0;
                        continue;
                    }
                }
                stackString.Push(a[i]);
            }
            return stackString.Pop(); //最后栈顶为最终结果
        }
    }
}