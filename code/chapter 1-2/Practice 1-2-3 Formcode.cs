using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        /* 算法（第四版） 1.2.3 */

        public static Form1 form1;

        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//按下按钮
            int N = Convert.ToInt32(textBox1.Text);
            int min = Convert.ToInt32(textBox2.Text);
            int max = Convert.ToInt32(textBox3.Text);
            Point2D.PointC(N,max,min);
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//按下按钮
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.Black);
            g.Dispose();
        }
    }

    public class Point2D
    {
        public static void PointC(int N,int max,int min)
        {
            Graphics g = Form1.form1.panel1.CreateGraphics();
            g.DrawRectangle(Pens.Blue, 110, 165, 200, 200);//画矩形（笔刷，左上角点的位置，宽，高）
            int[][] rect = Rect(N, min, max);
            OperateRect(g,rect);
            g.Dispose();
        }

        private static int[][] Rect(int N,int min,int max)
        {
            //处理矩形
            int[][] rect = new int[N][];
            Random k = new Random(Guid.NewGuid().GetHashCode());
            int temp = 0;
            for (int i = 0; i < N; i++)
            {
                rect[i] = new int[4];
                rect[i][0] = 110 + k.Next(1, 200);
                rect[i][1] = 165 + k.Next(1, 200);
                if ((rect[i][0] > 310 - max || rect[i][0] < 110 + max) && (rect[i][1] > 365 - max || rect[i][0] < 165 + max))
                {
                    temp = 310 - rect[i][0];
                    int temp2= 365 - rect[i][1];
                    if (temp > min && temp2>min)
                    {
                        rect[i][2] = k.Next(min, temp);
                        rect[i][3] = k.Next(min, temp2);                       
                        continue;
                    }
                    i--; continue;
                }
                if (rect[i][0] > 310 - max || rect[i][0] < 110 + max)
                {
                    temp = 310 - rect[i][0];
                    if (temp > min)
                    {
                        rect[i][2] = k.Next(min, temp);
                        rect[i][3] = k.Next(min, max);
                        continue;
                    }
                    i--; continue;
                }
                if (rect[i][1] > 365 - max || rect[i][0] < 165 + max)
                {
                    temp = 365 - rect[i][1];
                    if (temp > min)
                    {
                        rect[i][2] = k.Next(min, max);
                        rect[i][3] = k.Next(min, temp);
                        continue;
                    }
                    i--; continue;
                }
                rect[i][2] = k.Next(min, max);
                rect[i][3] = k.Next(min, max);
            }
            return rect;
        }

        private static void OperateRect(Graphics g,int[][] rect)
        {           
            int intercounts = 0;
            int containcounts = 0;
            for (int i=0;i<rect.Length;i++)
            {
                g.DrawRectangle(Pens.Gray,rect[i][0], rect[i][1], rect[i][2], rect[i][3]);//画出矩阵
                for (int j = i + 1; j < rect.Length; j++)
                {
                    //计算相交和包含的数量（包含算一种特殊的相交）
                    if (Intersect(rect[i], rect[j])) intercounts++;
                    if (Contain(rect[i], rect[j])) containcounts++;
                    if (Contain(rect[j], rect[i])) containcounts++;
                }
            }

            g.DrawString($"相交的数量为：{intercounts}", new Font("New Timer", 8), Brushes.White, new PointF(160,385));
            g.DrawString($"包含的数量为：{containcounts}", new Font("New Timer", 8), Brushes.White, new PointF(160, 405));
        }

        private static bool Intersect(int[] a,int[] b)
        {
            //以两个矩形的中点进行相交判断
            //思路来源https://www.cnblogs.com/avril/archive/2012/11/13/2767577.html
            if (Math.Abs(b[0]+b[2]/2-a[0]-a[2]/2) <= (a[2] / 2 + b[2] / 2)
                && Math.Abs(b[1] + b[3] / 2 - a[1] - a[3] / 2) <= (a[3] / 2 + b[3] / 2)) return true;
            return false;
        }

        private static bool Contain(int[] a,int[] b)
        {
            //以四个点进行包含判断
            if ((b[0] >= a[0] && b[0] <= a[0] + a[2]) && (b[0] + b[2] >= a[0] && b[0] + b[2] <= a[0] + a[2]))
            {
                if ((b[1] >= a[1] && b[1] <= a[1] + a[3]) && (b[1] + b[3] >= a[1] && b[1] + b[3] <= a[1] + a[3]))
                    return true;
            }
            return false;
        }
    }
}
