//快速排序
//打乱数组，切分并排序，缩小区间继续切分
//平均需要2NlnN次比较（以及1/6的交换）
public class Quick
{
    public static void sort(Comparable[] a)
    {
        StdRandom.shuffle(a);  //打乱数组，消除对输入的依赖
        sort(a, 0, a.Length - 1);
    }

    public static void sort(Comparable[] a, int lo, int hi)
    {
        if (hi <= lo) return;
        //切分，以j为中点，左边都小于a[j]，右边都大于a[j]
        int j = partition(a, lo, hi); 
        sort(a, lo, j - 1);
        sort(a, j + 1, hi);
    }

    private static int partition(Comparable[] a, int lo, int hi)
    {
        int i = lo, j = hi + 1;
        Comparable v = a[lo];  //切分元素
        while(true)
        {
            //扫描左边，若i指向的当前元素大于v或i指针超出边界，则停止
            while (less(a[++i, v])) if (i == hi) break;
            //扫描右边，若j指向的当前元素小于v或j指针超出边界，则停止 
            while (less(v, a[--j])) if (j == lo) break; 
            if (i >= j) break;  //若i超过j，扫描重叠，退出整个循环
            exch(a, i, j); 
        }
        exch(a, lo, j);  //把切分元素放到中间
        return j;
    }
}

//快排改进
//a.在排序小数组时切换到插入排序
//  把sort()中的if (hi <= lo) return;
//  改成if (hi <= lo + M) { Insertion.sort(a, lo, hi); return;
//  转换参数M最佳值和系统相关，一般为5~15 
//
//b.三取样切分
//  取三个元素的中位数作为切分元素
//  （还可以将取样元素放在数组末尾作为“哨兵”来去掉partition()中的边界验证）
//
//c.三向切分（见下一排序）