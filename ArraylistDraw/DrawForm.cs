using System;
using System.Drawing;
using System.Windows.Forms;

namespace painting
{
    public partial class DrawForm : Form
    {
        public DrawForm()
        {
            InitializeComponent();
            myg = CreateGraphics();
        }

        // 窗体加载
        private void DrawForm_Load(object sender, EventArgs e)
        {
            // 上下的padding
            dx = 5;
            dy = 5;

            // 为左侧工具栏留下的宽度
            minx = 250 + dx;
            miny = dy;

            maxx = Convert.ToInt32(ClientSize.Width - dx);
            maxy = Convert.ToInt32(Math.Floor((ClientSize.Height - dy) / 10.0) * 10);
            midx = Convert.ToInt32((minx + maxx) / 2);
            midy = Convert.ToInt32(Math.Floor((miny + maxy) / 20.0) * 10);

            movey = midy;

            //坐标转换（自己->屏幕）
            transPtoP1();

            downp = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            initdraw();
            drawpolygon();
        }

#region 全局变量

        Graphics myg;
        bool isdraw;
        bool isdrawy;

        int minx, maxx;
        int miny, maxy;
        int dx;
        int dy;
        int midx;
        int midy;

        int minpy = 0;
        int maxpy = 0;
        int movey;

        int downx;
        int downy;
        int downp = -1;

        float area = 0;
        Random rpx = new Random();
        Random rpy = new Random();

        DateTime dt;

        Point[] pointv =
        {
            new Point(115, 125),
            new Point(-56, 12),
            new Point(0, 153),
            new Point(-50, 150),
            new Point(-250, 200),
            new Point(-50, -110),
            new Point(10, -110),
            new Point(10, -180),
            new Point(60, -90),
            new Point(60, 0)
        };

#endregion

#region 工具函数

        void transPtoP1() //坐标转换（自己->屏幕）
        {
            for (int i = 0; i < pointv.Length; i++)
            {
                pointv[i].X = pointv[i].X + midx;
                pointv[i].Y = midy - pointv[i].Y;
            }
        }

        void transP1toP() //坐标转换（屏幕->自己）
        {
            for (int i = 0; i < pointv.Length; i++)
            {
                pointv[i].X = pointv[i].X - midx;
                pointv[i].Y = midy - pointv[i].Y;
            }
        }

        float form2screen(float index, bool isX)
        {
            if (isX)
                return index - midx;
            return midy - index;
        }

#endregion

#region 各种颜色

        Pen pen_AxisBorder = new Pen(Color.Red, 1);
        Pen pen_PolygonLines = new Pen(Color.DeepPink, 2);

        Brush brush_globalBG;
        Brush b2 = new SolidBrush(Color.LimeGreen);
        Brush brush_AxisZero = new SolidBrush(Color.Blue);
        Brush brush_polygonBG = new SolidBrush(Color.Gold);
        Brush brush_pointNormal = new SolidBrush(Color.Orange);
        Brush brush_ActivedPoint = new SolidBrush(Color.DarkBlue);
        Brush brush_FontNormal = new SolidBrush(Color.Black);
        Brush brush_FontActived = new SolidBrush(Color.Red);


        // 选择背景颜色
        private void lb_setcolor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lb_setcolor.BackColor = colorDialog.Color;
            }

            initdraw();
            drawpolygon();
        }

#endregion

