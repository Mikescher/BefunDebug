using BefunDebug.Helper;
using BefunGen.AST.CodeGen;
using BefunGen.AST.CodeGen.NumberCode;
using BefunRep;
using BefunRep.FileHandling;
using BefunRep.OutputHandling;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BefunDebug.Pages
{
	public partial class frmMain_BefunRep : UserControl
	{
		private const string SAFE_FILENAME = "safe.bin.gz";

		private RepresentationSafe safe;

		public frmMain_BefunRep()
		{
			InitializeComponent();

			ReloadSafe();
		}

		private void btnSingleBefunRepRep_Click(object sender, EventArgs e)
		{
			long number = Convert.ToInt64(edSingleBefunRepRep.Value);

			RepresentationSafe msafe = new MemorySafe();

			RepCalculator c1 = new RepCalculator(0, 4069, false, msafe, true);
			c1.Calculate();

			RepCalculator c2 = new RepCalculator(number - 64, number + 64, false, msafe, true);
			c2.Calculate();

			var result = msafe.GetCombined(number);

			if (result == null)
			{
				txtDebug.Text += Environment.NewLine + Environment.NewLine + number + ": ERROR";
			}
			else
			{
				var algorithm = RepCalculator.AlgorithmNames[result.Algorithm];

				txtDebug.Text += string.Format("{0}{0}{1}:       {2}         {3}", Environment.NewLine, number, algorithm, result.Representation);
			}
		}

		private void btnBenchBefunRepCSV_Click(object sender, EventArgs e)
		{
			long number = Convert.ToInt64(edBenchBefunRep.Value);

			RepresentationSafe msafe = new MemorySafe();
			OutputFormatter fmt = new CSVOutputFormatter();

			RepCalculator c1 = new RepCalculator(0, number, false, msafe, true);
			c1.Calculate();

			txtDebug.Text = fmt.Convert(msafe, 0, number);
		}

		private void btnBenchBefunRepXML_Click(object sender, EventArgs e)
		{
			long number = Convert.ToInt64(edBenchBefunRep.Value);

			RepresentationSafe msafe = new MemorySafe();
			OutputFormatter fmt = new XMLOutputFormatter();

			RepCalculator c1 = new RepCalculator(0, number, false, msafe, true);
			c1.Calculate();

			txtDebug.Text = fmt.Convert(msafe, 0, number);
		}

		private void btnBenchBefunRepJSON_Click(object sender, EventArgs e)
		{
			long number = Convert.ToInt64(edBenchBefunRep.Value);

			RepresentationSafe msafe = new MemorySafe();
			OutputFormatter fmt = new JSONOutputFormatter();

			RepCalculator c1 = new RepCalculator(0, number, false, msafe, true);
			c1.Calculate();

			txtDebug.Text = fmt.Convert(msafe, 0, number);
		}

		private void btnDebugNumberRep_Click(object sender, EventArgs e)
		{
			string bench = NumberCodeHelper.GenerateBenchmark(Convert.ToInt32(edNumberRep.Value), true);

			txtDebug.Text = bench;
		}

		private void btnSingleRep_Click(object sender, EventArgs e)
		{
			string bench = String.Join(
				Environment.NewLine,
				NumberCodeHelper
					.GenerateAllCode(Convert.ToInt64(edSingleRep.Value), true)
					.Select(p => p.Item1 + ":  " + p.Item2.ToSimpleString())
					.ToList());

			txtDebug.Text += Environment.NewLine + Environment.NewLine + bench;
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
						p.ReplaceWalkway(CSIZE - 1 - x, CSIZE - 1 - y, BCHelper.Chr('#'), false);
					}
				}
			}
			txtDebug.Text = p.ToSimpleString();
		}

		private void btnSafeRange_Click(object sender, EventArgs e)
		{
			if (safe == null) return;

			long min = (long) edSafeRangeMin.Value;
			long max = (long) edSafeRangeMax.Value;

			safe.Start();
			edSafeLog.Text += Environment.NewLine;
			for (long val = min; val < max; val++)
			{
				var rep = safe.GetCombined(val);

				if (rep != null)
				{
					edSafeLog.Text += Environment.NewLine +  string.Format("{0,6}:  {1,-20} {2}", val, RepCalculator.AlgorithmNames[rep.Algorithm], rep.Representation);
					edSafeLog.SelectionStart = edSafeLog.Text.Length;
					edSafeLog.ScrollToCaret();
				}
				else
				{
					edSafeLog.Text += Environment.NewLine + string.Format("{0,6}:  [NOT IN SAFE]", val);
					edSafeLog.SelectionStart = edSafeLog.Text.Length;
					edSafeLog.ScrollToCaret();
				}
			}
			safe.Stop();
		}

		private void GenericTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && (e.KeyCode == Keys.A))
			{
				(sender as TextBox)?.SelectAll();
				e.Handled = true;
			}
		}

		private void btnSafeReload_Click(object sender, EventArgs e)
		{
			ReloadSafe();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtDebug.Text = string.Empty;
		}

		private void btnSafeRetrieve_Click(object sender, EventArgs e)
		{
			if (safe == null) return;

			long val = (long)edSafeRetrieveValue.Value;

			safe.Start();

			var rep = safe.GetCombined(val);
			safe.Stop();

			if (rep != null)
			{
				edSafeLog.Text += string.Format("{0}{0}Algorithm-ID:   {1}{0}Algorithm:      {2}{0}Representation: {3}",
					Environment.NewLine,
					rep.Algorithm,
					RepCalculator.AlgorithmNames[rep.Algorithm],
					rep.Representation);
				edSafeLog.SelectionStart = edSafeLog.Text.Length;
				edSafeLog.ScrollToCaret();
			}
			else
			{
				edSafeLog.Text += "\r\n\r\nValue not found in Safe";
				edSafeLog.SelectionStart = edSafeLog.Text.Length;
				edSafeLog.ScrollToCaret();
			}
		}

		private void btnSafeInfo_Click(object sender, EventArgs e)
		{
			if (safe == null) return;

			safe.Start();
			var info = safe.GetInformations();
			safe.Stop();

			StringBuilder b = new StringBuilder();

			b.AppendLine(string.Format("Low          = {0}", info.LowestValue));
			b.AppendLine(string.Format("High         = {0}", info.HighestValue));
			b.AppendLine(string.Format("Total Count  = {0}", info.Count));
			b.AppendLine(string.Format("Found Count  = {0}", info.NonNullCount));
			b.AppendLine(string.Format("Total Length = {0}", info.TotalLen));
			b.AppendLine(string.Format("Avg Length   = {0}", info.AvgLen));
			b.AppendLine(string.Format("Min Length   = {0}", info.MinLen));
			b.AppendLine(string.Format("Max Length   = {0}", info.MaxLen));

			for (int i = 0; i < RepCalculator.Algorithms.Length; i++)
			{
				b.AppendLine();
				b.AppendLine(RepCalculator.AlgorithmNames[i]);
				b.AppendLine("{");
				b.AppendLine(string.Format("    Found Count  = {0}", info.NonNullPerAlgorithm[i]));
				b.AppendLine(string.Format("    Total Length = {0}", info.TotalLenPerAlgorithm[i]));
				b.AppendLine(string.Format("      Avg Length = {0}", info.AvgLenPerAlgorithm[i]));
				b.AppendLine(string.Format("      Min Length = {0}", info.MinLenPerAlgorithm[i]));
				b.AppendLine(string.Format("      Max Length = {0}", info.MaxLenPerAlgorithm[i]));
				b.AppendLine("}");
			}

			edSafeLog.Text = b.ToString();
			edSafeLog.SelectionStart = edSafeLog.Text.Length;
			edSafeLog.ScrollToCaret();
		}

		private void ReloadSafe(bool quiet = false)
		{
			Stopwatch sw = Stopwatch.StartNew();
			string error = null;

			if (!File.Exists(SAFE_FILENAME))
			{
				safe = null;
			}
			else
			{
				try
				{
					safe = new GZipBinarySafe(SAFE_FILENAME, 0, 0);
					safe.LightLoad();
				}
				catch (Exception e)
				{
					error = e.ToString();
					safe = null;
					if (e is FileNotFoundException) error = null;
				}
			}


			bool loaded = (safe != null);

			btnSafeRetrieve.Enabled = loaded;
			btnSafeInfo.Enabled = loaded;
			btnSafeRange.Enabled = loaded;

			edSafeRetrieveValue.Enabled = loaded;
			edSafeRangeMax.Enabled = loaded;
			edSafeRangeMin.Enabled = loaded;

			if (loaded)
			{
				edSafeMin.Text = FmtLongWithSpaces(safe.GetLowestValue());
				edSafeMax.Text = FmtLongWithSpaces(safe.GetHighestValue());

				if (!quiet)
				{
					edSafeLog.Text += $"\r\n\r\nLoaded in {sw.ElapsedTicks} nanoseconds ( = {sw.ElapsedMilliseconds}ms)";
					edSafeLog.SelectionStart = edSafeLog.Text.Length;
					edSafeLog.ScrollToCaret();
				}
			}
			else
			{
				edSafeMin.Text = "";
				edSafeMax.Text = "";

				if (!quiet && error != null)
				{
					edSafeLog.Text += "\r\n\r\nERROR while loading safe:\r\n\r\n" + error;
					edSafeLog.SelectionStart = edSafeLog.Text.Length;
					edSafeLog.ScrollToCaret();
				}

			}

			pnlSafeStatus.BackColor = loaded ? Color.Green : Color.Red;
		}

		private string FmtLongWithSpaces(long k)
		{
			if (k == 0) return "0";

			if (k < 0) return "-" + string.Format("{0:### ### ### ### ### ### ### ###}", -k).Trim();
			if (k > 0) return "+" + string.Format("{0:### ### ### ### ### ### ### ###}", +k).Trim();

			throw new ArgumentException();
		}

		private void btnSafeCreate_Click(object sender, EventArgs e)
		{
			safe = new GZipBinarySafe(SAFE_FILENAME, 0, 0);
			safe.Start();
			safe.Stop();

			edSafeLog.Text += string.Format("\r\n\r\nNew empty safe created in {0}:\r\n\r\n", SAFE_FILENAME);

			ReloadSafe();
		}

		private void btnRunBefunRep_Click(object sender, EventArgs e)
		{
			try
			{
				var tmpFile = Path.GetTempFileName();

				var args = string.Format("--safe=\"{0}\" --lower={1} --upper={2} --iterations={3} {4} {5} --log=\"{6}\"",
					SAFE_FILENAME,
					edRepRunnerStart.Value,
					edRepRunnerEnd.Value,
					edRepRunnerIterations.Value,
					cbRepRunnerTests.Checked ? "" : "-notest",
					cbRepRunnerQuiet.Checked ? "--quiet" : "",
					tmpFile);

				var output = ProcessHelper.ProcExecute("BefunRep", args, null, true);

				var log = File.ReadAllText(tmpFile);
				File.Delete(tmpFile);

				if (output.ExitCode != 0)
				{
					edSafeLog.Text = string.Format("ERROR {0}\r\n{1}", output.ExitCode, log);
					edSafeLog.SelectionStart = edSafeLog.Text.Length;
					edSafeLog.ScrollToCaret();
				}
				else
				{
					edSafeLog.Text = log;
					edSafeLog.SelectionStart = edSafeLog.Text.Length;
					edSafeLog.ScrollToCaret();
				}

			}
			catch (Exception ex)
			{
				edSafeLog.Text = ex.ToString();
				edSafeLog.SelectionStart = edSafeLog.Text.Length;
				edSafeLog.ScrollToCaret();
			}

			ReloadSafe(true);
		}
	}
}
