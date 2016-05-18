using System;
using System.Windows.Forms;
using BefunCompile;
using BefunDebug.BCTestData;

namespace BefunDebug.ThreadRunner
{
	class StackPredictTester : ThreadRunner<int>
	{
		private readonly TextBox outputBox;

		public StackPredictTester(TextBox box, Button caller) : base(caller)
		{
			outputBox = box;
		}

		protected override string GetButtonTextStart(int data) => $"Stacksize Summary (O:{data.ToString("X")})";

		protected override string GetButtonTextStop(int data) => "Stop Stacksize Summary";

		protected override bool RunAction(int optimizeLevel)
		{
			foreach (var data in BefunCompileTestData.Data)
			{
				try
				{
					var comp = new BefunCompiler(data.Code, false, true, false, false, true);
					var craph = comp.GENERATION_LEVELS[optimizeLevel].Run();
					var stacksize = craph.PredictStackSize();

					if (ForceStop) return false;

					if (stacksize == null)
					{
						OutputLine(outputBox, string.Format("[{0} | O:{1}] predicted stacksize => {2}", data.Name, optimizeLevel, "UnboundedGrowth"));
					}
					else
					{
						OutputLine(outputBox, string.Format("[{0} | O:{1}] predicted stacksize => {2}", data.Name, optimizeLevel, stacksize));
					}
				}
				catch (Exception exc)
				{
					OutputLine(outputBox, string.Format("[{0} | O:{1}] ERROR => {2}", data.Name, optimizeLevel, exc.Message));
				}
			}

			return true;
		}
	}
}
