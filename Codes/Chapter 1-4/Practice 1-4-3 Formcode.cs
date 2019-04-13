using System;
using System.Drawing;
using System.Windows.Forms;

namespace _1._4._3
{
    public partial class Form1 : Form
    {
        /* 算法（第四版） 1.4.3 */
        //8000以上的数据已经要很久了，所以截图只有到4000的
        //自适应待下周添加
        public static Form1 form1;

        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//按下按钮
            foreach(Control test in panel1.Controls)
            {
                if (test is Label)
                    test.Visible = true;
            }
            int N = Convert.ToInt32(textBox1.Text);
            int max = Convert.ToInt32(textBox2.Text);
            Draw(N, max);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//按下按钮
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.Black);
            foreach (Control test in panel1.Controls)
            {
                if (test is Label && test.Name!="label1"&& test.Name != "label2")
                    test.Visible = false;
            }
            form1.label3.Text = "数组长度\n\n";
            form1.label4.Text = "耗时(s)\n\n";
            g.Dispose();
        }

        public static void Draw(int N, int max)
        {
            Graphics g = form1.panel1.CreateGraphics();

            //画坐标轴
            g.DrawLine(Pens.White, 210, 400, 410, 400);
            g.DrawLine(Pens.White, 210, 100, 210, 400);
            g.DrawLine(Pens.White, 460, 400, 660, 400);
            g.DrawLine(Pens.White, 460, 100, 460, 400);

            //画原点刻度
            g.DrawString("0", new Font("New Timer", 8), Brushes.White, new PointF(200, 405));//原点刻度
            g.DrawString("0", new Font("New Timer", 8), Brushes.White, new PointF(450, 405));//原点刻度
            int count = Convert.ToInt32(Math.Sqrt(max / N)) + 1;//数据个数
            int section = 200 / Convert.ToInt32(Math.Pow(2, count - 1));//横刻度单位长度

            //计算结果
            double[] times = new double[count];//记录T(N)
            double[] lg = new double[count];//记录lg(T(N))
            for (int i = N, j = 0; i <= max; i += i, j++)
            {
                times[j] = DoublingTest.timeTrial(i);
                lg[j] = Math.Log10(times[j]);
                form1.label3.Text += " " + i + "\n\n";
                form1.label4.Text += " " + times[j] + "\n\n";
                g.DrawString($"{(double)i / 1000}k", new Font("New Timer", 8), Brushes.White, new PointF(190 + i / N * section, 405));//图1横刻度               
            }

            //根据结果画纵刻度
            int timer = Convert.ToInt32(Math.Ceiling(times[count - 1] / 6));
            double lger = lg[count - 1] / 6;
            for (int i = 1; i < 7; i++)
            {
                g.DrawString($"{i * timer}", new Font("New Timer", 8), Brushes.White, new PointF(185, 400 - i * 45));//图1纵刻度
                g.DrawString($"{i * lger:F1}", new Font("New Timer", 8), Brushes.White, new PointF(435, 400 - i * 45));//图2纵刻度
            }

            Point[] points1 = new Point[count];//图1点
            Point[] points2 = new Point[count];//图2点
            for (int i = 0; i < count; i++)
            {
                points1[i].X = (int)(190 + Math.Pow(2, i) * section);
                points1[i].Y = (int)(400 - times[i] / timer * 45);
                points2[i].X = 440 + (i + 1) * 200 / count;
                points2[i].Y = (int)(400 - lg[i] / lger * 45);
                g.FillRectangle(Brushes.Gray, points1[i].X, points1[i].Y, 3f, 3f);//画图1点
                g.FillRectangle(Brushes.Gray, points2[i].X, points2[i].Y, 3f, 3f);//画图2点
                g.DrawString($"{Math.Pow(2, i) * N / 1000}k", new Font("New Timer", 8), Brushes.White, new PointF(points2[i].X, 405));//图2横刻度
            }
            g.DrawCurve(Pens.White, points1);
            g.DrawLines(Pens.White, points2);
            g.Dispose();
        }
    }

    public class ThreeSum
    {
        /* 算法（第四版） 1.4.2 */
        public static int count(int[] a)
        {
            //统计和为0的元组的数量
            int N = a.Length;
            int cnt = 0;
            for (int i = 0; i < N; i++)
                for (int j = i + 1; j < N; j++)
                    for (int k = j + 1; k < N; k++)
                        if ((long)a[i] + a[j] + a[k] == 0)
                            cnt++;
            return cnt;
        }
    }

    public class DoublingTest
    {
        public static double timeTrial(int N)
        {
            int Max = 1000000;
            Random r = new Random();
            int[] a = new int[N];
            for (int i = 0; i < N; i++)
                a[i] = r.Next(-Max, Max);
            DateTime now = DateTime.Now;
            int cnt = ThreeSum.count(a);
            TimeSpan time = DateTime.Now - now;
            return time.TotalSeconds;
        }
    }
}
