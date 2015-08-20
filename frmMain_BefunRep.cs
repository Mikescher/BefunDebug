using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
		public frmMain_BefunRep()
		{
			InitializeComponent();
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

			txtDebug.Text = bench;
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

	}
}
