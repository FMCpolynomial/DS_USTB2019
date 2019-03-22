using System;
using System.Collections.Generic;
using System.Windows.Forms;
using painting;

namespace DS_Program
{
    public partial class RootForm : Form
    {
        public RootForm()
        {
            InitializeComponent();

            //todo:这里规定第一个打开的页面
//            tabControl.SelectedTab = tabPage_链表2;
            tabControl.SelectedTab = tabPage_栈;

            this.Load += new EventHandler(TabChange);
        }

        // 存储窗口的集合
        private Dictionary<string, Form> Forms_Collections = new Dictionary<string, Form>();
        // 活动窗口
        // 窗口 | 从属的Panel | 是嵌入窗口还是外部窗口
        public Form formIn;
        private Panel panel;
        private bool isInsert;


        // warning:自制event,适合于切换表时使用
        void TabChange(object sender, EventArgs e)
        {
            TabPage tabPage = tabControl.SelectedTab;

            // 窗口:是否第一次打开
            if (!Forms_Collections.ContainsKey(tabPage.Text) || Forms_Collections[tabPage.Text] == null)
            {
                formIn = Form2Tab(tabPage, out panel, out isInsert);

                // 内嵌窗口特殊福利
                if (isInsert)
                {
                    panel.Controls.Add(formIn);
                    formIn.Dock = DockStyle.Fill;
                }

                formIn.Show();

                // 存储相应form
                Forms_Collections.Add(tabPage.Text, formIn);
            }
        }

        // 由tab返回相应的form
        // tabpage | 从属的Panel | 是嵌入窗口还是外部窗口
        // warning:外部窗口 _panel = null  且 isInsert = false
        Form Form2Tab(TabPage tabPage, out Panel _panel, out bool isInsert)
        {
            try
            {
                if (tabPage.Text == "顺序表")
                {
                    _panel = panel_顺序表;
                    isInsert = true;
                    return new ArrayProcess {TopLevel = false};
                }

                if (tabPage.Text == "链表")
                {
                    _panel = panel_链表;
                    isInsert = true;
                    return new ListProcess {TopLevel = false};
                }

                if (tabPage.Text == "栈")
                {
                    _panel = panel_栈;
                    isInsert = true;
                    return new Stack_Calculator {TopLevel = false};
                }

                if (tabPage.Text == "链表_绘图")
                {
                    _panel = null;
                    isInsert = false;
                    return new DrawForm() {TopLevel = true};
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            _panel = null;
            isInsert = true;
            return null;
        }

        // 再生Form
        private void ReverseForm(object sender, EventArgs e)
        {
            var tabPage = tabControl.SelectedTab;

            // 判断页面是否存在:看现存的页面个数
            formIn = Form2Tab(tabPage, out panel, out isInsert);


            if (isInsert)
            {
                // 内嵌式窗口:
                // 提示不能重复打开内嵌式窗口
                if (panel.Controls.Count != 0)
                {
                    //warning:重载大法好!
                    panel.Controls[0].FindForm()?.ToString();
                    return;
                }

                // 添加新的页面
                panel.Controls.Add(formIn);
            }

            formIn.Show();

            // 存储相应form
            Forms_Collections.Remove(tabPage.Text);
            Forms_Collections.Add(tabPage.Text, formIn);
        }
    }
}