using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS_Program
{
    public partial class Stack_PZ : Form
    {
        //疯狂参考大佬的作品
        #region 安全性检测
        public bool IsSafe(int number)
        {
            if (number > 1000)
            {
                Log_Terminal("Error: Too Large -> larger than 1000.", logType.Error);
                return false;
            }

            if (number < 0)
            {
                Log_Terminal("Error: Too Small -> smaller than zero.", logType.Error);
                return false;
            }

            return true;
        }

        public bool IsSafe(int number, int limitUP = 1000, int limitDOWN = 0)
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

        #region 主程序
        //主程序
        public Stack_PZ()
        {
            InitializeComponent();
            Log_Terminal("Initialization 排列组合.");
            listlistbox[0] = 0;
            listlistbox[1] = 32;
            listlistbox[2] = 30;
            listlistbox[3] = 28;
            listlistbox[4] = 25;
            listlistbox[5] = 25;
            listlistbox[6] = 20;
            listlistbox[7] = 10;
            listlistbox[8] = 10;
        }
        #endregion

        #region 定义变量
        //临时表，存所有组合
        List<string> tmp_List = new List<string>();
        // n的值,即总个数
        private int totalnum;
        // m的值，即选择的个数
        private int picknum;
        //临时表，存当前组合
        List<int> m_percom_temp = new List<int>();
        //各班级人数数组
        int[] listlistbox = new int[9];
        //教室一的人数
        private int num1;
        //教室二的人数
        private int num2;
        #endregion

        #region 递归法求排列、组合、幂集
        //求排列
        void Permute_Recursion(int n, int m, int k)
        {
            //这个临时表比n大1，为了索引不溢出，把它初值设为0
            for (int i = 0; i <= n; i++)
            {
                m_percom_temp.Add(0);
            }
            //这段核心代码来自老师的ppt
            for (int i = 1; i <= n; i++)
            {
                bool tag = false;
                for (int j = 1; j <= k - 1; j++)
                {
                    if (i == m_percom_temp[j])
                    { tag = true; break; }
                }
                if (tag == false)
                {
                    m_percom_temp[k] = i;
                    if (k < m)
                        Permute_Recursion(n, m, k + 1);
                    else
                        tmp_List.Add(Getstr_percom_temp());

                }
            }
        }

        //求组合
        void Combine_Recursion(int n, int m, int k)
        {
            //这个临时表比n大1，为了索引不溢出，把它初值设为0
            for (int i = 0; i <= n; i++)
            {
                m_percom_temp.Add(0);
            }
            ////方法一，先排列再去除重复
            ////这段核心代码来自老师的ppt,改过
            //for (int i = 1; i <= n; i++)
            //{
            //    bool tag = false;
            //    for (int j = 1; j <= k - 1; j++)
            //    {
            //        if (i == m_percom_temp[j])
            //        { tag = true; break; }
            //    }

            //    if (tag == false)
            //    {
            //        m_percom_temp[k] = i;
            //        if (k < m)
            //            Combine_Recursion(n, m, k + 1);
            //        else  //土方法去除排列中重复的，完成组合
            //              { int p = 1;
            //               while(p<=m)
            //                  { if (m_percom_temp[p] < m_percom_temp[p - 1])
            //                    break; 
            //                    p++;
            //                   }
            //                 if (p == m+1) 
            //                   tmp_List.Add(Getstr_percom_temp());
            //              }

            //    }
            //}


            //方法二，直接递归
            if (k <= m)
                for (int i = k; i <= n - m + k; i++)
                {
                    m_percom_temp[k] = i;
                    if (i > m_percom_temp[k - 1])
                        Combine_Recursion(n, m, k + 1);
                }
            else
                tmp_List.Add(Getstr_percom_temp());
        }

        //幂集，使用递归法
        void Powerset_Recursion(int n)
        {
            tmp_List.Add(" ");
            for (int i = 1; i <= n; i++)
            {
                picknum = i;
                Combine_Recursion(n, i, 1);
                m_percom_temp.Clear();
            }
        }




        #endregion

        #region 栈法求排列、组合、幂集
        //拷贝ppt
        //求排列
        public void Fun_Permute_Stack(int n, int m)
        {
            //这个临时表比n大1，为了索引不溢出，把它初值设为0
            for (int i = 0; i <= totalnum; i++)
            {
                m_percom_temp.Add(0);
            }
            int[] s_no = new int[m + 1]; //存放栈顶次数的栈
            bool[] s_tag = new bool[n + 1];
            //存放下标是否在栈中的标记
            int top = 0;
            //第一个进栈
            top++;
            m_percom_temp[top] = 1;
            s_no[top] = 1;
            s_tag[1] = true;//在栈中
            //栈不空时循环
            while (top > 0)
            {
                if (s_no[top] == 1) //查看栈顶标记
                {
                    s_no[top] = 2; //修改栈顶标记                    
                    if (top < m) //继续进栈
                    {
                        for (int i = 1; i <= n; i++)
                        {
                            if (s_tag[i] == false)
                            {
                                top++;
                                m_percom_temp[top] = i;
                                s_no[top] = 1;
                                s_tag[i] = true;//在栈中
                                break;
                            }
                        }
                    }
                    else
                        tmp_List.Add(Getstr_percom_temp());
                }
                else if (s_no[top] == 2) //查看栈顶标记
                {
                    s_tag[m_percom_temp[top]] = false;//不在栈中了
                    top--; //出栈
                           //下一个进栈
                    for (int i = m_percom_temp[top + 1] + 1; i <= n; i++)
                    {
                        if (s_tag[i] == false)
                        {
                            top++;
                            m_percom_temp[top] = i;
                            s_no[top] = 1;
                            s_tag[i] = true;//在栈中
                            break;
                        }
                    }
                }

            }
        }



        //求组合
        public void NotFun_Permute_Stack(int n, int m)
        {
            //这个临时表比n大1，为了索引不溢出，把它初值设为0
            for (int i = 0; i <= totalnum; i++)
            {
                m_percom_temp.Add(0);
            }

            int[] s_no = new int[12]; //存放栈顶次数的栈
            bool[] s_tag = new bool[12];
            //存放下标是否在栈中的标记
            int top = 0;
            //第一个进栈
            top++;
            m_percom_temp[top] = 1;
            s_no[top] = 1;
            s_tag[1] = true;//在栈中
                            //栈不空时循环
            while (top > 0)
            {
                //方法一，如递归，在输出时去除重复
                if (s_no[top] == 1) //查看栈顶标记
                {
                    s_no[top] = 2; //修改栈顶标记                    
                    if (top < m) //继续进栈
                    {
                        for (int i = 1; i <= n; i++)
                        {
                            if (s_tag[i] == false)
                            {
                                top++;
                                m_percom_temp[top] = i;
                                s_no[top] = 1;
                                s_tag[i] = true;//在栈中
                                break;
                            }
                        }
                    }
                    else  //土方法去除排列中重复的，完成组合
                    {
                        int p = 1;
                        while (p <= m)
                        {
                            if (m_percom_temp[p] < m_percom_temp[p - 1])
                                break;
                            p++;
                        }
                        if (p == m + 1)
                            tmp_List.Add(Getstr_percom_temp());
                    }
                }
                else if (s_no[top] == 2) //查看栈顶标记
                {
                    s_tag[m_percom_temp[top]] = false;//不在栈中了
                    top--; //出栈
                           //下一个进栈
                    for (int i = m_percom_temp[top + 1] + 1; i <= n; i++)
                    {
                        if (s_tag[i] == false)
                        {
                            top++;
                            m_percom_temp[top] = i;
                            s_no[top] = 1;
                            s_tag[i] = true;//在栈中
                            break;
                        }
                    }
                }

                //方法二，直接栈法求组合,想不出来，枯了

            }
        }
        //幂集，使用栈法
        void Powerset_stack(int n)
        {
            tmp_List.Add(" ");
            for (int i = 1; i <= n; i++)
            {
                picknum = i;
                NotFun_Permute_Stack(n, i);
                m_percom_temp.Clear();
            }
        }
        //捕捉满足要求的排列组合
        string Getstr_percom_temp()
        {
            string str = ""; int i = 1;
            while (i < picknum)
            {
                str += " " + m_percom_temp[i] + ","; i++;
            }
            str += " " + m_percom_temp[i] + " ";
            return str;
        }

        #endregion

        #region 初始化并开始运行
        //排列的初始化
        void Permute_Init()

        {   //清空console
            Recursion_Clear();
            // 输入安全性检测    
            if (!IsInputNumSafe(textBox_totalnum, out totalnum, "totalnum")) return;
            if (!IsInputNumSafe(textBox_picknum, out picknum, "picknum")) return;
            if (totalnum > 10 || picknum > 10) { Log_Terminal("请输入不超过10的数", logType.Error); return; }
            //n必须大于等于m
            if (totalnum < picknum)
            { Log_Terminal("n的数值不能够小于m！", logType.Error); return; }
            if (radio_recursion.Checked == true)
                Permute_Recursion(totalnum, picknum, 1);
            if (radio_stack.Checked == true)
                Fun_Permute_Stack(totalnum, picknum);
            Output();

        }
        //组合的初始化
        void Combine_Init()

        {   //清空console
            Recursion_Clear();
            // 输入安全性检测    
            if (!IsInputNumSafe(textBox_totalnum, out totalnum, "totalnum")) return;
            if (!IsInputNumSafe(textBox_picknum, out picknum, "picknum")) return;
            if (totalnum > 10 && picknum > 10) { Log_Terminal("请输入不超过10的数", logType.Error); return; }
            //n必须大于等于m
            if (totalnum < picknum)
            { Log_Terminal("n的数值不能够小于m！", logType.Error); return; }
            if (radio_recursion.Checked == true)
                Combine_Recursion(totalnum, picknum, 1);
            if (radio_stack.Checked == true)
                NotFun_Permute_Stack(totalnum, picknum);
            Output();

        }
        //幂集的初始化
        void Powerset_Init()
        {
            Recursion_Clear();
            // 输入安全性检测    
            if (!IsInputNumSafe(textBox3, out totalnum, "totalnum")) return;
            if (totalnum > 10) { Log_Terminal("请输入不超过10的数", logType.Error); return; }
            if (radio_recursion.Checked == true)
                Powerset_Recursion(totalnum);
            if (radio_stack.Checked == true)
                Powerset_stack(totalnum);
            Output();
        }
        //清空函数
        void Recursion_Clear()
        {
            tmp_List.Clear();
            m_percom_temp.Clear();
            Console.Text = "";
        }

        //输出函数
        void Output()
        {
            int length = tmp_List.Count;
            for (int i = 1; i <= length; i++)
            {
                Log_Console($"({i})\t【{tmp_List[i - 1]}】");
            }

        }
        //Log跟进
        void Outputlog()
        {
            Log_Terminal($"tmp_List.Count\t{tmp_List.Count}");
            Log_Terminal($"-------生成完毕-------", logType.Warning);

        }
        #endregion

        #region 教室安排与初始化
        //此为递归组合
        void Room_pre(int m, int k)
        {

            for (int i = 0; i <= 8; i++)
            {
                m_percom_temp.Add(0);
            }
            if (k <= m)
                for (int i = k; i <= 8 - m + k; i++)
                {
                    m_percom_temp[k] = i;
                    if (i > m_percom_temp[k - 1])
                        Room_pre(m, k + 1);
                }
            else
                Room_Arrange();
        }
        //将满足要求的组合加入临时表
        void Room_Arrange()
        {
            int roomonetotal = 0;
            for (int i = 1; i <= 8; i++)
            {
                roomonetotal = roomonetotal + listlistbox[m_percom_temp[i]];
            }
            if ((roomonetotal <= num1) && ((180 - roomonetotal) <= num2))
                tmp_List.Add(Getstr_percom_temp());
        }
        //安排房间初始化
        void Room_Init()
        {
            //清空console
            Recursion_Clear();
            // 输入安全性检测    
            if (!IsInputNumSafe(textBox_room1, out num1, "room one num")) return;
            if (!IsInputNumSafe(textBox_room2, out num2, "room two num")) return;
            if (num1 + num2 < 180)
                Log_Terminal("不能完全容纳所有的学生", logType.Warning);
            //这是教室一为空的状态
            if (num2 >= 180)
                tmp_List.Add(" ");
            for (int i = 1; i <= 8; i++)//一共八个班级
            {
                picknum = i;
                Room_pre(i, 1);
                m_percom_temp.Clear();
            }
            Output();

        }

        #endregion

        #region Button_Trigger
        //这些都没有用处，但是又删不掉。。。
        private void button_ClearTerm_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox_room1_TextChanged(object sender, EventArgs e)
        {

        }

        //排列按钮
        private void button_A_Click(object sender, EventArgs e)
        {
            string radio = "";
            if (radio_recursion.Checked == true)
                radio = radio_recursion.Text;
            if (radio_stack.Checked == true)
                radio = radio_stack.Text;
            Permute_Init();
            if (tmp_List.Count != 0)//临时表没有元素，表示初始化失败
            {
                Log_Terminal($"{radio}执行{button_A.Text}：n={totalnum},m={picknum}", logType.Warning);
                Outputlog();
            }
            tmp_List.Clear();//清空临时表，防止影响下一次操作

        }
        //组合按钮
        private void button_C_Click(object sender, EventArgs e)
        {
            string radio = "";
            if (radio_recursion.Checked == true)
                radio = radio_recursion.Text;
            if (radio_stack.Checked == true)
                radio = radio_stack.Text;
            Combine_Init();
            if (tmp_List.Count != 0)//临时表没有元素，表示初始化失败
            {
                Log_Terminal($"{radio}执行{button_C.Text}：n={totalnum},m={picknum}", logType.Warning);
                Outputlog();
            }
            tmp_List.Clear();//清空临时表，防止影响下一次操作

        }
        //log清除按钮
        private void button_ClearTerm_Click_1(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_ClearTerm.Text}:", logType.Warning);
            Terminal.Text = "";
        }
        //幂集按钮
        private void button_powerset_Click(object sender, EventArgs e)
        {

            string radio = "";
            if (radio_recursion.Checked == true)
                radio = radio_recursion.Text;
            if (radio_stack.Checked == true)
                radio = radio_stack.Text;
            Powerset_Init();
            if (tmp_List.Count != 0)//临时表没有元素，表示初始化失败
            {
                Log_Terminal($"{radio}执行{button_powerset.Text}：n={totalnum}", logType.Warning);
                Outputlog();
            }
            tmp_List.Clear();//清空临时表，防止影响下一次操作
        }
        //安排房间按钮
        private void button_arrange_Click(object sender, EventArgs e)
        {
            Room_Init();
            if (tmp_List.Count != 0)//临时表没有元素，表示初始化失败
            {
                Log_Terminal($"执行{button_arrange.Text}：n={totalnum}", logType.Warning);
                Outputlog();
                tmp_List.Clear();//清空临时表，防止影响下一次操作
            }
        }
        //退出按钮
        private void button_exit_Click(object sender, EventArgs e)
        {
            Log_Terminal($"执行{button_exit.Text}:", logType.Warning);
            Recursion_Clear();
            Close();
        }
    }

}
#endregion