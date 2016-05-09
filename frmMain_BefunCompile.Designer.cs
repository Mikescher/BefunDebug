namespace BefunGen
{
	partial class frmMain_BefunCompile
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
			this.tabCompileOuterControl = new System.Windows.Forms.TabControl();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
			this.btnCompileGraphCompile = new System.Windows.Forms.Button();
			this.btnCompile = new System.Windows.Forms.Button();
			this.btnCompileGraph = new System.Windows.Forms.Button();
			this.btnRunCurrGraph = new System.Windows.Forms.Button();
			this.cbxCompileLevel = new System.Windows.Forms.ComboBox();
			this.btnCompileTest = new System.Windows.Forms.Button();
			this.cbxCompileData = new System.Windows.Forms.ComboBox();
			this.btnCompileExecute = new System.Windows.Forms.Button();
			this.btnCompileCompile = new System.Windows.Forms.Button();
			this.btnGenOverview = new System.Windows.Forms.Button();
			this.tabCompileControl = new System.Windows.Forms.TabControl();
			this.tabPage16 = new System.Windows.Forms.TabPage();
			this.memoCompileInput = new System.Windows.Forms.TextBox();
			this.tabPage17 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
			this.cbUseGZip = new System.Windows.Forms.CheckBox();
			this.cbSafeGridAccess = new System.Windows.Forms.CheckBox();
			this.cbSafeStackAccess = new System.Windows.Forms.CheckBox();
			this.cbIgnoreSelfModification = new System.Windows.Forms.CheckBox();
			this.cbOutFormat = new System.Windows.Forms.CheckBox();
			this.listBoxOutputLanguages = new System.Windows.Forms.CheckedListBox();
			this.tabPage14 = new System.Windows.Forms.TabPage();
			this.tabPage13 = new System.Windows.Forms.TabPage();
			this.tabControlOutput = new System.Windows.Forms.TabControl();
			this.tabPage15 = new System.Windows.Forms.TabPage();
			this.memoCompileLog = new System.Windows.Forms.TextBox();
			this.tabPage11 = new System.Windows.Forms.TabPage();
			this.edBefunCompileConsole = new System.Windows.Forms.TextBox();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
			this.btnGZipCompress = new System.Windows.Forms.Button();
			this.btnMSZipCompressSingle = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnMSZipDecompressSingle = new System.Windows.Forms.Button();
			this.btnMSZipCompressMulti = new System.Windows.Forms.Button();
			this.btnMSZipDecompressMulti = new System.Windows.Forms.Button();
			this.btnGZipDecompress = new System.Windows.Forms.Button();
			this.btnGZipCompressToList = new System.Windows.Forms.Button();
			this.btnGZipCompressToHex = new System.Windows.Forms.Button();
			this.btnCompressBenchmark = new System.Windows.Forms.Button();
			this.btnRunCodeCompressionTests = new System.Windows.Forms.Button();
			this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
			this.memoCodeCompressionInput = new System.Windows.Forms.TextBox();
			this.memoCodeCompressionOutput = new System.Windows.Forms.TextBox();
			this.memoCodeCompressionLog = new System.Windows.Forms.TextBox();
			this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
			this.graphUserControl1 = new BefunGen.GraphUserControl();
			this.tabCompileOuterControl.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tableLayoutPanel10.SuspendLayout();
			this.tableLayoutPanel11.SuspendLayout();
			this.tabCompileControl.SuspendLayout();
			this.tabPage16.SuspendLayout();
			this.tabPage17.SuspendLayout();
			this.tableLayoutPanel12.SuspendLayout();
			this.tabPage14.SuspendLayout();
			this.tabPage13.SuspendLayout();
			this.tabPage15.SuspendLayout();
			this.tabPage11.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tableLayoutPanel13.SuspendLayout();
			this.tableLayoutPanel14.SuspendLayout();
			this.tableLayoutPanel15.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabCompileOuterControl
			// 
			this.tabCompileOuterControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabCompileOuterControl.Controls.Add(this.tabPage7);
			this.tabCompileOuterControl.Controls.Add(this.tabPage8);
			this.tabCompileOuterControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabCompileOuterControl.Location = new System.Drawing.Point(0, 0);
			this.tabCompileOuterControl.Multiline = true;
			this.tabCompileOuterControl.Name = "tabCompileOuterControl";
			this.tabCompileOuterControl.SelectedIndex = 0;
			this.tabCompileOuterControl.Size = new System.Drawing.Size(800, 600);
			this.tabCompileOuterControl.TabIndex = 2;
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.tableLayoutPanel10);
			this.tabPage7.Location = new System.Drawing.Point(4, 4);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new System.Drawing.Size(792, 574);
			this.tabPage7.TabIndex = 0;
			this.tabPage7.Text = "Code Generation";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel10
			// 
			this.tableLayoutPanel10.ColumnCount = 2;
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel11, 0, 0);
			this.tableLayoutPanel10.Controls.Add(this.tabCompileControl, 1, 0);
			this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel10.Name = "tableLayoutPanel10";
			this.tableLayoutPanel10.RowCount = 1;
			this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel10.Size = new System.Drawing.Size(786, 568);
			this.tableLayoutPanel10.TabIndex = 0;
			// 
			// tableLayoutPanel11
			// 
			this.tableLayoutPanel11.ColumnCount = 1;
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel11.Controls.Add(this.btnCompileGraphCompile, 0, 8);
			this.tableLayoutPanel11.Controls.Add(this.btnCompile, 0, 0);
			this.tableLayoutPanel11.Controls.Add(this.btnCompileGraph, 0, 2);
			this.tableLayoutPanel11.Controls.Add(this.btnRunCurrGraph, 0, 7);
			this.tableLayoutPanel11.Controls.Add(this.cbxCompileLevel, 0, 1);
			this.tableLayoutPanel11.Controls.Add(this.btnCompileTest, 0, 11);
			this.tableLayoutPanel11.Controls.Add(this.cbxCompileData, 0, 6);
			this.tableLayoutPanel11.Controls.Add(this.btnCompileExecute, 0, 4);
			this.tableLayoutPanel11.Controls.Add(this.btnCompileCompile, 0, 3);
			this.tableLayoutPanel11.Controls.Add(this.btnGenOverview, 0, 10);
			this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel11.Name = "tableLayoutPanel11";
			this.tableLayoutPanel11.RowCount = 12;
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel11.Size = new System.Drawing.Size(144, 562);
			this.tableLayoutPanel11.TabIndex = 0;
			// 
			// btnCompileGraphCompile
			// 
			this.btnCompileGraphCompile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCompileGraphCompile.Location = new System.Drawing.Point(3, 465);
			this.btnCompileGraphCompile.Name = "btnCompileGraphCompile";
			this.btnCompileGraphCompile.Size = new System.Drawing.Size(138, 24);
			this.btnCompileGraphCompile.TabIndex = 9;
			this.btnCompileGraphCompile.Text = "Compile current Graph";
			this.btnCompileGraphCompile.UseVisualStyleBackColor = true;
			this.btnCompileGraphCompile.Click += new System.EventHandler(this.btnCompileGraphCompile_Click);
			// 
			// btnCompile
			// 
			this.btnCompile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCompile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCompile.Location = new System.Drawing.Point(3, 3);
			this.btnCompile.Name = "btnCompile";
			this.btnCompile.Size = new System.Drawing.Size(138, 24);
			this.btnCompile.TabIndex = 0;
			this.btnCompile.Text = "Compile";
			this.btnCompile.UseVisualStyleBackColor = true;
			this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
			// 
			// btnCompileGraph
			// 
			this.btnCompileGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCompileGraph.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCompileGraph.Location = new System.Drawing.Point(3, 63);
			this.btnCompileGraph.Name = "btnCompileGraph";
			this.btnCompileGraph.Size = new System.Drawing.Size(138, 24);
			this.btnCompileGraph.TabIndex = 2;
			this.btnCompileGraph.Text = "Graph   [     ]";
			this.btnCompileGraph.UseVisualStyleBackColor = true;
			this.btnCompileGraph.Click += new System.EventHandler(this.btnGraph_Compile_Click);
			// 
			// btnRunCurrGraph
			// 
			this.btnRunCurrGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnRunCurrGraph.Location = new System.Drawing.Point(3, 435);
			this.btnRunCurrGraph.Name = "btnRunCurrGraph";
			this.btnRunCurrGraph.Size = new System.Drawing.Size(138, 24);
			this.btnRunCurrGraph.TabIndex = 5;
			this.btnRunCurrGraph.Text = "Run current Graph";
			this.btnRunCurrGraph.UseVisualStyleBackColor = true;
			this.btnRunCurrGraph.Click += new System.EventHandler(this.btnRunCurrGraph_Click);
			// 
			// cbxCompileLevel
			// 
			this.cbxCompileLevel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbxCompileLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxCompileLevel.FormattingEnabled = true;
			this.cbxCompileLevel.Location = new System.Drawing.Point(3, 33);
			this.cbxCompileLevel.Name = "cbxCompileLevel";
			this.cbxCompileLevel.Size = new System.Drawing.Size(138, 21);
			this.cbxCompileLevel.TabIndex = 10;
			this.cbxCompileLevel.SelectedIndexChanged += new System.EventHandler(this.cbxCompileLevel_SelectedIndexChanged);
			// 
			// btnCompileTest
			// 
			this.btnCompileTest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCompileTest.Location = new System.Drawing.Point(3, 535);
			this.btnCompileTest.Name = "btnCompileTest";
			this.btnCompileTest.Size = new System.Drawing.Size(138, 24);
			this.btnCompileTest.TabIndex = 11;
			this.btnCompileTest.Text = "Run Tests";
			this.btnCompileTest.UseVisualStyleBackColor = true;
			this.btnCompileTest.Click += new System.EventHandler(this.btnCompileTest_Click);
			// 
			// cbxCompileData
			// 
			this.cbxCompileData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbxCompileData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxCompileData.FormattingEnabled = true;
			this.cbxCompileData.Location = new System.Drawing.Point(3, 405);
			this.cbxCompileData.Name = "cbxCompileData";
			this.cbxCompileData.Size = new System.Drawing.Size(138, 21);
			this.cbxCompileData.TabIndex = 12;
			this.cbxCompileData.SelectedIndexChanged += new System.EventHandler(this.cbxCompileData_SelectedIndexChanged);
			// 
			// btnCompileExecute
			// 
			this.btnCompileExecute.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCompileExecute.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnCompileExecute.Location = new System.Drawing.Point(3, 123);
			this.btnCompileExecute.Name = "btnCompileExecute";
			this.btnCompileExecute.Size = new System.Drawing.Size(138, 24);
			this.btnCompileExecute.TabIndex = 13;
			this.btnCompileExecute.Text = "Execute [     ]";
			this.btnCompileExecute.UseVisualStyleBackColor = true;
			this.btnCompileExecute.Click += new System.EventHandler(this.btnCompileExecute_Click);
			// 
			// btnCompileCompile
			// 
			this.btnCompileCompile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCompileCompile.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnCompileCompile.Location = new System.Drawing.Point(3, 93);
			this.btnCompileCompile.Name = "btnCompileCompile";
			this.btnCompileCompile.Size = new System.Drawing.Size(138, 24);
			this.btnCompileCompile.TabIndex = 14;
			this.btnCompileCompile.Text = "Compile [     ]";
			this.btnCompileCompile.UseVisualStyleBackColor = true;
			this.btnCompileCompile.Click += new System.EventHandler(this.btnCompileCompile_Click);
			// 
			// btnGenOverview
			// 
			this.btnGenOverview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGenOverview.Location = new System.Drawing.Point(3, 505);
			this.btnGenOverview.Name = "btnGenOverview";
			this.btnGenOverview.Size = new System.Drawing.Size(138, 24);
			this.btnGenOverview.TabIndex = 15;
			this.btnGenOverview.Text = "Generate Overview";
			this.btnGenOverview.UseVisualStyleBackColor = true;
			this.btnGenOverview.Click += new System.EventHandler(this.btnGenOverview_Click);
			// 
			// tabCompileControl
			// 
			this.tabCompileControl.Controls.Add(this.tabPage16);
			this.tabCompileControl.Controls.Add(this.tabPage17);
			this.tabCompileControl.Controls.Add(this.tabPage14);
			this.tabCompileControl.Controls.Add(this.tabPage13);
			this.tabCompileControl.Controls.Add(this.tabPage15);
			this.tabCompileControl.Controls.Add(this.tabPage11);
			this.tabCompileControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabCompileControl.Location = new System.Drawing.Point(153, 3);
			this.tabCompileControl.Name = "tabCompileControl";
			this.tabCompileControl.SelectedIndex = 0;
			this.tabCompileControl.Size = new System.Drawing.Size(630, 562);
			this.tabCompileControl.TabIndex = 1;
			// 
			// tabPage16
			// 
			this.tabPage16.Controls.Add(this.memoCompileInput);
			this.tabPage16.Location = new System.Drawing.Point(4, 22);
			this.tabPage16.Name = "tabPage16";
			this.tabPage16.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage16.Size = new System.Drawing.Size(622, 536);
			this.tabPage16.TabIndex = 3;
			this.tabPage16.Text = "Input";
			this.tabPage16.UseVisualStyleBackColor = true;
			// 
			// memoCompileInput
			// 
			this.memoCompileInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.memoCompileInput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memoCompileInput.Location = new System.Drawing.Point(3, 3);
			this.memoCompileInput.MaxLength = 2147483647;
			this.memoCompileInput.Multiline = true;
			this.memoCompileInput.Name = "memoCompileInput";
			this.memoCompileInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.memoCompileInput.Size = new System.Drawing.Size(616, 530);
			this.memoCompileInput.TabIndex = 1;
			this.memoCompileInput.WordWrap = false;
			// 
			// tabPage17
			// 
			this.tabPage17.Controls.Add(this.tableLayoutPanel12);
			this.tabPage17.Location = new System.Drawing.Point(4, 22);
			this.tabPage17.Name = "tabPage17";
			this.tabPage17.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage17.Size = new System.Drawing.Size(622, 536);
			this.tabPage17.TabIndex = 4;
			this.tabPage17.Text = "Options";
			this.tabPage17.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel12
			// 
			this.tableLayoutPanel12.ColumnCount = 1;
			this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel12.Controls.Add(this.cbUseGZip, 0, 4);
			this.tableLayoutPanel12.Controls.Add(this.cbSafeGridAccess, 0, 2);
			this.tableLayoutPanel12.Controls.Add(this.cbSafeStackAccess, 0, 1);
			this.tableLayoutPanel12.Controls.Add(this.cbIgnoreSelfModification, 0, 0);
			this.tableLayoutPanel12.Controls.Add(this.cbOutFormat, 0, 3);
			this.tableLayoutPanel12.Controls.Add(this.listBoxOutputLanguages, 0, 5);
			this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel12.Name = "tableLayoutPanel12";
			this.tableLayoutPanel12.RowCount = 7;
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel12.Size = new System.Drawing.Size(616, 530);
			this.tableLayoutPanel12.TabIndex = 0;
			// 
			// cbUseGZip
			// 
			this.cbUseGZip.AutoSize = true;
			this.cbUseGZip.Checked = true;
			this.cbUseGZip.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbUseGZip.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbUseGZip.Location = new System.Drawing.Point(3, 123);
			this.cbUseGZip.Name = "cbUseGZip";
			this.cbUseGZip.Size = new System.Drawing.Size(610, 24);
			this.cbUseGZip.TabIndex = 5;
			this.cbUseGZip.Text = "Use GZip compression";
			this.cbUseGZip.UseVisualStyleBackColor = true;
			// 
			// cbSafeGridAccess
			// 
			this.cbSafeGridAccess.AutoSize = true;
			this.cbSafeGridAccess.Checked = true;
			this.cbSafeGridAccess.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSafeGridAccess.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbSafeGridAccess.Location = new System.Drawing.Point(3, 63);
			this.cbSafeGridAccess.Name = "cbSafeGridAccess";
			this.cbSafeGridAccess.Size = new System.Drawing.Size(610, 24);
			this.cbSafeGridAccess.TabIndex = 2;
			this.cbSafeGridAccess.Text = "Implement Safe Grid Access";
			this.cbSafeGridAccess.UseVisualStyleBackColor = true;
			// 
			// cbSafeStackAccess
			// 
			this.cbSafeStackAccess.AutoSize = true;
			this.cbSafeStackAccess.Checked = true;
			this.cbSafeStackAccess.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSafeStackAccess.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbSafeStackAccess.Location = new System.Drawing.Point(3, 33);
			this.cbSafeStackAccess.Name = "cbSafeStackAccess";
			this.cbSafeStackAccess.Size = new System.Drawing.Size(610, 24);
			this.cbSafeStackAccess.TabIndex = 1;
			this.cbSafeStackAccess.Text = "Implement Safe Stack Access";
			this.cbSafeStackAccess.UseVisualStyleBackColor = true;
			// 
			// cbIgnoreSelfModification
			// 
			this.cbIgnoreSelfModification.AutoSize = true;
			this.cbIgnoreSelfModification.Checked = true;
			this.cbIgnoreSelfModification.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbIgnoreSelfModification.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbIgnoreSelfModification.Location = new System.Drawing.Point(3, 3);
			this.cbIgnoreSelfModification.Name = "cbIgnoreSelfModification";
			this.cbIgnoreSelfModification.Size = new System.Drawing.Size(610, 24);
			this.cbIgnoreSelfModification.TabIndex = 0;
			this.cbIgnoreSelfModification.Text = "Ignore Self Modifications";
			this.cbIgnoreSelfModification.UseVisualStyleBackColor = true;
			// 
			// cbOutFormat
			// 
			this.cbOutFormat.AutoSize = true;
			this.cbOutFormat.Checked = true;
			this.cbOutFormat.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbOutFormat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbOutFormat.Location = new System.Drawing.Point(3, 93);
			this.cbOutFormat.Name = "cbOutFormat";
			this.cbOutFormat.Size = new System.Drawing.Size(610, 24);
			this.cbOutFormat.TabIndex = 3;
			this.cbOutFormat.Text = "Format Compile Output";
			this.cbOutFormat.UseVisualStyleBackColor = true;
			// 
			// listBoxOutputLanguages
			// 
			this.listBoxOutputLanguages.CheckOnClick = true;
			this.listBoxOutputLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxOutputLanguages.FormattingEnabled = true;
			this.listBoxOutputLanguages.Location = new System.Drawing.Point(3, 153);
			this.listBoxOutputLanguages.Name = "listBoxOutputLanguages";
			this.listBoxOutputLanguages.Size = new System.Drawing.Size(610, 94);
			this.listBoxOutputLanguages.TabIndex = 6;
			// 
			// tabPage14
			// 
			this.tabPage14.Controls.Add(this.elementHost1);
			this.tabPage14.Location = new System.Drawing.Point(4, 22);
			this.tabPage14.Name = "tabPage14";
			this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage14.Size = new System.Drawing.Size(622, 536);
			this.tabPage14.TabIndex = 1;
			this.tabPage14.Text = "Graph";
			this.tabPage14.UseVisualStyleBackColor = true;
			// 
			// tabPage13
			// 
			this.tabPage13.Controls.Add(this.tabControlOutput);
			this.tabPage13.Location = new System.Drawing.Point(4, 22);
			this.tabPage13.Name = "tabPage13";
			this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage13.Size = new System.Drawing.Size(622, 536);
			this.tabPage13.TabIndex = 0;
			this.tabPage13.Text = "Output";
			this.tabPage13.UseVisualStyleBackColor = true;
			// 
			// tabControlOutput
			// 
			this.tabControlOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlOutput.Location = new System.Drawing.Point(3, 3);
			this.tabControlOutput.Name = "tabControlOutput";
			this.tabControlOutput.SelectedIndex = 0;
			this.tabControlOutput.Size = new System.Drawing.Size(616, 530);
			this.tabControlOutput.TabIndex = 0;
			// 
			// tabPage15
			// 
			this.tabPage15.Controls.Add(this.memoCompileLog);
			this.tabPage15.Location = new System.Drawing.Point(4, 22);
			this.tabPage15.Name = "tabPage15";
			this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage15.Size = new System.Drawing.Size(622, 536);
			this.tabPage15.TabIndex = 2;
			this.tabPage15.Text = "Log";
			this.tabPage15.UseVisualStyleBackColor = true;
			// 
			// memoCompileLog
			// 
			this.memoCompileLog.AcceptsReturn = true;
			this.memoCompileLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.memoCompileLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memoCompileLog.Location = new System.Drawing.Point(3, 3);
			this.memoCompileLog.MaxLength = 2147483647;
			this.memoCompileLog.Multiline = true;
			this.memoCompileLog.Name = "memoCompileLog";
			this.memoCompileLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.memoCompileLog.Size = new System.Drawing.Size(616, 530);
			this.memoCompileLog.TabIndex = 1;
			// 
			// tabPage11
			// 
			this.tabPage11.Controls.Add(this.edBefunCompileConsole);
			this.tabPage11.Location = new System.Drawing.Point(4, 22);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage11.Size = new System.Drawing.Size(622, 536);
			this.tabPage11.TabIndex = 5;
			this.tabPage11.Text = "Console";
			this.tabPage11.UseVisualStyleBackColor = true;
			// 
			// edBefunCompileConsole
			// 
			this.edBefunCompileConsole.BackColor = System.Drawing.SystemColors.Window;
			this.edBefunCompileConsole.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edBefunCompileConsole.Location = new System.Drawing.Point(3, 3);
			this.edBefunCompileConsole.MaxLength = 2147483647;
			this.edBefunCompileConsole.Multiline = true;
			this.edBefunCompileConsole.Name = "edBefunCompileConsole";
			this.edBefunCompileConsole.ReadOnly = true;
			this.edBefunCompileConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.edBefunCompileConsole.Size = new System.Drawing.Size(616, 530);
			this.edBefunCompileConsole.TabIndex = 0;
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.tableLayoutPanel13);
			this.tabPage8.Location = new System.Drawing.Point(4, 4);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage8.Size = new System.Drawing.Size(792, 574);
			this.tabPage8.TabIndex = 1;
			this.tabPage8.Text = "Code Compression";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel13
			// 
			this.tableLayoutPanel13.ColumnCount = 2;
			this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel13.Controls.Add(this.tableLayoutPanel14, 0, 0);
			this.tableLayoutPanel13.Controls.Add(this.tableLayoutPanel15, 1, 0);
			this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel13.Name = "tableLayoutPanel13";
			this.tableLayoutPanel13.RowCount = 1;
			this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel13.Size = new System.Drawing.Size(786, 568);
			this.tableLayoutPanel13.TabIndex = 0;
			// 
			// tableLayoutPanel14
			// 
			this.tableLayoutPanel14.ColumnCount = 1;
			this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel14.Controls.Add(this.btnGZipCompress, 0, 6);
			this.tableLayoutPanel14.Controls.Add(this.btnMSZipCompressSingle, 0, 1);
			this.tableLayoutPanel14.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel14.Controls.Add(this.label2, 0, 5);
			this.tableLayoutPanel14.Controls.Add(this.btnMSZipDecompressSingle, 0, 2);
			this.tableLayoutPanel14.Controls.Add(this.btnMSZipCompressMulti, 0, 3);
			this.tableLayoutPanel14.Controls.Add(this.btnMSZipDecompressMulti, 0, 4);
			this.tableLayoutPanel14.Controls.Add(this.btnGZipDecompress, 0, 7);
			this.tableLayoutPanel14.Controls.Add(this.btnGZipCompressToList, 0, 8);
			this.tableLayoutPanel14.Controls.Add(this.btnGZipCompressToHex, 0, 9);
			this.tableLayoutPanel14.Controls.Add(this.btnCompressBenchmark, 0, 11);
			this.tableLayoutPanel14.Controls.Add(this.btnRunCodeCompressionTests, 0, 12);
			this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel14.Name = "tableLayoutPanel14";
			this.tableLayoutPanel14.RowCount = 13;
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel14.Size = new System.Drawing.Size(144, 562);
			this.tableLayoutPanel14.TabIndex = 0;
			// 
			// btnGZipCompress
			// 
			this.btnGZipCompress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGZipCompress.Location = new System.Drawing.Point(3, 183);
			this.btnGZipCompress.Name = "btnGZipCompress";
			this.btnGZipCompress.Size = new System.Drawing.Size(138, 24);
			this.btnGZipCompress.TabIndex = 10;
			this.btnGZipCompress.Text = "Compress";
			this.btnGZipCompress.UseVisualStyleBackColor = true;
			this.btnGZipCompress.Click += new System.EventHandler(this.btnGZipCompress_Click);
			// 
			// btnMSZipCompressSingle
			// 
			this.btnMSZipCompressSingle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnMSZipCompressSingle.Location = new System.Drawing.Point(3, 33);
			this.btnMSZipCompressSingle.Name = "btnMSZipCompressSingle";
			this.btnMSZipCompressSingle.Size = new System.Drawing.Size(138, 24);
			this.btnMSZipCompressSingle.TabIndex = 9;
			this.btnMSZipCompressSingle.Text = "Compress Single";
			this.btnMSZipCompressSingle.UseVisualStyleBackColor = true;
			this.btnMSZipCompressSingle.Click += new System.EventHandler(this.btnMSZipCompressSingle_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(138, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "[MSZip]";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 150);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(138, 30);
			this.label2.TabIndex = 1;
			this.label2.Text = "[GZip]";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnMSZipDecompressSingle
			// 
			this.btnMSZipDecompressSingle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnMSZipDecompressSingle.Location = new System.Drawing.Point(3, 63);
			this.btnMSZipDecompressSingle.Name = "btnMSZipDecompressSingle";
			this.btnMSZipDecompressSingle.Size = new System.Drawing.Size(138, 24);
			this.btnMSZipDecompressSingle.TabIndex = 2;
			this.btnMSZipDecompressSingle.Text = "Decompress Single";
			this.btnMSZipDecompressSingle.UseVisualStyleBackColor = true;
			this.btnMSZipDecompressSingle.Click += new System.EventHandler(this.btnMSZipDecompressSingle_Click);
			// 
			// btnMSZipCompressMulti
			// 
			this.btnMSZipCompressMulti.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnMSZipCompressMulti.Location = new System.Drawing.Point(3, 93);
			this.btnMSZipCompressMulti.Name = "btnMSZipCompressMulti";
			this.btnMSZipCompressMulti.Size = new System.Drawing.Size(138, 24);
			this.btnMSZipCompressMulti.TabIndex = 3;
			this.btnMSZipCompressMulti.Text = "Compress";
			this.btnMSZipCompressMulti.UseVisualStyleBackColor = true;
			this.btnMSZipCompressMulti.Click += new System.EventHandler(this.btnMSZipCompressMulti_Click);
			// 
			// btnMSZipDecompressMulti
			// 
			this.btnMSZipDecompressMulti.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnMSZipDecompressMulti.Location = new System.Drawing.Point(3, 123);
			this.btnMSZipDecompressMulti.Name = "btnMSZipDecompressMulti";
			this.btnMSZipDecompressMulti.Size = new System.Drawing.Size(138, 24);
			this.btnMSZipDecompressMulti.TabIndex = 4;
			this.btnMSZipDecompressMulti.Text = "Decompress";
			this.btnMSZipDecompressMulti.UseVisualStyleBackColor = true;
			this.btnMSZipDecompressMulti.Click += new System.EventHandler(this.btnMSZipDecompressMulti_Click);
			// 
			// btnGZipDecompress
			// 
			this.btnGZipDecompress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGZipDecompress.Location = new System.Drawing.Point(3, 213);
			this.btnGZipDecompress.Name = "btnGZipDecompress";
			this.btnGZipDecompress.Size = new System.Drawing.Size(138, 24);
			this.btnGZipDecompress.TabIndex = 5;
			this.btnGZipDecompress.Text = "Decompress";
			this.btnGZipDecompress.UseVisualStyleBackColor = true;
			this.btnGZipDecompress.Click += new System.EventHandler(this.btnGZipDecompress_Click);
			// 
			// btnGZipCompressToList
			// 
			this.btnGZipCompressToList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGZipCompressToList.Location = new System.Drawing.Point(3, 243);
			this.btnGZipCompressToList.Name = "btnGZipCompressToList";
			this.btnGZipCompressToList.Size = new System.Drawing.Size(138, 24);
			this.btnGZipCompressToList.TabIndex = 6;
			this.btnGZipCompressToList.Text = "Compress To List";
			this.btnGZipCompressToList.UseVisualStyleBackColor = true;
			this.btnGZipCompressToList.Click += new System.EventHandler(this.btnGZipCompressToList_Click);
			// 
			// btnGZipCompressToHex
			// 
			this.btnGZipCompressToHex.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGZipCompressToHex.Location = new System.Drawing.Point(3, 273);
			this.btnGZipCompressToHex.Name = "btnGZipCompressToHex";
			this.btnGZipCompressToHex.Size = new System.Drawing.Size(138, 24);
			this.btnGZipCompressToHex.TabIndex = 7;
			this.btnGZipCompressToHex.Text = "Compress To Hex";
			this.btnGZipCompressToHex.UseVisualStyleBackColor = true;
			this.btnGZipCompressToHex.Click += new System.EventHandler(this.btnGZipCompressToHex_Click);
			// 
			// btnCompressBenchmark
			// 
			this.btnCompressBenchmark.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCompressBenchmark.Location = new System.Drawing.Point(3, 505);
			this.btnCompressBenchmark.Name = "btnCompressBenchmark";
			this.btnCompressBenchmark.Size = new System.Drawing.Size(138, 24);
			this.btnCompressBenchmark.TabIndex = 8;
			this.btnCompressBenchmark.Text = "Benchmark";
			this.btnCompressBenchmark.UseVisualStyleBackColor = true;
			this.btnCompressBenchmark.Click += new System.EventHandler(this.btnCompressBenchmark_Click);
			// 
			// btnRunCodeCompressionTests
			// 
			this.btnRunCodeCompressionTests.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnRunCodeCompressionTests.Location = new System.Drawing.Point(3, 535);
			this.btnRunCodeCompressionTests.Name = "btnRunCodeCompressionTests";
			this.btnRunCodeCompressionTests.Size = new System.Drawing.Size(138, 24);
			this.btnRunCodeCompressionTests.TabIndex = 11;
			this.btnRunCodeCompressionTests.Text = "Run Tests";
			this.btnRunCodeCompressionTests.UseVisualStyleBackColor = true;
			this.btnRunCodeCompressionTests.Click += new System.EventHandler(this.btnRunCodeCompressionTests_Click);
			// 
			// tableLayoutPanel15
			// 
			this.tableLayoutPanel15.ColumnCount = 2;
			this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel15.Controls.Add(this.memoCodeCompressionInput, 0, 0);
			this.tableLayoutPanel15.Controls.Add(this.memoCodeCompressionOutput, 1, 0);
			this.tableLayoutPanel15.Controls.Add(this.memoCodeCompressionLog, 0, 1);
			this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel15.Location = new System.Drawing.Point(153, 3);
			this.tableLayoutPanel15.Name = "tableLayoutPanel15";
			this.tableLayoutPanel15.RowCount = 2;
			this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel15.Size = new System.Drawing.Size(630, 562);
			this.tableLayoutPanel15.TabIndex = 1;
			// 
			// memoCodeCompressionInput
			// 
			this.memoCodeCompressionInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.memoCodeCompressionInput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memoCodeCompressionInput.Location = new System.Drawing.Point(3, 3);
			this.memoCodeCompressionInput.MaxLength = 2147483647;
			this.memoCodeCompressionInput.Multiline = true;
			this.memoCodeCompressionInput.Name = "memoCodeCompressionInput";
			this.memoCodeCompressionInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.memoCodeCompressionInput.Size = new System.Drawing.Size(309, 406);
			this.memoCodeCompressionInput.TabIndex = 0;
			this.memoCodeCompressionInput.WordWrap = false;
			// 
			// memoCodeCompressionOutput
			// 
			this.memoCodeCompressionOutput.BackColor = System.Drawing.SystemColors.Window;
			this.memoCodeCompressionOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.memoCodeCompressionOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memoCodeCompressionOutput.Location = new System.Drawing.Point(318, 3);
			this.memoCodeCompressionOutput.MaxLength = 2147483647;
			this.memoCodeCompressionOutput.Multiline = true;
			this.memoCodeCompressionOutput.Name = "memoCodeCompressionOutput";
			this.memoCodeCompressionOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.memoCodeCompressionOutput.Size = new System.Drawing.Size(309, 406);
			this.memoCodeCompressionOutput.TabIndex = 1;
			this.memoCodeCompressionOutput.WordWrap = false;
			// 
			// memoCodeCompressionLog
			// 
			this.tableLayoutPanel15.SetColumnSpan(this.memoCodeCompressionLog, 2);
			this.memoCodeCompressionLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.memoCodeCompressionLog.Location = new System.Drawing.Point(3, 415);
			this.memoCodeCompressionLog.Multiline = true;
			this.memoCodeCompressionLog.Name = "memoCodeCompressionLog";
			this.memoCodeCompressionLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.memoCodeCompressionLog.Size = new System.Drawing.Size(624, 144);
			this.memoCodeCompressionLog.TabIndex = 2;
			this.memoCodeCompressionLog.WordWrap = false;
			// 
			// elementHost1
			// 
			this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.elementHost1.Location = new System.Drawing.Point(3, 3);
			this.elementHost1.Name = "elementHost1";
			this.elementHost1.Size = new System.Drawing.Size(616, 530);
			this.elementHost1.TabIndex = 0;
			this.elementHost1.Text = "elementHost1";
			this.elementHost1.Child = this.graphUserControl1;
			// 
			// frmMain_BefunCompile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabCompileOuterControl);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "frmMain_BefunCompile";
			this.Size = new System.Drawing.Size(800, 600);
			this.Load += new System.EventHandler(this.frm_Load);
			this.tabCompileOuterControl.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.tableLayoutPanel10.ResumeLayout(false);
			this.tableLayoutPanel11.ResumeLayout(false);
			this.tabCompileControl.ResumeLayout(false);
			this.tabPage16.ResumeLayout(false);
			this.tabPage16.PerformLayout();
			this.tabPage17.ResumeLayout(false);
			this.tableLayoutPanel12.ResumeLayout(false);
			this.tableLayoutPanel12.PerformLayout();
			this.tabPage14.ResumeLayout(false);
			this.tabPage13.ResumeLayout(false);
			this.tabPage15.ResumeLayout(false);
			this.tabPage15.PerformLayout();
			this.tabPage11.ResumeLayout(false);
			this.tabPage11.PerformLayout();
			this.tabPage8.ResumeLayout(false);
			this.tableLayoutPanel13.ResumeLayout(false);
			this.tableLayoutPanel14.ResumeLayout(false);
			this.tableLayoutPanel14.PerformLayout();
			this.tableLayoutPanel15.ResumeLayout(false);
			this.tableLayoutPanel15.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabCompileOuterControl;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
		private System.Windows.Forms.Button btnCompileGraphCompile;
		private System.Windows.Forms.Button btnCompile;
		private System.Windows.Forms.Button btnCompileGraph;
		private System.Windows.Forms.Button btnRunCurrGraph;
		private System.Windows.Forms.ComboBox cbxCompileLevel;
		private System.Windows.Forms.Button btnCompileTest;
		private System.Windows.Forms.ComboBox cbxCompileData;
		private System.Windows.Forms.Button btnCompileExecute;
		private System.Windows.Forms.Button btnCompileCompile;
		private System.Windows.Forms.Button btnGenOverview;
		private System.Windows.Forms.TabControl tabCompileControl;
		private System.Windows.Forms.TabPage tabPage16;
		private System.Windows.Forms.TextBox memoCompileInput;
		private System.Windows.Forms.TabPage tabPage17;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
		private System.Windows.Forms.CheckBox cbUseGZip;
		private System.Windows.Forms.CheckBox cbSafeGridAccess;
		private System.Windows.Forms.CheckBox cbSafeStackAccess;
		private System.Windows.Forms.CheckBox cbIgnoreSelfModification;
		private System.Windows.Forms.CheckBox cbOutFormat;
		private System.Windows.Forms.TabPage tabPage14;
		private System.Windows.Forms.Integration.ElementHost elementHost1;
		private GraphUserControl graphUserControl1;
		private System.Windows.Forms.TabPage tabPage13;
		private System.Windows.Forms.TabPage tabPage15;
		private System.Windows.Forms.TextBox memoCompileLog;
		private System.Windows.Forms.TabPage tabPage11;
		private System.Windows.Forms.TextBox edBefunCompileConsole;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
		private System.Windows.Forms.Button btnGZipCompress;
		private System.Windows.Forms.Button btnMSZipCompressSingle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnMSZipDecompressSingle;
		private System.Windows.Forms.Button btnMSZipCompressMulti;
		private System.Windows.Forms.Button btnMSZipDecompressMulti;
		private System.Windows.Forms.Button btnGZipDecompress;
		private System.Windows.Forms.Button btnGZipCompressToList;
		private System.Windows.Forms.Button btnGZipCompressToHex;
		private System.Windows.Forms.Button btnCompressBenchmark;
		private System.Windows.Forms.Button btnRunCodeCompressionTests;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
		private System.Windows.Forms.TextBox memoCodeCompressionInput;
		private System.Windows.Forms.TextBox memoCodeCompressionOutput;
		private System.Windows.Forms.TextBox memoCodeCompressionLog;
		private System.Windows.Forms.TabControl tabControlOutput;
		private System.Windows.Forms.CheckedListBox listBoxOutputLanguages;
	}
}
