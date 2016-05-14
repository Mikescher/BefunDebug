using BefunCompile;
using BefunCompile.CodeGeneration;
using BefunCompile.CodeGeneration.Compiler;
using BefunCompile.CodeGeneration.Generator;
using BefunCompile.Graph;
using BefunCompile.Graph.Vertex;
using BefunCompile.Math;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BefunGen.Pages
{
	public partial class frmMain_BefunCompile : UserControl
	{
		private Dictionary<OutputLanguage, TextBox> OutputTextBoxes = new Dictionary<OutputLanguage, TextBox>();

		private readonly BefunCompileTester tester;

		private bool isConstructed = false;

		public frmMain_BefunCompile()
		{
			InitializeComponent();

			tester = new BefunCompileTester(memoCompileLog, edBefunCompileConsole, btnCompileTest);

			tabCompileControl.SelectedIndex = 0;
			tabCompileOuterControl.SelectedIndex = 0;
			
			foreach (var lang in (OutputLanguage[])Enum.GetValues(typeof(OutputLanguage)))
			{
				int idx = listBoxOutputLanguages.Items.Add(lang);
				listBoxOutputLanguages.SetItemCheckState(idx, CheckState.Checked);

				var page = new TabPage(lang.ToString());
				var textbox = new TextBox
				{
					Dock = DockStyle.Fill,
					Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0),
					MaxLength = 2147483647,
					Multiline = true,
					Name = "memoCompileOut",
					ScrollBars = ScrollBars.Vertical,
					Size = new System.Drawing.Size(616, 530),
					TabIndex = 0,
					WordWrap = false
				};
				textbox.KeyDown += GenericTextBoxKeyDown;
				page.Controls.Add(textbox);
				tabControlOutput.TabPages.Add(page);

				OutputTextBoxes[lang] = textbox;
			}

			for (int i = 0; i < BefunCompileTester.TestData.GetLength(0); i++)
			{
				cbxCompileData.Items.Add(BefunCompileTester.TestData[i, 0]);
			}

			foreach (var item in (new BefunCompiler("", false, false, false, false, false)).GENERATION_LEVELS)
			{
				cbxCompileLevel.Items.Add(item.ToString());
			}
			
			cbxCompileLevel.SelectedIndex = cbxCompileLevel.Items.Count - 1;

			LoadOptions();

			isConstructed = true;
		}

		private IEnumerable<OutputLanguage> GetCheckedLanguages()
		{
			foreach (var lang in (OutputLanguage[])Enum.GetValues(typeof(OutputLanguage)))
			{
				int idx = listBoxOutputLanguages.Items.IndexOf(lang);
				if (listBoxOutputLanguages.GetItemCheckState(idx) != CheckState.Checked) continue;

				yield return lang;
			}
		}

		private void frm_Load(object sender, EventArgs e)
		{
			memoCompileInput.Text = Properties.Resources.example_compile;
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

				foreach (var lang in (OutputLanguage[]) Enum.GetValues(typeof (OutputLanguage)))
				{
					OutputTextBoxes[lang].Text = comp.GenerateCode(lang);
				}

				tabCompileControl.SelectedIndex = 3;
			}
			catch (Exception exc)
			{

				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "ERROR: " + exc + Environment.NewLine;
				tabCompileControl.SelectedIndex = 4;
			}
		}

		private void btnCompileExecute_Click(object sender, EventArgs e)
		{
			try
			{
				var console = new StringBuilder();

				var comp = new BefunCompiler(memoCompileInput.Text,
					cbOutFormat.Checked,
					cbIgnoreSelfModification.Checked,
					cbSafeStackAccess.Checked,
					cbSafeGridAccess.Checked,
					cbUseGZip.Checked);

				var graph = comp.GENERATION_LEVELS[cbxCompileLevel.SelectedIndex].Run();

				foreach (var lang in GetCheckedLanguages())
				{
					try
					{
						var code = CodeGenerator.GenerateCode(lang, graph, cbOutFormat.Checked, cbSafeStackAccess.Checked, cbSafeGridAccess.Checked, cbUseGZip.Checked);

						var output = CodeCompiler.ExecuteCode(lang, code, console);

						memoCompileLog.Text += string.Format("[Execute {0}]\r\n{1}\r\n\r\n", CodeCompiler.GetAcronym(lang), output.TrimEnd('\r', '\n'));

					}
					catch (Exception exc)
					{
						memoCompileLog.Text += string.Format("[Execute {0}]\r\nERROR: {1}\r\n\r\n", CodeCompiler.GetAcronym(lang), exc);
						tabCompileControl.SelectedIndex = 4;
					}

					memoCompileLog.Refresh();
				}
				
				edBefunCompileConsole.Text = console.ToString();

				tabCompileControl.SelectedIndex = 4;
			}
			catch (Exception exc)
			{
				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "ERROR: " + exc + Environment.NewLine;
				tabCompileControl.SelectedIndex = 4;
			}
		}

		private BCGraph cbcGraph;

		private void cbxCompileLevel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxCompileLevel.SelectedIndex < 0)
			{
				btnCompileGraph.Text   = "Graph     [ --- ]";
				btnCompileExecute.Text = "Execute   [ --- ]";
				btnCompileCompile.Text = "Compile   [ --- ]";
			}
			else if (cbxCompileLevel.SelectedIndex == 0)
			{
				btnCompileGraph.Text   = "Graph     [     ]";
				btnCompileExecute.Text = "Execute   [     ]";
				btnCompileCompile.Text = "Compile   [     ]";
			}
			else
			{
				btnCompileGraph.Text   = "Graph     [ O:" + cbxCompileLevel.SelectedIndex.ToString("X") + " ]";
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
					int cycles = comp.LogCycles[item.Level];
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
				memoCompileLog.Text += "ERROR: " + exc + Environment.NewLine;
				tabCompileControl.SelectedIndex = 4;
			}
		}

		private void btnCompileGraphCompile_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (var lang in (OutputLanguage[])Enum.GetValues(typeof(OutputLanguage)))
				{
					OutputTextBoxes[lang].Text = CodeGenerator.GenerateCode(
					lang,
					cbcGraph,
					cbOutFormat.Checked,
					cbSafeStackAccess.Checked,
					cbSafeGridAccess.Checked,
					cbUseGZip.Checked);
				}

				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "Vertices: " + cbcGraph.Vertices.Count + Environment.NewLine;

				var ctrl = (GraphUserControl)elementHost1.Child;
				var model = (MainGraphViewModel)ctrl.graphLayout.DataContext;

				model.loadGraph(cbcGraph);
				tabCompileControl.SelectedIndex = 3;
			}
			catch (Exception exc)
			{
				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "ERROR: " + exc + Environment.NewLine;
				tabCompileControl.SelectedIndex = 4;
			}
		}

		private void btnCompileTest_Click(object sender, EventArgs e)
		{
			tabCompileControl.SelectedIndex = 4;

			tester.TriggerAction(GetCheckedLanguages().ToList());
		}

		private void cbxCompileData_SelectedIndexChanged(object sender, EventArgs e)
		{
			memoCompileInput.Text = BefunCompileTester.TestData[cbxCompileData.SelectedIndex, 1];
			tabCompileControl.SelectedIndex = 0;
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


				foreach (var lang in (OutputLanguage[])Enum.GetValues(typeof(OutputLanguage)))
				{
					string code = CodeGenerator.GenerateCode(
						lang,
						craph,
						cbOutFormat.Checked,
						cbSafeStackAccess.Checked,
						cbSafeGridAccess.Checked,
						cbUseGZip.Checked);

					OutputTextBoxes[lang].Text = code;
				}

				tabCompileControl.SelectedIndex = 3;
			}
			catch (Exception exc)
			{
				memoCompileLog.Text += Environment.NewLine;
				memoCompileLog.Text += "ERROR: " + exc + Environment.NewLine;
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

			memoCodeCompressionLog.Text += string.Format("Compressed from {0} to {1} ({2:0.#}%)", input.Count(), output.Count(), (output.Count() * 100.0) / input.Count()) + Environment.NewLine;

			memoCodeCompressionOutput.Text = string.Join("", output.Select(p => (char)p));
		}

		private void btnMSZipDecompressSingle_Click(object sender, EventArgs e)
		{
			var zip = new MSZipImplementation();

			var input = Encoding.ASCII.GetBytes(memoCodeCompressionOutput.Text).ToList();
			var output = zip.Decompress(input, 50000);

			memoCodeCompressionLog.Text += Environment.NewLine;

			memoCodeCompressionLog.Text += string.Format("Decompressed from {0} to {1} ({2:0.#}%)", input.Count(), output.Count(), (input.Count() * 100.0) / output.Count()) + Environment.NewLine;

			memoCodeCompressionInput.Text = string.Join("", output.Select(p => (char)p));
		}

		private void btnMSZipCompressMulti_Click(object sender, EventArgs e)
		{
			var zip = new MSZipImplementation();

			var input = Encoding.ASCII.GetBytes(memoCodeCompressionInput.Text).ToList();
			var it = 0;

			var output = zip.Compress(input, ref it);

			memoCodeCompressionLog.Text += Environment.NewLine;

			memoCodeCompressionLog.Text += string.Format("Compressed from {0} to {1} ({2:0.#}%)", input.Count(), output.Count(), (output.Count() * 100.0) / input.Count()) + Environment.NewLine;
			memoCodeCompressionLog.Text += "in " + it + " Recursions" + Environment.NewLine;

			memoCodeCompressionOutput.Text = string.Join("", output.Select(p => (char)p));
		}

		private void btnMSZipDecompressMulti_Click(object sender, EventArgs e)
		{
			var zip = new MSZipImplementation();

			var input = Encoding.ASCII.GetBytes(memoCodeCompressionOutput.Text).ToList();
			var output = zip.Decompress(input, 50000);

			memoCodeCompressionLog.Text += Environment.NewLine;

			memoCodeCompressionLog.Text += string.Format("Decompressed from {0} to {1} ({2:0.#}%)", input.Count(), output.Count(), (input.Count() * 100.0) / output.Count()) + Environment.NewLine;

			memoCodeCompressionInput.Text = string.Join("", output.Select(p => (char)p));
		}

		private void btnGZipCompress_Click(object sender, EventArgs e)
		{
			var zip = new GZipImplementation();

			var input = Encoding.ASCII.GetBytes(memoCodeCompressionInput.Text).ToList();
			var it = 0;

			var output = Convert.ToBase64String(zip.Compress(input, ref it).ToArray());

			memoCodeCompressionLog.Text += Environment.NewLine;

			memoCodeCompressionLog.Text += string.Format("Compressed from {0} to {1} ({2:0.#}%)", input.Count(), output.Length, (output.Length * 100.0) / input.Count()) + Environment.NewLine;
			memoCodeCompressionLog.Text += "in " + it + " Recursions" + Environment.NewLine;

			memoCodeCompressionOutput.Text = output;
		}

		private void btnGZipDecompress_Click(object sender, EventArgs e)
		{
			var zip = new GZipImplementation();

			var input = Convert.FromBase64String(memoCodeCompressionOutput.Text).ToList();
			var output = zip.Decompress(input, 50000);

			memoCodeCompressionLog.Text += Environment.NewLine;

			memoCodeCompressionLog.Text += string.Format("Decompressed from {0} to {1} ({2:0.#}%)", memoCodeCompressionOutput.Text.Length, output.Count(), (memoCodeCompressionOutput.Text.Length * 100.0) / output.Count()) + Environment.NewLine;

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
			tabCompileControl.SelectedIndex = 4;

			StringBuilder sb = new StringBuilder();

			string row = "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-15} | {5,-15} | {6,-10} | {7,-10} | {8,-10} | {9,-10} | {10,-10} | {11,-35} | {12,-10}";

			string header = string.Format(row, "Name", "Vertices", "NOPs", "Leafs", "const IO Acc", "dyn. IO Acc", "userVar", "systemVar", "Stack Acc", "Var Acc", "Size", "Cycles", "Time (ms)");

			sb.AppendLine(header);
			sb.AppendLine(new String('-', header.Length));

			for (int i = 0; i < BefunCompileTester.TestData.GetLength(0); i++)
			{
				long sw_time = Environment.TickCount;

				var compiler = new BefunCompiler(BefunCompileTester.TestData[i, 1],
					cbOutFormat.Checked,
					cbIgnoreSelfModification.Checked,
					cbSafeStackAccess.Checked,
					cbSafeGridAccess.Checked,
					cbUseGZip.Checked);
				var graph = compiler.GenerateGraph();

				sw_time = Environment.TickCount - sw_time;

				var cell_Name = BefunCompileTester.TestData[i, 0];
				var cell_Vertices = graph.Vertices.Count;
				var cell_Nops = graph.Vertices.Count(p => p is BCVertexNOP);
				var cell_Leafs = graph.Vertices.Count(p => p.Children.Count == 0);
				var cell_cIOAcc = graph.ListConstantVariableAccess().Count();
				var cell_dIOAcc = graph.ListDynamicVariableAccess().Count();
				var cell_uservar = graph.Variables.Count(p => p.isUserDefinied);
				var cell_sysvar = graph.Variables.Count(p => !p.isUserDefinied);
				var cell_sysscopes = graph.Variables.Where(p => !p.isUserDefinied).Sum(p => p.Scope.Count);
				var cell_systotal = string.Format("{0,-3} ({1})", cell_sysvar, cell_sysscopes);
				var cell_stackAcc = graph.Vertices.Count(p => !p.IsNotStackAccess());
				var cell_varAcc = graph.Vertices.Count(p => !p.IsNotVariableAccess());
				var cell_size = graph.GetAllCodePositions().Count;
				var cell_cycles = string.Join(" ", compiler.LogCycles.Select(p => string.Format("{0,3}", p)));
				var cell_time = sw_time.ToString();

				sb.AppendLine(string.Format(row,
					cell_Name, cell_Vertices, cell_Nops, cell_Leafs, cell_cIOAcc, cell_dIOAcc,
					cell_uservar, cell_systotal, cell_stackAcc, cell_varAcc, cell_size, cell_cycles, cell_time));

				memoCompileLog.Text = sb.ToString();
				memoCompileLog.Refresh();
			}

		}

		private void listBoxOutputLanguages_ItemCheck(object sender, ItemCheckEventArgs e) => OnOptionsChanged();

		private void cbIgnoreSelfModification_CheckedChanged(object sender, EventArgs e) => OnOptionsChanged();

		private void cbSafeStackAccess_CheckedChanged(object sender, EventArgs e) => OnOptionsChanged();

		private void cbSafeGridAccess_CheckedChanged(object sender, EventArgs e) => OnOptionsChanged();

		private void cbOutFormat_CheckedChanged(object sender, EventArgs e) => OnOptionsChanged();

		private void cbUseGZip_CheckedChanged(object sender, EventArgs e) => OnOptionsChanged();
		
		private void OnOptionsChanged()
		{
			if (!isConstructed) return;

			Program.SetConfigValue(this, "cbIgnoreSelfModification", cbIgnoreSelfModification.Checked);
			Program.SetConfigValue(this, "cbSafeStackAccess", cbSafeStackAccess.Checked);
			Program.SetConfigValue(this, "cbSafeGridAccess", cbSafeGridAccess.Checked);
			Program.SetConfigValue(this, "cbOutFormat", cbOutFormat.Checked);
			Program.SetConfigValue(this, "cbUseGZip", cbUseGZip.Checked);

			foreach (var lang in (OutputLanguage[])Enum.GetValues(typeof(OutputLanguage)))
			{
				int idx = listBoxOutputLanguages.Items.IndexOf(lang);
				Program.SetConfigValue(this, "OutputLanguage." + lang, listBoxOutputLanguages.GetItemCheckState(idx) == CheckState.Checked);
			}
		}
		
		private void LoadOptions()
		{
			cbIgnoreSelfModification.Checked = Program.GetConfigValue(this, "cbIgnoreSelfModification", true);
			cbSafeStackAccess.Checked        = Program.GetConfigValue(this, "cbSafeStackAccess", true);
			cbSafeGridAccess.Checked         = Program.GetConfigValue(this, "cbSafeGridAccess", true);
			cbOutFormat.Checked              = Program.GetConfigValue(this, "cbOutFormat", true);
			cbUseGZip.Checked                = Program.GetConfigValue(this, "cbUseGZip", true);

			foreach (var lang in (OutputLanguage[])Enum.GetValues(typeof(OutputLanguage)))
			{
				int idx = listBoxOutputLanguages.Items.IndexOf(lang);
				bool cfgValue = Program.GetConfigValue(this, "OutputLanguage." + lang, true);

				listBoxOutputLanguages.SetItemCheckState(idx, cfgValue ? CheckState.Checked : CheckState.Unchecked);
			}
		}

		private void GenericTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && (e.KeyCode == Keys.A))
			{
				(sender as TextBox)?.SelectAll();
				e.Handled = true;
			}
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);

			tester.Stop();
		}
	}
}
