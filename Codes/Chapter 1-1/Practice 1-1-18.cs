using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		/* 算法（第四版） 1.1.18 */
		public static int mystery(int a, int b) 
		{
			if (b == 0)  return 0;
			if (b % 2 == 0) return mystery(a + a, b / 2);
			return mystery(a + a, b / 2) + a;
		}

		public static int mystery2(int a, int b) 
		{
			if (b == 0)  return 1;
			if (b % 2 == 0) return mystery2(a * a, b / 2);
			return mystery2(a * a, b / 2) * a;
		}
			
		static void Main(string[] args)
		{
			//输出
			Console.WriteLine("mystery(2,25)="+mystery(2,25));
			Console.WriteLine("mystery(3,11)="+mystery(3,11));
			Console.WriteLine("mystery2(2,25)="+mystery2(2,25));
			Console.WriteLine("mystery2(3,11)="+mystery2(3,11));
			Console.ReadKey();
		}
	}
}