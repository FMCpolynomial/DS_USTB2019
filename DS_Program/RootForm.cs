using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DS_Program
{
    public partial class RootForm : Form
    {
        public RootForm()
        {
            InitializeComponent();
            tabControl.SelectedTab = tabPage_链表;
            this.Load += new EventHandler(TabChange);
        }

        // 存储窗口的集合
        private Dictionary<string, Form> Forms_Collections = new Dictionary<string, Form>();
        // 活动窗口
        public Form formIn;
        private Panel panel;


        // warning:自制event,适合于切换表时使用
        void TabChange(object sender, EventArgs e)
        {
            TabPage tabPage = tabControl.SelectedTab;

            // 是否第一次打开
            if (!Forms_Collections.ContainsKey(tabPage.Text) || Forms_Collections[tabPage.Text] == null)
            {
                formIn = Form2Tab(tabPage, out panel);
                panel.Controls.Add(formIn);
                formIn.Dock = DockStyle.Fill;
                formIn.Show();

                // 存储相应form
                Forms_Collections.Add(tabPage.Text, formIn);
            }
        }

        // 由tab返回相应的form
        Form Form2Tab(TabPage tabPage, out Panel _panel)
        {
            try
            {
                if (tabPage.Text == "顺序表")
                {
                    _panel = panel_顺序表;
                    return new ArrayProcess {TopLevel = false};
                }

                if (tabPage.Text == "链表")
                {
                    _panel = panel_链表;
                    return new ListProcess {TopLevel = false};
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            _panel = null;
            return null;
        }

        // 再生Form
        private void ReverseForm(object sender, EventArgs e)
        {
            var tabPage = tabControl.SelectedTab;

            // 判断页面是否存在:看现存的页面个数
            formIn = Form2Tab(tabPage, out panel);
            if (panel.Controls.Count != 0)
            {
                //warning:重载大法好!
                panel.Controls[0].FindForm().ToString();
                return;
            }

            // 添加新的页面
            panel.Controls.Add(formIn);
            formIn.Show();

            // 存储相应form
            Forms_Collections.Remove(tabPage.Text);
            Forms_Collections.Add(tabPage.Text, formIn);
        }
    }
}