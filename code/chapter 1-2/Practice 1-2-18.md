代码如下：<br>
public class Accumulator<br>
{<br>
　　private double m;<br>
　　private double s;<br>
　　private int N;<br>
<br>
　　public void addDataValue(double x)<br>
　　{<br>
　　　　N++;<br>
　　　　s = s + 1.0 * (N - 1) / N * (x - m) * (x - m);<br>
　　　　m = m + (x - m) / N;//平均值<br>
　　}<br>
<br>
　　public double mean()<br>
　　{ return m; }<br>
<br>
　　public double var()//方差<br>
　　{ return s / (N - 1); }<br>
<br>
　　public double stddev()//标准差<br>
　　{ return Math.Sqrt(this.var()); }<br>
}<br>
<br>
在C#语言中，double类型的存储方式遵从IEEE规范，占64bit。<br>
其存储方式是用二进制的科学计数法来存储的，即分为符号、指数和尾数来进行储存。<br>
double的精度是由尾数的位数来决定的，其尾数站52bit，即double的精度为15~16位有效数字。<br>
当使用所有数据的平方求和的方法来求方差时，当结果的数字长度大于16位之后，底数的整数部分每增加一位数字长度，相对的就会减少底数小数部分的有效数字，对最后一位进行四舍五入，指数增加1，从而丢失精度产生误差。<br>
而上面的代码中的s是根据已输入的值的平均值来进行已输入的值的平方和求和，结果的整数部分长度变化相对直接求和来说浮动不会那么大，对比来说减少了底数丢失小数而产生的误差。