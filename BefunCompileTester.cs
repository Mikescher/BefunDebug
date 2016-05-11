
using BefunCompile;
using BefunCompile.CodeGeneration;
using BefunCompile.CodeGeneration.Compiler;
using BefunGen.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BefunGen
{
	internal class BefunCompileTester
	{
		public static readonly string[,] TestData = 
		{
			{ "data_001", Resources.testdata_001, "233168" },
			{ "data_002", Resources.testdata_002, "4613732" },
			{ "data_003", Resources.testdata_003, "6857" },
			{ "data_005", Resources.testdata_005, "232792560" },
			{ "data_006", Resources.testdata_006, "25164150" },
			{ "data_007", Resources.testdata_007, "104743" },
			{ "data_008", Resources.testdata_008, "5576689664895=23514624000" },
			{ "data_010", Resources.testdata_010, "142913828922" },
			{ "data_011", Resources.testdata_011, "70600674" },
			{ "data_012", Resources.testdata_012, "76576500" },
			{ "data_013", Resources.testdata_013, "5537376230" },
			{ "data_015", Resources.testdata_015, "137846528820" },
			{ "data_016", Resources.testdata_016, "1366" },
			{ "data_017", Resources.testdata_017, "21124" },
			{ "data_018", Resources.testdata_018, "1074" },
			{ "data_019", Resources.testdata_019, "171" },
			{ "data_020", Resources.testdata_020, "648" },
			{ "data_024", Resources.testdata_024, "2783915460" },
			{ "data_026", Resources.testdata_026, "983" },
			{ "data_027", Resources.testdata_027, "-59231" },
			{ "data_028", Resources.testdata_028, "669171001" },
			{ "data_030", Resources.testdata_030, "443839" },
			{ "data_031", Resources.testdata_031, "73682" },
			{ "data_032", Resources.testdata_032, "45228" },
			{ "data_033", Resources.testdata_033, "100" },
			{ "data_035", Resources.testdata_035, @"2\n3\n5\n7\n11\n13\n17\n31\n37\n71\n73\n79\n97\n113\n131\n197\n199\n311\n337\n373\n719\n733\n919\n971\n991\n1193\n1931\n3119\n3779\n7793\n7937\n9311\n9377\n11939\n19391\n19937\n37199\n39119\n71993\n91193\n93719\n93911\n99371\n193939\n199933\n319993\n331999\n391939\n393919\n919393\n933199\n939193\n939391\n993319\n999331\n =55" },
			{ "data_036", Resources.testdata_036, @"585585\n9009\n7447\n99\n33\n73737\n53835\n53235\n39993\n32223\n15351\n717\n585\n313\n9\n7\n5\n3\n1\n =872187" },
			{ "data_037", Resources.testdata_037, @"73\n739397\n797\n53\n37\n317\n313\n3137\n373\n3797\n23\n =748317" },
			{ "data_038", Resources.testdata_038, "932718654" },
			{ "data_039", Resources.testdata_039, "840" },
			{ "data_040", Resources.testdata_040, "210" },
			{ "data_041", Resources.testdata_041, "7652413" },
			{ "data_042", Resources.testdata_042, "162" },
			{ "data_043", Resources.testdata_043, @"4130952867\n1430952867\n4160357289\n1460357289\n4106357289\n1406357289\n\n= 16695334890" },
			{ "data_045", Resources.testdata_045, "1533776805" },
			{ "data_046", Resources.testdata_046, "5777" },
			{ "data_048", Resources.testdata_048, "9110846700" },
			{ "data_049", Resources.testdata_049, "2969 6299 9629" },
			{ "data_050", Resources.testdata_050, "997651" },
			{ "data_052", Resources.testdata_052, "142857" },
			{ "data_053", Resources.testdata_053, "4075" },
			{ "data_054", Resources.testdata_054, "376" },
			{ "data_055", Resources.testdata_055, "249" },
			{ "data_056", Resources.testdata_056, "972" },
			{ "data_057", Resources.testdata_057, "153" },
			{ "data_058", Resources.testdata_058, "26241" },
			{ "data_059", Resources.testdata_059, "107359" },
			{ "data_061", Resources.testdata_061, @"1281\n8128\n2882\n8256\n5625\n2512\n  = 28684" },
			{ "data_063", Resources.testdata_063, "49" },
			{ "data_064", Resources.testdata_064, "1322" },
			{ "data_065", Resources.testdata_065, "272" },
			{ "data_067", Resources.testdata_067, "7273" },
			{ "data_068", Resources.testdata_068, "6531031914842725" },
			{ "data_069", Resources.testdata_069, "510510" },
			{ "data_070", Resources.testdata_070, "8319823" },
			{ "data_071", Resources.testdata_071, @"428570 /\n999997" },
			{ "data_076", Resources.testdata_076, "190569291" },
			{ "data_077", Resources.testdata_077, "71" },
			{ "data_079", Resources.testdata_079, "73162890" },

		};
		
		private bool forceStop = false;
		private bool running = false;
		private Thread runner = null;

		public void TriggerAction(TextBox tbLog, TextBox tbConsole, Button btnRun, IEnumerable<OutputLanguage> languages)
		{
			languages = languages.ToList();

			if (!running)
			{
				btnRun.Text = "Starting ...";

				runner = new Thread(Run);

				forceStop = false;
				runner.Start(Tuple.Create(tbLog, tbConsole, btnRun, languages.ToList()));
			}
			else
			{
				btnRun.Text = "Stopping";

				forceStop = true;

				int i = 0;
				while (running)
				{
					i++;
					btnRun.Text = new string('.', i % 4) + " Stopping " + new string('.', i % 4);
					btnRun.Refresh();

					Thread.Sleep(200);
				}

				forceStop = false;

				btnRun.Text = "Run Tests"; ;
			}
		}

		private void Run(object obj)
		{
			var data = (Tuple<TextBox, TextBox, Button, List<OutputLanguage>>)obj;

			running = true;
			try
			{
				data.Item3.BeginInvoke(new Action(() => { data.Item3.Text = "Stop Tests"; }));

				StartTest(data.Item1, data.Item2, data.Item4);
			}
			finally
			{
				if (forceStop) Thread.Sleep(2000);
				data.Item3.BeginInvoke(new Action(() => { data.Item3.Text = "Run Tests"; }));
				running = false;
			}
		}

		private void Output(TextBox box, string line)
		{
			box.BeginInvoke(new Action(() =>
			{
				box.Text += line;
				box.SelectionStart = box.Text.Length;
				box.ScrollToCaret();
			}));
		}

		private void OutputLine(TextBox box, string line = "")
		{
			box.BeginInvoke(new Action(() =>
			{
				box.Text += line + Environment.NewLine;
				box.SelectionStart = box.Text.Length;
				box.ScrollToCaret();
			}));
		}

		private bool StartTest(TextBox logbox, TextBox consoleBox, List<OutputLanguage> languages)
		{
			OutputLine(logbox);
			OutputLine(logbox, "Running Tests");
			
			for (int i = 0; i < TestData.GetLength(0); i++)
			{
				TestAll(TestData[i, 0], TestData[i, 1], TestData[i, 2], languages, logbox, consoleBox);
				OutputLine(logbox);

				if (forceStop) return false;
			}

			OutputLine(logbox, "Tests finished");
			return true;
		}

		private bool TestAll(string name, string code, string result, IEnumerable<OutputLanguage> languages, TextBox logbox, TextBox consoleBox)
		{
			foreach (var lang in languages)
			{
				if (forceStop) return false;

				var tmstart = DateTime.Now;

				int timeGenerate = 0;
				int timeCompile = 0;
				int timeExecute = 0;

				var bc = new BefunCompiler(code, true, true, true, true, true);

				timeGenerate = Environment.TickCount;
				var gencode = bc.GenerateCode(lang);
				timeGenerate = Environment.TickCount - timeGenerate;

				if (forceStop) return false;

				var file = Path.GetTempFileName() + "." + CodeCompiler.GetBinaryExtension(lang);

				bool failed = false;
				try
				{
					timeCompile = Environment.TickCount;
					var consoleBuilder = new StringBuilder();
					CodeCompiler.Compile(lang, gencode, file, consoleBuilder);
					timeCompile = Environment.TickCount - timeCompile;
					if (consoleBuilder.Length > 0)
						OutputLine(consoleBox, consoleBuilder.ToString());

					if (forceStop) return false;

					timeExecute = Environment.TickCount;
					string output = CodeCompiler.Execute(lang, file).Replace("\r\n", "\n").Replace("\n", "\\n");
					timeExecute = Environment.TickCount - timeExecute;

					if (forceStop) return false;

					if (output != result)
					{
						OutputLine(logbox, string.Format("[{0,000}-{1}] Failure: ('{2}' <> '{3}')", name, CodeCompiler.GetAcronym(lang), output, result));
						failed = true;
					}
				}
				catch (CodeCompilerError e)
				{
					OutputLine(logbox, string.Format("[{0,000}-{1}] Failure: {2}: {3}", name, CodeCompiler.GetAcronym(lang), e.ExitCode, e.StdErr));
					failed = true;
				}

				File.Delete(file);

				if (!failed)
				{
					OutputLine(logbox, string.Format("[{0,000}-{1}] Tests successful ({2,-6} ms) :: Generate= {3,-6} Compile= {4,-10} Run= {5,-10}", 
						name, 
						CodeCompiler.GetAcronym(lang), 
						(int)(DateTime.Now - tmstart).TotalMilliseconds, 
						timeGenerate, 
						timeCompile, 
						timeExecute));
				}
			}

			return true;
		}
	}
}
