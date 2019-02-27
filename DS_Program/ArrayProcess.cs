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
    public partial class ArrayProcess : Form
    {
#region Terminal 日志

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

            string text = $@"[{DateTime.Now.ToLongTimeString()}]{log}";
            Terminal.AppendText(text);

            Terminal.SelectionColor = Terminal.ForeColor;
        }

#endregion

#region 顺序表定义

        class CSeqList<T> //顺序表泛型类
        {
            private T[] data; //顺序表数据
            private int MaxSize; //最大空间
            private int datasize; //实际元素个数
            public int DataSize
            {
                get { return datasize; }
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

#region 程序变量

        CSeqList<int> _cSeqList;

#endregion

#region 程序初始化

#endregion
    }
}