using System;

namespace Mahjong
{
    class WinTheCards
    {
        static void Main(string[] args)
        {
            //题目：简单（单花色）麻将胡牌判断
            //命令行输入任意2、5、8、11、14张已排序的牌
            //牌面大小从1至9，每张牌的个数最多只有4张
            //每副牌只要含有一个对子（AA）、任意对刻子（AAA）、任意对顺子（ABC）即可胡牌
            //编写程序判断输入的牌能否胡牌，能返回yes，不能返回no
            //例子：输入11123455
            //刻子111、顺子234、对子55
            //即输出应为yes
            //这是今天纠结出来的另外的题目，拿此仓库顺便做个记录=v=
            string cards = Console.ReadLine();
            if (cards.Length % 3 != 2)
            {
                Console.WriteLine("Input error");
                Console.ReadKey();
                return;
            }
            int result = Judge(cards);
            if (result == 1) Console.WriteLine("yes");
            else Console.WriteLine("no");
            Console.ReadLine();
        }

        static int Judge(string a)
        {
            //处理输入
            int sum = a.Length;
            string[] cardsGroup = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                cardsGroup[i] = a.Substring(i, 1);
            }
            
            //计字符个数
            int[] counts = new int[10];
            for (int i = 0; i < cardsGroup.Length; i++)
                counts[Convert.ToInt32(cardsGroup[i])]++;

            //判断胡牌
            int result = 0;
            for (int i = 1; i < 10; i++)
            {
                if (counts[i] >= 2)
                {
                    counts[i] -= 2;
                    result = Handle(counts,sum - 2);
                    if (result == 1) return 1;
                    counts[i] += 2;
                }
            }
            return result;
        }

        static int Handle(int[] a,int sum)
        {
            //处理牌方法
            if (sum == 0) return 1;
            for (int i = 1; i < 10; i++)
            {
                if (a[i] == 0) continue;
                if (a[i] == 1 || a[i] == 2 || a[i] == 4)
                {
                    if (a[i + 1] > 0 && a[i + 2] > 0)
                    {
                        a[i]--;
                        a[i + 1]--;
                        a[i + 2]--;                        
                        return Handle(a, sum - 3);
                    }
                    else return 0;
                }
                else
                {
                    a[i] -= 3;
                    return Handle(a, sum - 3);
                }
            }
            return 0;
        }
    }
}

