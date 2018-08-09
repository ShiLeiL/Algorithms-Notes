using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		static void Main(string[] args)
		{
			/* 算法（第四版） 1.1.6 */
			Random rd = new Random();
			double a = rd.Next();
			double b = rd.Next();
			if(a>0 && a<1 && b>0 && b<1)
			{
				Console.WriteLine("true");
			}
			else
			{
				Console.WriteLine("false");
			}
			Console.ReadKey();
		}
	}
}