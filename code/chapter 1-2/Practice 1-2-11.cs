using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.2.11 */
            //控制台输入日期并进行判断和打印
            Console.WriteLine("请输入月份：");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入日期：");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入年份：");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            SmartDate date = new SmartDate(m, d, y);
            Console.WriteLine(date.toString());
            Console.ReadKey();
        }
    }

    class SmartDate
    {
        private readonly int month;
        private readonly int day;
        private readonly int year;

        public SmartDate(int m,int d,int y)
        { month = m;day = d;year = y; }
        
        public int Month()
        { return month; }

        public int Day()
        { return day; }

        public int Year()
        { return year; }

        public string toString()
        {
            try
            {
                //判断日期异常，若异常则实例化自定义异常
                switch (Month())
                {
                    case 1:case 3:case 5:case 7:case 8:case 10:case 12:
                        if (Day() > 31)
                            throw new MyException("Day is wrong!");
                        break;
                    case 2:
                        if(((Year()%400==0)||(Year()%4==0&&Year()%100!=0))&&Day()>29)
                            throw new MyException("Day is wrong!");
                        else if(Day()>28)
                            throw new MyException("Day is wrong!");
                        break;
                    case 4:case 6:case 9:case 11:
                        if (Day() > 30)
                            throw new MyException("Day is wrong!");
                        break;
                }
                if (Month() < 0 || Day() < 0 || Year() < 0)
                    throw new MyException("Input is wrong!");
                if (Month() > 12)
                    throw new MyException("Month is wrong!");
            }
            catch (MyException me)
            {
                //打印出异常信息
                Console.WriteLine(me.Message);
            }
            return Month() + "/" + Day() + "/" + Year();
        }
    }

    class MyException : ApplicationException
    {
        //自定义异常
        public MyException (string message):base(message)
        {  }
    }
}