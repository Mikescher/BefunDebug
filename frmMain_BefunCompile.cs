using BefunCompile;
using BefunCompile.CodeGeneration;
using BefunCompile.CodeGeneration.Generator;
using BefunCompile.Graph;
using BefunCompile.Graph.Vertex;
using BefunCompile.Math;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BefunGen
{
	public partial class frmMain_BefunCompile : UserControl
	{
		public frmMain_BefunCompile()
		{
			InitializeComponent();

			tabCompileControl.SelectedIndex = 0;
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
			
			cbxCompileLanguage.SelectedIndex = 0;
			cbxCompileLevel.SelectedIndex = cbxCompileLevel.Items.Count - 1;
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

				var cbcCodeGCC = CodeGenerator.GenerateCode(OutputLanguage.C, cbcGraph, cbOutFormat.Checked, cbSafeStackAccess.Checked, cbSafeGridAccess.Checked, cbUseGZip.Checked);
				var cbcCodeCSC = CodeGenerator.GenerateCode(OutputLanguage.CSharp, cbcGraph, cbOutFormat.Checked, cbSafeStackAccess.Checked, cbSafeGridAccess.Checked, cbUseGZip.Checked);
				var cbcCodeJVC = CodeGenerator.GenerateCode(OutputLanguage.Java, cbcGraph, cbOutFormat.Checked, cbSafeStackAccess.Checked, cbSafeGridAccess.Checked, cbUseGZip.Checked);

				var tester = new BefunCompileTester();

				var output_GCC = tester.ExecuteGCC(cbcCodeGCC);
				memoCompileLog.Text += Environment.NewLine + "[Execute GCC]" + output_GCC;

				var output_CSC = tester.ExecuteCSC(cbcCodeCSC);
				memoCompileLog.Text += Environment.NewLine + "[Execute CSC]" + output_CSC;

				var output_JVC = tester.ExecuteJVC(cbcCodeJVC);
				memoCompileLog.Text += Environment.NewLine + "[Execute JVC]" + output_CSC;

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
				memoCompileLog.Text += "ERROR: " + exc.ToString() + Environment.NewLine;
				tabCompileControl.SelectedIndex = 4;
			}
		}

		private void btnCompileGraphCompile_Click(object sender, EventArgs e)
		{
			try
			{
				memoCompileOut.Text = CodeGenerator.GenerateCode(
					(OutputLanguage)cbxCompileLanguage.SelectedItem, 
					cbcGraph,
					cbOutFormat.Checked,
					cbSafeStackAccess.Checked,
					cbSafeGridAccess.Checked,
					cbUseGZip.Checked);

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

				string code = CodeGenerator.GenerateCode(
					(OutputLanguage)cbxCompileLanguage.SelectedItem,
					craph, 
					cbOutFormat.Checked, 
					cbSafeStackAccess.Checked, 
					cbSafeGridAccess.Checked, 
					cbUseGZip.Checked);

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
			tabCompileControl.SelectedIndex = 3;

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

				memoCompileOut.Text = sb.ToString();
				memoCompileOut.Refresh();
			}

		}


	}
}
