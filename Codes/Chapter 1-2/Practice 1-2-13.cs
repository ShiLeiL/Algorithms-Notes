using System;

namespace AlgorithmsApplication
{
    /* 算法（第四版） 1.2.13 */
    class Date
    {
        private readonly int month;
        private readonly int day;
        private readonly int year;

        public Date(int m, int d, int y)
        { month = m; day = d; year = y; }

        public Date(string date)
        {
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
            string[] inPut = transaction.Split('\n');
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
    }
}