代码如下：<br>
<br>
Stack<string> stack = new Stack<string>();<br>
while(!q.isEmpty())<br>
　　stack.push(q.dequeue());<br>
while(!stack.isEmpty())<br>
　　q.enqueue(stack.pop());<br>
<br>
//上面的程序是利用栈翻转队列顺序<br>
//先依次把队列表头元素压入栈直到队列为空后，再把栈里的所有元素添加到队列中<br>
//这样最后压入栈的原来的队尾就会成为队列的新表头<br>