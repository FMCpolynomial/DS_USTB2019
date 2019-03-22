using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace DS_Program
{
    partial class Stack_Calculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_strout = new System.Windows.Forms.TextBox();
            this.tb_express = new System.Windows.Forms.TextBox();
            this.bt_calculat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_result = new System.Windows.Forms.TextBox();
            this.bt_close = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_clear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Terminal = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_mr = new System.Windows.Forms.Button();
            this.button_ml = new System.Windows.Forms.Button();
            this.button_sr = new System.Windows.Forms.Button();
            this.button_sl = new System.Windows.Forms.Button();
            this.button_diff = new System.Windows.Forms.Button();
            this.button_multi = new System.Windows.Forms.Button();
            this.button_minus = new System.Windows.Forms.Button();
            this.button_plus = new System.Windows.Forms.Button();
            this.button_point = new System.Windows.Forms.Button();
            this.button_3 = new System.Windows.Forms.Button();
            this.button_6 = new System.Windows.Forms.Button();
            this.button_9 = new System.Windows.Forms.Button();
            this.button_0 = new System.Windows.Forms.Button();
            this.button_2 = new System.Windows.Forms.Button();
            this.button_5 = new System.Windows.Forms.Button();
            this.button_8 = new System.Windows.Forms.Button();
            this.button_1 = new System.Windows.Forms.Button();
            this.button_4 = new System.Windows.Forms.Button();
            this.button_7 = new System.Windows.Forms.Button();
            this.button_eDel = new System.Windows.Forms.Button();
            this.button_eClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_strout
            // 
            this.tb_strout.BackColor = System.Drawing.SystemColors.Window;
            this.tb_strout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_strout.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_strout.Location = new System.Drawing.Point(3, 35);
            this.tb_strout.Margin = new System.Windows.Forms.Padding(6);
            this.tb_strout.Multiline = true;
            this.tb_strout.Name = "tb_strout";
            this.tb_strout.ReadOnly = true;
            this.tb_strout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_strout.Size = new System.Drawing.Size(602, 1084);
            this.tb_strout.TabIndex = 2;
            // 
            // tb_express
            // 
            this.tb_express.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_express.Location = new System.Drawing.Point(74, 84);
            this.tb_express.Margin = new System.Windows.Forms.Padding(6);
            this.tb_express.Name = "tb_express";
            this.tb_express.Size = new System.Drawing.Size(626, 39);
            this.tb_express.TabIndex = 2;
            // 
            // bt_calculat
            // 
            this.bt_calculat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_calculat.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.bt_calculat.ForeColor = System.Drawing.Color.Red;
            this.bt_calculat.Location = new System.Drawing.Point(6, 6);
            this.bt_calculat.Margin = new System.Windows.Forms.Padding(6);
            this.bt_calculat.Name = "bt_calculat";
            this.bt_calculat.Size = new System.Drawing.Size(205, 56);
            this.bt_calculat.TabIndex = 0;
            this.bt_calculat.Text = "算吧您呢!";
            this.bt_calculat.UseVisualStyleBackColor = true;
            this.bt_calculat.Click += new System.EventHandler(this.bt_calculat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "表达式的运算结果";
            // 
            // tb_result
            // 
            this.tb_result.BackColor = System.Drawing.SystemColors.Window;
            this.tb_result.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_result.Location = new System.Drawing.Point(74, 242);
            this.tb_result.Margin = new System.Windows.Forms.Padding(6);
            this.tb_result.Name = "tb_result";
            this.tb_result.ReadOnly = true;
            this.tb_result.Size = new System.Drawing.Size(626, 39);
            this.tb_result.TabIndex = 2;
            this.tb_result.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_close
            // 
            this.bt_close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_close.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.bt_close.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bt_close.Location = new System.Drawing.Point(440, 6);
            this.bt_close.Margin = new System.Windows.Forms.Padding(6);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(206, 56);
            this.bt_close.TabIndex = 10;
            this.bt_close.Text = "退出";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_strout);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(608, 1122);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Controls.Add(this.tb_express);
            this.groupBox3.Controls.Add(this.tb_result);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(626, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(762, 430);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IO";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.button_clear, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bt_calculat, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bt_close, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(62, 328);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(652, 68);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // button_clear
            // 
            this.button_clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_clear.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_clear.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_clear.Location = new System.Drawing.Point(223, 6);
            this.button_clear.Margin = new System.Windows.Forms.Padding(6);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(205, 56);
            this.button_clear.TabIndex = 11;
            this.button_clear.Text = "清空Terminal";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(28, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "请输入一个正确的表达式！";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(28, 200);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(551, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "表达式的运算可以实现“+-*/”，并能使用“()[]”";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Terminal);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(626, 768);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 366);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Terminal";
            // 
            // Terminal
            // 
            this.Terminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Terminal.Location = new System.Drawing.Point(3, 35);
            this.Terminal.Name = "Terminal";
            this.Terminal.ReadOnly = true;
            this.Terminal.Size = new System.Drawing.Size(756, 328);
            this.Terminal.TabIndex = 0;
            this.Terminal.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_mr);
            this.groupBox4.Controls.Add(this.button_ml);
            this.groupBox4.Controls.Add(this.button_sr);
            this.groupBox4.Controls.Add(this.button_sl);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.button_diff);
            this.groupBox4.Controls.Add(this.button_multi);
            this.groupBox4.Controls.Add(this.button_minus);
            this.groupBox4.Controls.Add(this.button_plus);
            this.groupBox4.Controls.Add(this.button_point);
            this.groupBox4.Controls.Add(this.button_3);
            this.groupBox4.Controls.Add(this.button_6);
            this.groupBox4.Controls.Add(this.button_9);
            this.groupBox4.Controls.Add(this.button_0);
            this.groupBox4.Controls.Add(this.button_2);
            this.groupBox4.Controls.Add(this.button_5);
            this.groupBox4.Controls.Add(this.button_8);
            this.groupBox4.Controls.Add(this.button_eClear);
            this.groupBox4.Controls.Add(this.button_eDel);
            this.groupBox4.Controls.Add(this.button_1);
            this.groupBox4.Controls.Add(this.button_4);
            this.groupBox4.Controls.Add(this.button_7);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(626, 448);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(762, 314);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Keyboard";
            // 
            // button_mr
            // 
            this.button_mr.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_mr.Location = new System.Drawing.Point(523, 235);
            this.button_mr.Name = "button_mr";
            this.button_mr.Size = new System.Drawing.Size(80, 61);
            this.button_mr.TabIndex = 0;
            this.button_mr.Text = "]";
            this.button_mr.UseVisualStyleBackColor = true;
            this.button_mr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_ml
            // 
            this.button_ml.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_ml.Location = new System.Drawing.Point(523, 168);
            this.button_ml.Name = "button_ml";
            this.button_ml.Size = new System.Drawing.Size(80, 61);
            this.button_ml.TabIndex = 0;
            this.button_ml.Text = "[";
            this.button_ml.UseVisualStyleBackColor = true;
            this.button_ml.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_sr
            // 
            this.button_sr.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_sr.Location = new System.Drawing.Point(523, 101);
            this.button_sr.Name = "button_sr";
            this.button_sr.Size = new System.Drawing.Size(80, 61);
            this.button_sr.TabIndex = 0;
            this.button_sr.Text = ")";
            this.button_sr.UseVisualStyleBackColor = true;
            this.button_sr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_sl
            // 
            this.button_sl.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_sl.Location = new System.Drawing.Point(523, 34);
            this.button_sl.Name = "button_sl";
            this.button_sl.Size = new System.Drawing.Size(80, 61);
            this.button_sl.TabIndex = 0;
            this.button_sl.Text = "(";
            this.button_sl.UseVisualStyleBackColor = true;
            this.button_sl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_diff
            // 
            this.button_diff.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_diff.Location = new System.Drawing.Point(437, 235);
            this.button_diff.Name = "button_diff";
            this.button_diff.Size = new System.Drawing.Size(80, 61);
            this.button_diff.TabIndex = 0;
            this.button_diff.Text = "/";
            this.button_diff.UseVisualStyleBackColor = true;
            this.button_diff.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_multi
            // 
            this.button_multi.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_multi.Location = new System.Drawing.Point(437, 168);
            this.button_multi.Name = "button_multi";
            this.button_multi.Size = new System.Drawing.Size(80, 61);
            this.button_multi.TabIndex = 0;
            this.button_multi.Text = "*";
            this.button_multi.UseVisualStyleBackColor = true;
            this.button_multi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_minus
            // 
            this.button_minus.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_minus.Location = new System.Drawing.Point(437, 101);
            this.button_minus.Name = "button_minus";
            this.button_minus.Size = new System.Drawing.Size(80, 61);
            this.button_minus.TabIndex = 0;
            this.button_minus.Text = "-";
            this.button_minus.UseVisualStyleBackColor = true;
            this.button_minus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_plus
            // 
            this.button_plus.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_plus.Location = new System.Drawing.Point(437, 34);
            this.button_plus.Name = "button_plus";
            this.button_plus.Size = new System.Drawing.Size(80, 61);
            this.button_plus.TabIndex = 0;
            this.button_plus.Text = "+";
            this.button_plus.UseVisualStyleBackColor = true;
            this.button_plus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_point
            // 
            this.button_point.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_point.Location = new System.Drawing.Point(351, 235);
            this.button_point.Name = "button_point";
            this.button_point.Size = new System.Drawing.Size(80, 61);
            this.button_point.TabIndex = 0;
            this.button_point.Text = ".";
            this.button_point.UseVisualStyleBackColor = true;
            this.button_point.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_3.Location = new System.Drawing.Point(351, 168);
            this.button_3.Name = "button_3";
            this.button_3.Size = new System.Drawing.Size(80, 61);
            this.button_3.TabIndex = 0;
            this.button_3.Text = "3";
            this.button_3.UseVisualStyleBackColor = true;
            this.button_3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_6
            // 
            this.button_6.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_6.Location = new System.Drawing.Point(351, 101);
            this.button_6.Name = "button_6";
            this.button_6.Size = new System.Drawing.Size(80, 61);
            this.button_6.TabIndex = 0;
            this.button_6.Text = "6";
            this.button_6.UseVisualStyleBackColor = true;
            this.button_6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_9
            // 
            this.button_9.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_9.Location = new System.Drawing.Point(351, 34);
            this.button_9.Name = "button_9";
            this.button_9.Size = new System.Drawing.Size(80, 61);
            this.button_9.TabIndex = 0;
            this.button_9.Text = "9";
            this.button_9.UseVisualStyleBackColor = true;
            this.button_9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_0
            // 
            this.button_0.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_0.Location = new System.Drawing.Point(265, 235);
            this.button_0.Name = "button_0";
            this.button_0.Size = new System.Drawing.Size(80, 61);
            this.button_0.TabIndex = 0;
            this.button_0.Text = "0";
            this.button_0.UseVisualStyleBackColor = true;
            this.button_0.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_2.Location = new System.Drawing.Point(265, 168);
            this.button_2.Name = "button_2";
            this.button_2.Size = new System.Drawing.Size(80, 61);
            this.button_2.TabIndex = 0;
            this.button_2.Text = "2";
            this.button_2.UseVisualStyleBackColor = true;
            this.button_2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_5
            // 
            this.button_5.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_5.Location = new System.Drawing.Point(265, 101);
            this.button_5.Name = "button_5";
            this.button_5.Size = new System.Drawing.Size(80, 61);
            this.button_5.TabIndex = 0;
            this.button_5.Text = "5";
            this.button_5.UseVisualStyleBackColor = true;
            this.button_5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_8
            // 
            this.button_8.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_8.Location = new System.Drawing.Point(265, 34);
            this.button_8.Name = "button_8";
            this.button_8.Size = new System.Drawing.Size(80, 61);
            this.button_8.TabIndex = 0;
            this.button_8.Text = "8";
            this.button_8.UseVisualStyleBackColor = true;
            this.button_8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_1.Location = new System.Drawing.Point(179, 168);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(80, 61);
            this.button_1.TabIndex = 0;
            this.button_1.Text = "1";
            this.button_1.UseVisualStyleBackColor = true;
            this.button_1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_4.Location = new System.Drawing.Point(179, 101);
            this.button_4.Name = "button_4";
            this.button_4.Size = new System.Drawing.Size(80, 61);
            this.button_4.TabIndex = 0;
            this.button_4.Text = "4";
            this.button_4.UseVisualStyleBackColor = true;
            this.button_4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_7
            // 
            this.button_7.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_7.Location = new System.Drawing.Point(179, 34);
            this.button_7.Name = "button_7";
            this.button_7.Size = new System.Drawing.Size(80, 61);
            this.button_7.TabIndex = 0;
            this.button_7.Text = "7";
            this.button_7.UseVisualStyleBackColor = true;
            this.button_7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // button_eDel
            // 
            this.button_eDel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_eDel.Location = new System.Drawing.Point(62, 235);
            this.button_eDel.Name = "button_eDel";
            this.button_eDel.Size = new System.Drawing.Size(111, 61);
            this.button_eDel.TabIndex = 0;
            this.button_eDel.Text = "Del";
            this.button_eDel.UseVisualStyleBackColor = true;
            this.button_eDel.Click += new System.EventHandler(this.button_eDel_Click);
            // 
            // button_eClear
            // 
            this.button_eClear.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_eClear.Location = new System.Drawing.Point(62, 168);
            this.button_eClear.Name = "button_eClear";
            this.button_eClear.Size = new System.Drawing.Size(111, 61);
            this.button_eClear.TabIndex = 0;
            this.button_eClear.Text = "Clear";
            this.button_eClear.UseVisualStyleBackColor = true;
            this.button_eClear.Click += new System.EventHandler(this.button_eClear_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button1.Location = new System.Drawing.Point(179, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "^";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_mr_MouseClick);
            // 
            // Stack_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 1168);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Stack_Calculator";
            this.Text = "表达式的运算";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        // Token: 0x04000109 RID: 265
        private TextBox tb_strout;

        // Token: 0x0400010D RID: 269
        private TextBox tb_express;
        private Button bt_calculat;
        private Label label1;
        private TextBox tb_result;
        private Button bt_close;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label4;
        private GroupBox groupBox1;
        private RichTextBox Terminal;
        private Button button_clear;
        private GroupBox groupBox4;
        private Button button_7;
        private Button button_ml;
        private Button button_sr;
        private Button button_sl;
        private Button button_multi;
        private Button button_minus;
        private Button button_plus;
        private Button button_3;
        private Button button_6;
        private Button button_9;
        private Button button_2;
        private Button button_5;
        private Button button_8;
        private Button button_1;
        private Button button_4;
        private Button button_mr;
        private Button button_diff;
        private Button button_point;
        private Button button_0;
        private Button button_eClear;
        private Button button_eDel;
        private Button button1;
    }
}

#endregion