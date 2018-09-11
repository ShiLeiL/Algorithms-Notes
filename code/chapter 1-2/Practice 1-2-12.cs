using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.2.12 */
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
            Console.WriteLine(date.dayOfTheWeek());//打印星期
            Console.ReadKey();
        }
    }

    class SmartDate
    {
        private readonly int month;
        private readonly int day;
        private readonly int year;
        private readonly int week;

        public SmartDate(int m, int d, int y)
        {
            month = m; day = d; year = y;
            //运用蔡勒公式计算星期
            week = (year % 100 + (int)Math.Truncate(year % 100 / 4.0) - 35 + (int)Math.Truncate(26 * (month + 1) / 10.0) + day - 1) % 7;
            if (week < 0) week = 7 + week;//若取余结果为负，则+7取正
        }

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
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        if (Day() > 31)
                            throw new MyException("Day is wrong!");
                        break;
                    case 2:
                        if (((Year() % 400 == 0) || (Year() % 4 == 0 && Year() % 100 != 0)) && Day() > 29)
                            throw new MyException("Day is wrong!");
                        else if (Day() > 28)
                            throw new MyException("Day is wrong!");
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
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

        public string dayOfTheWeek()
        {
            if (year < 2001 || year > 2100)
                return "This is not twenty-first Century!";
            switch (week)
            {
                case 0:
                    return "Sunday";
                case 1:
                    return "Monday";
                case 2:
                    return "Tuesday";
                case 3:
                    return "Wednesday";
                case 4:
                    return "Thursday";
                case 5:
                    return "Friday";
                case 6:
                    return "Saturday";
            }
            return "false";
        }
    }

    class MyException : ApplicationException
    {
        //自定义异常
        public MyException(string message) : base(message)
        { }
    }
}