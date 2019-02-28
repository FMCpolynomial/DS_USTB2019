using System;
using System.Windows.Forms;

namespace DS_Program
{
    public partial class RootForm : Form
    {
        public RootForm()
        {
            InitializeComponent();
            tabControl.SelectedTab = tabPage_链表;
        }

        // 内含窗口
        private Form formIn;

        private void RootForm_Load(object sender, EventArgs e)
        {
        }

        void TabChange(object sender, EventArgs e)
        {
            if (formIn != null)
            {
            }

            if (tabPage_顺序表.Visible)
            {
                formIn = new ArrayProcess {TopLevel = false};
                panel_顺序表.Controls.Add(formIn);
                formIn.Show();
            }

            if (tabPage_链表.Visible)
            {
                formIn = new ArrayProcess {TopLevel = false};
                panel_链表.Controls.Add(formIn);
                formIn.Show();
            }
        }
    }
}