
using BefunCompile;
using BefunGen.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
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
		};

		public StringBuilder Output;

		public void Test(ref TextBox logbox)
		{
			logbox.Text += Environment.NewLine;
			logbox.Text += "Running Tests" + Environment.NewLine;

			Output = new StringBuilder();
			for (int i = 0; i < TestData.GetLength(0); i++)
			{
				logbox.Text += TestAll(TestData[i, 0], TestData[i, 1], TestData[i, 2]);
				logbox.SelectionStart = logbox.Text.Length;
				logbox.ScrollToCaret();
				logbox.Refresh();
			}

			logbox.Text += "Tests finished" + Environment.NewLine;
			logbox.ScrollToCaret();
			logbox.Refresh();
		}

		public string TestAll(string name, string code, string result)
		{
			var resultlog = string.Empty;
			var tmstart = DateTime.Now;

			try
			{
				resultlog += TestGCC(name, code, result, true);
				resultlog += TestCSC(name, code, result, true);
			}
			catch (Exception e)
			{
				return string.Format("[{0}] Exception thrown: {1}: {2}\r\n", name, e.GetType().Name, e.Message);
			}

			if (resultlog == string.Empty)
				return string.Format("[{0}] Tests successful ({1} ms)\r\n", name, (DateTime.Now - tmstart).TotalMilliseconds);

			return resultlog;
		}

		private string TestGCC(string name, string code, string result, bool safeAcc)
		{
			var bc = new BefunCompiler(code, true, true, safeAcc, safeAcc, true);
			var gencode = bc.GenerateCode(OutputLanguage.C);
			var fn1 = Path.GetTempFileName();
			var fn2 = Path.GetTempPath() + Guid.NewGuid() + ".exe";
			File.WriteAllText(fn1, gencode);

			Process p_gcc = new Process
			{
				StartInfo =
				{
					FileName = "gcc.exe",
					Arguments = string.Format(" -x c \"{0}\" -o \"{1}\"", fn1, fn2),
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true,
					ErrorDialog = false
				}
			};
			p_gcc.Start();
			Output.AppendLine();
			Output.AppendLine("> " + p_gcc.StartInfo.FileName + " " + p_gcc.StartInfo.Arguments);

			string gccerror = p_gcc.StandardError.ReadToEnd();
			string gccoutput = p_gcc.StandardOutput.ReadToEnd();

			p_gcc.WaitForExit();
			Output.AppendLine(gccerror);
			Output.AppendLine(gccoutput);


			if (p_gcc.ExitCode != 0)
			{
				File.Delete(fn1);
				File.Delete(fn2);

				return string.Format("[{0}] FAILURE (GCC ExitCode  = {1}): {2}\r\n", name, p_gcc.ExitCode, gccerror);
			}

			Process p_prog = new Process
			{
				StartInfo =
				{
					FileName = fn2,
					Arguments = string.Empty,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true,
					ErrorDialog = false
				}
			};
			p_prog.Start();
			string output = p_prog.StandardOutput.ReadToEnd().Replace("\r\n", "\n").Replace("\n", "\\n");
			p_prog.WaitForExit();

			if (p_prog.ExitCode != 0)
			{
				File.Delete(fn1);
				File.Delete(fn2);

				return string.Format("[{0}] FAILURE (PROG ExitCode  = {1}): {2}\r\n", name, p_prog.ExitCode, output);
			}

			if (output != result)
			{
				File.Delete(fn1);
				File.Delete(fn2);

				return string.Format("[{0}] FAILURE ('{1}' <> '{2}')\r\n", name, output, result);
			}

			File.Delete(fn1);
			File.Delete(fn2);

			return string.Empty;
		}

		private string TestCSC(string name, string code, string result, bool safeAcc)
		{
			var bc = new BefunCompiler(code, true, true, safeAcc, safeAcc, true);
			var gencode = bc.GenerateCode(OutputLanguage.CSharp);
			var fn1 = Path.GetTempFileName() + ".cs";
			var fn2 = Path.GetTempPath() + Guid.NewGuid() + ".exe";
			File.WriteAllText(fn1, gencode);

			Process p_csc = new Process
			{
				StartInfo =
				{
					FileName = "csc.exe",
					Arguments = string.Format("/out:\"{1}\" /optimize /nologo \"{0}\"", fn1, fn2),
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true,
					ErrorDialog = false
				}
			};
			p_csc.Start();
			Output.AppendLine();
			Output.AppendLine("> " + p_csc.StartInfo.FileName + " " + p_csc.StartInfo.Arguments);

			string cscoutput = p_csc.StandardOutput.ReadToEnd();
			string cscerror = p_csc.StandardError.ReadToEnd();
			p_csc.WaitForExit();
			Output.AppendLine(cscerror);
			Output.AppendLine(cscoutput);


			if (p_csc.ExitCode != 0)
			{
				File.Delete(fn1);
				File.Delete(fn2);

				return string.Format("[{0}] FAILURE (CSC ExitCode  = {1}): {2}\r\n", name, p_csc.ExitCode, cscoutput); // csc writes errors to stdout
			}

			Process p_prog = new Process
			{
				StartInfo =
				{
					FileName = fn2,
					Arguments = string.Empty,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true,
					ErrorDialog = false
				}
			};
			p_prog.Start();
			string output = p_prog.StandardOutput.ReadToEnd().Replace("\r\n", "\n").Replace("\n", "\\n");
			p_prog.WaitForExit();

			if (p_prog.ExitCode != 0)
			{
				File.Delete(fn1);
				File.Delete(fn2);

				return string.Format("[{0}] FAILURE (PROG ExitCode  = {1}): {2}\r\n", name, p_prog.ExitCode, output);
			}

			if (output != result)
			{
				File.Delete(fn1);
				File.Delete(fn2);

				return string.Format("[{0}] FAILURE ('{1}' <> '{2}')\r\n", name, output, result);
			}

			File.Delete(fn1);
			File.Delete(fn2);

			return string.Empty;
		}

		public string ExecuteGCC(string code)
		{
			var fn1 = Path.GetTempPath() + Guid.NewGuid() + ".b93.c";
			var fn2 = Path.GetTempPath() + Guid.NewGuid() + ".exe";
			File.WriteAllText(fn1, code);

			Process p_gcc = new Process
			{
				StartInfo =
				{
					FileName = "gcc.exe",
					Arguments = string.Format(" -x c \"{0}\" -o \"{1}\"", fn1, fn2),
					UseShellExecute = false,
					RedirectStandardError = true,
					CreateNoWindow = true,
					ErrorDialog = false
				}
			};

			p_gcc.Start();
			string gccerror = p_gcc.StandardError.ReadToEnd();
			p_gcc.WaitForExit();

			if (p_gcc.ExitCode != 0)
			{
				File.Delete(fn1);
				File.Delete(fn2);

				return string.Format("FAILURE (GCC ExitCode  = {0}): {1}\r\n", p_gcc.ExitCode, gccerror);
			}

			Process p_prog = new Process
			{
				StartInfo =
				{
					FileName = fn2,
					Arguments = string.Empty,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true,
					ErrorDialog = false
				}
			};

			p_prog.Start();
			string output = p_prog.StandardOutput.ReadToEnd();
			p_prog.WaitForExit();

			File.Delete(fn1);
			File.Delete(fn2);

			if (p_prog.ExitCode != 0)
			{
				return string.Format("FAILURE (PROG ExitCode  = {0}): {1}\r\n", p_prog.ExitCode, output);
			}

			return output;
		}

		public string ExecuteCSC(string code)
		{
			var fn1 = Path.GetTempPath() + Guid.NewGuid() + ".b93.cs";
			var fn2 = Path.GetTempPath() + Guid.NewGuid() + ".exe";
			File.WriteAllText(fn1, code);

			Process p_csc = new Process
			{
				StartInfo =
				{
					FileName = "csc.exe",
					Arguments = string.Format("/out:\"{1}\" /optimize /nologo \"{0}\"", fn1, fn2),
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true,
					ErrorDialog = false
				}
			};

			p_csc.Start();
			string cscerror = p_csc.StandardOutput.ReadToEnd();
			p_csc.WaitForExit();

			if (p_csc.ExitCode != 0)
			{
				File.Delete(fn1);
				File.Delete(fn2);

				return string.Format("FAILURE (CSC ExitCode  = {0}): {1}\r\n", p_csc.ExitCode, cscerror);
			}

			Process p_prog = new Process
			{
				StartInfo =
				{
					FileName = fn2,
					Arguments = string.Empty,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true,
					ErrorDialog = false
				}
			};

			p_prog.Start();
			string output = p_prog.StandardOutput.ReadToEnd();
			p_prog.WaitForExit();

			File.Delete(fn1);
			File.Delete(fn2);

			if (p_prog.ExitCode != 0)
			{
				return string.Format("FAILURE (PROG ExitCode  = {0}): {1}\r\n", p_prog.ExitCode, output);
			}

			return output;
		}
	}
}
