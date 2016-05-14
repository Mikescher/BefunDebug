using BefunGen.Helper;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Path = System.IO.Path;

namespace BefunGen.ThreadRunner
{
	class BefunRunInfoCollector : ThreadRunner<string[,]>
	{
		private readonly TextBox outputBox;

		public BefunRunInfoCollector(TextBox box, Button caller) : base(caller)
		{
			outputBox = box;
		}

		protected override string GetButtonTextStart() => "Start collecting BefunRun info";

		protected override string GetButtonTextStop() => "Stop collecting BefunRun info";
		
		protected override bool RunAction(string[,] data)
		{
			try
			{
				for (int i = 0; i < data.GetLength(0); i++)
				{

					string name = data[i, 0];
					string code = data[i, 1];
					string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".b93");
					File.WriteAllText(path, code);

					if (i > 0)
					{
						Output(outputBox, string.Format(" {0,-" + GetColSize("name") + "}", name));
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

						if (i == 0)
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
						
						if (i == 0) Output(outputBox, string.Format(" {0,-" + GetColSize("name") + "}", name));

						var lineBuilder = new StringBuilder();
						foreach (var line in lines)
						{
							lineBuilder.Append(" | ");
							lineBuilder.Append(string.Format("{0,-" + GetColSize(line.Name) + "}", line.Value));
						}
						OutputLine(outputBox, lineBuilder.ToString());
					}


					File.Delete(path);

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
