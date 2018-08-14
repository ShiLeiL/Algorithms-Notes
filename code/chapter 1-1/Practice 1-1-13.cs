using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		/* 算法（第四版） 1.1.13 */
		public static void transpositionArray(int[,] tranArray)
		{
		    int rows = tranArray.GetLength(0);//获取行数
		    int columns = tranArray.GetLength(1);//获取列数

		    //转置数组并打印
		    for(int i=0;i<columns;i++)
		    {
		    	for(int j=0;j<rows;j++)
		    	{
		    		Console.Write("{0}\t",tranArray[j,i]);
		    	}
		    	Console.WriteLine();
		    }
		}
		
		static void Main(string[] args)
		{
			//测试，创建一个数组
			int[,] a=new int[4,3]{
				{ 1,2,3 }, 
				{ 4,5,6 },
				{ 7,8,9 },
				{ 11,12,13 }};
			transpositionArray(a);
			Console.ReadKey();
		}
	}
}