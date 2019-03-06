using System;

namespace painting
{
    partial class DrawForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_Square = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Axis = new System.Windows.Forms.TextBox();
            this.checkBox_显示扫描线 = new System.Windows.Forms.CheckBox();
            this.checkBox_显示标号 = new System.Windows.Forms.CheckBox();
            this.checkBox_显示坐标 = new System.Windows.Forms.CheckBox();
            this.checkBox_分层填充 = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lb_setcolor = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 1645);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox7, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 1645);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 989);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(494, 158);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "提示";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 332);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(494, 487);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "顶点列表";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(3, 31);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(488, 453);
            this.listBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.checkBox_显示扫描线);
            this.groupBox1.Controls.Add(this.checkBox_显示标号);
            this.groupBox1.Controls.Add(this.checkBox_显示坐标);
            this.groupBox1.Controls.Add(this.checkBox_分层填充);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 323);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "显示";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_Square);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 82);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "面积";
            // 
            // textBox_Square
            // 
            this.textBox_Square.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Square.Location = new System.Drawing.Point(3, 31);
            this.textBox_Square.Name = "textBox_Square";
            this.textBox_Square.ReadOnly = true;
            this.textBox_Square.Size = new System.Drawing.Size(482, 35);
            this.textBox_Square.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Axis);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "坐标";
            // 
            // textBox_Axis
            // 
            this.textBox_Axis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Axis.Location = new System.Drawing.Point(3, 31);
            this.textBox_Axis.Name = "textBox_Axis";
            this.textBox_Axis.ReadOnly = true;
            this.textBox_Axis.Size = new System.Drawing.Size(482, 35);
            this.textBox_Axis.TabIndex = 0;
            // 
            // checkBox_显示扫描线
            // 
            this.checkBox_显示扫描线.AutoSize = true;
            this.checkBox_显示扫描线.Location = new System.Drawing.Point(152, 121);
            this.checkBox_显示扫描线.Name = "checkBox_显示扫描线";
            this.checkBox_显示扫描线.Size = new System.Drawing.Size(162, 28);
            this.checkBox_显示扫描线.TabIndex = 0;
            this.checkBox_显示扫描线.Text = "显示扫描线";
            this.checkBox_显示扫描线.UseVisualStyleBackColor = true;
            // 
            // checkBox_显示标号
            // 
            this.checkBox_显示标号.AutoSize = true;
            this.checkBox_显示标号.Location = new System.Drawing.Point(152, 62);
            this.checkBox_显示标号.Name = "checkBox_显示标号";
            this.checkBox_显示标号.Size = new System.Drawing.Size(138, 28);
            this.checkBox_显示标号.TabIndex = 0;
            this.checkBox_显示标号.Text = "显示标号";
            this.checkBox_显示标号.UseVisualStyleBackColor = true;
            // 
            // checkBox_显示坐标
            // 
            this.checkBox_显示坐标.AutoSize = true;
            this.checkBox_显示坐标.Location = new System.Drawing.Point(10, 121);
            this.checkBox_显示坐标.Name = "checkBox_显示坐标";
            this.checkBox_显示坐标.Size = new System.Drawing.Size(138, 28);
            this.checkBox_显示坐标.TabIndex = 0;
            this.checkBox_显示坐标.Text = "显示坐标";
            this.checkBox_显示坐标.UseVisualStyleBackColor = true;
            // 
            // checkBox_分层填充
            // 
            this.checkBox_分层填充.AutoSize = true;
            this.checkBox_分层填充.Location = new System.Drawing.Point(10, 62);
            this.checkBox_分层填充.Name = "checkBox_分层填充";
            this.checkBox_分层填充.Size = new System.Drawing.Size(138, 28);
            this.checkBox_分层填充.TabIndex = 0;
            this.checkBox_分层填充.Text = "分层填充";
            this.checkBox_分层填充.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.richTextBox2);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 1153);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(494, 489);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Terminal";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 31);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(488, 455);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lb_setcolor);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 825);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(494, 158);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "结点";
            // 
            // lb_setcolor
            // 
            this.lb_setcolor.AutoSize = true;
            this.lb_setcolor.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lb_setcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_setcolor.Location = new System.Drawing.Point(138, 49);
            this.lb_setcolor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_setcolor.Name = "lb_setcolor";
            this.lb_setcolor.Padding = new System.Windows.Forms.Padding(50, 5, 50, 5);
            this.lb_setcolor.Size = new System.Drawing.Size(208, 36);
            this.lb_setcolor.TabIndex = 1;
            this.lb_setcolor.Text = "颜色提取";
            this.lb_setcolor.Click += new System.EventHandler(this.lb_setcolor_Click);
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1837, 1645);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DrawForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DrawForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawForm_MouseUp);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lb_setcolor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_显示扫描线;
        private System.Windows.Forms.CheckBox checkBox_显示标号;
        private System.Windows.Forms.CheckBox checkBox_显示坐标;
        private System.Windows.Forms.CheckBox checkBox_分层填充;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_Square;
        private System.Windows.Forms.TextBox textBox_Axis;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

