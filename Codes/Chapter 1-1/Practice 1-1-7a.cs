using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		static void Main(string[] args)
		{
			/* 算法（第四版） 1.1.7a */
			double t = 9.0;
			while (Math.Abs(t - 9.0 / t) > .001)
				t = (9.0 / t + t) / 2.0;
			Console.WriteLine("{0:F5}",t);
			Console.ReadKey();
		}
	}
}