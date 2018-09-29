using System;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 同事出的题（运用面向对象思维）：
             * 啤酒2元一瓶，用四个瓶盖可换一瓶啤酒
             * 两个空瓶也可换一瓶啤酒
             * 你用10元钱最多可以喝多少瓶啤酒? 
             */
            Console.WriteLine("请输入你有多少钱：");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            test(N);
            Console.ReadKey();
        }

        static void test(int N)
        {
            person a = new person();
            a.money = N;
            a.changeBeerByMoney();
            while(a.cap>3||a.bottle>1)
            {
                if(a.bottle>1)
                    a.changeBeerByBottle();
                if(a.cap>3)
                    a.changeBeerByCap();
            }
            Console.WriteLine($"可以喝{a.count}瓶啤酒");
        }
    }

    class person
    {
        public int money;
        public int cap;
        public int bottle;
        public int count;

        public void changeBeerByMoney()
        {
            int temp = money / 2;
            count += temp;
            cap += temp;
            bottle += temp;
        }

        public void changeBeerByCap()
        {
            int temp = cap / 4;
            count += temp;
            cap = temp + cap % 4;
            bottle += temp;
        }

        public void changeBeerByBottle()
        {
            int temp = bottle / 2;
            count += temp;
            cap += temp;
            bottle =temp + bottle % 2;
        }
    }
}