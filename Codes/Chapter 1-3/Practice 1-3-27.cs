public static int max(Algorithms<int>.Node first)
{
    /* 算法（第四版） 1.3.27 */
    if (first == null)
        return 0;
    int max = 0;
    Algorithms<int>.Node temp = first;//存储当前结点
    while(temp!=null)
    {
        if (temp.item > max)
            max = temp.item;
        temp = temp.next;
    }
    return max;
}