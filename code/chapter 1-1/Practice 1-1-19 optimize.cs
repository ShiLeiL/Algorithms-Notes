using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		/* 算法（第四版） 1.1.19 optimize */		
		public  static int a = 100;
		public static long[] record=new long[a];
		public static long F(int N)
		{
			if (N == 0)        return 0;
			if (N == 1)        return 1;
			if(record[N]!=0)   return record[N];
			record[N]=F(N - 1) + F(N - 2);
			return record[N];
		}

		public static void Main(String[] args)
		{
			for (int N = 0; N < a; N++)
			Console.WriteLine(N + " " + F(N));
		}
	}
}