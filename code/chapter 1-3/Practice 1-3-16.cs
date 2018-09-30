using System;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    class Date
    {
        /* 算法（第四版） 1.3.16 */
        private readonly int month;
        private readonly int day;
        private readonly int year;

        public Date(int m, int d, int y)
        { month = m; day = d; year = y; }

        public Date(string date)
        {
            //1.2.19部分
            string[] inPut = date.Split('/');
            month = Convert.ToInt32(inPut[0]);
            day = Convert.ToInt32(inPut[1]);
            year = Convert.ToInt32(inPut[2]);
        }

        public static Date[] readDates()
        {
            Console.WriteLine("请输入字符串组：(一行一个日期，以输入0为结束）");
            Queue<Date> date = new Queue<Date>();
            while (true)
            {
                string temp1 = Console.ReadLine();
                if (temp1 == "0") break;
                Date temp2 = new Date(temp1);
                date.Enqueue(temp2);
            }

            int N = date.Count;
            Date[] a = new Date[N];
            for (int i = 0; i < N; i++)
                a[i] = date.Dequeue();
            return a;
        }
    }
}