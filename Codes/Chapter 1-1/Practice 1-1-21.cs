using System;
namespace AlgorithmsApplication
{
	class Algorithms
	{
		/* 算法（第四版） 1.1.21 */
		public static void inputf(string[,] N,int a)
		{
			//输入
			for(int i=0;i<a;i++)
			{
				Console.WriteLine("请输入名字");
				N[i,0]=Console.ReadLine();
				Console.WriteLine("请输入整数成绩1");
				N[i,1]=Console.ReadLine();
				Console.WriteLine("请输入整数成绩2");
				N[i,2]=Console.ReadLine();
				
				//计算成绩3并转换回string
				int date1=Convert.ToInt32(N[i,1]);
				int date2=Convert.ToInt32(N[i,2]);
				double date3=Math.Round((double)date1/(double)date2, 3);
				N[i,3]=date3.ToString();
			}
		}

		public static void printf(string[,] N,int a)
		{
			//输出
			//输出表头
			Console.WriteLine();
			Console.WriteLine("\t名字\t成绩1\t成绩2\t成绩3");

			//输出表格
			for(int i=0;i<a;i++)
			{
				Console.WriteLine();
				for(int j=0;j<4;j++)
				{
					Console.Write("\t{0}",N[i,j]);
				}
			}
		}

		public static void Main(String[] args)
		{
			int numbers=5;
			string[,] students=new string[numbers,4];
			inputf(students,numbers);
			printf(students,numbers);
			Console.ReadKey();
		}
	}
}