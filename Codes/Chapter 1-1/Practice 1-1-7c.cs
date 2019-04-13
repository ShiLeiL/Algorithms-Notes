using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		static void Main(string[] args)
		{
			/* 算法（第四版） 1.1.7c */
			int sum = 0;
			for (int i = 1; i < 1000; i *= 2) 
			{
				for (int j = 0; j < 1000; j++) 
				{
					sum++;
				}
			}
			Console.WriteLine(sum);
			Console.ReadKey();
		}
	}
}