using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace painting
{
    public partial class DrawForm : Form
    {
        Graphics myg = null;
        bool isdraw = false;
        bool isdrawy = false;

        int minx = 0, maxx = 0;
        int miny = 0, maxy = 0;
        int dx = 0;
        int dy = 0;
        int midx = 0;
        int midy = 0;

        int minpy = 0;
        int maxpy = 0;
        int movey = 0;

        int downx = 0;
        int downy = 0;
        int downp = -1;

        float area = 0;
        Random rpx = new Random();
        Random rpy = new Random();

        DateTime dt;

        Point[] pointv = new Point[]
                         {
                             new Point(115,125),
                             new Point(-56,12),
                             new Point(0,153),
                             new Point(-50,150),
                             new Point(-250,200),
                             new Point(-50,-110),
                             new Point(10,-110),
                             new Point(10,-180),
                             new Point(60,-90),
                             new Point(60,0)
                         };
        void transPtoP1()//坐标转换（自己->屏幕）
        {
            for (int i = 0; i < pointv.Length; i++)
            {
                pointv[i].X = pointv[i].X + midx;
                pointv[i].Y = midy - pointv[i].Y;
            }
        }
        void transP1toP()//坐标转换（屏幕->自己）
        {
            for (int i = 0; i < pointv.Length; i++)
            {
                pointv[i].X = pointv[i].X - midx;
                pointv[i].Y = midy - pointv[i].Y;
            }
        }

        void initdraw()
        {
            Brush b0 = new SolidBrush(lb_setcolor.BackColor);
            myg.Clear(Color.FromArgb(255, 224, 224, 224));
            myg.FillRectangle(b0, minx, miny, maxx - minx, maxy - miny);

            Pen pen1 = new Pen(Color.Red, 1);
            myg.DrawLine(pen1, new Point(minx, miny), new Point(maxx, miny));
            myg.DrawLine(pen1, new Point(minx, midy), new Point(maxx, midy));
            myg.DrawLine(pen1, new Point(minx, maxy), new Point(maxx, maxy));
            myg.DrawLine(pen1, new Point(minx, miny), new Point(minx, maxy));
            myg.DrawLine(pen1, new Point(midx, miny), new Point(midx, maxy));
            myg.DrawLine(pen1, new Point(maxx, miny), new Point(maxx, maxy));
            Brush b1 = new SolidBrush(Color.Blue);
            myg.FillEllipse(b1, midx - 5, midy - 5, 10, 10);

        }

        void drawpolygon()
        {
            //double area2 = CalArea(pointv);
            //labelarea2.Text = "面积=" + Math.Round(area2, 2);
            //labelarea2.Visible = true;

            Pen pen1 = new Pen(Color.FromArgb(255, 255, 0, 255), 2);
            Brush b2 = new SolidBrush(Color.FromArgb(255, 0, 255, 0));

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

            myg.DrawPolygon(pen1, pointv);

            //drawallline(pointv);

            Brush b1 = new SolidBrush(Color.FromArgb(255, 255, 100, 0));
            listBox1.Items.Clear();
            for (int i = 0; i < pointv.Length; i++)
            {
                myg.FillEllipse(b1, pointv[i].X - 5, pointv[i].Y - 5, 10, 10);
                // drawstr(i);
                listBox1.Items.Add("" + (i + 1) + ".(" + (pointv[i].X - midx) + "," + (midy - pointv[i].Y) + ")");
            }
            if (downp >= 0)
            {
                listBox1.SelectedIndex = downp;
                Brush bt = new SolidBrush(Color.FromArgb(255, 100, 50, 255));
                myg.FillRectangle(bt, pointv[downp].X - 5, pointv[downp].Y - 5, 10, 10);
            }


        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            initdraw();
            drawpolygon();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
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



        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isdrawy == true)
            {
                movey = e.Y;
                if (movey < minpy)
                    movey = minpy;
                else if (movey > maxpy)
                    movey = maxpy;
                initdraw();
                drawpolygon();
            }
            else if (isdraw == true)
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


        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isdraw = false;
            isdrawy = false;
        }

        public DrawForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myg = this.CreateGraphics();

            dx = 10;
            minx = 130 + dx;
            maxx = Convert.ToInt32(this.ClientSize.Width - dx);
            dy = 10;
            miny = dy;
            maxy = Convert.ToInt32(Math.Floor((this.ClientSize.Height - dy) / 10.0) * 10);
            midx = Convert.ToInt32((minx + maxx) / 2);
            midy = Convert.ToInt32(Math.Floor((miny + maxy) / 20.0) * 10);

            movey = midy;

            transPtoP1();//坐标转换（自己->屏幕）

            downp = 0;

        }
    }
}
