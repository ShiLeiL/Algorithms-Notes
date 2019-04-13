using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1._4._3
{
    public partial class Form1 : Form
    {
        /* 算法（第四版） 1.4.3 自适应版本 */
        //自适应参考自https://www.cnblogs.com/jife/articles/3090166.html

        public static Form1 form1;
        GraphicsPath gp = new GraphicsPath();
        Graphics g;

        #region 控件缩放
        double formWidth;//窗体原始宽度
        double formHeight;//窗体原始高度
        float scaleX;//水平缩放比例
        float scaleY;//垂直缩放比例
        Dictionary<string, string> ControlsInfo = new Dictionary<string, string>();//控件中心Left,Top,控件Width,控件Height,控件字体Size
        #endregion

        public Form1()
        {
            InitializeComponent();
            form1 = this;
            g = form1.panel1.CreateGraphics();
            scaleX = 1;
            scaleY = 1;
            #region 窗体缩放
            formWidth = Convert.ToDouble(this.Width);
            formHeight = Convert.ToDouble(this.Height);
            GetAllInitInfo(this.Controls[0]);
            #endregion
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            if (ControlsInfo.Count > 0)//如果字典中有数据，即窗体改变
            {
                ControlsChangeInit(this.Controls[0]);//表示pannel控件               
                ControlsChange(this.Controls[0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//按下按钮
            foreach (Control label in panel1.Controls)
            {
                if (label is Label)
                    label.Visible = true;
            }
            int N = Convert.ToInt32(textBox1.Text);
            int max = Convert.ToInt32(textBox2.Text);
            Draw(N, max);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//按下按钮
            g.Clear(Color.Black);
            Queue<Control> query = new Queue<Control>();
            foreach (Control label in panel1.Controls)
            {
                if (!(label is Label))
                    continue;
                if ((string)label.Tag == "scale")
                {
                    query.Enqueue(label);
                }
                if (label is Label && label.Name != "label1" && label.Name != "label2")
                    label.Visible = false;
            }
            while(query.Count!=0)
            {
                Control temp = new Control();
                temp = query.Dequeue();
                Controls.Remove(temp);
                temp.Dispose();
                ControlsInfo.Remove(temp.Name);
            }
            form1.label3.Text = "数组长度\n\n";
            form1.label4.Text = "耗时(s)\n\n";
        }

        public static void Draw(int N, int max)
        {
            form1.gp.Reset();

            //画坐标轴           
            form1.gp.AddLine(210, 400, 410, 400);
            form1.gp.StartFigure();
            form1.gp.AddLine(210, 100, 210, 400);
            form1.gp.StartFigure();
            form1.gp.AddLine(460, 400, 660, 400);
            form1.gp.StartFigure();
            form1.gp.AddLine(460, 100, 460, 400);

            int count = Convert.ToInt32(Math.Sqrt(max / N)) + 1;//数据个数
            int section = Convert.ToInt32(200 / Math.Pow(2, count - 1));//横刻度单位长度

            //计算结果
            double[] times = new double[count];//记录T(N)
            double[] lg = new double[count];//记录lg(T(N))
            for (int i = N, j = 0; i <= max; i += i, j++)
            {
                times[j] = DoublingTest.TimeTrial(i);
                lg[j] = Math.Log10(times[j]);
                form1.label3.Text += " " + i + "\n\n";
                form1.label4.Text += " " + times[j] + "\n\n";

                //图1横刻度
                Label heng1 = new Label
                {
                    Name = "heng1" + i,
                    Text = $"{(double)i / 1000}k",
                    Location = new Point(190 + i / N * section,405),
                    ForeColor = SystemColors.HighlightText,
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    Tag = "scale"
                };
                form1.ControlsInfo.Add(heng1.Name, (heng1.Left + heng1.Width / 2) + "," + (heng1.Top + heng1.Height / 2) + "," + heng1.Width + "," + heng1.Height + "," + heng1.Font.Size);
                if (form1.scaleX != 1 || form1.scaleY != 1)
                {
                    heng1.Location = new Point((int)(heng1.Location.X * form1.scaleX), (int)(heng1.Location.Y * form1.scaleY));
                    heng1.Font = new Font(heng1.Font.Name, float.Parse((heng1.Font.Size * Math.Min(form1.scaleX, form1.scaleY)).ToString()));//字体
                }                    
                form1.panel1.Controls.Add(heng1);
            }

            //根据结果画纵刻度
            int timer = Convert.ToInt32(Math.Ceiling(times[count - 1] / 6));
            double lger = lg[count - 1] / 6;
            for (int i = 1; i < 7; i++)
            {
                //图1纵刻度
                Label zong1 = new Label
                {
                    Name = "zong1" + i,
                    Text = $"{i * timer}",
                    Location = new Point(185, 400 - i * 45),
                    ForeColor = SystemColors.HighlightText,
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    Tag = "scale"
                };
                form1.ControlsInfo.Add(zong1.Name, (zong1.Left + zong1.Width / 2) + "," + (zong1.Top + zong1.Height / 2) + "," + zong1.Width + "," + zong1.Height + "," + zong1.Font.Size);
                if (form1.scaleX != 1 || form1.scaleY != 1)
                {
                    zong1.Location = new Point((int)(zong1.Location.X * form1.scaleX), (int)(zong1.Location.Y * form1.scaleY));
                    zong1.Font = new Font(zong1.Font.Name, float.Parse((zong1.Font.Size * Math.Min(form1.scaleX, form1.scaleY)).ToString()));//字体
                }
                   
                form1.panel1.Controls.Add(zong1);

                //图2纵刻度
                Label zong2 = new Label
                {
                    Name = "zong2" + i,
                    Text = $"{i * lger:F1}",
                    Location = new Point(435, 400 - i * 45),
                    ForeColor = SystemColors.HighlightText,
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    Tag = "scale"
                };
                form1.ControlsInfo.Add(zong2.Name, (zong2.Left + zong2.Width / 2) + "," + (zong2.Top + zong2.Height / 2) + "," + zong2.Width + "," + zong2.Height + "," + zong2.Font.Size);
                if (form1.scaleX != 1 || form1.scaleY != 1)
                {
                    zong2.Location = new Point((int)(zong2.Location.X * form1.scaleX), (int)(zong2.Location.Y * form1.scaleY));
                    zong2.Font = new Font(zong2.Font.Name, float.Parse((zong2.Font.Size * Math.Min(form1.scaleX, form1.scaleY)).ToString()));//字体
                }                    
                form1.panel1.Controls.Add(zong2);
            }

            Point[] points1 = new Point[count];//图1点
            Point[] points2 = new Point[count];//图2点
            for (int i = 0; i < count; i++)
            {
                points1[i].X = (int)(190 + Math.Pow(2, i) * section);
                points1[i].Y = (int)(400 - times[i] / timer * 45);
                points2[i].X = 440 + (i + 1) * 200 / count;
                points2[i].Y = (int)(400 - lg[i] / lger * 45);
                //g.FillRectangle(Brushes.Gray, points1[i].X, points1[i].Y, 3f, 3f);//画图1点
                //g.FillRectangle(Brushes.Gray, points2[i].X, points2[i].Y, 3f, 3f);//画图2点

                //图2横刻度
                Label heng2 = new Label
                {
                    Name = "heng2" + i,
                    Text = $"{Math.Pow(2, i) * N / 1000}k",
                    Location = new Point(points2[i].X, 405),
                    ForeColor = SystemColors.HighlightText,
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    Tag = "scale"
                };
                form1.ControlsInfo.Add(heng2.Name, (heng2.Left + heng2.Width / 2) + "," + (heng2.Top + heng2.Height / 2) + "," + heng2.Width + "," + heng2.Height + "," + heng2.Font.Size);
                if (form1.scaleX != 1 || form1.scaleY != 1)
                {
                    heng2.Location = new Point((int)(heng2.Location.X * form1.scaleX), (int)(heng2.Location.Y * form1.scaleY));
                    heng2.Font = new Font(heng2.Font.Name, float.Parse((heng2.Font.Size * Math.Min(form1.scaleX, form1.scaleY)).ToString()));//字体
                }                   
                form1.panel1.Controls.Add(heng2);
            }

            form1.gp.StartFigure();
            form1.gp.AddCurve(points1);
            form1.gp.StartFigure();
            form1.gp.AddLines(points2);
            Matrix m1 = new Matrix();
            m1.Scale(form1.scaleX, form1.scaleY);
            GraphicsPath gpCache = new GraphicsPath();
            gpCache = (GraphicsPath)form1.gp.Clone();//创建图形副本
            gpCache.Transform(m1);
            form1.g.DrawPath(Pens.White, gpCache);//画出变化后的副本
        }

        protected void GetAllInitInfo(Control ctrlContainer)
        {
            foreach (Control item in ctrlContainer.Controls)
            {
                if (item.Name.Trim() != "" && !ControlsInfo.ContainsKey(item.Name))
                {
                    //添加信息：键值：控件名，内容：据左边距离，距顶部距离，控件宽度，控件高度，控件字体。
                    ControlsInfo.Add(item.Name, (item.Left + item.Width / 2) + "," + (item.Top + item.Height / 2) + "," + item.Width + "," + item.Height + "," + item.Font.Size);
                }
                if ((item as UserControl) == null && item.Controls.Count > 0)
                {
                    GetAllInitInfo(item);
                }
            }
        }

        private void ControlsChangeInit(Control ctrlContainer)
        {
            scaleX = (float)(ctrlContainer.Width / formWidth);
            scaleY = (float)(ctrlContainer.Height / formHeight);
        }

        /// <summary>
        /// 改变控件大小
        /// </summary>
        /// <param name="ctrlContainer"></param>
        private void ControlsChange(Control ctrlContainer)
        {
            g.Clear(Color.Black);
            g = form1.panel1.CreateGraphics();
            if (gp.PointCount != 0)
            {
                //变化图形
                Matrix m1 = new Matrix();
                m1.Scale(scaleX, scaleY);
                GraphicsPath gpCache = new GraphicsPath();
                gpCache = (GraphicsPath)gp.Clone();//创建图形副本
                gpCache.Transform(m1);
                form1.g.DrawPath(Pens.White, gpCache);//画出变化后的副本
            }

            double[] pos = new double[5];//pos数组保存当前控件中心Left,Top,控件Width,控件Height,控件字体Size
            foreach (Control item in ctrlContainer.Controls)//遍历控件
            {
                if (item.Name.Trim() != "")//如果控件名不是空，则执行
                {
                    if ((item as UserControl) == null && item.Controls.Count > 0)//如果不是自定义控件
                    {
                        ControlsChange(item);//循环执行
                    }
                    string[] strs = ControlsInfo[item.Name].Split(',');//从字典中查出的数据，以‘，’分割成字符串组

                    for (int i = 0; i < 5; i++)
                    {
                        pos[i] = Convert.ToDouble(strs[i]);//添加到临时数组
                    }
                    double itemWidth = pos[2] * scaleX;     //计算控件宽度，double类型
                    double itemHeight = pos[3] * scaleY;    //计算控件高度
                    item.Left = Convert.ToInt32(pos[0] * scaleX - itemWidth / 2);//计算控件距离左边距离
                    item.Top = Convert.ToInt32(pos[1] * scaleY - itemHeight / 2);//计算控件距离顶部距离
                    item.Width = Convert.ToInt32(itemWidth);//控件宽度，int类型
                    item.Height = Convert.ToInt32(itemHeight);//控件高度
                    item.Font = new Font(item.Font.Name, float.Parse((pos[4] * Math.Min(scaleX, scaleY)).ToString()));//字体
                }
            }
        }
    }

    public class ThreeSum
    {
        /* 算法（第四版） 1.4.2 */
        public static int Count(int[] a)
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
        public static double TimeTrial(int N)
        {
            int Max = 1000000;
            Random r = new Random();
            int[] a = new int[N];
            for (int i = 0; i < N; i++)
                a[i] = r.Next(-Max, Max);
            DateTime now = DateTime.Now;
            int cnt = ThreeSum.Count(a);
            TimeSpan time = DateTime.Now - now;
            return time.TotalSeconds;
        }
    }
}
