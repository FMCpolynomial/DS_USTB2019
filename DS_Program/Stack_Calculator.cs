using System;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DS_Program
{
    public partial class Stack_Calculator : Form
    {
        public Stack_Calculator()
        {
            InitializeComponent();
        }

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

        //warning:重载大法好!
        public override string ToString()
        {
            Log_Terminal("当前已存在窗体,新建无效", logType.Error);
            return base.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Terminal.Text = "";
        }

#endregion

#region 数据结构:栈的接口 | 实现

        // 栈的接口
        public interface ICStack<T>
        {
            bool IsEmpty();
            bool IsFull();
            void MakeEmpty();
            bool Push(T item);
            T Pop();
            T Gettop();
            string GetStackALLDate(string sname);
        }

        // 栈的实现1:链栈结点
        class CStacknode<T>
        {
            public CStacknode()
            {
                next = null;
            }

            public CStacknode(T data)
            {
                this.data = data;
                next = null;
            }

            public CStacknode(T data, CStacknode<T> next)
            {
                this.data = data;
                this.next = next;
            }

            public T Data
            {
                get => data;
                set => data = value;
            }
            public CStacknode<T> Next
            {
                get => next;
                set => next = value;
            }
            private T data;
            private CStacknode<T> next;
        }

        // 栈的实现2:链栈本体
        class CLinkStack<T> : ICStack<T>
        {
            public void MakeEmpty()
            {
                top = null;
            }

            public bool IsEmpty()
            {
                return top == null;
            }

            public bool IsFull()
            {
                return false;
            }

            public CLinkStack()
            {
                top = null;
            }

            public bool Push(T item)
            {
                top = new CStacknode<T>(item, top);
                return true;
            }

            public T Pop()
            {
                T data = top.Data;
                top = top.Next;
                return data;
            }

            public T Gettop()
            {
                bool flag = top == null;
                T result;
                if (flag)
                {
                    result = default(T);
                }
                else
                {
                    result = top.Data;
                }

                return result;
            }

            public string GetStackALLDate(string sname)
            {
                string text = "  】";
                bool flag = IsEmpty();
                if (flag)
                {
                    text = sname + " stack is null";
                }

                for (CStacknode<T> next = top; next != null; next = next.Next)
                {
                    text = next.Data + "    " + text;
                }

                text = "【  " + text + "\r\n";
                return text + "---------------------------------------\r\n";
            }

            private CStacknode<T> top;
        }

#endregion

#region 有理数类

        class Rational
        {
            private int num; //分子
            private int den; //分母
            public int Num
            {
                get => num;
                set => num = value;
            }
            public int Den
            {
                get => den;
                set => den = value;
            }

            public void optimization()
            {
                bool flag = den == 0;
                if (flag)
                {
                    num = 0;
                }

                bool flag2 = this.num == 0;
                if (flag2)
                {
                    den = 1;
                }
                else
                {
                    int num = (Math.Abs(this.num) < Math.Abs(den)) ? Math.Abs(this.num) : Math.Abs(den);
                    bool flag3 = num == 0;
                    if (!flag3)
                    {
                        int i;
                        for (i = num; i > 1; i--)
                        {
                            bool flag4 = this.num % i == 0 && den % i == 0;
                            if (flag4)
                            {
                                break;
                            }
                        }

                        this.num /= i;
                        den /= i;
                        bool flag5 = this.num < 0 && den < 0;
                        if (flag5)
                        {
                            this.num = -this.num;
                            den = -den;
                        }
                        else
                        {
                            bool flag6 = this.num < 0 || den < 0;
                            if (flag6)
                            {
                                this.num = -Math.Abs(this.num);
                                den = Math.Abs(den);
                            }
                        }
                    }
                }
            }

            public Rational()
            {
                num = 0;
                den = 1;
            }

            public Rational(int x, int y)
            {
                num = x;
                den = y;
                optimization();
            }

            public Rational(Rational ob)
            {
                num = ob.num;
                den = ob.den;
                optimization();
            }

            public Rational(double x)
            {
                // todo:这里可能有错,是一个检验浮点数是否相等的判断
                //bool flag = (double) ((int) x) == x;
                bool flag = Math.Abs((double) ((int) x) - x) < 0.000001;

                if (flag)
                {
                    num = (int) x;
                    den = 1;
                }
                else
                {
                    num = (int) (x * 1000.0 + 0.5);
                    den = 1000;
                }

                optimization();
            }

            // 输出展示函数
            public override string ToString()
            {
                bool flag = den == 1;
                string result;
                if (flag)
                {
                    result = string.Concat(num);
                }
                else
                {
                    result = num + "/" + den;
                }

                return result;
            }

            public double todouble()
            {
                return (double) num / (double) den;
            }

#region 操作符重载

            public static Rational operator +(Rational rat1, Rational rat2)
            {
                Rational rational = new Rational(0, 1);
                rational.den = rat1.den * rat2.den;
                rational.num = rat1.num * rat2.den + rat1.den * rat2.num;
                rational.optimization();
                return rational;
            }

            public static Rational operator -(Rational rat1, Rational rat2)
            {
                Rational rational = new Rational(0, 1);
                rational.den = rat1.den * rat2.den;
                rational.num = rat1.num * rat2.den - rat1.den * rat2.num;
                rational.optimization();
                return rational;
            }

            public static Rational operator -(Rational rat1)
            {
                Rational rational = new Rational(0, 1);
                rational.den = rat1.den;
                rational.num = -rat1.num;
                rational.optimization();
                return rational;
            }

            public static Rational operator *(Rational rat1, Rational rat2)
            {
                Rational rational = new Rational(0, 1);
                rational.den = rat1.den * rat2.den;
                rational.num = rat1.num * rat2.num;
                rational.optimization();
                return rational;
            }

            public static Rational operator /(Rational rat1, Rational rat2)
            {
                Rational rational = new Rational(0, 1);
                rational.den = rat1.den * rat2.num;
                rational.num = rat1.num * rat2.den;
                rational.optimization();
                return rational;
            }

            public static Rational operator ^(Rational rat1, int k)
            {
                Rational rational = new Rational(1, 1);
                rational.den = 1;
                rational.num = 1;
                bool flag = k > 0;
                if (flag)
                {
                    for (int i = 1; i <= k; i++)
                    {
                        rational.den *= rat1.den;
                        rational.num *= rat1.num;
                    }
                }
                else
                {
                    bool flag2 = k < 0;
                    if (flag2)
                    {
                        for (int j = 1; j <= -k; j++)
                        {
                            rational.den *= rat1.num;
                            rational.num *= rat1.den;
                        }
                    }
                }

                rational.optimization();
                return rational;
            }

            public static Rational operator ++(Rational rat1)
            {
                Rational rat2 = new Rational(1, 1);
                rat1 += rat2;
                rat1.optimization();
                return rat1;
            }

            public static Rational operator --(Rational rat1)
            {
                Rational rat2 = new Rational(1, 1);
                rat1 -= rat2;
                rat1.optimization();
                return rat1;
            }

#endregion
        }

#endregion

#region 计算器类

        class Calculator
        {
            private CLinkStack<Rational> data; //操作数栈
            private CLinkStack<char> oper; //操作符栈
            private CLinkStack<int> degree; //操作符优先级栈

            public Calculator(int sz)
            {
                _sz = sz;
                data = new CLinkStack<Rational>();
                oper = new CLinkStack<char>();
                degree = new CLinkStack<int>();
            }

            private readonly int _sz;

            private void AddOperand(Rational value)
            {
                data.Push(value);
            }

            private bool Get2Operands(out Rational left, out Rational right)
            {
                Rational rational;
                right = (rational = new Rational());
                left = rational;
                bool flag = data.IsEmpty();
                bool result;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    right = data.Pop();
                    bool flag2 = data.IsEmpty();
                    if (flag2)
                    {
                        result = false;
                    }
                    else
                    {
                        left = data.Pop();
                        result = true;
                    }
                }

                return result;
            }

            private void DoOperator(char op)
            {
                Rational rational = new Rational();
                Rational rat;
                Rational rational2;
                bool flag = Get2Operands(out rat, out rational2);
                if (flag)
                {
                    switch (op)
                    {
                        case '*':
                            data.Push(rat * rational2);
                            break;
                        case '+':
                            data.Push(rat + rational2);
                            break;
                        case ',':
                        case '.':
                            break;
                        case '-':
                            data.Push(rat - rational2);
                            break;
                        case '/':
                        {
                            bool flag2 = rational2 == rational;
                            if (flag2)
                            {
                                data.MakeEmpty();
                            }
                            else
                            {
                                data.Push(rat / rational2);
                            }

                            break;
                        }
                        default:
                            if (op == '^')
                            {
                                bool flag3 = rational2 == rational;
                                if (flag3)
                                {
                                    data.MakeEmpty();
                                }
                                else
                                {
                                    data.Push(rat ^ rational2.Num);
                                }
                            }

                            break;
                    }
                }
                else
                {
                    data.MakeEmpty();
                }
            }

            public void Clear()
            {
                data.MakeEmpty();
            }

            public Rational Run(string pc, out string strout, out int errorCode)
            {
                int num = 0;
                int length = pc.Length;
                char c = pc[num++];
                Rational result = new Rational();
                strout = "";
                while (c > '\0')
                {
                    while (c == ' ')
                    {
                        c = pc[num++];
                    }

                    // 1. 输入非法判断
                    string text = "+-*/^()[]0123456789.";
                    bool flag = text.IndexOf(c) >= 0;
                    if (!flag)
                    {
                        //warning:输入非法
                        errorCode = 1;
                        return result;
                    }

                    // 2. 运算优先级判断
                    text = "+-*/^()[]";
                    bool flag2 = text.IndexOf(c) >= 0;
                    if (flag2)
                    {
                        char c2 = c;
                        // 运算优先级
                        int num_priority;
                        switch (c2)
                        {
                            case '(':
                                num_priority = 4;
                                break;
                            case ')':
                                num_priority = 0;
                                break;
                            case '*':
                                num_priority = 2;
                                break;
                            case '+':
                                num_priority = 1;
                                break;
                            case ',':
                            case '.':
                                goto IL_F0;
                            case '-':
                                num_priority = 1;
                                break;
                            case '/':
                                num_priority = 2;
                                break;
                            default:
                                switch (c2)
                                {
                                    case '[':
                                        num_priority = 4;
                                        break;
                                    case '\\':
                                        goto IL_F0;
                                    case ']':
                                        num_priority = 0;
                                        break;
                                    case '^':
                                        num_priority = 3;
                                        break;
                                    default:
                                        goto IL_F0;
                                }

                                break;
                        }

                        IL_F5:
                        while (!degree.IsEmpty() && num_priority <= degree.Gettop())
                        {
                            char c4;
                            char c3 = c4 = oper.Gettop();
                            switch (c4)
                            {
                                case '(':
                                    break;
                                case ')':
                                case ',':
                                case '.':
                                    break;
                                case '*':
                                case '+':
                                case '-':
                                case '/':
                                    goto IL_13F;
                                default:
                                    if (c4 == '^')
                                    {
                                        goto IL_13F;
                                    }

                                    break;
                            }

                            IL_14C:
                            oper.Pop();
                            degree.Pop();
                            strout += oper.GetStackALLDate("oper");
                            strout += data.GetStackALLDate("data");
                            bool flag3 = c3 == '(' || c3 == '[';
                            if (flag3)
                            {
                                break;
                            }

                            continue;
                            IL_13F:
                            DoOperator(c3);
                            goto IL_14C;
                        }

                        bool flag4 = c != ')' && c != ']';
                        if (flag4)
                        {
                            oper.Push(c);
                            strout += oper.GetStackALLDate("oper");
                            bool flag5 = c == '(' || c == '[';
                            if (flag5)
                            {
                                degree.Push(0);
                            }
                            else
                            {
                                degree.Push(num_priority);
                            }
                        }

                        bool flag6 = num < length;
                        if (flag6)
                        {
                            c = pc[num++];
                        }
                        else
                        {
                            c = '\0';
                        }

                        continue;
                        IL_F0:
                        num_priority = 10;
                        goto IL_F5;
                    }

                    string text2 = "";
                    bool flag7 = c > '\0';
                    if (flag7)
                    {
                        text2 += c.ToString();
                    }

                    bool flag8 = num < length;
                    if (flag8)
                    {
                        c = pc[num++];
                    }
                    else
                    {
                        c = '\0';
                    }

                    text = "0123456789.";
                    while (c != '\0' && text.IndexOf(c) >= 0)
                    {
                        bool flag9 = c > '\0';
                        if (flag9)
                        {
                            text2 += c.ToString();
                        }

                        bool flag10 = num < length;
                        if (flag10)
                        {
                            c = pc[num++];
                        }
                        else
                        {
                            c = '\0';
                        }
                    }

                    data.Push(new Rational(Convert.ToDouble(text2)));
                    strout += data.GetStackALLDate("data");
                }

                while (!oper.IsEmpty())
                {
                    char c5;
                    char c3 = c5 = oper.Gettop();
                    switch (c5)
                    {
                        case '(':
                            break;
                        case ')':
                        case ',':
                        case '.':
                            break;
                        case '*':
                        case '+':
                        case '-':
                        case '/':
                            goto IL_398;
                        default:
                            if (c5 != '[')
                            {
                                if (c5 == '^')
                                {
                                    goto IL_398;
                                }
                            }

                            break;
                    }

                    IL_3A7:
                    oper.Pop();
                    degree.Pop();
                    strout += oper.GetStackALLDate("oper");
                    strout += data.GetStackALLDate("data");
                    continue;
                    IL_398:
                    DoOperator(c3);
                    goto IL_3A7;
                }

                //warning:平安无事
                errorCode = 0;
                return data.Gettop();
            }
        }

#endregion

#region 按键响应

        private void Form_Calculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            //FormMain.myform_calculator = null;
        }

        string Console_text;
        int Terminal_errorCode;

        private void bt_calculat_Click(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator(50);
            Rational rational;
            bool flag = tb_express.Text == "";
            if (flag)
            {
                tb_result.Text = "null";
            }
            else
            {
                rational = calculator.Run(tb_express.Text, out Console_text, out Terminal_errorCode);


                long num = (long) rational.Num;
                long num2 = (long) rational.Den;
                bool flag2 = num2 == 1L;
                string text2;
                if (flag2)
                {
                    text2 = string.Concat(num);
                }
                else
                {
                    text2 = num + "/" + num2;
                }

                tb_result.Text = text2;
                tb_strout.Text = Console_text;
            }


            switch (Terminal_errorCode)
            {
                case 0:
                    Log_Terminal("计算完成", logType.CommonLog);
                    break;
                case 1:
                    Log_Terminal("输入存在非法字符,请检查后重新输入", logType.Error);
                    break;
            }

            // 还原输出
            Console_text = "";
            Terminal_errorCode = 0;
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
            //FormMain.myform_calculator = null;
        }


        private void button_mr_MouseClick(object sender, MouseEventArgs e)
        {
            Button _button = (Button) sender;
            tb_express.Text += _button.Text.ToString();
        }

        private void button_eClear_Click(object sender, EventArgs e)
        {
            tb_express.Text = "";
            Log_Terminal("清空输入框", logType.Warning);
        }

        private void button_eDel_Click(object sender, EventArgs e)
        {
            if (tb_express.Text != "")
            {
                string tmp = tb_express.Text;
                tmp = tmp.Remove(tmp.Length - 1, 1);
                tb_express.Text = tmp;
                Log_Terminal("回删", logType.Warning);
            }
            else
            {
                Log_Terminal("输入框已清空", logType.Warning);
            }
        }

#endregion
    }
}