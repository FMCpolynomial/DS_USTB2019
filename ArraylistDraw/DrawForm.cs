using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace painting
{
    public partial class DrawForm : Form
    {
        #region Terminal 日志 || Console 输出台

        // Log 类型
        public enum logType
        {
            CommonLog,
            Warning,
            Error
        }

        // Log 调用 注意Warning和Error时应有第二个参数 不换行有第三参数为false
        public void Log_Terminal(string log, logType logtype = logType.CommonLog, bool addNewLine = true)
        {
            if (addNewLine)
            {
                log += Environment.NewLine;
            }

            Color color = new Color();
            switch (logtype)
            {
                case logType.CommonLog:
                    color = Color.Green;
                    break;
                case logType.Warning:
                    color = Color.Orange;
                    break;
                case logType.Error:
                    color = Color.Red;
                    break;
            }

            Terminal.SelectionStart = Terminal.TextLength;
            Terminal.SelectionLength = 0;
            Terminal.SelectionColor = color;

            string text = $@"[{DateTime.Now.ToLongTimeString()}] {log}";
            Terminal.Focus(); //warning:这句话没有的话会使得terminal不能跟踪到最新的log 
            Terminal.AppendText(text);

            Terminal.SelectionColor = Terminal.ForeColor;
        }

        #endregion

        #region 初始化

        public DrawForm()
        {
            InitializeComponent();
            myg = CreateGraphics();
            timer1.Enabled = true;
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

        #endregion

        #region 全局变量

        // 老师遗留
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

        // 边缘绘制
        int edge_x_t = 0, edge_x_b = 0, edge_y_t = 0, edge_y_b = 0;
        Point scan_l, scan_r;
        private bool isDrawScanLine;

        // 日期和时间
        DateTime dt;

        // 初始点集
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

        //坐标转换（自己->屏幕）
        void transPtoP1()
        {
            for (int i = 0; i < pointv.Length; i++)
            {
                pointv[i].X = pointv[i].X + midx;
                pointv[i].Y = midy - pointv[i].Y;
            }
        }

        //坐标转换（屏幕->自己）
        void transP1toP()
        {
            for (int i = 0; i < pointv.Length; i++)
            {
                pointv[i].X = pointv[i].X - midx;
                pointv[i].Y = midy - pointv[i].Y;
            }
        }

        // 坐标转换
        int form2screen(int index, bool isX)
        {
            if (isX)
                return index - midx;
            return midy - index;
        }

        // 计算面积
        public double Calarea(Point[] _Points)
        {
            double area = 0;
            for (int i = 0; i < _Points.Length - 1; i++)
            {
                area += (_Points[i].X * (double)_Points[i + 1].Y - _Points[i + 1].X * (double)_Points[i].Y) / 2;
            }

            area +=
                1.0f * (_Points[_Points.Length - 1].X * _Points[0].Y - _Points[0].X * _Points[_Points.Length - 1].Y) /
                2;
            area = Math.Abs(area);
            return area;
        }

        #endregion

        #region 各种颜色

        Pen pen_AxisBorder = new Pen(Color.Red, 1);
        Pen pen_PolygonLines = new Pen(Color.DeepPink, 4);
        Pen pen_FrameLines = new Pen(Color.FromArgb(184, 255, 238, 0), 10);
        Pen pen_ScanLines = new Pen(Color.FromArgb(184, 255, 36, 50), 6);

        Brush brush_globalBG;
        Brush b2 = new SolidBrush(Color.LimeGreen);
        Brush brush_AxisZero = new SolidBrush(Color.Blue);
        Brush brush_polygonBG = new SolidBrush(Color.LimeGreen);
        Brush brush_pointNormal = new SolidBrush(Color.Yellow);
        Brush brush_ActivedPoint = new SolidBrush(Color.DarkBlue);
        Brush brush_FontNormal = new SolidBrush(Color.Black);
        Brush brush_FontAxis = new SolidBrush(Color.Green);
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
            // 画坐标轴
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
            double area2 = Calarea(pointv);
            textBox_Square.Text = $"面积\t=\t{Math.Round(area2, 2)}";

            myg.DrawPolygon(pen_PolygonLines, pointv);

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
                if (checkBox_显示标号.Checked)
                {
                    myg.DrawString((i + 1).ToString(), new Font("Arial", 14), brush_FontNormal, pointv[i].X + 5,
                        pointv[i].Y - 7,
                        new StringFormat());
                }

                // - 画坐标
                if (checkBox_显示坐标.Checked)
                {
                    string str = $"({pointv[i].X - midx},{midy - pointv[i].Y})";
                    myg.DrawString(str, new Font("Arial", 8), brush_FontAxis, pointv[i].X + 5,
                        pointv[i].Y + 10,
                        new StringFormat());
                }
            }

            //     - 被选中
            if (downp >= 0)
            {
                if (!(listBox1.Items.Count >= downp))
                {
                    Log_Terminal("结点暂时丢失", logType.Warning);
                    return;
                }

                listBox1.SelectedIndex = downp;
                myg.FillRectangle(brush_ActivedPoint, pointv[downp].X - 5, pointv[downp].Y - 5, 10, 10);

                // - 画文字
                // drawstr(i);
                if (checkBox_显示标号.Checked)
                    myg.DrawString((downp + 1).ToString(), new Font("Arial", 14), brush_FontActived,
                        pointv[downp].X + 5,
                        pointv[downp].Y - 7,
                        new StringFormat());
            }

            // - 画扫描线
            if (checkBox_显示扫描线.Checked)
            {
                //     - 获取边缘坐标

                for (int i = 0; i < pointv.Length; i++)
                {
                    if (i == 0)
                    {
                        edge_x_t = pointv[i].X;
                        edge_x_b = pointv[i].X;
                        edge_y_t = pointv[i].Y;
                        edge_y_b = pointv[i].Y;
                    }

                    if (pointv[i].X > edge_x_t)
                        edge_x_t = pointv[i].X;
                    if (pointv[i].X < edge_x_b)
                        edge_x_b = pointv[i].X;
                    if (pointv[i].Y > edge_y_t)
                        edge_y_t = pointv[i].Y;
                    if (pointv[i].Y < edge_y_b)
                        edge_y_b = pointv[i].Y;
                }

                //Log_Terminal($"{edge_x_t} {edge_x_b} {edge_y_t} {edge_y_b}");

                //     - 画出来
                //         - 轮廓
                Point lt, lb, rt, rb;
                lt = new Point(edge_x_b, edge_y_b);
                lb = new Point(edge_x_b, edge_y_t);
                rt = new Point(edge_x_t, edge_y_b);
                rb = new Point(edge_x_t, edge_y_t);

                myg.DrawLine(pen_FrameLines, lt, lb);
                myg.DrawLine(pen_FrameLines, lb, rb);
                myg.DrawLine(pen_FrameLines, rb, rt);
                myg.DrawLine(pen_FrameLines, rt, lt);

                //         - 扫描线
                scan_l.X = edge_x_b;
                scan_r.X = edge_x_t;
                if (isDrawScanLine)
                    myg.DrawLine(pen_ScanLines, scan_l, scan_r);
            }
        }

        private void 图像更新(object sender, EventArgs e)
        {
            initdraw();
            drawpolygon();
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
                else if (Math.Abs(e.X - pointv[i].X) <= 5 && Math.Abs(e.Y - pointv[i].Y) <= 5)
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

            // 扫描线
            if (checkBox_显示扫描线.Checked)
            {
                if (e.Y < edge_y_t && e.Y > edge_y_b)
                {
                    isDrawScanLine = true;
                    scan_l.Y = e.Y;
                    scan_r.Y = e.Y;
                    initdraw();
                    drawpolygon();
                }
                else
                {
                    isDrawScanLine = false;
                }

                //myg.DrawLine(pen_FrameLines, scan_l, scan_r);
            }


            // 更新坐标
            textBox_Axis.Text = $"X:{form2screen(e.X, true)}\t\t  Y:{form2screen(e.Y, false)}";
        }

        private void DrawForm_MouseUp(object sender, MouseEventArgs e)
        {
            isdraw = false;
            isdrawy = false;
        }

        // 新增结点
        private void DrawForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (radioButton_NoPlugin.Checked)
            {
                Log_Terminal("结点插入方式:不插入", logType.Error);
                return;
            }


            // 转回去
            transP1toP();

            Point newPoint = new Point(form2screen(e.X, true), form2screen(e.Y, false));

            float distance;
            float res = 0;
            int index = -1;
            for (int i = 0; i < pointv.Length; i++)
            {
                distance = (pointv[i].X - newPoint.X) * (pointv[i].X - newPoint.X) +
                           (pointv[i].Y - newPoint.Y) * (pointv[i].Y - newPoint.Y);

                Log_Terminal($"第{i}个结点距离为{distance}");
                if (i == 0 || distance < res)
                {
                    res = distance;
                    index = i;
                }
            }

            Log_Terminal($"第{index}个结点距离最近为{res}", logType.Warning);

            if (index == -1)
            {
                Log_Terminal("Index 丢失", logType.Error);
                return;
            }

            if (radioButton_BackPlugin.Checked)
            {
                index++;
                Point[] points = new Point[pointv.Length + 1];
                for (int i = 0; i < pointv.Length + 1; i++)
                {
                    if (i < index)
                    {
                        points[i] = pointv[i];
                    }

                    if (i == index)
                    {
                        points[i] = newPoint;
                    }

                    if (i > index)
                    {
                        points[i] = pointv[i - 1];
                    }
                }

                pointv = points;
            }

            if (radioButton_FrontPlugin.Checked)
            {
                Point[] points = new Point[pointv.Length + 1];
                for (int i = 0; i < pointv.Length + 1; i++)
                {
                    if (i < index)
                    {
                        points[i] = pointv[i];
                    }

                    if (i == index)
                    {
                        points[i] = newPoint;
                    }

                    if (i > index)
                    {
                        points[i] = pointv[i - 1];
                    }
                }

                pointv = points;
            }

            // 转回来
            transPtoP1();

            // 画出来
            initdraw();
            drawpolygon();
        }

        #endregion

        #region 显示

        // 计时器显示时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            var dt = DateTime.Now;
            var date = dt.ToLongDateString();
            var time = dt.ToLongTimeString();
            lb_datetime.Text = date + time;
        }

        #endregion

        #region 其他事件

        // 初始化结点
        private void button_Init_Click(object sender, EventArgs e)
        {
            pointv = new[]
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
            transPtoP1();


            initdraw();
            drawpolygon();
        }

        // 删除结点
        private void button_DeleteNode_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 3)
            {
                Log_Terminal("点不足3,不能成为多边形", logType.Error);
                return;
            }

            int index = listBox1.SelectedIndex;
            Log_Terminal($"要删除的Index:\t{listBox1.SelectedIndex}");

            // 转回去
            transP1toP();

            Point[] points = new Point[pointv.Length - 1];
            for (int i = 0; i < pointv.Length - 1; i++)
            {
                if (i < index)
                {
                    points[i] = pointv[i];
                }

                if (i >= index)
                {
                    points[i] = pointv[i + 1];
                }
            }

            pointv = points;
            Log_Terminal($"list数量{listBox1.Items.Count}", logType.Warning);

            // debug：这里给downy减一，fixed了删除最后一个节点downy溢出的bug

            Log_Terminal($"删除前downy：{downp}", logType.Warning);
            downp--;
            Log_Terminal($"删除后downy：{downp}", logType.Warning);

            // 转回来
            transPtoP1();

            // 画出来
            initdraw();
            drawpolygon();
        }

        #endregion
    }
}