using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		static void Main(string[] args)
		{
			/* 算法（第四版） 1.1.1 */
			var a = ( 0 + 15 ) / 2;
			var b = 2.0e-6 * 1000000.1;
			var c = true && false || true && true;
			
			Console.WriteLine("a."+a);
			Console.WriteLine("b."+b);
			Console.WriteLine("c."+c);
			Console.ReadKey();
		}
	}
}