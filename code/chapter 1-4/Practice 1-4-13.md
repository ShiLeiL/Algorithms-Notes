a.Accumulator<br>
该数据类型的官网代码为：<br>
public class Accumulator <br>
{<br>
    private int n = 0;<br>          
    private double sum = 0.0;<br>   
    private double mu = 0.0;<br>
...<br>
}<br>
则一个Accumulator对象需要使用40字节<br>
其中16字节的对象开销，4字节用于int实例变量，2个8字节用于double实例变量，以及4个填充字节。<br>
<br>
b.Transaction<br>
该数据类型的官网代码为：<br>
public class Transaction implements Comparable<Transaction><br>
{<br>
    private final String  who;<br>
    private final Date    when;<br>   
    private final double  amount;<br>
...<br>
}<br>
则一个Transaction对象需要使用40字节<br>
其中16字节的对象开销，8字节用于string实例变量（一个引用），8字节用于Date实例变量（一个引用），8字节用于double实例变量。<br>
<br>
c.FixedCapacityStackOfStrings，其容量为C且含有N个元素<br>
该数据类型的官网代码为：<br>
public class FixedCapacityStackOfStrings implements Iterable<String><br> 
{<br>
    private String[] a;<br>
    private int N;<br>
...<br>
}<br>
则一个FixedCapacityStackOfStrings对象需要使用32字节<br>
其中16字节的对象开销，8字节用于string数组实例变量（一个引用），4字节用于int实例变量，以及4个填充字节。<br>
<br>
d.Point2D<br>
该数据类型的官网代码为：<br>
public final class Point2D implements Comparable<Point2D><br>
{<br>
...<br>
    private final double x;<br>
    private final double y;<br>
...<br>
}<br>
则一个Point2D对象需要使用32字节<br>
其中16字节的对象开销，2个8字节用于double实例变量。<br>
<br>
e.Interval1D<br>
该数据类型的官网代码为：<br>
public final class Interval1D<br>
{<br>
...<br>
    private final double min;<br>
    private final double max;<br>
...<br>
}<br>
则一个Interval1D对象需要使用32字节<br>
其中16字节的对象开销，2个8字节用于double实例变量。<br>
<br>
f.Interval2D<br>
该数据类型的官网代码为：<br>
public class Interval2D 
{
    private final Interval1D x;
    private final Interval1D y;
}<br>
则一个Transaction对象需要使用32字节<br>
其中16字节的对象开销，2个8字节用于Interval1D实例变量（一个引用）。<br>
<br>
g.Double<br>
一个Double对象需要使用24字节<br>
其中16字节的对象开销，8字节用于double实例变量。<br>