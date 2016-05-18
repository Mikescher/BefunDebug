using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BefunCompile;
using BefunCompile.CodeGeneration;
using BefunCompile.CodeGeneration.Compiler;
using BefunDebug.BCTestData;

namespace BefunDebug.ThreadRunner
{
	internal class BefunCompileTester : ThreadRunner<List<OutputLanguage>>
	{
		private readonly TextBox logbox;
		private readonly TextBox consoleBox;

		public BefunCompileTester(TextBox tbLog, TextBox tbConsole, Button btnRun) : base(btnRun)
		{
			logbox = tbLog;
			consoleBox = tbConsole;
		}

		protected override string GetButtonTextStart(List<OutputLanguage> data) => "Run Tests";

		protected override string GetButtonTextStop(List<OutputLanguage> data) => "Stop Tests";

		protected override bool RunAction(List<OutputLanguage> languages)
		{
			OutputLine(logbox);
			OutputLine(logbox, "Running Tests");

			foreach (var data in BefunCompileTestData.Data)
			{
				try
				{
					TestAll(data.Name, data.Code, data.Result, languages);
					OutputLine(logbox);
				}
				catch (Exception e)
				{
					OutputLine(logbox, e.ToString());
					return false;
				}

				if (ForceStop) return false;
			}

			OutputLine(logbox, "Tests finished");
			return true;
		}

		private bool TestAll(string name, string code, string result, IEnumerable<OutputLanguage> languages)
		{
			foreach (var lang in languages)
			{
				if (ForceStop) return false;

				var tmstart = DateTime.Now;

				int timeGenerate = 0;
				int timeCompile = 0;
				int timeExecute = 0;

				var bc = new BefunCompiler(code, true, true, true, true, true);

				timeGenerate = Environment.TickCount;
				var gencode = bc.GenerateCode(lang);
				timeGenerate = Environment.TickCount - timeGenerate;

				if (ForceStop) return false;

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

					if (ForceStop) return false;

					timeExecute = Environment.TickCount;
					string output = CodeCompiler.Execute(lang, file).Replace("\r\n", "\n").Replace("\n", "\\n");
					timeExecute = Environment.TickCount - timeExecute;

					if (ForceStop) return false;

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
