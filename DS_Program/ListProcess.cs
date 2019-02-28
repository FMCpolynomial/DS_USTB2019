﻿using System;
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

        public void Log_Console(string log, logType logtype = logType.CommonLog, bool addNewLine = true)
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

            Console.SelectionStart = Console.TextLength;
            Console.SelectionLength = 0;
            Console.SelectionColor = color;

//            string text = $@"[{DateTime.Now.ToLongTimeString()}] {log}";
            Console.Focus(); //warning:这句话没有的话会使得Console不能跟踪到最新的log 
            Console.AppendText(log);

            Console.SelectionColor = Console.ForeColor;
        }

#endregion

#region 链表定义

        //单链表结点类
        class CSListnode<T>
        {
            private T data;
            private CSListnode<T> next;

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
            private CSListnode<T> head; //头结点的引用
            private CSListnode<T> current; //当前结点的引用

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

            public T FirstNode() //指针指向头结点 -> 返回头结点的值
            {
                current = head;
                return current.Data;
            }

            public T NextNode() //指针指向下一个结点 -> 返回下个结点的值
            {
                if (current.Next != null)
                    current = current.Next;
                return current.Data;
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

//            Graphics myg = this.CreateGraphics();
//            Brush bkbrush = new SolidBrush(Color.FromArgb(255, 19, 14));
//            myg.FillRectangle(bkbrush, 0, 0, 200, 300);
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

#endregion

#region 程序part1:初始化

        // button_初始化
        void Initialize_Init()
        {
            Initialize_Clear();


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


            m_slist = new CSList<int>();
            for (int i = 0; i < ListSize; i++)
            {
                // todo:这里修改生成的链表的内容
                // 这里就默认顺序生成了
                int insertNum = i;

                m_slist.Insert(i, frontT_backF);
            }

            Log_Terminal($"m_slist.Length:\t{m_slist.Length}");
            Log_Terminal("-------生成链表完成-------", logType.Warning);
        }

        // button_清空
        void Initialize_Clear()
        {
            m_slist = new CSList<int>();
            Log_Terminal($"m_slist.Length:\t{m_slist.Length}");
            Log_Terminal("-------清空链表完成-------", logType.Warning);
        }

        // 遍历赋值并遍历输出 => 初始化
        void iterate_Assign_plus_Log()
        {
            //通过画刷进行填充
            Graphics myg = Console.CreateGraphics();
            Brush bkbrush = new SolidBrush(Color.White);
            myg.FillRectangle(bkbrush, 0, 0, 200, 300);
//            myg.FillRectangle(bkbrush, x1, y1, xd, yd);
//            Color bkColor = Color.FromArgb(255, 125, 125, 125);
//            bkBrush = new SolidBrush(bkColor0);
//
//            //通过画笔进行画线
//            Pen pen1 = new Pen(Color.Red, 1);
//            p1 = new Point(x1, y1);
//            p2 = new Point(x2, y2);
//            myg.Draw1(penLine, p1, p2);
//
//            //画箭头             System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);
//            Pen penLine = new Pen(Color.Red, 1);
//            penLine.CustomEndCap = lineCap;
//            myg.DrawLine(penLine, p1, p2);
//
//            //显示字符串
//            string str = “显示";
//            Font font = new Font("Arial", 12);
//            SolidBrush b1 = new SolidBrush(Color.Blue);
//            StringFormat sf1 = new StringFormat();
//            myg.DrawString(str, font, b1, x0, y0, sf1);
        }

        void DrawSList() //单链表的遍历并显示
        {
//            CSListnode<int> cp = m_slist.Current;
//            int n = m_slist.Length;
//            m_slist.FirstNode();
//            for (int i = 0; i <= n; i++)
//            {
//                tb_address.Text = "" + m_slist.Current.GetHashCode();
//                tb_data.Text = "" + m_slist.Current.Data;
//                if (m_slist.Next != null)
//                    tb_next.Text = "" + m_slist.Next.GetHashCode();
//                m_slist.NextNode();
//            }
//
//            m_slist.Current = cp;
        }


        // 遍历赋值并遍历输出 => 结点移动
        void iterate_Log()
        {
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