using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        /* 算法（第四版） 1.2.1 */
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//按下按钮
            Graphics g = panel1.CreateGraphics();
            int N = Convert.ToInt32(textBox1.Text);
            g.DrawRectangle(Pens.Blue,110,165,200,200);//画矩形（笔刷，左上角点的位置，宽，高）

            //随机生成点
            Point[] points = new Point[N];
            for (int i = 0; i < N; i++)
            {
                Random k = new Random(Guid.NewGuid().GetHashCode());
                points[i].X = (int)(110 + k.Next(1,200));
                points[i].Y = (int)(165 + k.Next(1, 200));
                g.FillEllipse(Brushes.White, points[i].X, points[i].Y, 3, 3);//画点
            }

            //画最短线
            int mina = 0;
            int minb = 0;
            double minl = 999;
            for (int i = 0; i < N; i++)
            {
                for (int j = i+1; j < N; j++)
                {
                    if(PointLength(points[i],points[j])<minl)//比较两点间的距离与最小距离
                    {
                        mina = i;
                        minb = j;
                        minl = PointLength(points[i], points[j]);
                    }
                }
            }
            g.DrawLine(Pens.Gray, points[mina], points[minb]);//画最短线
            g.DrawString($"{minl:n}", new Font("New Timer", 8), Brushes.White, new PointF(points[mina].X + 5, points[mina].Y + 5));

            g.Dispose();
        }

        private double PointLength(Point a,Point b)
        {
            //计算两点间的距离
            int xdiff = Math.Abs(a.X - b.X);
            int ydiff = Math.Abs(a.Y-b.Y);
            return Math.Sqrt(Math.Pow(xdiff, 2) + Math.Pow(ydiff, 2));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//按下按钮
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.Black);
            g.Dispose();
        }
    }
}
