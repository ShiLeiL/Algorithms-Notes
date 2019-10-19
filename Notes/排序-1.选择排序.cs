//选择排序
//每次遍历i到N-1，把第i+1小的数放到a[i]中
//每次循环记录a[i]的值，若遍历的数比其小，则交换
//大约N^2/2次比较和N次交换
//
//ps.  a.运行时间和输入无关  
//     b.数据移动最少
public class Selection
{
    public static void sort(Comparable[] a)
    {
        int N = a.Length;
        for(int i=0;i<N;i++)
        {
            int min = i;  
            for (int j = i + 1; j < N; j++)
                if (less(a[j], a[min]))  //a[j]是否比a[min]小
                    min = j;
            exch(a, i, min);  //交换a数组中i和min的值
        }
    }
}