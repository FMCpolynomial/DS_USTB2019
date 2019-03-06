using System;
using System.Windows.Forms;

namespace DS_Program
{
    partial class RootForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_顺序表 = new System.Windows.Forms.TabPage();
            this.panel_顺序表 = new System.Windows.Forms.Panel();
            this.tabPage_链表 = new System.Windows.Forms.TabPage();
            this.panel_链表 = new System.Windows.Forms.Panel();
            this.tabPage_栈 = new System.Windows.Forms.TabPage();
            this.panel_栈 = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabPage_顺序表.SuspendLayout();
            this.tabPage_链表.SuspendLayout();
            this.tabPage_栈.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_顺序表);
            this.tabControl.Controls.Add(this.tabPage_链表);
            this.tabControl.Controls.Add(this.tabPage_栈);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1442, 1290);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabChange);
            this.tabControl.DoubleClick += new System.EventHandler(this.ReverseForm);
            // 
            // tabPage_顺序表
            // 
            this.tabPage_顺序表.Controls.Add(this.panel_顺序表);
            this.tabPage_顺序表.Location = new System.Drawing.Point(8, 39);
            this.tabPage_顺序表.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_顺序表.Name = "tabPage_顺序表";
            this.tabPage_顺序表.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_顺序表.Size = new System.Drawing.Size(1426, 1243);
            this.tabPage_顺序表.TabIndex = 0;
            this.tabPage_顺序表.Text = "顺序表";
            this.tabPage_顺序表.UseVisualStyleBackColor = true;
            // 
            // panel_顺序表
            // 
            this.panel_顺序表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_顺序表.Location = new System.Drawing.Point(4, 4);
            this.panel_顺序表.Margin = new System.Windows.Forms.Padding(0);
            this.panel_顺序表.Name = "panel_顺序表";
            this.panel_顺序表.Size = new System.Drawing.Size(1418, 1235);
            this.panel_顺序表.TabIndex = 0;
            // 
            // tabPage_链表
            // 
            this.tabPage_链表.Controls.Add(this.panel_链表);
            this.tabPage_链表.Location = new System.Drawing.Point(8, 39);
            this.tabPage_链表.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_链表.Name = "tabPage_链表";
            this.tabPage_链表.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_链表.Size = new System.Drawing.Size(1426, 1243);
            this.tabPage_链表.TabIndex = 1;
            this.tabPage_链表.Text = "链表";
            this.tabPage_链表.UseVisualStyleBackColor = true;
            // 
            // panel_链表
            // 
            this.panel_链表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_链表.Location = new System.Drawing.Point(4, 4);
            this.panel_链表.Margin = new System.Windows.Forms.Padding(0);
            this.panel_链表.Name = "panel_链表";
            this.panel_链表.Size = new System.Drawing.Size(1418, 1235);
            this.panel_链表.TabIndex = 1;
            // 
            // tabPage_栈
            // 
            this.tabPage_栈.Controls.Add(this.panel_栈);
            this.tabPage_栈.Location = new System.Drawing.Point(8, 39);
            this.tabPage_栈.Name = "tabPage_栈";
            this.tabPage_栈.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_栈.Size = new System.Drawing.Size(1426, 1243);
            this.tabPage_链表.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_栈.TabIndex = 2;
            this.tabPage_栈.Text = "栈";
            this.tabPage_栈.UseVisualStyleBackColor = true;
            // 
            // panel_栈
            // 
            this.panel_栈.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_栈.Location = new System.Drawing.Point(4, 4);
            this.panel_栈.Name = "panel_栈";
            this.panel_栈.Size = new System.Drawing.Size(1418, 1235);
            this.panel_栈.TabIndex = 0;
            // 
            // RootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 1290);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RootForm";
            this.Text = "数据结构应用程序";
            this.tabControl.ResumeLayout(false);
            this.tabPage_顺序表.ResumeLayout(false);
            this.tabPage_链表.ResumeLayout(false);
            this.tabPage_栈.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_顺序表;
        private System.Windows.Forms.Panel panel_顺序表;
        private System.Windows.Forms.TabPage tabPage_链表;
        private System.Windows.Forms.Panel panel_链表;
        private TabPage tabPage_栈;
        private Panel panel_栈;
    }
}

