using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		/* 算法（第四版） 1.1.19 */
		public static long F(int N)
		{
			if (N == 0)    return 0;
			if (N == 1)    return 1;
			return F(N - 1) + F(N - 2);
		}

		public static void Main(String[] args)
		{
			for (int N = 0; N < 100; N++)
			Console.WriteLine(N + " " + F(N));
		}
	}
}