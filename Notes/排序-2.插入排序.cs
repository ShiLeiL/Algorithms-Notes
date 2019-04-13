//插入排序
//每次循环把a[i]跟左边已经排好序的数据进行递减对比
//一旦比当前对比的左边数据小，就进行交换，直至比左边大
//平均N^2/4次比较和交换
public class Insertion
{
    public static void sort(Comparable[] a)
    {
        int N = a.Length;
        for(int i=1;i<N;i++)
        {
            for (int j = i; j > 0 && less(a[j], a[j - 1]); j--)
                exch(a, j, j - 1);
        }
    }
}