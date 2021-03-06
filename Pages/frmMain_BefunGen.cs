﻿using BefunDebug.Helper;
using BefunGen.AST;
using BefunGen.AST.CodeGen;
using BefunGen.AST.DirectRun;
using BefunGen.AST.Exceptions;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BefunDebug.Pages
{
	public partial class frmMain_BefunGen: UserControl
	{
		private DemoParser MyParser = new DemoParser();
		private TextFungeParser GParser = new TextFungeParser();

		private bool loaded = false;

		private string currentSC = "";
		private Thread parseThread;
		bool threadRunning = true;

		public frmMain_BefunGen()
		{
			InitializeComponent();

			tabBefunGenControl.SelectedIndex = 0;

			foreach (var piece in CodePieceStore.CODEPIECES)
			{
				cbxCodePieceStore.Items.Add(piece.Name);
			}

			cbxCodePieceStore.SelectedIndex = 0;
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
				if (MyParser.Setup(new BinaryReader(new MemoryStream(GParser.GetGrammar()))))
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

		private void frm_Load(object sender, EventArgs e)
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
					BefunGen.AST.Program p = GParser.GenerateAst(txt);

					log += (string.Format("AST-Gen: {0}ms\r\n", MyParser.Time));

					long gdst = Environment.TickCount;
					string debug = p.GetDebugString().Replace("\n", Environment.NewLine);
					gdst = Environment.TickCount - gdst;

					asttree = debug;

					log += (string.Format("AST-DebugOut: {0}ms\r\n", gdst));
				}
				catch (Exception e)
				{
					asttree = e.ToString();
				}

				grammar = GParser.GetGrammarDefinition();
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

		public void frm_Closing(object sender, FormClosingEventArgs e)
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

			BefunGen.AST.Program p = GParser.GenerateAst(txt);


			return ((ExpressionCast)((StatementAssignment)((StatementStatementList)p.MainMethod.Body).List[0]).Expr).Expr;
		}

		private Statement parseStatement(string stmt)
		{
			string txt = String.Format("program b var  bool a; begin {0} end end", stmt);
			BefunGen.AST.Program p = GParser.GenerateAst(txt);


			return ((StatementStatementList)p.MainMethod.Body).List[0];
		}

		private Method parseMethod(string meth)
		{
			string txt = String.Format("program b begin end {0} end", meth);
			BefunGen.AST.Program p = GParser.GenerateAst(txt);

			return p.MethodList[1];
		}

		private BefunGen.AST.Program parseProgram(string prog)
		{
			BefunGen.AST.Program p = GParser.GenerateAst(prog);

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
				CodePiece pc = e.GenerateCode(CodeGenEnvironment.CreateDummy(), false);
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
				CodePiece pc = e.GenerateCode(CodeGenEnvironment.CreateDummy(), false);
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
				CodePiece pc = e.GenerateCode(CodeGenEnvironment.CreateDummy(), 0, 0);
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
				CodePiece pc = e.GenerateCode();
				txtDebug.Text += pc.ToString() + Environment.NewLine;
			}
			catch (Exception e)
			{
				txtDebug.Text += e.ToString();
			}
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			try
			{
				string code = txtCode.Text;

				string path = Path.Combine(Application.StartupPath, "code_tmp.tfd");

				File.WriteAllText(path, code, Encoding.UTF8);

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

		private void btnRun2_Click(object sender, EventArgs e)
		{
			try
			{
				BefunGen.AST.Program p = GParser.GenerateAst(txtSource.Document.Text);
				txtCode.Text = p.GenerateCode().ToSimpleString();

				string code = txtCode.Text.Replace('¤', 'A');
				string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".b93");
				File.WriteAllText(path, code, Encoding.ASCII);

				var result = ProcessHelper.ProcExecute("BefunRun", $"\"{path}\" --errorlevel=3 --limit={5*1000*1000}");

				File.Delete(path);

				tbCodeOut.Text = (result.StdOut + "\r\n" + result.StdErr).Trim();
			}
			catch (Exception e2)
			{
				tbCodeOut.Text = e2.ToString();
			}

		}

		private void btnGen_Click(object sender, EventArgs e)
		{
			try
			{
				BefunGen.AST.Program p = GParser.GenerateAst(txtSource.Document.Text);

				try
				{
					txtCode.Text = p.GenerateCode().ToString();
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

		private void btnCodePieceStorePreview_Click(object sender, EventArgs e)
		{
			var code = CodePieceStore.CODEPIECES[cbxCodePieceStore.SelectedIndex].Function(cbCodePieceStoreReverse.Checked);

			txtCode.Text = code.ToSimpleString();
		}

		private void btnGenExpr_Click(object sender, EventArgs e)
		{
			debugExpression(txtDebugIn.Text);
		}

		private void btnGenStmt_Click(object sender, EventArgs e)
		{
			debugStatement(txtDebugIn.Text);
		}

		private void btnGenSub_Click(object sender, EventArgs e)
		{
			debugMethod(txtDebugIn.Text);
		}

		private void btnGenProg_Click(object sender, EventArgs e)
		{
			debugProgram(txtDebugIn.Text);
		}

		private void btnDirectRun_Click(object sender, EventArgs e)
		{
			edDirectRun.Text = "";

			try
			{
				string inputCode = txtSource.Document.Text;

				var prog = GParser.GenerateAst(inputCode);
				var env = new RunnerEnvironment();

				prog.RunDirect(env, "");

				edDirectRun.Text = env.Output.ToString();
			}
			catch (BefunGenException ex)
			{
				edDirectRun.Text = "Error while compiling:\n\n" + ex;
			}
			catch (Exception ex)
			{
				edDirectRun.Text = "Internal error:\n\n" + ex;
			}
		}
	}
}
