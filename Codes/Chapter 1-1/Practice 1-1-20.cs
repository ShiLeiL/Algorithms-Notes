using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		/* 算法（第四版） 1.1.20 */
		public static double factorial(int N)
		{
			if (N > 0)	return factorial(N - 1)+Math.Log(N);
			return 0;
		}

		public static void Main(String[] args)
		{
			//测试，创建一个整数
			double a = factorial(5);
			Console.WriteLine(a);
			Console.ReadKey();
		}
	}
}