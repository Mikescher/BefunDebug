using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BefunRep;
using BefunRep.OutputHandling;
using BefunRep.FileHandling;
using BefunGen.AST.CodeGen.NumberCode;
using BefunGen.AST.CodeGen;

namespace BefunGen
{
	public partial class frmMain_BefunRep : UserControl
	{
		private const string SAFE_FILENAME = "safe.bin";

		private BinarySafe safe;

		public frmMain_BefunRep()
		{
			InitializeComponent();

			try
			{
				if (! File.Exists(SAFE_FILENAME)) throw new FileNotFoundException();

				safe = new BinarySafe(SAFE_FILENAME, 0, 0);
				safe.start();
				safe.stop();

				edSafeMin.Text = safe.getLowestValue().ToString();
				edSafeMax.Text = safe.getHighestValue().ToString();

				pnlSafeState.BackColor = Color.Green;
			}
			catch (Exception)
			{
				btnSafeGet.Enabled = false;
				btnSafeInfo.Enabled = false;
				btnSafeRange.Enabled = false;
				
				edSafeValue.Enabled = false;
				edSafeRangeMax.Enabled = false;
				edSafeRangeMin.Enabled = false;

				pnlSafeState.BackColor = Color.Red;
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
				txtDebug.Text += Environment.NewLine + Environment.NewLine + number + ": ERROR";
			else
			{
				var algorithm = RepCalculator.algorithmNames[safe.getAlgorithm(number).Value];

				txtDebug.Text += Environment.NewLine + Environment.NewLine + number + ":       " + algorithm + "         " + result;
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

		private void btnDebugNumberRep_Click(object sender, EventArgs e)
		{
			string bench = NumberCodeHelper.generateBenchmark(Convert.ToInt32(edNumberRep.Value), true);

			txtDebug.Text = bench;
		}

		private void btnSingleRep_Click(object sender, EventArgs e)
		{
			string bench = String.Join(
				Environment.NewLine,
				NumberCodeHelper
					.generateAllCode(Convert.ToInt64(edSingleRep.Value), true)
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
						p.replaceWalkway(CSIZE - 1 - x, CSIZE - 1 - y, BCHelper.chr('#'), false);
					}
				}
			}
			txtDebug.Text = p.ToSimpleString();
		}

		private void btnSafeGet_Click(object sender, EventArgs e)
		{
			long val = (long)edSafeValue.Value;

			safe.start();
			var rep = safe.get(val);
			var algo = safe.getAlgorithm(val);
			safe.stop();

			if (rep != null)
			{
				txtDebug.Text += string.Format("{0}{0}Algorithm-ID:   {1}{0}Algorithm:      {2}{0}Representation: {3}", 
					Environment.NewLine,
					algo,
					RepCalculator.algorithmNames[algo ?? -1],
					rep);
			}
			else
			{
				txtDebug.Text += Environment.NewLine + Environment.NewLine + "Value not found in Safe";
			}
		}

		private void btnSafeRange_Click(object sender, EventArgs e)
		{
			long min = (long) edSafeRangeMin.Value;
			long max = (long) edSafeRangeMax.Value;

			safe.start();
			txtDebug.Text += Environment.NewLine;
			for (long val = min; val < max; val++)
			{
				var rep = safe.get(val);
				var algo = safe.getAlgorithm(val);

				if (rep != null)
				{
					txtDebug.Text += Environment.NewLine +  string.Format("{0,6}:  {1,-20} {2}", val, RepCalculator.algorithmNames[algo ?? -1], rep);
				}
				else
				{
					txtDebug.Text += Environment.NewLine + string.Format("{0,6}:  [NOT IN SAFE]", val);
				}
			}
			safe.stop();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtDebug.Text = string.Empty;
		}
	}
}
