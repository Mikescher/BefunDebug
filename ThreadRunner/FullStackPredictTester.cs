using BefunCompile;
using BefunGen.BCTestData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BefunGen.ThreadRunner
{
	class FullStackPredictTester : ThreadRunner<BefunCompileTestData.BCData[]>
	{
		private readonly TextBox outputBox;

		public FullStackPredictTester(TextBox box, Button caller) : base(caller)
		{
			outputBox = box;
		}

		protected override string GetButtonTextStart(BefunCompileTestData.BCData[] data) => "Full Stacksize Summary";

		protected override string GetButtonTextStop(BefunCompileTestData.BCData[] data) => "Stop Predictor Thread";

		protected override bool RunAction(BefunCompileTestData.BCData[] datas)
		{
			string sep = "";

			for (int i = 0; i < datas.Length; i++)
			{
				try
				{
					var data = datas[i];

					var comp = new BefunCompiler(data.Code, false, true, false, false, true);

					var builderTop = new List<string>();
					var builderBot = new List<string>();

					builderTop.Add(data.Name);
					builderBot.Add("");

					foreach (BefunCompiler.GenerationLevel lvl in comp.GENERATION_LEVELS)
					{
						var graph = lvl.Run();
						var sw = Stopwatch.StartNew();
						var stacksize = graph.PredictStackSize();
						sw.Stop();

						builderTop.Add(stacksize?.ToString() ?? "{UBG}");
						builderBot.Add(sw.ElapsedMilliseconds + "ms");

						if (ForceStop) return false;
					}

					if (i == 0)
					{
						var head = string.Join("|", Enumerable.Range(0, builderTop.Count).Select(p => (p == 0) ? "" : ($"O:{p:00}")).Select(p => " " + p.PadRight(8) + " "));

						OutputLine(outputBox, head);

						sep = Regex.Replace(head, @"[^|]", "-");
						OutputLine(outputBox, sep);
					}

					OutputLine(outputBox, string.Join("|", builderTop.Select(p => " " + p.PadRight(8) + " ")));
					OutputLine(outputBox, string.Join("|", builderBot.Select(p => " " + p.PadRight(8) + " ")));
					OutputLine(outputBox, sep);


					if (ForceStop) return false;
				}
				catch (Exception exc)
				{
					OutputLine(outputBox, exc.Message);
					return false;
				}
			}

			return true;
		}
	}
}