#region 作画函数

        void initdraw()
        {
            brush_globalBG = new SolidBrush(lb_setcolor.BackColor);

            myg.Clear(Color.White);
            myg.FillRectangle(brush_globalBG, minx, miny, maxx - minx, maxy - miny);

            myg.DrawLine(pen_AxisBorder, new Point(minx, miny), new Point(maxx, miny));
            myg.DrawLine(pen_AxisBorder, new Point(minx, midy), new Point(maxx, midy));
            myg.DrawLine(pen_AxisBorder, new Point(minx, maxy), new Point(maxx, maxy));
            myg.DrawLine(pen_AxisBorder, new Point(minx, miny), new Point(minx, maxy));
            myg.DrawLine(pen_AxisBorder, new Point(midx, miny), new Point(midx, maxy));
            myg.DrawLine(pen_AxisBorder, new Point(maxx, miny), new Point(maxx, maxy));
            myg.FillEllipse(brush_AxisZero, midx - 5, midy - 5, 10, 10);
        }

        void drawpolygon()
        {
//            double area2 = CalArea(pointv);
//            labelarea2.Text = "面积=" + Math.Round(area2, 2);
//            labelarea2.Visible = true;


            //if (cb_fill.Checked == true)
            //{
            //  area = LoopFill(pointv);
            //labelarea.Text = "面积=" + area;
            //labelarea.Visible = true;
            // }
            /// else
            //{
            //   myg.FillPolygon(b2, pointv);
            //  labelarea.Visible = false;
            // }

            myg.DrawPolygon(pen_PolygonLines, pointv);

            //drawallline(pointv);

            // - 清空图像
            listBox1.Items.Clear();

            // - 先画背景
            myg.FillPolygon(brush_polygonBG, pointv);

            // - 画点 & 文字
            //     - 未被选中
            for (int i = 0; i < pointv.Length; i++)
            {
                myg.FillEllipse(brush_pointNormal, pointv[i].X - 5, pointv[i].Y - 5, 10, 10);
                listBox1.Items.Add("" + (i + 1) + ".(" + (pointv[i].X - midx) + "," + (midy - pointv[i].Y) + ")");

                // - 画文字
                // drawstr(i);
                if (checkBox_显示标号.Checked)
                    myg.DrawString(i.ToString(), new Font("Arial", 14), brush_FontNormal, pointv[i].X + 5,
                        pointv[i].Y - 7,
                        new StringFormat());
            }

            //     - 被选中
            if (downp >= 0)
            {
                listBox1.SelectedIndex = downp;

                myg.FillRectangle(brush_ActivedPoint, pointv[downp].X - 5, pointv[downp].Y - 5, 10, 10);

                // - 画文字
                // drawstr(i);
                if (checkBox_显示标号.Checked)
                    myg.DrawString(downp.ToString(), new Font("Arial", 14), brush_FontActived,
                        pointv[downp].X + 5,
                        pointv[downp].Y - 7,
                        new StringFormat());
            }
        }

#endregion

#region 移动顶点事件

        private void DrawForm_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < pointv.Length; i++)
            {
                if (Math.Abs(e.Y - movey) <= 5)
                {
                    isdrawy = true;
                    movey = e.Y;
                }
                else if ((Math.Abs(e.X - pointv[i].X)) <= 5 && (Math.Abs(e.Y - pointv[i].Y) <= 5))
                {
                    downp = i;
                    isdraw = true;
                    downx = e.X;
                    downy = e.Y;
                }
            }

            initdraw();
            drawpolygon();
        }

        private void DrawForm_MouseMove(object sender, MouseEventArgs e)
        {
            // 基础作图
            if (isdrawy)
            {
                movey = e.Y;
                if (movey < minpy)
                    movey = minpy;
                else if (movey > maxpy)
                    movey = maxpy;

                initdraw();
                drawpolygon();
            }
            else if (isdraw)
            {
                {
                    pointv[downp].X = e.X;
                    pointv[downp].Y = e.Y;
                    if (e.X < minx + 10)
                        pointv[downp].X = minx + 10;
                    if (e.X > maxx - 10)
                        pointv[downp].X = maxx - 10;
                    if (e.Y < miny + 10)
                        pointv[downp].Y = miny + 10;
                    if (e.Y > maxy - 10)
                        pointv[downp].Y = maxy - 10;
                }

                initdraw();
                drawpolygon();
            }

            // 更新坐标
            textBox_Axis.Text = $"\tX:{form2screen(e.X, true)}\t\t  Y:{form2screen(e.Y, false)}";
        }

        private void DrawForm_MouseUp(object sender, MouseEventArgs e)
        {
            isdraw = false;
            isdrawy = false;
        }

#endregion

#region 其他鼠标事件

#endregion
    }
}