namespace BefunGen
{
	partial class frmMain_BefunGen
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
			this.components = new System.ComponentModel.Container();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.btnLoad = new System.Windows.Forms.Button();
			this.txtTableFile = new System.Windows.Forms.TextBox();
			this.btnLoadSYN = new System.Windows.Forms.Button();
			this.txtSynFile = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txtSource = new Alsing.Windows.Forms.SyntaxBoxControl();
			this.tabBefunGenControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtParseTree = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.txtParseTrimTree = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtAST = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.txtGrammar = new System.Windows.Forms.TextBox();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.btnGen = new System.Windows.Forms.Button();
			this.btnRun = new System.Windows.Forms.Button();
			this.cbxCodePieceStore = new System.Windows.Forms.ComboBox();
			this.btnCodePieceStorePreview = new System.Windows.Forms.Button();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.txtDebugIn = new System.Windows.Forms.TextBox();
			this.txtDebug = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.btnGenExpr = new System.Windows.Forms.Button();
			this.btnGenStmt = new System.Windows.Forms.Button();
			this.btnGenSub = new System.Windows.Forms.Button();
			this.btnGenProg = new System.Windows.Forms.Button();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabBefunGenControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 600);
			this.tableLayoutPanel2.TabIndex = 10;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel3.Controls.Add(this.btnLoad, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.txtTableFile, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnLoadSYN, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.txtSynFile, 0, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(794, 64);
			this.tableLayoutPanel3.TabIndex = 12;
			// 
			// btnLoad
			// 
			this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnLoad.Enabled = false;
			this.btnLoad.Location = new System.Drawing.Point(697, 3);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(94, 26);
			this.btnLoad.TabIndex = 9;
			this.btnLoad.Text = "Load EGT";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// txtTableFile
			// 
			this.txtTableFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtTableFile.Location = new System.Drawing.Point(3, 3);
			this.txtTableFile.Name = "txtTableFile";
			this.txtTableFile.Size = new System.Drawing.Size(688, 20);
			this.txtTableFile.TabIndex = 8;
			// 
			// btnLoadSYN
			// 
			this.btnLoadSYN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnLoadSYN.Enabled = false;
			this.btnLoadSYN.Location = new System.Drawing.Point(697, 35);
			this.btnLoadSYN.Name = "btnLoadSYN";
			this.btnLoadSYN.Size = new System.Drawing.Size(94, 26);
			this.btnLoadSYN.TabIndex = 10;
			this.btnLoadSYN.Text = "Load SYN";
			this.btnLoadSYN.UseVisualStyleBackColor = true;
			this.btnLoadSYN.Click += new System.EventHandler(this.btnLoadSYN_Click);
			// 
			// txtSynFile
			// 
			this.txtSynFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSynFile.Location = new System.Drawing.Point(3, 35);
			this.txtSynFile.Name = "txtSynFile";
			this.txtSynFile.Size = new System.Drawing.Size(688, 20);
			this.txtSynFile.TabIndex = 11;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 70);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.txtSource);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabBefunGenControl);
			this.splitContainer1.Size = new System.Drawing.Size(800, 530);
			this.splitContainer1.SplitterDistance = 236;
			this.splitContainer1.TabIndex = 11;
			// 
			// txtSource
			// 
			this.txtSource.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
			this.txtSource.AutoListPosition = null;
			this.txtSource.AutoListSelectedText = "a123";
			this.txtSource.AutoListVisible = false;
			this.txtSource.BackColor = System.Drawing.Color.White;
			this.txtSource.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
			this.txtSource.CopyAsRTF = false;
			this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSource.FontName = "Courier new";
			this.txtSource.HighLightActiveLine = true;
			this.txtSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.txtSource.Indent = Alsing.Windows.Forms.SyntaxBox.IndentStyle.Smart;
			this.txtSource.InfoTipCount = 1;
			this.txtSource.InfoTipPosition = null;
			this.txtSource.InfoTipSelectedIndex = 1;
			this.txtSource.InfoTipVisible = false;
			this.txtSource.Location = new System.Drawing.Point(0, 0);
			this.txtSource.LockCursorUpdate = false;
			this.txtSource.Name = "txtSource";
			this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtSource.ShowGutterMargin = false;
			this.txtSource.ShowScopeIndicator = false;
			this.txtSource.ShowTabGuides = true;
			this.txtSource.Size = new System.Drawing.Size(800, 236);
			this.txtSource.SmoothScroll = true;
			this.txtSource.SplitView = false;
			this.txtSource.SplitviewH = -4;
			this.txtSource.SplitviewV = -4;
			this.txtSource.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.txtSource.TabIndex = 5;
			this.txtSource.TabSize = 2;
			this.txtSource.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
			this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
			this.txtSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSource_KeyPress);
			// 
			// tabBefunGenControl
			// 
			this.tabBefunGenControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabBefunGenControl.Controls.Add(this.tabPage1);
			this.tabBefunGenControl.Controls.Add(this.tabPage3);
			this.tabBefunGenControl.Controls.Add(this.tabPage2);
			this.tabBefunGenControl.Controls.Add(this.tabPage4);
			this.tabBefunGenControl.Controls.Add(this.tabPage5);
			this.tabBefunGenControl.Controls.Add(this.tabPage6);
			this.tabBefunGenControl.Controls.Add(this.tabPage7);
			this.tabBefunGenControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabBefunGenControl.Location = new System.Drawing.Point(0, 0);
			this.tabBefunGenControl.Name = "tabBefunGenControl";
			this.tabBefunGenControl.SelectedIndex = 0;
			this.tabBefunGenControl.Size = new System.Drawing.Size(800, 290);
			this.tabBefunGenControl.TabIndex = 10;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtParseTree);
			this.tabPage1.Location = new System.Drawing.Point(4, 4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(792, 264);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Reduction Tree";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// txtParseTree
			// 
			this.txtParseTree.BackColor = System.Drawing.SystemColors.Window;
			this.txtParseTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtParseTree.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtParseTree.Location = new System.Drawing.Point(3, 3);
			this.txtParseTree.Multiline = true;
			this.txtParseTree.Name = "txtParseTree";
			this.txtParseTree.ReadOnly = true;
			this.txtParseTree.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtParseTree.Size = new System.Drawing.Size(786, 258);
			this.txtParseTree.TabIndex = 6;
			this.txtParseTree.WordWrap = false;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.txtParseTrimTree);
			this.tabPage3.Location = new System.Drawing.Point(4, 4);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(792, 264);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Trimmed Tree";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// txtParseTrimTree
			// 
			this.txtParseTrimTree.BackColor = System.Drawing.SystemColors.Window;
			this.txtParseTrimTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtParseTrimTree.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtParseTrimTree.Location = new System.Drawing.Point(3, 3);
			this.txtParseTrimTree.Multiline = true;
			this.txtParseTrimTree.Name = "txtParseTrimTree";
			this.txtParseTrimTree.ReadOnly = true;
			this.txtParseTrimTree.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtParseTrimTree.Size = new System.Drawing.Size(786, 258);
			this.txtParseTrimTree.TabIndex = 7;
			this.txtParseTrimTree.WordWrap = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtAST);
			this.tabPage2.Location = new System.Drawing.Point(4, 4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(792, 264);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "AST";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtAST
			// 
			this.txtAST.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtAST.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAST.Location = new System.Drawing.Point(3, 3);
			this.txtAST.Multiline = true;
			this.txtAST.Name = "txtAST";
			this.txtAST.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtAST.Size = new System.Drawing.Size(786, 258);
			this.txtAST.TabIndex = 0;
			this.txtAST.WordWrap = false;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.txtLog);
			this.tabPage4.Location = new System.Drawing.Point(4, 4);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(792, 264);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Log";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// txtLog
			// 
			this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtLog.Location = new System.Drawing.Point(3, 3);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.Size = new System.Drawing.Size(786, 258);
			this.txtLog.TabIndex = 0;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.txtGrammar);
			this.tabPage5.Location = new System.Drawing.Point(4, 4);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(792, 264);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Grammar";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// txtGrammar
			// 
			this.txtGrammar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtGrammar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGrammar.Location = new System.Drawing.Point(3, 3);
			this.txtGrammar.Multiline = true;
			this.txtGrammar.Name = "txtGrammar";
			this.txtGrammar.ReadOnly = true;
			this.txtGrammar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtGrammar.Size = new System.Drawing.Size(786, 258);
			this.txtGrammar.TabIndex = 0;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.splitContainer2);
			this.tabPage6.Location = new System.Drawing.Point(4, 4);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(792, 264);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Code";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.txtCode);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel4);
			this.splitContainer2.Size = new System.Drawing.Size(786, 258);
			this.splitContainer2.SplitterDistance = 568;
			this.splitContainer2.TabIndex = 1;
			// 
			// txtCode
			// 
			this.txtCode.BackColor = System.Drawing.Color.White;
			this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCode.Location = new System.Drawing.Point(0, 0);
			this.txtCode.Multiline = true;
			this.txtCode.Name = "txtCode";
			this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtCode.Size = new System.Drawing.Size(568, 258);
			this.txtCode.TabIndex = 0;
			this.txtCode.WordWrap = false;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.btnGen, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.btnRun, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.cbxCodePieceStore, 0, 3);
			this.tableLayoutPanel4.Controls.Add(this.btnCodePieceStorePreview, 0, 4);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 6;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new System.Drawing.Size(214, 258);
			this.tableLayoutPanel4.TabIndex = 0;
			// 
			// btnGen
			// 
			this.btnGen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGen.Location = new System.Drawing.Point(3, 3);
			this.btnGen.Name = "btnGen";
			this.btnGen.Size = new System.Drawing.Size(208, 26);
			this.btnGen.TabIndex = 0;
			this.btnGen.Text = "Generate";
			this.btnGen.UseVisualStyleBackColor = true;
			this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
			// 
			// btnRun
			// 
			this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnRun.Location = new System.Drawing.Point(3, 35);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(208, 26);
			this.btnRun.TabIndex = 1;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// cbxCodePieceStore
			// 
			this.cbxCodePieceStore.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbxCodePieceStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxCodePieceStore.FormattingEnabled = true;
			this.cbxCodePieceStore.Location = new System.Drawing.Point(3, 87);
			this.cbxCodePieceStore.Name = "cbxCodePieceStore";
			this.cbxCodePieceStore.Size = new System.Drawing.Size(208, 21);
			this.cbxCodePieceStore.TabIndex = 2;
			// 
			// btnCodePieceStorePreview
			// 
			this.btnCodePieceStorePreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCodePieceStorePreview.Location = new System.Drawing.Point(3, 119);
			this.btnCodePieceStorePreview.Name = "btnCodePieceStorePreview";
			this.btnCodePieceStorePreview.Size = new System.Drawing.Size(208, 26);
			this.btnCodePieceStorePreview.TabIndex = 3;
			this.btnCodePieceStorePreview.Text = "Preview";
			this.btnCodePieceStorePreview.UseVisualStyleBackColor = true;
			this.btnCodePieceStorePreview.Click += new System.EventHandler(this.btnCodePieceStorePreview_Click);
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.tableLayoutPanel1);
			this.tabPage7.Location = new System.Drawing.Point(4, 4);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new System.Drawing.Size(792, 264);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "Debug";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
			this.tableLayoutPanel1.Controls.Add(this.txtDebugIn, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtDebug, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 258);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// txtDebugIn
			// 
			this.txtDebugIn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDebugIn.Location = new System.Drawing.Point(3, 3);
			this.txtDebugIn.Multiline = true;
			this.txtDebugIn.Name = "txtDebugIn";
			this.txtDebugIn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDebugIn.Size = new System.Drawing.Size(600, 110);
			this.txtDebugIn.TabIndex = 0;
			// 
			// txtDebug
			// 
			this.txtDebug.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDebug.Location = new System.Drawing.Point(3, 119);
			this.txtDebug.Multiline = true;
			this.txtDebug.Name = "txtDebug";
			this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDebug.Size = new System.Drawing.Size(600, 136);
			this.txtDebug.TabIndex = 1;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.ColumnCount = 1;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.Controls.Add(this.btnGenExpr, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.btnGenStmt, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.btnGenSub, 0, 2);
			this.tableLayoutPanel5.Controls.Add(this.btnGenProg, 0, 3);
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Location = new System.Drawing.Point(609, 3);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 7;
			this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel5, 2);
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(174, 252);
			this.tableLayoutPanel5.TabIndex = 2;
			// 
			// btnGenExpr
			// 
			this.btnGenExpr.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGenExpr.Location = new System.Drawing.Point(3, 3);
			this.btnGenExpr.Name = "btnGenExpr";
			this.btnGenExpr.Size = new System.Drawing.Size(168, 24);
			this.btnGenExpr.TabIndex = 0;
			this.btnGenExpr.Text = "Generate Expression";
			this.btnGenExpr.UseVisualStyleBackColor = true;
			this.btnGenExpr.Click += new System.EventHandler(this.btnGenExpr_Click);
			// 
			// btnGenStmt
			// 
			this.btnGenStmt.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGenStmt.Location = new System.Drawing.Point(3, 33);
			this.btnGenStmt.Name = "btnGenStmt";
			this.btnGenStmt.Size = new System.Drawing.Size(168, 24);
			this.btnGenStmt.TabIndex = 1;
			this.btnGenStmt.Text = "Generate Statement";
			this.btnGenStmt.UseVisualStyleBackColor = true;
			this.btnGenStmt.Click += new System.EventHandler(this.btnGenStmt_Click);
			// 
			// btnGenSub
			// 
			this.btnGenSub.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGenSub.Location = new System.Drawing.Point(3, 63);
			this.btnGenSub.Name = "btnGenSub";
			this.btnGenSub.Size = new System.Drawing.Size(168, 24);
			this.btnGenSub.TabIndex = 2;
			this.btnGenSub.Text = "Generate Method";
			this.btnGenSub.UseVisualStyleBackColor = true;
			this.btnGenSub.Click += new System.EventHandler(this.btnGenSub_Click);
			// 
			// btnGenProg
			// 
			this.btnGenProg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGenProg.Location = new System.Drawing.Point(3, 93);
			this.btnGenProg.Name = "btnGenProg";
			this.btnGenProg.Size = new System.Drawing.Size(168, 24);
			this.btnGenProg.TabIndex = 3;
			this.btnGenProg.Text = "Generate Program";
			this.btnGenProg.UseVisualStyleBackColor = true;
			this.btnGenProg.Click += new System.EventHandler(this.btnGenProg_Click);
			// 
			// frmMain_BefunGen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel2);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "frmMain_BefunGen";
			this.Size = new System.Drawing.Size(800, 600);
			this.Load += new System.EventHandler(this.frm_Load);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabBefunGenControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel5.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		internal System.Windows.Forms.Button btnLoad;
		internal System.Windows.Forms.TextBox txtTableFile;
		private System.Windows.Forms.Button btnLoadSYN;
		private System.Windows.Forms.TextBox txtSynFile;
		private System.Windows.Forms.SplitContainer splitContainer1;
		internal Alsing.Windows.Forms.SyntaxBoxControl txtSource;
		private System.Windows.Forms.TabControl tabBefunGenControl;
		private System.Windows.Forms.TabPage tabPage1;
		internal System.Windows.Forms.TextBox txtParseTree;
		private System.Windows.Forms.TabPage tabPage3;
		internal System.Windows.Forms.TextBox txtParseTrimTree;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtAST;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TextBox txtGrammar;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Button btnGen;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.ComboBox cbxCodePieceStore;
		private System.Windows.Forms.Button btnCodePieceStorePreview;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox txtDebugIn;
		private System.Windows.Forms.TextBox txtDebug;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.Button btnGenExpr;
		private System.Windows.Forms.Button btnGenStmt;
		private System.Windows.Forms.Button btnGenSub;
		private System.Windows.Forms.Button btnGenProg;
	}
}
