public Stack(Stack<T> s)
{
    /* 算法（第四版） 1.3.42 */
    Stack<T> temp = new Stack<T>();
    while (!s.isEmpty())
        temp.push(s.peek());
    while (!temp.isEmpty())
        push(temp.peek());
}