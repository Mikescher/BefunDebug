namespace BefunGen
{
	partial class frmMain_BefunHighlight
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnHighlight = new System.Windows.Forms.Button();
			this.tcHighlight = new System.Windows.Forms.TabControl();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.edHighlightCode = new System.Windows.Forms.TextBox();
			this.tabPage10 = new System.Windows.Forms.TabPage();
			this.edHighlighted = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel7.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.tcHighlight.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tabPage10.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.ColumnCount = 2;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel7.Controls.Add(this.flowLayoutPanel1, 1, 0);
			this.tableLayoutPanel7.Controls.Add(this.tcHighlight, 0, 0);
			this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel7.Size = new System.Drawing.Size(800, 600);
			this.tableLayoutPanel7.TabIndex = 0;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.btnHighlight);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(723, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(74, 594);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// btnHighlight
			// 
			this.btnHighlight.Location = new System.Drawing.Point(3, 3);
			this.btnHighlight.Name = "btnHighlight";
			this.btnHighlight.Size = new System.Drawing.Size(65, 23);
			this.btnHighlight.TabIndex = 0;
			this.btnHighlight.Text = "Highlight";
			this.btnHighlight.UseVisualStyleBackColor = true;
			this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
			// 
			// tcHighlight
			// 
			this.tcHighlight.Controls.Add(this.tabPage9);
			this.tcHighlight.Controls.Add(this.tabPage10);
			this.tcHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcHighlight.Location = new System.Drawing.Point(3, 3);
			this.tcHighlight.Name = "tcHighlight";
			this.tcHighlight.SelectedIndex = 0;
			this.tcHighlight.Size = new System.Drawing.Size(714, 594);
			this.tcHighlight.TabIndex = 1;
			// 
			// tabPage9
			// 
			this.tabPage9.Controls.Add(this.edHighlightCode);
			this.tabPage9.Location = new System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage9.Size = new System.Drawing.Size(706, 568);
			this.tabPage9.TabIndex = 0;
			this.tabPage9.Text = "Code";
			this.tabPage9.UseVisualStyleBackColor = true;
			// 
			// edHighlightCode
			// 
			this.edHighlightCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edHighlightCode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.edHighlightCode.Location = new System.Drawing.Point(3, 3);
			this.edHighlightCode.MaxLength = 2147483647;
			this.edHighlightCode.Multiline = true;
			this.edHighlightCode.Name = "edHighlightCode";
			this.edHighlightCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.edHighlightCode.Size = new System.Drawing.Size(700, 562);
			this.edHighlightCode.TabIndex = 1;
			// 
			// tabPage10
			// 
			this.tabPage10.Controls.Add(this.edHighlighted);
			this.tabPage10.Location = new System.Drawing.Point(4, 22);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage10.Size = new System.Drawing.Size(706, 568);
			this.tabPage10.TabIndex = 1;
			this.tabPage10.Text = "Highlight";
			this.tabPage10.UseVisualStyleBackColor = true;
			// 
			// edHighlighted
			// 
			this.edHighlighted.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edHighlighted.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.edHighlighted.Location = new System.Drawing.Point(3, 3);
			this.edHighlighted.MaxLength = 2147483647;
			this.edHighlighted.Multiline = true;
			this.edHighlighted.Name = "edHighlighted";
			this.edHighlighted.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.edHighlighted.Size = new System.Drawing.Size(700, 562);
			this.edHighlighted.TabIndex = 2;
			// 
			// frmMain_BefunHighlight
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel7);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "frmMain_BefunHighlight";
			this.Size = new System.Drawing.Size(800, 600);
			this.tableLayoutPanel7.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.tcHighlight.ResumeLayout(false);
			this.tabPage9.ResumeLayout(false);
			this.tabPage9.PerformLayout();
			this.tabPage10.ResumeLayout(false);
			this.tabPage10.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button btnHighlight;
		private System.Windows.Forms.TabControl tcHighlight;
		private System.Windows.Forms.TabPage tabPage9;
		private System.Windows.Forms.TextBox edHighlightCode;
		private System.Windows.Forms.TabPage tabPage10;
		private System.Windows.Forms.TextBox edHighlighted;
	}
}
