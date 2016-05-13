﻿namespace BefunGen.Pages
{
	partial class frmMain_BefunRun
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.cbxErrorLevel = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.edLimit = new System.Windows.Forms.NumericUpDown();
			this.btnRun = new System.Windows.Forms.Button();
			this.edReturnCode = new System.Windows.Forms.TextBox();
			this.edInputCode = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.edStdErr = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.edStdOut = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel7.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.edLimit)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.ColumnCount = 1;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel7.Controls.Add(this.edInputCode, 0, 1);
			this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel1, 0, 2);
			this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 3;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
			this.tableLayoutPanel7.Size = new System.Drawing.Size(800, 600);
			this.tableLayoutPanel7.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 7;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
			this.tableLayoutPanel2.Controls.Add(this.label4, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.cbxErrorLevel, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.edLimit, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnRun, 5, 0);
			this.tableLayoutPanel2.Controls.Add(this.edReturnCode, 6, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 29);
			this.tableLayoutPanel2.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Location = new System.Drawing.Point(187, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 29);
			this.label4.TabIndex = 2;
			this.label4.Text = "Limit";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbxErrorLevel
			// 
			this.cbxErrorLevel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbxErrorLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxErrorLevel.FormattingEnabled = true;
			this.cbxErrorLevel.Items.AddRange(new object[] {
            "Errorlevel 0",
            "Errorlevel 1",
            "Errorlevel 2",
            "Errorlevel 3"});
			this.cbxErrorLevel.Location = new System.Drawing.Point(60, 3);
			this.cbxErrorLevel.Name = "cbxErrorLevel";
			this.cbxErrorLevel.Size = new System.Drawing.Size(121, 21);
			this.cbxErrorLevel.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 29);
			this.label3.TabIndex = 1;
			this.label3.Text = "Errorlevel";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// edLimit
			// 
			this.edLimit.Location = new System.Drawing.Point(221, 3);
			this.edLimit.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
			this.edLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.edLimit.Name = "edLimit";
			this.edLimit.Size = new System.Drawing.Size(94, 20);
			this.edLimit.TabIndex = 3;
			this.edLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			// 
			// btnRun
			// 
			this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRun.Location = new System.Drawing.Point(581, 3);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(144, 23);
			this.btnRun.TabIndex = 4;
			this.btnRun.Text = "Run with BefunExec";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// edReturnCode
			// 
			this.edReturnCode.Location = new System.Drawing.Point(731, 3);
			this.edReturnCode.Name = "edReturnCode";
			this.edReturnCode.ReadOnly = true;
			this.edReturnCode.Size = new System.Drawing.Size(60, 20);
			this.edReturnCode.TabIndex = 5;
			// 
			// edInputCode
			// 
			this.edInputCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edInputCode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.edInputCode.Location = new System.Drawing.Point(3, 38);
			this.edInputCode.Multiline = true;
			this.edInputCode.Name = "edInputCode";
			this.edInputCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.edInputCode.Size = new System.Drawing.Size(794, 309);
			this.edInputCode.TabIndex = 3;
			this.edInputCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GenericTextBoxKeyDown);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.edStdErr, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.edStdOut, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 353);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 244);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Standard Output";
			// 
			// edStdErr
			// 
			this.edStdErr.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edStdErr.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.edStdErr.Location = new System.Drawing.Point(400, 16);
			this.edStdErr.Multiline = true;
			this.edStdErr.Name = "edStdErr";
			this.edStdErr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.edStdErr.Size = new System.Drawing.Size(391, 225);
			this.edStdErr.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(400, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Standard Error";
			// 
			// edStdOut
			// 
			this.edStdOut.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edStdOut.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.edStdOut.Location = new System.Drawing.Point(3, 16);
			this.edStdOut.Multiline = true;
			this.edStdOut.Name = "edStdOut";
			this.edStdOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.edStdOut.Size = new System.Drawing.Size(391, 225);
			this.edStdOut.TabIndex = 2;
			this.edStdOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GenericTextBoxKeyDown);
			// 
			// frmMain_BefunRun
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel7);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "frmMain_BefunRun";
			this.Size = new System.Drawing.Size(800, 600);
			this.tableLayoutPanel7.ResumeLayout(false);
			this.tableLayoutPanel7.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.edLimit)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbxErrorLevel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown edLimit;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.TextBox edInputCode;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox edStdErr;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox edStdOut;
		private System.Windows.Forms.TextBox edReturnCode;
	}
}