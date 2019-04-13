//快速排序—三向切分
//a[lo...lt-1]中的元素都小于v，a[gt+1...hi]中的元素都大于v
//a[lt..i-1]中的元素都等于v，a[i...gt]中的元素都还未确定
//需要(2lin2)NH次比较，其中H为主键的香农信息量
public class Quick3way
{
    public static void sort(Comparable[] a)
    {
        StdRandom.shuffle(a);  //打乱数组，消除对输入的依赖
        sort(a, 0, a.Length - 1);
    }

    public static void sort(Comparable[] a, int lo, int hi)
    {
        if (hi <= lo) return;
        int lt = lo, i = lo + 1, gt = hi;
        Comparable v = a[lo];
        while(i<=gt)
        {
            int cmp = a[i].compareTo(v);
            if (cmp < 0) exch(a, lt++, i++);
            else if (cmp > 0) exch(a, i, gt--);
            else i++;
        }
        sort(a, lo, lt - 1);
        sort(a, gt + 1, hi);
    }
}