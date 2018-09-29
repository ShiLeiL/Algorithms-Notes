using System;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 同事出的题（运用面向对象思维）：
             * 小红  爱 小黄
             * 小黄  爱 小蓝
             * 小蓝  爱 小红
             * 请问 小红(的爱人)* n 是谁
             */
            Console.WriteLine("请输入要求的人：");
            string inP = Console.ReadLine();
            Console.WriteLine("请输入“的爱人”的次数：");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            test(inP, N);
            Console.ReadKey();
        }

        static void test(string inP, int N)
        {
            person a = new person("小红");
            person b = new person("小黄");
            person c = new person("小蓝");
            a.SetLover(b);
            b.SetLover(c);
            c.SetLover(a);
            person temp = a;
            for (int i = 0; i < N; i++)
            {
                temp = temp.GetLover();
            }
            Console.WriteLine($"结果为：{temp.GetName()}");
        }
    }

    class person
    {
        string name;
        person lover;

        public person(string a)
        { name = a; }

        public void SetLover(person a)
        { lover = a; }

        public person GetLover()
        { return lover; }

        public string GetName()
        { return name; }
    }
}