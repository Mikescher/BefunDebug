﻿using BefunCompile;
using BefunCompile.Graph;
using BefunGen.AST;
using BefunGen.AST.CodeGen;
using BefunGen.AST.CodeGen.NumberCode;
using BefunHighlight;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BefunGen
{
	public partial class frmMain : Form
	{
		private DemoParser MyParser = new DemoParser();
		private TextFungeParser GParser = new TextFungeParser();

		private bool loaded = false;

		private string currentSC = "";
		private Thread parseThread;
		bool threadRunning = true;

		public frmMain()
		{
			InitializeComponent();
			tabControl1.SelectedIndex = 6;

			foreach (var lang in (OutputLanguage[])Enum.GetValues(typeof(OutputLanguage)))
			{
				cbxCompileLanguage.Items.Add(lang);
			}
			cbxCompileLanguage.SelectedIndex = 0;
			cbxCompileLevel.SelectedIndex = 0;
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			doLoad();
		}

		private void btnLoadSYN_Click(object sender, EventArgs e)
		{
			doLoadSYN();
		}

		private void doLoadSYN()
		{
			try
			{
				txtSource.Document.SyntaxFile = txtSynFile.Text;
				txtSource.Document.ParseAll();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void doLoad()
		{
			try
			{
				if (MyParser.Setup(new BinaryReader(new MemoryStream(GParser.getGrammar()))))
				{
					loaded = true;
				}
				else
				{
					txtParseTree.Text = MyParser.FailMessage + Environment.NewLine + "CGT failed to load";
					txtAST.Text = MyParser.FailMessage + Environment.NewLine + "CGT failed to load";
				}
			}
			catch (GOLD.ParserException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			txtTableFile.Text = Path.Combine(Application.StartupPath, "TextFunge.egt");

			if (File.Exists(txtTableFile.Text))
				doLoad();
			else
				txtLog.AppendText(string.Format("EGT not found: {0} \r\n", txtTableFile.Text));

			//#########

			txtSynFile.Text = Path.Combine(Application.StartupPath, "TextFunge.syn");
			if (File.Exists(txtSynFile.Text))
				doLoadSYN();
			else
				txtLog.AppendText(string.Format("Syntaxfile not found: {0} \r\n", txtSynFile.Text));

			txtSource.Document.Text = Properties.Resources.example;
			memoCompileInput.Text = Properties.Resources.example_compile;
			currentSC = txtSource.Document.Text;

			//##########

			doLoad();

			//##########

			parseThread = new Thread(work);
			parseThread.IsBackground = true;
			parseThread.Start();
		}

		private void txtSource_TextChanged(object sender, EventArgs e)
		{
			currentSC = txtSource.Document.Text;
		}

		private Tuple<string, string, string, string, string> doParse(string txt)
		{
			long time_full = Environment.TickCount;

			string redtree = "";
			string trimtree = "";
			string asttree = "";
			string log = "";
			string grammar = "";

			if (loaded)
			{
				string refout1 = "";
				MyParser.Parse(new StringReader(txt), ref refout1, false);
				redtree = refout1;
				log += (string.Format("Reduction Tree: {0}ms\r\n", MyParser.Time));

				string refout2 = "";
				MyParser.Parse(new StringReader(txt), ref refout2, true);
				trimtree = refout2;
				log += (string.Format("Trimmed Reduction Tree: {0}ms\r\n", MyParser.Time));

				try
				{
					BefunGen.AST.Program p = GParser.generateAST(txt);

					log += (string.Format("AST-Gen: {0}ms\r\n", MyParser.Time));

					long gdst = Environment.TickCount;
					string debug = p.getDebugString().Replace("\n", Environment.NewLine);
					gdst = Environment.TickCount - gdst;

					asttree = debug;

					log += (string.Format("AST-DebugOut: {0}ms\r\n", gdst));
				}
				catch (Exception e)
				{
					asttree = e.ToString();
				}

				grammar = GParser.getGrammarDefinition();
			}
			else
			{
				redtree = "Grammar not loaded";
				trimtree = "Grammar not loaded";
				asttree = "Grammar not loaded";
			}

			time_full = Environment.TickCount - time_full;

			log += "\r\n----------\r\n";
			log += (string.Format("Parse: {0}ms\r\n", time_full));

			return Tuple.Create(redtree, trimtree, asttree, log, grammar);
		}

		private void txtSource_KeyPress(object sender, KeyPressEventArgs e)
		{
			currentSC = txtSource.Document.Text;
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			threadRunning = false;
		}

		private void work()
		{
			string currentTxt = null;

			while (threadRunning)
			{
				string newtxt = currentSC;

				if (newtxt != currentTxt)
				{
					bool hasChangedAgain = true;
					while (hasChangedAgain)
					{
						Thread.Sleep(500);
						hasChangedAgain = (currentSC != newtxt);
						newtxt = currentSC;
					}

					var result = doParse(newtxt);

					txtParseTree.SetPropertyThreadSafe(() => txtParseTree.Text, result.Item1);
					txtParseTrimTree.SetPropertyThreadSafe(() => txtParseTrimTree.Text, result.Item2);
					txtAST.SetPropertyThreadSafe(() => txtAST.Text, result.Item3);
					txtLog.SetPropertyThreadSafe(() => txtLog.Text, result.Item4);
					txtGrammar.SetPropertyThreadSafe(() => txtGrammar.Text, result.Item5);

					currentTxt = newtxt;
				}
				else
				{
					Thread.Sleep(100);
				}
			}
		}

		private Expression parseExpression(string expr)
		{
			string txt = String.Format("program b var  bool a; begin a = (bool)({0}); end end", expr);

			BefunGen.AST.Program p = GParser.generateAST(txt);


			return ((Expression_Cast)((Statement_Assignment)((Statement_StatementList)p.MainMethod.Body).List[0]).Expr).Expr;
		}

		private Statement parseStatement(string stmt)
		{
			string txt = String.Format("program b var  bool a; begin {0} end end", stmt);
			BefunGen.AST.Program p = GParser.generateAST(txt);


			return ((Statement_StatementList)p.MainMethod.Body).List[0];
		}

		private Method parseMethod(string meth)
		{
			string txt = String.Format("program b begin end {0} end", meth);
			BefunGen.AST.Program p = GParser.generateAST(txt);

			return p.MethodList[1];
		}

		private BefunGen.AST.Program parseProgram(string prog)
		{
			BefunGen.AST.Program p = GParser.generateAST(prog);

			return p;
		}

		private void debugExpression(string expr)
		{
			txtDebug.Clear();

			try
			{
				expr = expr.Replace(@"''", "\"");

				txtDebug.Text += expr + Environment.NewLine;

				Expression e = parseExpression(expr);
				CodePiece pc = e.generateCode(false);
				txtDebug.Text += pc.ToString() + Environment.NewLine;
			}
			catch (Exception e)
			{
				txtDebug.Text += e.ToString();
			}
		}

		private void debugStatement(string stmt)
		{
			txtDebug.Clear();

			try
			{
				stmt = stmt.Replace(@"''", "\"");

				txtDebug.Text += stmt + Environment.NewLine;

				Statement e = parseStatement(stmt);
				CodePiece pc = e.generateCode(false);
				txtDebug.Text += pc.ToString() + Environment.NewLine;
			}
			catch (Exception e)
			{
				txtDebug.Text += e.ToString();
			}
		}

		private void debugMethod(string meth)
		{
			txtDebug.Clear();

			try
			{
				meth = meth.Replace(@"''", "\"");

				meth = Regex.Replace(meth, @"[\r\n]{1,2}[ \t]+[\r\n]{1,2}", "\r\n");
				meth = Regex.Replace(meth, @"^[ \t]*[\r\n]{1,2}", "");
				meth = Regex.Replace(meth, @"[\r\n]{1,2}[ \t]*$", "");

				Method e = parseMethod(meth);
				txtDebug.Text += "[METHOD] " + e.Identifier + ":" + e.MethodAddr + Environment.NewLine;
				CodePiece pc = e.generateCode(0, 0);
				txtDebug.Text += pc.ToString() + Environment.NewLine;
			}
			catch (Exception e)
			{
				txtDebug.Text += e.ToString();
			}
		}

		private void debugProgram(string prog)
		{
			txtDebug.Clear();

			try
			{
				prog = prog.Replace(@"''", "\"");

				BefunGen.AST.Program e = parseProgram(prog);
				txtDebug.Text += "[PROGRAM] " + e.Identifier + Environment.NewLine;
				CodePiece pc = e.generateCode();
				txtDebug.Text += pc.ToString() + Environment.NewLine;
			}
			catch (Exception e)
			{
				txtDebug.Text += e.ToString();
			}
		}

		private void btnExecuteDebug_Click(object sender, EventArgs earg)
		{
			debugProgram(@"
program example
	begin
		a();
	end

	void a()
	var
		int i;
	begin
		FOR(i = (int)'A'; i <= (int)'Z'; i++) DO
			OUT (char)i;
		END
	end
end
			");

			txtDebug.Text += CodePieceStore.ModuloRangeLimiter(131, false).ToString();
		}

		private void btnDebugNumberRep_Click(object sender, EventArgs e)
		{
			string bench = NumberCodeHelper.generateBenchmark(Convert.ToInt32(edNumberRep.Value), true);

			txtDebug.Text = bench;
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			try
			{
				string code = txtCode.Text;

				string path = Path.Combine(Application.StartupPath, "code_tmp.tfd");

				File.WriteAllText(path, code);

				//-----

				ProcessStartInfo start = new ProcessStartInfo();

				start.Arguments = String.Format("-file=\"{0}\" -debug", path);
				start.FileName = Path.Combine(Application.StartupPath, "BefunExec.exe");

				Process.Start(start);
			}
			catch (Exception ex)
			{
				txtCode.Text = ex.ToString();
			}
		}

		private void btnGen_Click(object sender, EventArgs e)
		{
			try
			{
				BefunGen.AST.Program p = GParser.generateAST(txtSource.Document.Text);

				try
				{
					txtCode.Text = p.generateCode().ToString();
				}
				catch (Exception ex)
				{
					txtCode.Text = ex.ToString();
				}

			}
			catch (Exception e2)
			{
				txtCode.Text = e2.ToString();
			}
		}

		private void btnSendToRun_Click(object sender, EventArgs e)
		{
			string txt = txtDebug.Text;

			int start = txt.IndexOf('{');
			int end = txt.LastIndexOf('}');

			if (end > start && end >= 0 && start >= 0)
			{
				txtCode.Text = txtDebug.Text;
				txtCode.Select(0, 0);

				tabControl1.SelectedIndex = 5;
			}
		}

		private void btnQCircle_Click(object sender, EventArgs e)
		{
			const int CSIZE = 4 * 4 * 4 * 4;

			CodePiece p = new CodePiece();
			p.Fill(0, 0, CSIZE, CSIZE, BCHelper.Walkway);

			for (int x = 0; x < CSIZE; x++)
			{
				for (int y = 0; y < CSIZE; y++)
				{
					if (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) < (CSIZE - 0.5))
					{
						p.replaceWalkway(CSIZE - 1 - x, CSIZE - 1 - y, BCHelper.chr('#'), false);
					}
				}
			}
			txtDebug.Text = p.ToSimpleString();
		}

		private void btnFocus_Click(object sender, EventArgs e)
		{
			txtDebug.Focus();
			txtDebug.SelectAll();
		}

		private void btnHighlight_Click(object sender, EventArgs e)
		{
			string eh = edHighlightCode.Text;

			int w;
			int h;
			BeGraphCommand[,] cmds = BeGraphHelper.parse(eh, out w, out h);

			BeGraph graph = new BeGraph(w, h);

			graph.Calculate(0, 0, BeGraphDirection.LeftRight, cmds);

			string dh = graph.toDebugString();

			edHighlighted.Text = dh;
			tcHighlight.SelectedIndex = 1;
		}

		private void btnSingleRep_Click(object sender, EventArgs e)
		{
			string bench = String.Join(Environment.NewLine, NumberCodeHelper.generateAllCode(Convert.ToInt64(edSingleRep.Value), true).Select(p => p.Item1 + ":  " + p.Item2.ToSimpleString()).ToList());

			txtDebug.Text = bench;
		}

		private void btnReverse_Click(object sender, EventArgs e)
		{
			if (chkbxReverseAutoDirection.Checked)
				edReverse.Text = edReverse.Text
					.Replace("<", "##REPL_LEFT_##")
					.Replace(">", "<")
					.Replace("##REPL_LEFT_##", ">")
					.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
					.Select(p => string.Join("", p.ToCharArray().Reverse()))
					.Aggregate((a, b) => a + Environment.NewLine + b);
			else
				edReverse.Text = edReverse.Text
					.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
					.Select(p => string.Join("", p.ToCharArray().Reverse()))
					.Aggregate((a, b) => a + Environment.NewLine + b);
		}

		private void edReverse_TextChanged(object sender, EventArgs e)
		{
			if (edReverse.Text.Contains('_'))
			{
				lblReverseValidity.ForeColor = Color.Red;
				lblReverseValidity.Text = "UNKNOWN";
			}
			else
			{
				lblReverseValidity.ForeColor = Color.DarkGreen;
				lblReverseValidity.Text = "OK";
			}
		}

		private void btnSquash_Click(object sender, EventArgs e)
		{
			SquashHelper sh = new SquashHelper(edSquashInput.Text);

			sh.Squash();

			edSquashInput.Text = sh.ToString();

		}

		private void btnCompile_Click(object sender, EventArgs e)
		{
			try
			{
				var comp = new BefunCompiler(memoCompileInput.Text,
					cbOutFormat.Checked,
					cbIgnoreSelfModification.Checked,
					cbSafeStackAccess.Checked,
					cbSafeGridAccess.Checked,
					cbUseGZip.Checked);

				memoCompileOut.Text = comp.GenerateCode((OutputLanguage)cbxCompileLanguage.SelectedItem);
				tabCompileControl.SelectedIndex = 3;
			}
			catch (Exception exc)
			{

				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "ERROR: " + exc.ToString() + Environment.NewLine;
				tabCompileControl.SelectedIndex = 4;
			}
		}

		private BCGraph cbcGraph;

		private void cbxCompileLevel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxCompileLevel.SelectedIndex == 0)
			{
				btnCompileGraph.Text = "Graph [     ]";
			}
			else
			{
				btnCompileGraph.Text = "Graph [ O:" + cbxCompileLevel.SelectedIndex.ToString("X") + " ]";
			}
		}

		private void btnGraph_Compile_Click(object sender, EventArgs e)
		{
			try
			{
				var comp = new BefunCompiler(memoCompileInput.Text,
					cbOutFormat.Checked,
					cbIgnoreSelfModification.Checked,
					cbSafeStackAccess.Checked,
					cbSafeGridAccess.Checked,
					cbUseGZip.Checked);

				switch (cbxCompileLevel.SelectedIndex)
				{
					case 0:
						cbcGraph = comp.GenerateUntouchedGraph();
						break;
					case 1:
						cbcGraph = comp.GenerateMinimizedGraph();
						break;
					case 2:
						cbcGraph = comp.GenerateSubstitutedGraph();
						break;
					case 3:
						cbcGraph = comp.GenerateFlattenedGraph();
						break;
					case 4:
						cbcGraph = comp.GenerateVariablizedGraph();
						break;
					case 5:
						cbcGraph = comp.GenerateBlockCombinedGraph();
						break;
					case 6:
						cbcGraph = comp.GenerateBlockReducedGraph();
						break;
				}

				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "Generate Graph O:" + cbxCompileLevel.SelectedIndex + Environment.NewLine;
				memoCompileLog.Text += "Vertices: " + cbcGraph.Vertices.Count + Environment.NewLine;

				memoCompileLog.Text += "[1] Minimize Cycles: " + comp.log_Cycles_Minimize + Environment.NewLine;
				memoCompileLog.Text += "[2] Substitute Cycles: " + comp.log_Cycles_Substitute + Environment.NewLine;
				memoCompileLog.Text += "[3] Flatten Cycles: " + comp.log_Cycles_Flatten + Environment.NewLine;
				memoCompileLog.Text += "[4] Variablize Cycles: " + comp.log_Cycles_Variablize + Environment.NewLine;
				memoCompileLog.Text += "[5] CombineBlocks Cycles: " + comp.log_Cycles_CombineBlocks + Environment.NewLine;
				memoCompileLog.Text += "[6] ReduceBlocks Cycles: " + comp.log_Cycles_ReduceBlocks + Environment.NewLine;

				var ctrl = (elementHost1.Child as GraphUserControl);
				var model = ctrl.graphLayout.DataContext as MainGraphViewModel;

				model.loadGraph(cbcGraph);
				tabCompileControl.SelectedIndex = 2;
			}
			catch (Exception exc)
			{

				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "ERROR: " + exc + Environment.NewLine;
				tabCompileControl.SelectedIndex = 4;
			}
		}

		private void btnRunCurrGraph_Click(object sender, EventArgs e)
		{
			try
			{
				var runner = new GraphRunner(cbcGraph);

				runner.run();

				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "Run Graph via GraphRunner" + Environment.NewLine;
				memoCompileLog.Text += "Steps:" + runner.Steps + Environment.NewLine;
				memoCompileLog.Text += "Stack: [" + string.Join(", ", runner.Stack.Select(p => p.ToString())) + "]" + Environment.NewLine;
				memoCompileLog.Text += "Output:" + Environment.NewLine + runner.Output + Environment.NewLine;

				tabCompileControl.SelectedIndex = 4;
			}
			catch (Exception exc)
			{

				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "ERROR: " + exc.ToString() + Environment.NewLine;
				tabCompileControl.SelectedIndex = 4;
			}
		}

		private void btnCompileGraphCompile_Click(object sender, EventArgs e)
		{
			try
			{
				var comp = new BefunCompiler(memoCompileInput.Text,
					cbOutFormat.Checked,
					cbIgnoreSelfModification.Checked,
					cbSafeStackAccess.Checked,
					cbSafeGridAccess.Checked,
					cbUseGZip.Checked);

				switch ((OutputLanguage)cbxCompileLanguage.SelectedItem)
				{
					case OutputLanguage.CSharp:
						memoCompileOut.Text = cbcGraph.GenerateCodeCSharp(
							cbOutFormat.Checked,
						cbSafeStackAccess.Checked,
						cbSafeGridAccess.Checked,
					cbUseGZip.Checked);
						break;
					case OutputLanguage.C:
						memoCompileOut.Text = cbcGraph.GenerateCodeC(
							cbOutFormat.Checked,
							cbSafeStackAccess.Checked,
							cbSafeGridAccess.Checked,
							cbUseGZip.Checked);
						break;
					case OutputLanguage.Python:
						memoCompileOut.Text = cbcGraph.GenerateCodePython(
							cbOutFormat.Checked,
							cbSafeStackAccess.Checked,
							cbSafeGridAccess.Checked,
					cbUseGZip.Checked);
						break;
					default:
						break;
				}

				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "Vertices: " + cbcGraph.Vertices.Count + Environment.NewLine;

				var ctrl = (elementHost1.Child as GraphUserControl);
				var model = ctrl.graphLayout.DataContext as MainGraphViewModel;

				model.loadGraph(cbcGraph);
				tabCompileControl.SelectedIndex = 3;
			}
			catch (Exception exc)
			{

				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "ERROR: " + exc.ToString() + Environment.NewLine;
				tabCompileControl.SelectedIndex = 4;
			}
		}

	}
} //Form