using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgorithmsApplication
{
    public partial class Form1 : Form
    {
        /* 算法（第四版） 1.1.31 */
        //C#跟java不太一样，所以用winform画的图
        //参考了https://alg4.ikesnowy.com/1-1-31/ 和无数网络资料
        //因为是这两天新学的winform，如果出错和遗漏，欢迎大家指正
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//按下按钮
            Graphics g = panel1.CreateGraphics();
            int N = Convert.ToInt32(textBox1.Text);
            double p = Convert.ToDouble(textBox2.Text);
            g.DrawEllipse(Pens.Blue, 110, 155, 200, 200);//画圆（笔刷，圆心位置，宽，高）

            //计算点坐标并画点
            Point[] points = new Point[N];
            for (int i = 0; i < N; i++)
            {
                double dgrees = 2 * i * Math.PI / N;
                points[i].X = (int)(210 + 100*Math.Cos(dgrees));
                points[i].Y = (int)(255 + 100*Math.Sin(dgrees));
                g.FillEllipse(Brushes.White, points[i].X, points[i].Y, 3f, 3f);//画点

            }

            //画线
            int accuracy = 10000;
            Random r = new Random();
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    if (r.Next(0, accuracy) <= p * accuracy)
                    {
                        g.DrawLine(Pens.Gray, points[i], points[j]);
                    }
                }

            }
            g.Dispose();
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
