//希尔排序
//在插入排序中引入递增序列h的概念
//让每次循环以h的间距跳跃对比数据，以此让数组达到h有序
//减少h=1时，对比和交换的次数
public class Shell
{
    public static void sort(Comparable[] a)
    {
        int N = a.Length;
        int h = 1;
        while (h < N / 3)
            h = 3 * h + 1;
        while(h>=1)
        {
            for(int i=h;i<N;i++)
            {
                for (int j = i; j >= h && less(a[j], a[j - h]); j -= h)
                    exch(a, j, j - h);
            }
            h = h / 3;
        }
    }
}