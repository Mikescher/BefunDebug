using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BefunDebug.BCTestData;
using BefunDebug.Helper;
using Path = System.IO.Path;

namespace BefunDebug.ThreadRunner
{
	class BefunRunInfoCollector : ThreadRunner<BefunCompileTestData.BCData[]>
	{
		private readonly TextBox outputBox;

		public BefunRunInfoCollector(TextBox box, Button caller) : base(caller)
		{
			outputBox = box;
		}

		protected override string GetButtonTextStart(BefunCompileTestData.BCData[] data) => "Start collecting BefunRun info";

		protected override string GetButtonTextStop(BefunCompileTestData.BCData[] data) => "Stop collecting BefunRun info";
		
		protected override bool RunAction(BefunCompileTestData.BCData[] datas)
		{
			try
			{
				bool first = true;
				foreach (var data in datas)
				{
					
					string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".b93");
					File.WriteAllText(path, data.Code);

					if (! first)
					{
						Output(outputBox, string.Format(" {0,-" + GetColSize("name") + "}", data.Name));
					}

					var result = ProcessHelper.ProcExecute("BefunRun", $"\"{path}\" --info");
					
					if (result.ExitCode != 0)
					{
						OutputLine(outputBox, "Error: " + result.StdOut.Replace("\r", "").Replace("\n", " "));
					}
					else
					{
						var lines = Regex
							.Split(result.StdOut, @"\r?\n")
							.Where(p => !string.IsNullOrWhiteSpace(p))
							.Select(p => p.Split('=').Select(s => s.Trim()).ToList())
							.Where(p => p.Count == 2)
							.Select(p => new {Name = p[0], Value = p[1]})
							.ToList();

						if (first)
						{
							var lineBuilder2 = new StringBuilder();

							lineBuilder2.Append(" ");
							lineBuilder2.Append(string.Format("{0,-"+ GetColSize("name") + "}", "name"));
							foreach (var line in lines)
							{
								lineBuilder2.AppendFormat(" | {0,-" + GetColSize(line.Name) + "}", line.Name);
							}

							OutputLine(outputBox, lineBuilder2.ToString());
						}
						
						if (first) Output(outputBox, string.Format(" {0,-" + GetColSize("name") + "}", data.Name));

						var lineBuilder = new StringBuilder();
						foreach (var line in lines)
						{
							lineBuilder.Append(" | ");
							lineBuilder.Append(string.Format("{0,-" + GetColSize(line.Name) + "}", line.Value));
						}
						OutputLine(outputBox, lineBuilder.ToString());
					}


					File.Delete(path);

					first = false;
					if (ForceStop) return false;
				}

				return true;
			}
			catch (Exception e)
			{
				OutputLine(outputBox, e.ToString());
				return true;
			}
		}

		private int GetColSize(string title)
		{
			if (title == "name") return 8;
			if (title == "steps") return 9;
			if (title == "value_min") return 20;
			if (title == "value_max") return 20;

			return title.Length;
		}
	}
}
