using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DS_Program
{
    public partial class ArrayProcess : Form
    {
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

        public bool IsInputNumSafe(TextBox tb, out int num, string errorStr)
        {
            if (!Int32.TryParse(tb.Text, out num))
            {
                Log_Terminal($"{errorStr} Input  Error", logType.Error);
                return false;
            }

            if (!IsSafe(num))
            {
                Log_Terminal($"{errorStr} Safety Error", logType.Error);
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

#region 顺序表定义

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        class CSeqList<T> //顺序表泛型类
        {
            private T[] data; //顺序表数据
            private int MaxSize; //最大空间
            private int datasize; //实际元素个数
            public int DataSize
            {
                get { return datasize; }
            }

            //todo:这里是我乱加的
            public T this[int index]
            {
                // 暂时只给get不给set
                get => data[index];
//                set => data[index];
            }


            public CSeqList(int MaxSize) //构造函数
            {
                this.MaxSize = MaxSize;
                data = new T[MaxSize];
                datasize = 0;
            }

            public CSeqList(int MaxSize, T[] data, int n)
            {
                this.MaxSize = MaxSize;
                this.data = new T[MaxSize];
                for (int i = 0; i < n; i++)
                    this.data[i] = data[i];
                datasize = n;
            }

            public bool Inset(int k, T dt)
            {
                if (k < 1 || k > datasize + 1)
                    return false;
                if (datasize == MaxSize)
                    return false;
                for (int i = datasize - 1; i >= k - 1; i--)
                    data[i + 1] = data[i];
                data[k - 1] = dt;
                datasize++;
                return true;
            }

            public bool Delete(int k)
            {
                if (k < 1 || k > datasize)
                    return false;
                for (int i = k - 1; i < datasize - 1; i++)
                    data[i] = data[i + 1];
                datasize--;
                return true;
            }

            public bool Update(int k, T dt)
            {
                if (k < 1 || k > datasize)
                    return false;
                data[k - 1] = dt;
                return true;
            }

            public void MakeEmpty()
            {
                datasize = 0;
                //todo:这里是我乱加的
                data = new T[MaxSize];
            }

            public string MyPrint()
            {
                string strout = "";
                for (int i = 0; i < MaxSize; i++)
                {
                    if (i < datasize)
                        strout += (i + 1) + "\t【" + data[i] + "】\n";
                }

                return strout;
            }
        }

#endregion

        // 程序启动
        public ArrayProcess()
        {
            InitializeComponent();
            Log_Terminal("Initialization.");
        }

#region  程序变量

        // 顺序表
        CSeqList<int> _cSeqList;
        // 临时表 => 所有生成的表都先存放在这里 若顺序则直接用 若随机打乱顺序之后使用
        List<int> tmp_List = new List<int>();

        // 最大数量
        private int MaxSize;
        // 顺序表长度
        private int ArraySize;

        // 操作位置
        private int ProcessPos;
        // 操作数据
        private int ProcessData;

#endregion

#region 程序part1:初始化

        // button_初始化
        void Initialize_Init()
        {
            Initialize_Clear();

            // 检测输入安全性
//            if (!Int32.TryParse(textBox_MaxSize.Text, out MaxSize))
//            {
//                Log_Terminal("MaxSize Checked Error", logType.Error);
//                return;
//            }
//
//            if (!IsSafe(MaxSize))
//            {
//                Log_Terminal("MaxSize Safety Error", logType.Error);
//                return;
//            }
//
//            if (!Int32.TryParse(textBox_DataNum.Text, out ArraySize))
//            {
//                Log_Terminal("ArraySize Checked Error", logType.Error);
//                return;
//            }
//
//            if (!IsSafe(ArraySize))
//            {
//                Log_Terminal("ArraySize Safety Error", logType.Error);
//                return;
//            }

            // 输入安全性检测    
            if (!IsInputNumSafe(textBox_MaxSize, out MaxSize, "MaxSize")) return;
            if (!IsInputNumSafe(textBox_ArraySize, out ArraySize, "ArraySize")) return;
            if (!radio_Sequence.Checked && !radio_Random.Checked)
            {
                Log_Terminal("Radion button Unchecked", logType.Error);
            }

            // 正式运行程序
            _cSeqList = new CSeqList<int>(MaxSize);
            if (radio_Random.Checked)
            {
                Log_Terminal("_____随机生成_____");

//                这个是给素数和fib用的
//                disturbListOrder();

                Random rand = new Random();
                for (int i = 0; i < ArraySize; i++)
                {
                    tmp_List.Add(rand.Next(MaxSize));
                    Log_Terminal($"随机数列第{i}:\t {tmp_List[i].ToString()}");
                }

                iterate_Assign_plus_Log();
            }

            if (radio_Sequence.Checked)
            {
                Log_Terminal("_____顺序生成_____");

                for (int i = 0; i < ArraySize; i++)
                {
                    tmp_List.Add(i + 1);
                    Log_Terminal($"顺序数列第{i}:\t {tmp_List[i].ToString()}");
                }

                iterate_Assign_plus_Log();
            }
        }

        // button_清空
        void Initialize_Clear()
        {
            _cSeqList = new CSeqList<int>(MaxSize);
            _cSeqList.MakeEmpty();

            MaxSize = 0;
            ArraySize = 0;
            tmp_List.Clear();

            Console.Text = "";
        }

        // button_斐波那契
        int Generate_Fibonacci(int index)
        {
            index++;
            int f1 = 0, f2 = 1, res = 0;
            Log_Terminal($"Fibonacci数列第 {1}项： {f2}");
            List<int> tmp = new List<int>();
            tmp.Add(f2);

            for (int n = 2; n < index; n++)
            {
                if (n % 2 == 1)
                {
                    f1 = f1 + f2;
                    Log_Terminal($"Fibonacci数列第 {n}项： {f1}");

                    // 扩充
                    tmp.Add(f1);
                    ArraySize = tmp.Count;

                    if (n == index - 1) res = f1;
                }

                if (n % 2 == 0)
                {
                    f2 = f1 + f2;
                    Log_Terminal($"Fibonacci数列第 {n}项： {f2}");

                    // 扩充
                    tmp.Add(f2);
                    ArraySize = tmp.Count;

                    if (n == index - 1) res = f2;
                }

                tmp_List = tmp;
            }


            return res;
        }

        void Initialize_Fibonacci()
        {
            Initialize_Clear();

            // 输入安全性检测    
            if (!IsInputNumSafe(textBox_MaxSize, out MaxSize, "MaxSize")) return;
            if (!IsInputNumSafe(textBox_ArraySize, out ArraySize, "ArraySize")) return;
            if (!radio_Sequence.Checked && !radio_Random.Checked)
            {
                Log_Terminal("Radion button Unchecked", logType.Error);
            }

            // 正式运行程序
            _cSeqList = new CSeqList<int>(MaxSize);
            if (radio_Random.Checked)
            {
                Log_Terminal("_____随机生成Fib_____");

                //这个是给素数和fib用的
                Generate_Fibonacci(ArraySize);
                disturbListOrder();

                iterate_Assign_plus_Log();
            }

            if (radio_Sequence.Checked)
            {
                Log_Terminal("_____顺序生成Fib_____");

                //这个是给素数和fib用的
                Generate_Fibonacci(ArraySize);
                iterate_Assign_plus_Log();
            }
        }

        // button_素数
        void Generate_PrimeNum(int index)
        {
            Log_Terminal("只能作用于10000以内的素数查询", logType.Warning);
            tmp_List.Add(2);
            Log_Terminal($"素数数列第{1}:\t {tmp_List.Last().ToString()}");

            // 输出1~n之间的所有素数，n>=3
            int i, j = 0;
            for (i = 3; i <= 10000; i = i + 2)
            {
                int k = (int) Math.Sqrt(i);
                for (j = 2; j <= k; j++)
                {
                    if ((i % j) == 0)
                    {
                        break;
                    }
                }

                if (j > k)
                {
                    tmp_List.Add(i);
                    Log_Terminal($"素数数列第{tmp_List.Count}:\t {tmp_List.Last().ToString()}");
                    if (tmp_List.Count == index)
                    {
                        return;
                    }
                }
            }
        }

        void Initialize_PrimeNum()
        {
            Initialize_Clear();

            // 输入安全性检测    
            if (!IsInputNumSafe(textBox_MaxSize, out MaxSize, "MaxSize")) return;
            if (!IsInputNumSafe(textBox_ArraySize, out ArraySize, "ArraySize")) return;
            if (!radio_Sequence.Checked && !radio_Random.Checked)
            {
                Log_Terminal("Radion button Unchecked", logType.Error);
            }

            // 正式运行程序
            _cSeqList = new CSeqList<int>(MaxSize);
            if (radio_Random.Checked)
            {
                Log_Terminal("_____随机生成Fib_____");

                //这个是给素数和fib用的
                Generate_PrimeNum(ArraySize);
                disturbListOrder();

                iterate_Assign_plus_Log();
            }

            if (radio_Sequence.Checked)
            {
                Log_Terminal("_____顺序生成Fib_____");

                //这个是给素数和fib用的
                Generate_PrimeNum(ArraySize);
                iterate_Assign_plus_Log();
            }
        }

        // 打乱顺序
        void disturbListOrder()
        {
            var random = new Random();
            List<int> newList = new List<int>();
            foreach (var item in tmp_List)
            {
                newList.Insert(random.Next(newList.Count), item);
            }

            tmp_List = newList;
        }

        // 遍历赋值并遍历输出 => 初始化
        void iterate_Assign_plus_Log()
        {
            for (int i = 0; i < tmp_List.Count; i++)
            {
                _cSeqList.Inset(i + 1, tmp_List[i]);

                //为了和老师的序号同步,序号集体加1
                Log_Console($"{i + 1}\t[{_cSeqList[i]}]");
            }

            Log_Terminal($"ArraySize     \t{ArraySize}");
            Log_Terminal($"cSeqList.Count\t{_cSeqList.DataSize}");
            Log_Terminal($"tmp_List.Count\t{tmp_List.Count}");
        }

        // 遍历赋值并遍历输出 => 结点移动
        void iterate_Log()
        {
            for (int i = 0; i < _cSeqList.DataSize; i++)
            {
                //为了和老师的序号同步,序号集体加1
                Log_Console($"{i + 1}\t[{_cSeqList[i]}]");
            }

            Log_Terminal($"ArraySize     \t{ArraySize}");
            Log_Terminal($"cSeqList.Count\t{_cSeqList.DataSize}");
            Log_Terminal($"tmp_List.Count\t{tmp_List.Count}");
        }

#endregion

#region 程序part2:结点移动

        bool Check_cSeqList()
        {
            if (_cSeqList == null) return false;
            return true;
        }

#endregion

#region Button_Trigger

        private void button_Init_Click(object sender, EventArgs e)
        {
            Initialize_Init();
        }

        private void button_ClearTerm_Click(object sender, EventArgs e)
        {
            Terminal.Text = "";
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Console.Text = "";
        }

        private void button_Fibbnacii_Click(object sender, EventArgs e)
        {
            Initialize_Fibonacci();
        }

        private void button_PrimeNum_Click(object sender, EventArgs e)
        {
            Initialize_PrimeNum();
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            if (!Check_cSeqList())
            {
                Log_Terminal("顺序表未加载!", logType.Error);
                return;
            }

            if (radio_Head.Checked)
            {
                _cSeqList.Delete(1);
            }
            else if (radio_Tail.Checked)
            {
                _cSeqList.Delete(_cSeqList.DataSize - 1);
            }
            else if (radio_ten.Checked)
            {
                // 输入安全性检测    
                if (!IsInputNumSafe(textBox_DataPos, out ProcessPos, "ProcessPos")) return;
//                if (!IsInputNumSafe(textBox_Data, out ProcessData, "ProcessData")) return;

                if (ProcessPos <= ArraySize && ProcessPos >= 1)
                {
                    _cSeqList.Delete(ProcessPos);
                }
                else
                {
                    Log_Terminal($"ArraySize:\t{ArraySize.ToString()}", logType.Warning);
                    Log_Terminal($"ProcessPos:\t{ProcessPos.ToString()}", logType.Warning);
                    Log_Terminal("操作位置非法!", logType.Error);
                    return;
                }
            }
            else
            {
                Log_Terminal("操作位置未选择!", logType.Error);
                return;
            }

            ArraySize--;
            Console.Clear();
            iterate_Log();
        }

        private void button_Modify_Click(object sender, EventArgs e)
        {
            if (!Check_cSeqList())
            {
                Log_Terminal("顺序表未加载!", logType.Error);
                return;
            }

            if (radio_Head.Checked)
            {
//                _cSeqList.Delete(0);
            }
            else if (radio_Tail.Checked)
            {
//                _cSeqList.Delete(_cSeqList.DataSize - 1);
            }
            else if (radio_ten.Checked)
            {
                // 输入安全性检测    
                if (!IsInputNumSafe(textBox_DataPos, out ProcessPos, "ProcessPos")) return;
                if (!IsInputNumSafe(textBox_Data, out ProcessData, "ProcessData")) return;
            }
            else
            {
                Log_Terminal("操作位置未选择!", logType.Error);
            }
        }

        private void button_Insert_Click(object sender, EventArgs e)
        {
            if (!Check_cSeqList())
            {
                Log_Terminal("顺序表未加载!", logType.Error);
                return;
            }

            if (radio_Head.Checked)
            {
//                _cSeqList.Delete(0);
            }
            else if (radio_Tail.Checked)
            {
//                _cSeqList.Delete(_cSeqList.DataSize - 1);
            }
            else if (radio_ten.Checked)
            {
                // 输入安全性检测    
                if (!IsInputNumSafe(textBox_DataPos, out ProcessPos, "ProcessPos")) return;
                if (!IsInputNumSafe(textBox_Data, out ProcessData, "ProcessData")) return;
            }
            else
            {
                Log_Terminal("操作位置未选择!", logType.Error);
            }
        }

#endregion
    }
}