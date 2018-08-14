using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		static void Main(string[] args)
		{
			/* 算法（第四版） 1.1.2 */
			var a = ( 1 + 2.236 ) / 2;
			var b = 1 + 2 + 3 + 4.0;
			var c = (4.1 >= 4);
			var d = 1 + 2 + "3";
			Console.WriteLine("a."+a.GetType()+"\t"+a);
			Console.WriteLine("b."+b.GetType()+"\t"+b);
			Console.WriteLine("c."+c.GetType()+"\t"+c);
			Console.WriteLine("d."+d.GetType()+"\t"+d);
			Console.ReadKey();
		}
	}
}