using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.3.43 */
            Console.WriteLine("请输入文件夹名：");
            Queue catalog = new Queue();
            string fileName = Console.ReadLine();
            Search(fileName, catalog,-1);
            Console.ReadKey();
        }

        public static void Search(string fileName,Queue Catalog,int deth)
        {
            deth++;//递归深度
            //缩进
            string temp="";
            for (int i = 0; i < deth ; i++)
                temp += "\t";
            
            string input = fileName.Split('\\').Last();//获取文件名
            Catalog.Enqueue(temp+input);

            if (File.Exists(fileName))
                return;//若为文件则直接返回

            string[] Subdirectorys = Directory.GetFileSystemEntries(fileName);//获得子文件列表
            if (Subdirectorys.Length == 0)  
                return;//若该文件夹无子文件则返回                
            for(int i=0;i<Subdirectorys.Length;i++)
            {
                Search(Subdirectorys[i], Catalog,deth);
                while (Catalog.Count!=0)//输出该直线队列里的所有文件
                    Console.WriteLine(Catalog.Dequeue());
            } 
        }
    }
}