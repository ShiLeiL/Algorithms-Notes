public static void remove<T>(Algorithms<T> line,string key)
{
    /* 算法（第四版） 1.3.26 */
    Algorithms<T>.Node temp1 = line.first;
    Algorithms<T>.Node temp2 = null;
    T result = (T)Convert.ChangeType(key, typeof(T));//把目标值转换为T类型
    while (true)
    {
        if (temp1 == null)
            break;
        if (temp1.item.Equals(result))
        {
            if(temp2==null)
            {
                line.first=line.first.next;
                temp1 = line.first;
                continue;
            }
            temp2.next = temp1.next;
            temp1 = temp2;
        }
        temp2 = temp1;
        temp1 = temp1.next;
    }
}