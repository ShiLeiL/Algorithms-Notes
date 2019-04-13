using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		/* 算法（第四版） 1.1.16 */
		public static string exR1(int n)
		{
			if (n <= 0)  return "";
			return exR1(n - 3) + n + exR1(n - 2) + n;
		}
			
		static void Main(string[] args)
		{
			//输出
			Console.WriteLine(exR1(6));
			Console.ReadKey();
		}
	}
}