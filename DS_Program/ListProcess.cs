using System;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DS_Program
{
    public partial class ListProcess : Form
    {
#region 安全性检测

        public bool IsSafe(int number, int limitUP = 100, int limitDOWN = 0)
        {
            if (number > limitUP)
            {
                Log_Terminal($"Error: Too Large -> larger than {limitUP.ToString()}.", logType.Error);
                return false;
            }

            if (number < limitDOWN)
            {
                Log_Terminal($"Error: Too Small -> smaller than {limitDOWN.ToString()}.", logType.Error);
                return false;
            }

            return true;
        }

        public bool IsInputNumSafe(TextBox tb, out int num, string errorStr)
        {
            if (!Int32.TryParse(tb.Text, out num))
            {
                Log_Terminal($"{errorStr} 输入数字非法  Error", logType.Error);
                return false;
            }

            if (!IsSafe(num))
            {
                Log_Terminal($"{errorStr} 取值范围有误 Error", logType.Error);
                return false;
            }

            return true;
        }

#endregion

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

        // 通用性Event
        private void Alert_None_More_Form(object sender, EventArgs e)
        {
        }

        //warning:重载大法好!
        public override string ToString()
        {
            Log_Terminal("当前已存在窗体,新建无效", logType.Error);
            return base.ToString();
        }

#endregion

#region 链表定义

        //单链表结点类
        class CSListnode<T>
        {
            public T data;
            public CSListnode<T> next;

            public T Data
            {
                get { return data; }
                set { data = value; }
            }
            public CSListnode<T> Next
            {
                get { return next; }
                set { next = value; }
            }

            public CSListnode()
            {
                next = null;
            }

            public CSListnode(T data)
            {
                this.data = data;
                next = null;
            }

            public CSListnode(T data, CSListnode<T> next)
            {
                this.data = data;
                this.next = next;
            }
        }

        //单链表类
        class CSList<T>
        {
            public CSListnode<T> head; //头结点的引用
            public CSListnode<T> current; //当前结点的引用

            //单链表长度
            public int Length
            {
                get
                {
                    CSListnode<T> p = head.Next;
                    int count = 0;
                    while (p != null)
                    {
                        p = p.Next;
                        count++;
                    }

                    return count;
                }
            }

            //尾结点
            public CSListnode<T> Rear
            {
                get
                {
                    CSListnode<T> p = head;
                    while (p.Next != null)
                        p = p.Next;
                    return p;
                }
            }

            public CSList() //构造函数，空表，只有头结点
            {
                head = new CSListnode<T>();
                current = head; //只是一个引用，不是一个对象实体
            }

            public void MakeEmpty() //清空单链表
            {
                head.Next = null;
                current = head;
            }

            //warning:FisrtNode 和 NextNode 我改成了返回结点
            public CSListnode<T> FirstNode() //指针指向头结点 -> 返回头结点的值
            {
                current = head;
                return current;
            }

            public CSListnode<T> NextNode() //指针指向下一个结点 -> 返回下个结点的值
            {
                if (current.Next != null)
                    current = current.Next;
                return current;
            }

            //////////////////////
            //类运算
            //////////////////////

            public void InsertHead(T value) //头插法插入结点
            {
                head.Next = new CSListnode<T>(value, head.Next);
                current = head.Next;
            }

            public void AppendRear(T value) //尾插法插入结点
            {
                current = new CSListnode<T>(value, null);
                Rear.Next = current;
            }

            public void CreateHead(T[] dt, int n) //头插法生成n个结点
            {
                MakeEmpty();
                for (int i = 1; i <= n; i++)
                    head.Next = new CSListnode<T>(dt[i - 1], head.Next);
                current = head.Next;
            }

            public void CreateRear(T[] dt, int n) //尾插法生成n个结点
            {
                MakeEmpty();
                for (int i = 1; i <= n; i++)
                {
                    current.Next = new CSListnode<T>(dt[i - 1], null);
                    current = current.Next;
                }
            }

            public void Insert(T value, bool before) //插入结点,true前false后
            {
                if (current == head)
                    before = false;
                if (before)
                {
                    CSListnode<T> p = head;
                    while (p.Next != current)
                        p = p.Next;
                    p.Next = new CSListnode<T>(value, p.Next);
                    current = p.Next;
                }
                else
                {
                    current.Next = new CSListnode<T>(value, current.Next);
                    current = current.Next;
                }
            }

            public enum ListPos
            {
                front = 1,
                back = 0
            }

            public void Insert(T value, ListPos listPos) //插入结点,listPos.front|back
            {
                if (current == head)
                    listPos = ListPos.back;
//                    before = false;

                if (listPos == ListPos.front)
                {
                    CSListnode<T> p = head;
                    while (p.Next != current)
                        p = p.Next;
                    p.Next = new CSListnode<T>(value, p.Next);
                    current = p.Next;
                }
                else
                {
                    current.Next = new CSListnode<T>(value, current.Next);
                    current = current.Next;
                }
            }

            public void Delete() //删除当前结点
            {
                if (current == head)
                    return;
                CSListnode<T> p = head;
                while (p.Next != current)
                    p = p.Next;
                p.Next = current.Next;
                if (p.Next != null)
                    current = p.Next;
                else
                    current = p;
            }
        }

#endregion

        // 程序启动
        public ListProcess()
        {
            InitializeComponent();
            Log_Terminal("Initialization. 链表");
        }

        // 程序启动结束
        private void ListProcessDone(object sender, EventArgs e)
        {
            //准备绘图
            myg = Console.CreateGraphics();

            //整理一波
            Initialize_Clear();
        }

#region  程序变量

        // 链表本体
        private CSList<int> m_slist;

        // 链表长度
        private int ListSize;

        // 操作位置
        private int ProcessPos;
        // 操作地址
        private int ProcessAddress;
        // 操作数据
        private int ProcessData;
        // 操作下指针
        private int ProcessNext;


        // 图形
        Graphics myg;

#endregion

#region 程序part1:初始化

        // button_初始化
        void Initialize_Init()
        {
            // 1. 检查安全性
            // 检查是否有选择前茶还是后插
            bool frontT_backF;
            if (!radio_HeadInsert.Checked && !radio_TailInsert.Checked)
            {
                Log_Terminal("初始化部分 Radion button Unchecked", logType.Error);
                return;
            }
            else if (radio_HeadInsert.Checked)
            {
                frontT_backF = true;
            }
            else
            {
                frontT_backF = false;
            }

            // 检查输入安全性
            if (!IsInputNumSafe(textBox_ListSize, out ListSize, "ListSize")) return;
            if (!IsSafe(ListSize, 60))
            {
                Log_Terminal("链表长度不能超过60,否则无法绘制多余的结点", logType.Warning);
                return;
            }

            // 2. 清空
            Initialize_Clear();

            // 3. 生成基础链表
            m_slist = new CSList<int>();
            for (int i = 0; i < ListSize; i++)
            {
                // todo:这里修改生成的链表的内容
                // 这里就默认顺序生成了
                int insertNum = i + 1;

                m_slist.Insert(insertNum, frontT_backF);
            }

            Log_Terminal($"m_slist.Length:\t{m_slist.Length}");
            Log_Terminal("-------生成链表完成-------", logType.Warning);

            // 4. 绘制链表
            Paint_Unit(ListSize);
        }

        // button_清空
        void Initialize_Clear()
        {
            m_slist = new CSList<int>();
            Log_Terminal($"m_slist.Length:\t{m_slist.Length}");
            Log_Terminal("-------清空链表完成-------", logType.Warning);

            block_posX.Clear();
            block_posY.Clear();
            myg.Clear(SystemColors.Control);
            Log_Terminal("-------清空画布完成-------", logType.Warning);

            // 1.先生成head
            block_posX.Add(edge_interval);
            block_posY.Add(block_height_interval);
            myg.FillRectangle(new SolidBrush(color_head), block_posX[0], block_posY[0], block_width, block_height);
            myg.DrawString("HEAD", new Font("Arial", 7), new SolidBrush(Color.Red), block_posX[0], block_posY[0] + 10,
                new StringFormat());
            Log_Terminal("-------绘制HEAD结点-------", logType.Warning);
        }


        // 遍历赋值并遍历输出 => 结点移动
        void iterate_Log()
        {
        }

        // 遍历赋值并遍历输出 => 初始化
        private void Console_Paint(object sender, PaintEventArgs e)
        {
            // 写
            string str;
            str = "未生成链表";

            Font font = new Font("Arial", 10);
            SolidBrush b1 = new SolidBrush(Color.Blue);
            StringFormat sf1 = new StringFormat();
            myg.DrawString(str, font, b1, Console.Width / 2, Console.Height / 2, sf1);
        }

        private int block_width = 30;
        private int block_height = 30;
        private int edge_interval = 12;
        private int block_width_interval = 20;
        private int block_height_interval = 20;

        private List<int> block_posX = new List<int>();
        private List<int> block_posY = new List<int>();

        private Color color_head = Color.Gray;
        private Color color_block = Color.Gold;
        private Color color_block_current = Color.Red;
        private Color color_pen = Color.Red;
        private Color color_arrow;
        private Color color_font;

        void Paint_Unit(int block_num)
        {
            // 声明各种物件
            //pen
            Pen penLine = new Pen(color_pen, 2);


            var node = m_slist.FirstNode();
            // 2.再生成其他
            for (int i = 1; i <= block_num; i++)
            {
                // 确定基础位置(犯了很多错误在 i % 10)
                if (i / 10 % 2 == 0)
                    block_posX.Add(edge_interval + i % 10 * (block_width_interval + block_width));
                else
                    block_posX.Add(edge_interval + (9 - i % 10) * (block_width_interval + block_width));

                block_posY.Add(block_height_interval + i / 10 * (block_height_interval + block_height));

                // 画
                //block
                myg.FillRectangle(new SolidBrush(color_block), block_posX[i], block_posY[i], block_width, block_height);

                //arrow
                if (i != 0)
                {
                    Log_Terminal($"Arrow {i}");
                    Point p1;
                    Point p2;

                    if ((i) % 10 == 0)
                    {
                        p1 = new Point(block_posX[i - 1] + block_width / 2, block_posY[i - 1] + block_height);
                        p2 = new Point(block_posX[i] + block_width / 2, block_posY[i]);
                    }
                    else
                    {
                        if (i / 10 % 2 == 0)
                        {
                            p1 = new Point(block_posX[i - 1] + block_width, block_posY[i - 1] + block_height / 2);
                            p2 = new Point(block_posX[i], block_posY[i] + block_height / 2);
                        }
                        else
                        {
                            p1 = new Point(block_posX[i - 1], block_posY[i - 1] + block_height / 2);
                            p2 = new Point(block_posX[i] + block_width, block_posY[i] + block_height / 2);
                        }
                    }

                    AdjustableArrowCap lineCap = new AdjustableArrowCap(4, 4, true);
                    myg.DrawLine(penLine, p1, p2);
                    penLine.CustomEndCap = lineCap;
                }


                // 绘制链表内容
                string str = i.ToString();
                Font font_code = new Font("Arial", 6);
                SolidBrush b1 = new SolidBrush(Color.Blue);
                StringFormat sf1 = new StringFormat();
                myg.DrawString(str, font_code, b1, block_posX[i], block_posY[i], sf1);

                str = node.next.Data.ToString();
                node = node.next;
                Font font_content = new Font("Arial", 10);
                myg.DrawString(str, font_content, b1, block_posX[i], block_posY[i] + 12, sf1);

                System.Threading.Thread.Sleep(40);
                Log_Terminal($"绘制第{i}个方块:\tX:{block_posX[i]}\tY:{block_posY[i]}");
            }
        }

#endregion

#region 程序part2:结点移动

#endregion

#region 程序part3:结点操作

#endregion

#region 程序part4:显示

#endregion

#region Button_Trigger

        private void button_Init_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_Init.Text}:", logType.Warning);
            Initialize_Init();
        }

        private void button_ClearTerm_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_ClearTerm.Text}:", logType.Warning);
            Terminal.Text = "";
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_Clear.Text}:", logType.Warning);
            Initialize_Clear();
            Console.Text = "";
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_Del.Text}:", logType.Warning);
        }

        private void button_Modify_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_Modify.Text}:", logType.Warning);
        }

        private void button_Insert_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_Insert.Text}:", logType.Warning);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_Exit.Text}:", logType.Warning);
            Initialize_Clear();

            //todo:这里这么做有点争议,先这么着吧
            Dispose();
            Close();
        }

        private void button_HeadNode_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_HeadNode.Text}:", logType.Warning);
        }

        private void button_NextNode_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_NextNode.Text}:", logType.Warning);
        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_Find.Text}:", logType.Warning);
        }

        private void button_Reverse_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_Reverse.Text}:", logType.Warning);
        }

#endregion
    }
}