using System;
using System.Windows.Forms;

namespace DS_Program
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //暂时先这么着
            Application.Run(new RootForm());
        }
    }
}