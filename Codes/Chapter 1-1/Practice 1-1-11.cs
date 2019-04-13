using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		/* 算法（第四版） 1.1.11 */
		public static void printBoolArray(bool[,] boolArray)
		{
			int rows = boolArray.GetLength(0);//获取行数
			int columns = boolArray.GetLength(1);//获取列数

			//输出列号
			for(int i=0;i<columns;i++)
			{
				Console.Write("\t{0}",i+1);
			}

			//输出行号以及数组
			for(int j=0;j<rows;j++)
			{
				Console.Write("\n{0}\t",j+1);//输出行号
				for(int i=0;i<columns;i++)
				{
					if(boolArray[j,i]==true)//输出数组
					{
						Console.Write("*\t");
					}
					else
					{
						Console.Write(" \t");
					}
				}
			}
		}
		
		static void Main(string[] args)
		{
			//测试，创建一个数组
			bool[,] a=new bool[4,3]{
				{ true, false, true }, 
				{ false, true, false },
				{ true, true, true },
				{ true, true, false }};
			printBoolArray(a);
			Console.ReadKey();
		}
	}
}