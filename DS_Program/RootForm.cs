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
//            if (tabPage_顺序表.Visible)
//            {
//                formIn = new ArrayProcess {TopLevel = false};
//                panel_顺序表.Controls.Add(formIn);
//                formIn.Show();
//            }
//
//            if (tabPage_链表.Visible)
//            {
//                formIn = new ListProcess {TopLevel = false};
//                panel_链表.Controls.Add(formIn);
//                formIn.Show();
//            }

//            foreach (TabPage tabPage in tabControl.TabPages)
//            {
//                // 打开某tab
//                if (tabPage.Visible)
//                {
//                    // 是否第一次打开
//                    if (!Forms_Collections.ContainsKey(tabPage.Text))
//                    {
//                        Console.WriteLine(tabPage.Text);
//                        formIn = Form2Tab(tabPage);
//                        tabPage.Controls.Add(formIn);
//                        formIn.Show();
//
//                        // 存储相应form
//                        Forms_Collections.Add(tabPage.Text, formIn);
//                    }
//                    else
//                    {
//                        formIn = Forms_Collections[tabPage.Text];
//                    }
//                }
//            }
            // 打开某tab
            TabPage tabPage = tabControl.SelectedTab;

            // 是否第一次打开
            if (!Forms_Collections.ContainsKey(tabPage.Text) || Forms_Collections[tabPage.Text] == null)
            {
                formIn = Form2Tab(tabPage, out panel);
                panel.Controls.Add(formIn);
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

        private void ReverseForm(object sender, EventArgs e)
        {
            var tabPage = tabControl.SelectedTab;

            // 判断页面是否存在
            formIn = Form2Tab(tabPage, out panel);
            if (panel.Controls.Contains(formIn))
//            if (Forms_Collections.)
                return;

            // 添加新的页面
            panel.Controls.Add(formIn);
            formIn.Show();

            // 存储相应form
            Forms_Collections.Remove(tabPage.Text);
            Forms_Collections.Add(tabPage.Text, formIn);
        }

        private void panel_顺序表_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}