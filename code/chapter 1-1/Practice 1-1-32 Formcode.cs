using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AlgorithmsApplication
{
    public partial class Form1 : Form
    {
        /* 算法（第四版） 1.1.32 */
        //因为是这两天新学的winform，如果出错和遗漏，欢迎大家指正
        public Form1()
        {
            InitializeComponent();
        }

        //输入提示
        //textbox的text要先设默认值，且属性里的事件上要绑定方法       
        private void textBox3_Enter(object sender, EventArgs e)
        {
            //textbox获得焦点
            if (textBox3.Text == "请用逗号隔开")
                textBox3.Text = "";
            textBox3.ForeColor = Color.Black;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            //textbox失去焦点
            if (textBox3.Text == "")
            {
                textBox3.Text = "请用逗号隔开";
                textBox3.ForeColor = Color.LightGray;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //按下提交按钮绘制直方图

            Button btn = (Button)sender;//按下按钮
            Graphics g = panel1.CreateGraphics();//创建画布

            //获取输入值
            int N = Convert.ToInt32(textBox4.Text);
            double l = Convert.ToDouble(textBox1.Text);
            double r = Convert.ToDouble(textBox2.Text);
            string[] strSplit = textBox3.Text.Split(',');
            double[] d = new double[strSplit.Length];
            for (int i = 0; i < strSplit.Length; i++)
            {
                d[i] = Convert.ToDouble(strSplit[i]);
            }

            //画坐标轴
            g.DrawLine(Pens.White, 60, 400, 405, 400);
            g.DrawLine(Pens.White, 60, 400, 60, 150);

            //画刻度
            double section = (r - l) / N;//区间
            g.DrawString("0", new Font("New Timer", 8), Brushes.White, new PointF(50, 408));//原点刻度
            for (int i = 0; i < N + 1; i++)//横刻度
            {
                g.DrawString($"{l + i * section:F}", new Font("New Timer", 8), Brushes.White, new PointF(70 + i * 300 / N, 408));
            }

            //计数
            int[] counts = new int[N];
            foreach (double i in d)
            {
                for(int j=0;j<N;j++)
                {
                    if (i <=  l + (j + 1) * section && i > l + j * section)
                    {
                        counts[j]+=1;
                        break;
                    }
                }
            }

            //绘制直方图
            int unit = 200 / counts.Max();
            for(int i=0;i<N;i++)
            {
                g.FillRectangle(Brushes.Gray, 83 + i * 300 / N, 399- unit * counts[i], 300/N-2, unit * counts[i]);
            }

            //标数量
            for (int i = 0; i < N; i++)
            {
                g.DrawString($"{counts[i]}", new Font("New Timer", 8), Brushes.White, new PointF(76 + (i+0.5f) * 300 / N, 383-unit * counts[i]));
            }

            g.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //按下清除按钮
            Button btn = (Button)sender;//按下按钮
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.Black);
            g.Dispose();
        }
    }
}