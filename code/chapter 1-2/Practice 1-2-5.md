java代码转换成C#如下：<br>
<br>
string s = "Hello World";<br>
s.ToUpper();　　//在VS上对该方法的直接解释是“返回此字符串转换为大写形式的副本”，故不会对s本身造成影响<br>
s.Substring(6,5);　　//该方法同ToUpper一样返回的是截取字符串的副本，不会对s本身进行截取<br>
Console.WriteLine(s);<br>
Console.ReadKey();<br>
<br>
//最后输出为<br>
//Hello World<br>