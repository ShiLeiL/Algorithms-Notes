using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        /* 算法（第四版） 1.2.10 */

        public static Form1 form1;
        Graphics g;
        int N = 0, max = 0;
        VisualCounter visual;
        Point temppoint;//用于记录上一次操作的点，方便连线

        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//按下按钮
            button3.Visible = true;//显示按钮
            button4.Visible = true;
            g = panel1.CreateGraphics();

            //获取输入值
            N = Convert.ToInt32(textBox1.Text);
            max = Convert.ToInt32(textBox2.Text);

            //画坐标轴
            g.DrawLine(Pens.White, 40, 305, 405, 305);
            g.DrawLine(Pens.White, 40, 430, 40, 180);

            visual = new VisualCounter(N, max);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//按下按钮
            g = panel1.CreateGraphics();
            g.Clear(Color.Black);
            button3.Visible = false;//隐藏按钮
            button4.Visible = false;
            g.Dispose();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (visual.tallytemp() < N && Math.Abs(visual.tally()) <= max)//判断是否超过最大值
            {
                visual.increment(g);
                Point F = new Point();
                F.X = 40 + visual.tallytemp() * 15;
                F.Y = 305 - visual.tally() * 15;
                g.FillEllipse(Brushes.White, F.X, F.Y, 3, 3);//画点
                g.DrawString(visual.toString(), new Font("New Timer", 8), Brushes.White, new PointF(F.X - 5, F.Y - 20));
                if (visual.tallytemp() > 1) g.DrawLine(Pens.Gray, F, temppoint);
                temppoint = F;
            }
            else//超过则隐藏按钮并释放资源
            {
                g.DrawString($"已超过设置的最大值", new Font("New Timer", 8), Brushes.White, new PointF(160, 405));
                button3.Visible = false ;//隐藏按钮
                button4.Visible = false ;
                g.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (visual.tallytemp() < N && Math.Abs(visual.tally()) <= max)//判断是否超过最大值
            {
                visual.decrement(g);
                Point F = new Point();
                F.X = 40 + visual.tallytemp() * 15;
                F.Y = 305 - visual.tally() * 15;
                g.FillEllipse(Brushes.White, F.X, F.Y, 3, 3);//画点
                g.DrawString(visual.toString(), new Font("New Timer", 8), Brushes.White, new PointF(F.X , F.Y - 20));
                if (visual.tallytemp() > 1) g.DrawLine(Pens.Gray, F, temppoint);
                temppoint = F;
            }
            else//超过则隐藏按钮并释放资源
            {
                g.DrawString($"已超过设置的最大值", new Font("New Timer", 8), Brushes.White, new PointF(160, 405));
                button3.Visible = false;//隐藏按钮
                button4.Visible = false;
                g.Dispose();
            }
        }
    }

    public class VisualCounter
    {
        private int N;
        private int max;
        private int count;
        private int tempN;//记录操作次数

        public VisualCounter(int NMax, int maxAbs)
        { N = NMax; max = maxAbs; }

        public void increment(Graphics g)
        {
            tempN++;
            count++;
        }

        public void decrement(Graphics g)
        {
            tempN++;
            count--;
        }

        public int tally()
        { return count; }

        public int tallytemp()
        { return tempN; }

        public string toString()
        { return Convert.ToString(count); }
    }

}