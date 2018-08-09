using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		static void Main(string[] args)
		{
			/* 算法（第四版） 1.1.6 */
		static void Main(string[] args)
		{
			int f = 0;
			int g = 1;
			for (int i = 0; i <= 15; i++) 
			{
				Console.WriteLine(f);
				f = f + g;
				g = f - g;
			}
		}
	}
}