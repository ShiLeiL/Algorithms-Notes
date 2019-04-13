using System;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    /* 算法（第四版） 1.3.17 */
    class Date
    {
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

        public int Month()
        { return month; }

        public int Day()
        { return day; }

        public int Year()
        { return year; }

        public string toString()
        { return Month() + "/" + Day() + "/" + Year(); }
    }

    class Transaction
    {
        private readonly string name;
        private readonly Date dates;
        private readonly double amounts;

        public Transaction(string who, Date when, double amount)
        { name = who; dates = when; amounts = amount; }

        public Transaction(string transaction)
        {
            //1.2.19部分
            string[] inPut = transaction.Split(' ');
            name = inPut[0];
            dates = new Date(inPut[1]);
            amounts = Convert.ToDouble(inPut[2]);
        }

        public string Who()
        { return name; }

        public Date When()
        { return dates; }

        public double Amount()
        { return amounts; }

        public string toString()
        { return Who() + "\n" + When().toString() + "\n" + Amount(); }

        public bool Tequals(object that)
        {
            if (that == this) return true;
            if (that == null) return false;
            if (that.GetType() != GetType()) return false;
            Transaction thatTran = (Transaction)that;
            return (thatTran.Who() == Who()) &&
                (thatTran.When() == When()) &&
                (thatTran.Amount() == Amount());
        }

        public int compareTo(Date that)
        {
            if ((that.Year() * 512 + that.Month() * 4 + that.Day()) > (When().Year() * 512 + When().Month() * 4 + When().Day()))
                return 1;
            if ((that.Year() * 512 + that.Month() * 4 + that.Day()) < (When().Year() * 512 + When().Month() * 4 + When().Day()))
                return -1;
            else return 0;
        }

        public int hashCode()
        { return toString().GetHashCode(); }

        public static Transaction[] readTransactions()
        {
            //1.3.17部分
            Console.WriteLine("请输入字符串组：(一行一个记录，以输入0为结束）");
            Queue<Transaction> transaction = new Queue<Transaction>();
            while (true)
            {
                string temp1 = Console.ReadLine();
                if (temp1 == "0") break;
                Transaction temp2 = new Transaction(temp1);
                transaction.Enqueue(temp2);
            }

            int N = transaction.Count;
            Transaction[] a = new Transaction[N];
            for (int i = 0; i < N; i++)
                a[i] = transaction.Dequeue();
            return a;
        }
    }
}