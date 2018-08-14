using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		/* 算法（第四版） 1.1.14 */
		//本程序暂不考虑虚数情况，待以后补充
		public static int lg(int N)
		{
			int pow=1;
			int i;
			for(i=0;pow<N;i++)
			{
				pow*=2;
			}
			return i;
		}
		static void Main(string[] args)
		{
			int a =1025;
			int b =lg(a);
			Console.WriteLine(b);
			Console.ReadKey();
		}
	}
}