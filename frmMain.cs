using BefunCompile;
using BefunCompile.Graph;
using BefunCompile.Math;
using BefunGen.AST;
using BefunGen.AST.CodeGen;
using BefunGen.AST.CodeGen.NumberCode;
using BefunHighlight;
using BefunRep;
using BefunRep.FileHandling;
using BefunRep.OutputHandling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using BefunCompile.Graph.Vertex;

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

			tabBefunGenControl.SelectedIndex = 0;
			tabCompileControl.SelectedIndex = 0;
			tabMainControl.SelectedIndex = 0;
			tabCompileOuterControl.SelectedIndex = 0;

			foreach (var lang in (OutputLanguage[])Enum.GetValues(typeof(OutputLanguage)))
			{
				cbxCompileLanguage.Items.Add(lang);
			}

			for (int i = 0; i < BefunCompileTester.TestData.GetLength(0); i++)
			{
				cbxCompileData.Items.Add(BefunCompileTester.TestData[i, 0]);
			}

			foreach (var item in (new BefunCompiler("", false, false, false, false, false)).GENERATION_LEVELS)
			{
				cbxCompileLevel.Items.Add(item.ToString());
			}

			foreach (var piece in CodePieceStore.CODEPIECES)
			{
				cbxCodePieceStore.Items.Add(piece.Name);
			}

			cbxCodePieceStore.SelectedIndex = 0;
			cbxCompileLanguage.SelectedIndex = 0;
			cbxCompileLevel.SelectedIndex = cbxCompileLevel.Items.Count - 1;
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

				tabBefunGenControl.SelectedIndex = 5;
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
			string bench = String.Join(
				Environment.NewLine,
				NumberCodeHelper
					.generateAllCode(Convert.ToInt64(edSingleRep.Value), true)
					.Select(p => p.Item1 + ":  " + p.Item2.ToSimpleString())
					.ToList());

			txtDebug.Text = bench;
		}

		private void btnReverse_Click(object sender, EventArgs e)
		{
			if (chkbxReverseAutoDirection.Checked)
				edReverseOut.Text = edReverseIn.Text
					.Replace("<", "##REPL_LEFT_##")
					.Replace(">", "<")
					.Replace("##REPL_LEFT_##", ">")
					.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
					.Select(p => string.Join("", p.ToCharArray().Reverse()))
					.Aggregate((a, b) => a + Environment.NewLine + b);
			else
				edReverseOut.Text = edReverseIn.Text
					.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
					.Select(p => string.Join("", p.ToCharArray().Reverse()))
					.Aggregate((a, b) => a + Environment.NewLine + b);
		}

		private void edReverse_TextChanged(object sender, EventArgs e)
		{
			if (edReverseIn.Text.Contains('_'))
			{
				lblReverseValidity.ForeColor = Color.Red;
				lblReverseValidity.Text = "UNKNOWN";

				edReverseOut.Text = string.Empty;
			}
			else
			{
				lblReverseValidity.ForeColor = Color.DarkGreen;
				lblReverseValidity.Text = "OK";

				btnReverse_Click(null, null);
			}
		}

		private void btnSquash_Click(object sender, EventArgs e)
		{
			SquashHelper sh = new SquashHelper(edSquashInputIn.Text);

			sh.Squash();

			edSquashInputOut.Text = sh.ToString();

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


		private void btnCompileExecute_Click(object sender, EventArgs e)
		{
			try
			{
				var comp = new BefunCompiler(memoCompileInput.Text,
					cbOutFormat.Checked,
					cbIgnoreSelfModification.Checked,
					cbSafeStackAccess.Checked,
					cbSafeGridAccess.Checked,
					cbUseGZip.Checked);

				var cbcGraph = comp.GENERATION_LEVELS[cbxCompileLevel.SelectedIndex].Run();
				var cbcCodeGCC = cbcGraph.GenerateCodeC(cbOutFormat.Checked, cbSafeStackAccess.Checked, cbSafeGridAccess.Checked, cbUseGZip.Checked);
				var cbcCodeCSC = cbcGraph.GenerateCodeCSharp(cbOutFormat.Checked, cbSafeStackAccess.Checked, cbSafeGridAccess.Checked, cbUseGZip.Checked);

				var tester = new BefunCompileTester();

				var output_GCC = tester.ExecuteGCC(cbcCodeGCC);
				var output_CSC = tester.ExecuteCSC(cbcCodeCSC);

				memoCompileLog.Text += Environment.NewLine + "[Execute GCC]" + output_GCC + Environment.NewLine + "[Execute CSC]" + output_CSC;
				tabCompileControl.SelectedIndex = 4;
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
			if (cbxCompileLevel.SelectedIndex < 0)
			{
				btnCompileGraph.Text = "Graph     [ --- ]";
				btnCompileExecute.Text = "Execute   [ --- ]";
				btnCompileCompile.Text = "Compile   [ --- ]";
			}
			else if (cbxCompileLevel.SelectedIndex == 0)
			{
				btnCompileGraph.Text = "Graph     [     ]";
				btnCompileExecute.Text = "Execute   [     ]";
				btnCompileCompile.Text = "Compile   [     ]";
			}
			else
			{
				btnCompileGraph.Text = "Graph     [ O:" + cbxCompileLevel.SelectedIndex.ToString("X") + " ]";
				btnCompileExecute.Text = "Execute   [ O:" + cbxCompileLevel.SelectedIndex.ToString("X") + " ]";
				btnCompileCompile.Text = "Compile   [ O:" + cbxCompileLevel.SelectedIndex.ToString("X") + " ]";
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

				cbcGraph = comp.GENERATION_LEVELS[cbxCompileLevel.SelectedIndex].Run();

				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "Generate Graph O:" + cbxCompileLevel.SelectedIndex + Environment.NewLine;
				memoCompileLog.Text += "Vertices: " + cbcGraph.Vertices.Count + Environment.NewLine;

				foreach (var item in comp.GENERATION_LEVELS)
				{
					int cycles = comp.log_Cycles[item.Level];
					memoCompileLog.Text += "[" + item.Level + "] " + item.Name + " Cycles: " + cycles + Environment.NewLine;
				}

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

		private void btnCompileTest_Click(object sender, EventArgs e)
		{
			BefunCompileTester bct = new BefunCompileTester();

			tabCompileControl.SelectedIndex = 4;

			bct.Test(ref memoCompileLog);

			edBefunCompileConsole.Text = bct.Output.ToString();
		}

		private void cbxCompileData_SelectedIndexChanged(object sender, EventArgs e)
		{
			memoCompileInput.Text = BefunCompileTester.TestData[cbxCompileData.SelectedIndex, 1];
			tabCompileControl.SelectedIndex = 0;
		}

		private void btnCodePieceStorePreview_Click(object sender, EventArgs e)
		{
			var code = CodePieceStore.CODEPIECES[cbxCodePieceStore.SelectedIndex].Function();

			txtCode.Text = code.ToSimpleString();
		}

		private void btnCompileCompile_Click(object sender, EventArgs e)
		{
			try
			{
				var comp = new BefunCompiler(memoCompileInput.Text,
					cbOutFormat.Checked,
					cbIgnoreSelfModification.Checked,
					cbSafeStackAccess.Checked,
					cbSafeGridAccess.Checked,
					cbUseGZip.Checked);

				var craph = comp.GENERATION_LEVELS[cbxCompileLevel.SelectedIndex].Run();
				string code = string.Empty;

				switch ((OutputLanguage)cbxCompileLanguage.SelectedItem)
				{
					case OutputLanguage.CSharp:
						code = craph.GenerateCodeCSharp(cbOutFormat.Checked, cbSafeStackAccess.Checked, cbSafeGridAccess.Checked, cbUseGZip.Checked);
						break;
					case OutputLanguage.C:
						code = craph.GenerateCodeC(cbOutFormat.Checked, cbSafeStackAccess.Checked, cbSafeGridAccess.Checked, cbUseGZip.Checked);
						break;
					case OutputLanguage.Python:
						code = craph.GenerateCodePython(cbOutFormat.Checked, cbSafeStackAccess.Checked, cbSafeGridAccess.Checked, cbUseGZip.Checked);
						break;
				}

				memoCompileOut.Text = code;
				tabCompileControl.SelectedIndex = 3;
			}
			catch (Exception exc)
			{

				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "ERROR: " + exc.ToString() + Environment.NewLine;
				tabCompileControl.SelectedIndex = 4;
			}
		}

		private void btnMSZipCompressSingle_Click(object sender, EventArgs e)
		{
			var zip = new MSZipImplementation();

			var input = Encoding.ASCII.GetBytes(memoCodeCompressionInput.Text).ToList();

			List<uint> result = new List<uint>();
			zip.CompressSingle(result, input.Select(p => (uint)p).ToList(), 0, input.Count());
			var output = zip.Escape(result);

			memoCodeCompressionLog.Text += Environment.NewLine;

			memoCodeCompressionLog.Text += String.Format("Compressed from {0} to {1} ({2:0.#}%)", input.Count(), output.Count(), (output.Count() * 100.0) / input.Count()) + Environment.NewLine;

			memoCodeCompressionOutput.Text = string.Join("", output.Select(p => (char)p));
		}

		private void btnMSZipDecompressSingle_Click(object sender, EventArgs e)
		{
			var zip = new MSZipImplementation();

			var input = Encoding.ASCII.GetBytes(memoCodeCompressionOutput.Text).ToList();
			var output = zip.Decompress(input, 50000);

			memoCodeCompressionLog.Text += Environment.NewLine;

			memoCodeCompressionLog.Text += String.Format("Decompressed from {0} to {1} ({2:0.#}%)", input.Count(), output.Count(), (input.Count() * 100.0) / output.Count()) + Environment.NewLine;

			memoCodeCompressionInput.Text = string.Join("", output.Select(p => (char)p));
		}

		private void btnMSZipCompressMulti_Click(object sender, EventArgs e)
		{
			var zip = new MSZipImplementation();

			var input = Encoding.ASCII.GetBytes(memoCodeCompressionInput.Text).ToList();
			var it = 0;

			var output = zip.Compress(input, ref it);

			memoCodeCompressionLog.Text += Environment.NewLine;

			memoCodeCompressionLog.Text += String.Format("Compressed from {0} to {1} ({2:0.#}%)", input.Count(), output.Count(), (output.Count() * 100.0) / input.Count()) + Environment.NewLine;
			memoCodeCompressionLog.Text += "in " + it + " Recursions" + Environment.NewLine;

			memoCodeCompressionOutput.Text = string.Join("", output.Select(p => (char)p));
		}

		private void btnMSZipDecompressMulti_Click(object sender, EventArgs e)
		{
			var zip = new MSZipImplementation();

			var input = Encoding.ASCII.GetBytes(memoCodeCompressionOutput.Text).ToList();
			var output = zip.Decompress(input, 50000);

			memoCodeCompressionLog.Text += Environment.NewLine;

			memoCodeCompressionLog.Text += String.Format("Decompressed from {0} to {1} ({2:0.#}%)", input.Count(), output.Count(), (input.Count() * 100.0) / output.Count()) + Environment.NewLine;

			memoCodeCompressionInput.Text = string.Join("", output.Select(p => (char)p));
		}

		private void btnGZipCompress_Click(object sender, EventArgs e)
		{
			var zip = new GZipImplementation();

			var input = Encoding.ASCII.GetBytes(memoCodeCompressionInput.Text).ToList();
			var it = 0;

			var output = Convert.ToBase64String(zip.Compress(input, ref it).ToArray());

			memoCodeCompressionLog.Text += Environment.NewLine;

			memoCodeCompressionLog.Text += String.Format("Compressed from {0} to {1} ({2:0.#}%)", input.Count(), output.Length, (output.Length * 100.0) / input.Count()) + Environment.NewLine;
			memoCodeCompressionLog.Text += "in " + it + " Recursions" + Environment.NewLine;

			memoCodeCompressionOutput.Text = output;
		}

		private void btnGZipDecompress_Click(object sender, EventArgs e)
		{
			var zip = new GZipImplementation();

			var input = Convert.FromBase64String(memoCodeCompressionOutput.Text).ToList();
			var output = zip.Decompress(input, 50000);

			memoCodeCompressionLog.Text += Environment.NewLine;

			memoCodeCompressionLog.Text += String.Format("Decompressed from {0} to {1} ({2:0.#}%)", memoCodeCompressionOutput.Text.Length, output.Count(), (memoCodeCompressionOutput.Text.Length * 100.0) / output.Count()) + Environment.NewLine;

			memoCodeCompressionInput.Text = string.Join("", output.Select(p => (char)p));
		}

		private void btnGZipCompressToList_Click(object sender, EventArgs e)
		{
			var zip = new GZipImplementation();

			memoCodeCompressionOutput.Text = zip.GenerateBase64StringList(memoCodeCompressionInput.Text).Aggregate((a, b) => a + Environment.NewLine + Environment.NewLine + b);
		}

		private void btnGZipCompressToHex_Click(object sender, EventArgs e)
		{
			var zip = new GZipImplementation();

			memoCodeCompressionOutput.Text = zip.CompressToHex(memoCodeCompressionInput.Text);
		}

		private void btnCompressBenchmark_Click(object sender, EventArgs e)
		{
			Stopwatch sw = new Stopwatch();


			memoCodeCompressionInput.Text = "MSZip:" + Environment.NewLine;
			memoCodeCompressionInput.Text += Environment.NewLine;
			memoCodeCompressionInput.Text += "Data       | Compression (%) | Initial     | Final       | Recursions | Time (ms)" + Environment.NewLine;

			var mszip = new MSZipImplementation();
			for (int i = 0; i < BefunCompileTester.TestData.GetLength(0); i++)
			{
				var name = BefunCompileTester.TestData[i, 0];
				var data = BefunCompileTester.TestData[i, 1];
				int reccount = 0;

				sw.Restart();
				var comp = mszip.CompressToString(data, ref reccount);
				sw.Stop();

				var str = string.Format("{0,-10} | {1,-15:#,0} | {2,-11:#,0} | {3,-11:#,0} | {4,-10} | {5,-9:#,0}", 
					name, 
					(int)(data.Length * 100.0 / comp.Length), 
					data.Length,
					comp.Length,
					reccount,
					sw.ElapsedMilliseconds);

				memoCodeCompressionInput.Text += str + Environment.NewLine;
			}

			memoCodeCompressionOutput.Text = "GZip:" + Environment.NewLine;
			memoCodeCompressionOutput.Text += Environment.NewLine;
			memoCodeCompressionOutput.Text += "Data       | Compression (%) | Initial     | Final       | Recursions | Time (ms)" + Environment.NewLine;

			var gzip = new GZipImplementation();
			for (int i = 0; i < BefunCompileTester.TestData.GetLength(0); i++)
			{
				var name = BefunCompileTester.TestData[i, 0];
				var data = BefunCompileTester.TestData[i, 1];
				int reccount = 0;

				sw.Restart();
				var comp = gzip.CompressToString(data);
				sw.Stop();
				
				var str = string.Format("{0,-10} | {1,-15:#,0} | {2,-11:#,0} | {3,-11:#,0} | {4,-10} | {5,-9:#,0}", 
					name, 
					(int)(data.Length * 100.0 / comp.Length), 
					data.Length,
					comp.Length,
					reccount,
					sw.ElapsedMilliseconds);

				memoCodeCompressionOutput.Text += str + Environment.NewLine;
			}
		}

		private void btnSingleBefunRepRep_Click(object sender, EventArgs e)
		{
			long number = Convert.ToInt64(edSingleBefunRepRep.Value);

			RepresentationSafe safe = new MemorySafe();

			RepCalculator c1 = new RepCalculator(0, 4069, false, safe, true);
			c1.calculate();

			RepCalculator c2 = new RepCalculator(number - 64, number + 64, false, safe, true);
			c2.calculate();

			string result = safe.get(number);

			if (result == null)
				txtDebug.Text = "ERROR";
			else
			{
				var algorithm = RepCalculator.algorithmNames[safe.getAlgorithm(number).Value];

				txtDebug.Text = algorithm + "         " + result;
			}
		}

		private void btnBenchBefunRepCSV_Click(object sender, EventArgs e)
		{
			long number = Convert.ToInt64(edBenchBefunRep.Value);

			RepresentationSafe safe = new MemorySafe();
			OutputFormatter fmt = new CSVOutputFormatter();

			RepCalculator c1 = new RepCalculator(0, number, false, safe, true);
			c1.calculate();

			txtDebug.Text = fmt.Convert(safe, 0, number);
		}

		private void btnBenchBefunRepXML_Click(object sender, EventArgs e)
		{
			long number = Convert.ToInt64(edBenchBefunRep.Value);

			RepresentationSafe safe = new MemorySafe();
			OutputFormatter fmt = new XMLOutputFormatter();

			RepCalculator c1 = new RepCalculator(0, number, false, safe, true);
			c1.calculate();

			txtDebug.Text = fmt.Convert(safe, 0, number);
		}

		private void btnBenchBefunRepJSON_Click(object sender, EventArgs e)
		{
			long number = Convert.ToInt64(edBenchBefunRep.Value);

			RepresentationSafe safe = new MemorySafe();
			OutputFormatter fmt = new JSONOutputFormatter();

			RepCalculator c1 = new RepCalculator(0, number, false, safe, true);
			c1.calculate();

			txtDebug.Text = fmt.Convert(safe, 0, number);
		}

		private void btnRunCodeCompressionTests_Click(object sender, EventArgs e)
		{
			var mszip = new MSZipImplementation();
			var result_mszip = Enumerable.Range(0, BefunCompileTester.TestData.GetLength(0))
				.Select(p => new { Name = BefunCompileTester.TestData[p, 0], Data = BefunCompileTester.TestData[p, 1], Compressed = mszip.CompressToString(BefunCompileTester.TestData[p, 1]) })
				.Select(p => new { Name = p.Name, Data = p.Data, Compressed = p.Compressed, Decompressed = mszip.DecompressToString(p.Compressed, p.Data.Length * 2) })
				.Select(p => new { Name = p.Name, Data = p.Data, Compressed = p.Compressed, Decompressed = p.Decompressed, Success = p.Data == p.Decompressed })
				.ToList();

			memoCodeCompressionInput.Text = "MSZip:" + Environment.NewLine;
			memoCodeCompressionInput.Text += Environment.NewLine;
			memoCodeCompressionInput.Text += "Sucessrate:" + result_mszip.Count(p => p.Success) + "/" + result_mszip.Count();
			memoCodeCompressionInput.Text += Environment.NewLine;
			memoCodeCompressionInput.Text += string.Join(Environment.NewLine, result_mszip.Where(p => !p.Success).Select(p => p.Name + " (" + p.Data.Length + " vs " + p.Decompressed.Length + ")"));

			var gzip = new MSZipImplementation();
			var result_gzip = Enumerable.Range(0, BefunCompileTester.TestData.GetLength(0))
				.Select(p => new { Name = BefunCompileTester.TestData[p, 0], Data = BefunCompileTester.TestData[p, 1], Compressed = gzip.CompressToString(BefunCompileTester.TestData[p, 1]) })
				.Select(p => new { Name = p.Name, Data = p.Data, Compressed = p.Compressed, Decompressed = gzip.DecompressToString(p.Compressed, p.Data.Length * 2) })
				.Select(p => new { Name = p.Name, Data = p.Data, Compressed = p.Compressed, Decompressed = p.Decompressed, Success = p.Data == p.Decompressed })
				.ToList();

			memoCodeCompressionOutput.Text = "GZip:" + Environment.NewLine;
			memoCodeCompressionOutput.Text += Environment.NewLine;
			memoCodeCompressionOutput.Text += "Sucessrate:" + result_gzip.Count(p => p.Success) + "/" + result_gzip.Count();
			memoCodeCompressionOutput.Text += Environment.NewLine;
			memoCodeCompressionOutput.Text += string.Join(Environment.NewLine, result_gzip.Where(p => !p.Success).Select(p => p.Name + " (" + p.Data.Length + " vs " + p.Decompressed.Length + ")"));
		}

		private void btnGenOverview_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();

			string row = "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-15} | {5,-15} | {6,-10} | {7,-10} | {8,-10} | {9,-10} | {10,-10} | {11,-25}";

			string header = string.Format(row, "Name", "Vertices", "NOPs", "Leafs", "const IO Acc", "dyn. IO Acc", "userVar", "systemVar", "Stack Acc", "Var Acc", "Size", "Cycles");

			sb.AppendLine(header);
			sb.AppendLine(new String('-', header.Length));

			for (int i = 0; i < BefunCompileTester.TestData.GetLength(0); i++)
			{
				var compiler = new BefunCompiler(BefunCompileTester.TestData[i, 1],
					cbOutFormat.Checked,
					cbIgnoreSelfModification.Checked,
					cbSafeStackAccess.Checked,
					cbSafeGridAccess.Checked,
					cbUseGZip.Checked);
				var graph = compiler.GenerateGraph();

				var cell_Name = BefunCompileTester.TestData[i, 0];
				var cell_Vertices = graph.Vertices.Count;
				var cell_Nops = graph.Vertices.Count(p => p is BCVertexNOP);
				var cell_Leafs = graph.Vertices.Count(p => p.Children.Count == 0);
				var cell_cIOAcc = graph.ListConstantVariableAccess().Count();
				var cell_dIOAcc = graph.ListDynamicVariableAccess().Count();
				var cell_uservar = graph.Variables.Count(p => p.isUserDefinied);
				var cell_sysvar = graph.Variables.Count(p => !p.isUserDefinied);
				var cell_stackAcc = graph.Vertices.Count(p => !p.IsNotStackAccess());
				var cell_varAcc = graph.Vertices.Count(p => !p.IsNotVariableAccess());
				var cell_size = graph.GetAllCodePositions().Count;
				var cell_cycles = string.Join("-", compiler.log_Cycles.Select(p => string.Format("{0:00}", p)));

				sb.AppendLine(string.Format(row, 
					cell_Name, cell_Vertices, cell_Nops, cell_Leafs, cell_cIOAcc, cell_dIOAcc, 
					cell_uservar, cell_sysvar, cell_stackAcc, cell_varAcc, cell_size, cell_cycles));
			}

			memoCompileOut.Text = sb.ToString();
			tabCompileControl.SelectedIndex = 3;

		}

	}
}