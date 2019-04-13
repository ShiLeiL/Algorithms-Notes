using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		static void Main(string[] args)
		{
			/* 算法（第四版） 1.1.7b */
			int sum = 0;
			for (int i = 1; i < 1000; i++) 
			{
				for (int j = 0; j < i; j++) 
				{
					sum++;
				}
			}
			Console.WriteLine(sum);
			Console.ReadKey();
		}
	}
}