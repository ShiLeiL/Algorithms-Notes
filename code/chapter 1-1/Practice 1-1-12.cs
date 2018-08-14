using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		static void Main(string[] args)
		{
			/* 算法（第四版） 1.1.12 */
			int[] a = new int[10];
			for (int i = 0; i < 10; i++) 
			{
				a[i] = 9 - i;
			}
			for (int i = 0; i < 10; i++) 
			{
				a[i] = a[a[i]];//a[]={0,1,2,3,4,4,3,2,1,0}
			}

			for (int i = 0; i < 10; i++) 
			{
				Console.WriteLine(i);//输出为"0,1,2,3,4,5,6,7,8,9" 实际输出逗号替换成换行
			}		
			Console.ReadKey();
		}
	}
}