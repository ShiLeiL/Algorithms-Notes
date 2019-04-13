//归并排序-原地归并（merge方法）
//把数组分为两部分，并给予i和j两个指针
//对比i和j指向的元素值，把较小的元素放入a[k]中
public static void merge(Comparable[] a,int lo,int mid,int hi)
{
    int i = lo, j = mid + 1;
    for (int k = lo; k <= hi; k++)
        aux[k] = a[k];  //把所有元素复制到辅助数组

    for (int k = lo; k <= hi; k++)
        if      (i > mid)               a[k] = aux[j++];  //临界判定
        else if (j > hi)                a[k] = aux[i++];  //临界判定
        else if (less(aux[j], aux[i]))  a[k] = aux[j++];
        else                            a[k] = aux[i++];
}


//归并排序-自顶向下
//先将左半部分分割到底再合并并排序，再对右半部分处理
//需要1/2NlgN至NlgN次比较
//最多需要6NlgN次访问数组（2N次复制，2N次移动，最多2N次比较）
//Improve: a.对小规模子数组使用插入排序（例如长度小于15）
//         b.测试数组是否已经有序(a[mid]<=a[mid+1])，若有则跳过merge方法
//         c.不将元素复制到辅助数组（将输入数组排序到辅助数组、将辅助数组排序到输入数组）
public class Merge
{
    private static Comparable[] aux; //辅助数组，merge函数用到

    public static void sort(Comparable[] a)
    {
        aux = new Comparable[a.Length];
        sort(a, 0, a.Length - 1);
    }

    private static void sort(Comparable[] a,int lo,int hi)
    {
        if (hi <= lo) return;
        int mid = lo + (hi - lo) / 2;
        sort(a, lo, mid);
        sort(a, mid + 1, hi);
        merge(a, lo, mid, hi);  //原地归并
    }
}


//归并排序-自顶向上
//先将数组一个一个合并，再两个两个合并，以此类推
//需要1/2NlgN至NlgN次比较，最多6NlgN次访问数组
//适合用链表组织的数据
public class MergeBU
{
    private static Comparable[] aux; //辅助数组

    private static void sort(Comparable[] a)
    {
        int N = a.Length;
        aux = new Comparable[N];
        for (int sz = 1; sz < N; sz = sz + sz)
            for (int lo = 0; lo < N - sz; lo += sz + sz)
                //原地归并
                merge(a, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, N - 1));
    }
}