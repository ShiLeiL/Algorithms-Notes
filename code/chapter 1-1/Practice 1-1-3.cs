using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		static void Main(string[] args)
		{
			/* 算法（第四版） 1.1.3 */
			Random rd = new Random();
			int a = rd.Next();
			int b = rd.Next();
			int c = rd.Next();
			if(a==b && a==c)
			{
				Console.WriteLine("equal");
			}
			else
			{
				Console.WriteLine("not equal");
			}
			Console.ReadKey();
		}
	}
}