public static int max(Algorithms<int>.Node first)
{
    /* 算法（第四版） 1.3.28 */
    if (first == null)
        return 0;
    if (first.item > max(first.next))
        return first.item;
    return max(first.next);
}