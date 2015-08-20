namespace BefunGen
{
	partial class frmMain_BefunTools
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
			this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
			this.edSquashInputIn = new System.Windows.Forms.TextBox();
			this.edReverseIn = new System.Windows.Forms.TextBox();
			this.edReverseOut = new System.Windows.Forms.TextBox();
			this.btnReverse = new System.Windows.Forms.Button();
			this.edSquashInputOut = new System.Windows.Forms.TextBox();
			this.btnSquash = new System.Windows.Forms.Button();
			this.chkbxReverseAutoDirection = new System.Windows.Forms.CheckBox();
			this.lblReverseValidity = new System.Windows.Forms.Label();
			this.tableLayoutPanel9.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel9
			// 
			this.tableLayoutPanel9.ColumnCount = 3;
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel9.Controls.Add(this.edSquashInputIn, 0, 4);
			this.tableLayoutPanel9.Controls.Add(this.edReverseIn, 0, 0);
			this.tableLayoutPanel9.Controls.Add(this.edReverseOut, 1, 0);
			this.tableLayoutPanel9.Controls.Add(this.btnReverse, 2, 1);
			this.tableLayoutPanel9.Controls.Add(this.edSquashInputOut, 1, 4);
			this.tableLayoutPanel9.Controls.Add(this.btnSquash, 2, 4);
			this.tableLayoutPanel9.Controls.Add(this.chkbxReverseAutoDirection, 2, 0);
			this.tableLayoutPanel9.Controls.Add(this.lblReverseValidity, 2, 2);
			this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 9;
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel9.Size = new System.Drawing.Size(800, 600);
			this.tableLayoutPanel9.TabIndex = 0;
			// 
			// edSquashInputIn
			// 
			this.edSquashInputIn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edSquashInputIn.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.edSquashInputIn.Location = new System.Drawing.Point(3, 115);
			this.edSquashInputIn.MaxLength = 2147483647;
			this.edSquashInputIn.Multiline = true;
			this.edSquashInputIn.Name = "edSquashInputIn";
			this.tableLayoutPanel9.SetRowSpan(this.edSquashInputIn, 5);
			this.edSquashInputIn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.edSquashInputIn.Size = new System.Drawing.Size(319, 482);
			this.edSquashInputIn.TabIndex = 7;
			this.edSquashInputIn.WordWrap = false;
			// 
			// edReverseIn
			// 
			this.edReverseIn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edReverseIn.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.edReverseIn.Location = new System.Drawing.Point(3, 3);
			this.edReverseIn.Multiline = true;
			this.edReverseIn.Name = "edReverseIn";
			this.tableLayoutPanel9.SetRowSpan(this.edReverseIn, 4);
			this.edReverseIn.Size = new System.Drawing.Size(319, 106);
			this.edReverseIn.TabIndex = 6;
			this.edReverseIn.TextChanged += new System.EventHandler(this.edReverse_TextChanged);
			// 
			// edReverseOut
			// 
			this.edReverseOut.BackColor = System.Drawing.SystemColors.Window;
			this.edReverseOut.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edReverseOut.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.edReverseOut.Location = new System.Drawing.Point(328, 3);
			this.edReverseOut.Multiline = true;
			this.edReverseOut.Name = "edReverseOut";
			this.edReverseOut.ReadOnly = true;
			this.tableLayoutPanel9.SetRowSpan(this.edReverseOut, 4);
			this.edReverseOut.Size = new System.Drawing.Size(319, 106);
			this.edReverseOut.TabIndex = 0;
			// 
			// btnReverse
			// 
			this.btnReverse.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnReverse.Location = new System.Drawing.Point(653, 31);
			this.btnReverse.Name = "btnReverse";
			this.btnReverse.Size = new System.Drawing.Size(144, 22);
			this.btnReverse.TabIndex = 1;
			this.btnReverse.Text = "Reverse";
			this.btnReverse.UseVisualStyleBackColor = true;
			this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
			// 
			// edSquashInputOut
			// 
			this.edSquashInputOut.BackColor = System.Drawing.SystemColors.Window;
			this.edSquashInputOut.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edSquashInputOut.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.edSquashInputOut.Location = new System.Drawing.Point(328, 115);
			this.edSquashInputOut.MaxLength = 2147483647;
			this.edSquashInputOut.Multiline = true;
			this.edSquashInputOut.Name = "edSquashInputOut";
			this.edSquashInputOut.ReadOnly = true;
			this.tableLayoutPanel9.SetRowSpan(this.edSquashInputOut, 5);
			this.edSquashInputOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.edSquashInputOut.Size = new System.Drawing.Size(319, 482);
			this.edSquashInputOut.TabIndex = 2;
			this.edSquashInputOut.WordWrap = false;
			// 
			// btnSquash
			// 
			this.btnSquash.Location = new System.Drawing.Point(653, 115);
			this.btnSquash.Name = "btnSquash";
			this.btnSquash.Size = new System.Drawing.Size(144, 22);
			this.btnSquash.TabIndex = 3;
			this.btnSquash.Text = "Squash";
			this.btnSquash.UseVisualStyleBackColor = true;
			this.btnSquash.Click += new System.EventHandler(this.btnSquash_Click);
			// 
			// chkbxReverseAutoDirection
			// 
			this.chkbxReverseAutoDirection.AutoSize = true;
			this.chkbxReverseAutoDirection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkbxReverseAutoDirection.Location = new System.Drawing.Point(653, 3);
			this.chkbxReverseAutoDirection.Name = "chkbxReverseAutoDirection";
			this.chkbxReverseAutoDirection.Size = new System.Drawing.Size(144, 22);
			this.chkbxReverseAutoDirection.TabIndex = 4;
			this.chkbxReverseAutoDirection.Text = "Auto Direction";
			this.chkbxReverseAutoDirection.UseVisualStyleBackColor = true;
			// 
			// lblReverseValidity
			// 
			this.lblReverseValidity.AutoSize = true;
			this.lblReverseValidity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblReverseValidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblReverseValidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.lblReverseValidity.Location = new System.Drawing.Point(653, 56);
			this.lblReverseValidity.Name = "lblReverseValidity";
			this.lblReverseValidity.Size = new System.Drawing.Size(144, 28);
			this.lblReverseValidity.TabIndex = 5;
			this.lblReverseValidity.Text = "???";
			this.lblReverseValidity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmMain_BefunTools
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel9);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "frmMain_BefunTools";
			this.Size = new System.Drawing.Size(800, 600);
			this.tableLayoutPanel9.ResumeLayout(false);
			this.tableLayoutPanel9.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
		private System.Windows.Forms.TextBox edSquashInputIn;
		private System.Windows.Forms.TextBox edReverseIn;
		private System.Windows.Forms.TextBox edReverseOut;
		private System.Windows.Forms.Button btnReverse;
		private System.Windows.Forms.TextBox edSquashInputOut;
		private System.Windows.Forms.Button btnSquash;
		private System.Windows.Forms.CheckBox chkbxReverseAutoDirection;
		private System.Windows.Forms.Label lblReverseValidity;
	}
}
