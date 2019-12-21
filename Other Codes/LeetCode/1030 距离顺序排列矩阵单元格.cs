//题目：给出 R 行 C 列的矩阵，并给出了一个坐标为 (r0, c0) 的单元格。
//返回矩阵中的所有单元格的坐标，并按到 (r0, c0) 的距离从最小到最大的顺序排。
//例：输入: R = 1, C = 2, r0 = 0, c0 = 0
//   输出: [[0,0],[0,1]]

//这是第一次的提交记录
//执行用时320ms，超过100%的C#提交记录=v=
//思路是通过曼哈顿距离从小到最大进行循环，每次循环向该单元格四周进行记录
//并以横坐标的变化为子循环，保证每个曼哈顿距离的横纵变化都有遍布到

public class Solution {
    public int[][] AllCellsDistOrder(int R, int C, int r0, int c0) 
    {
        int[][] result = new int[R * C][];
        result[0] = new int[] { r0, c0 };//最近的单元格一定是自己本身
        int n = 1;
        for (int i = 1; i < R + C - 1; i++)//曼哈顿距离,从1到坐标轴单元格最大距离
        {
            for (int j = 0; j < i + 1; j++)//横坐标变化距离
            {
                if (r0 - j > -1 && r0 - j < R)//判断当向左移动j未超过边界
                {
                    if (c0 - i + j > -1 && c0 - i + j < C)//判断向上移动i-j未超过边界
                    { result[n++] = new int[] { r0 - j, c0 - i + j }; }
                    if (j != i && c0 + i - j > -1 && c0 + i - j < C)//判断未重复记录并向下移动i-j未超过边界
                    { result[n++] = new int[] { r0 - j, c0 + i - j }; }
                }
                if (j != 0 && r0 + j > -1 && r0 + j < R)//判断未重复记录并当向右移动j未超过边界
                {
                    if (c0 - i + j > -1 && c0 - i + j < C)
                    { result[n++] = new int[] { r0 + j, c0 - i + j }; }
                    if (j != i && c0 + i - j > -1 && c0 + i - j < C)
                    { result[n++] = new int[] { r0 + j, c0 + i - j }; }
                }
            }
        }
        return result;
    }
}