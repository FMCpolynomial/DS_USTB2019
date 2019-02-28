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
            this.Load += new EventHandler(TabChange);
        }

        private void RootForm_Load(object sender, EventArgs e)
        {
        }

        void TabChange(object sender, EventArgs e)
        {
            if (tabPage_顺序表.Visible)
            {
                var formIn = new ArrayProcess {TopLevel = false};
                panel_顺序表.Controls.Add(formIn);
                formIn.Show();
            }

            if (tabPage_链表.Visible)
            {
                var formIn = new ListProcess {TopLevel = false};
                panel_链表.Controls.Add(formIn);
                formIn.Show();
            }
        }
    }
}