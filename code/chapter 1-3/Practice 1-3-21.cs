public bool find(string key)
{
    /* 算法（第四版） 1.3.21 */
    Node temp = first;
    T result = (T)Convert.ChangeType(key, typeof(T));//把目标值转换为T类型
    while (true)
    {
        if (temp.item.Equals(result))
            return true;
        if (temp.next == null)
            break;
        temp = temp.next;
    }
    return false;
}