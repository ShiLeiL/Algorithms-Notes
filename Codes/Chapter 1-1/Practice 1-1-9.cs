using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		static void Main(string[] args)
		{
			/* 算法（第四版） 1.1.9 */
			int N = 4;

			//按照题目给出的解答以及十进制转换为二进制的原理算法改写
			string s = "";
			for (int n = N; n > 0; n /= 2)
			{
				s = (n % 2) + s;
			}
			Console.WriteLine(s);
			Console.ReadKey();
		}
	}
}