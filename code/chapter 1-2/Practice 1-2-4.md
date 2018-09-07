java代码转换成C#如下：<br>
<br>
string string1 = "hello";　　//因为string为引用类型，即该语句意为，让变量string1指向"hello"<br>
string string2 = string1;　　//复制string1的引用，让string2也指向"hello"<br>
string1 = "world";　　　　　　//让string1指向"world"<br>
Console.WriteLine(string1);<br>
Console.WriteLine(string2);<br>
Console.ReadKey();<br>
<br>
//最后输出为<br>
//word<br>
//hello<br>