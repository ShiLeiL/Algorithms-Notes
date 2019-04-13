public bool find(string key)
{
    /* 算法（第四版） 1.3.21 */
    Node temp = first;
    T result = (T)Convert.ChangeType(key, typeof(T));//把目标值转换为T类型
    while (temp != null)
    {
        if (temp.item.Equals(result))
            return true;
        temp = temp.next;
    }
    return false;
}