using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		/* 算法（第四版） 1.1.15 */
		public static int[] histogram(int[] a,int M)
		{
			int[] b=new int[M];
			for(int i=0;i<a.Length;i++)
			{
				if(a[i]>=0 && a[i]<M)
				{
					b[a[i]]+=1;
				}
			}
			return b;
		}
		static void Main(string[] args)
		{
			int[] num={1,4,4,3,2,2,3,-1,8};
			int N=5;
			int[] count=histogram(num,N);
			foreach(int i in count)
			{
				Console.Write(i+" ");
			}
			Console.ReadKey();
		}
	}
}