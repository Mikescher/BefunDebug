using BefunCompile;
using BefunCompile.CodeGeneration.Generator;
using BefunCompile.Graph.Vertex;
using BefunDebug.BCTestData;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BefunDebug.ThreadRunner
{
	class CompileOverviewGenerator : ThreadRunner<BefunCompileTestData.BCData[]>
	{
		private readonly TextBox outputBox;

		public CompileOverviewGenerator(TextBox box, Button caller) : base(caller)
		{
			outputBox = box;
		}

		protected override string GetButtonTextStart(BefunCompileTestData.BCData[] data) => "Generate Overview";

		protected override string GetButtonTextStop(BefunCompileTestData.BCData[] data) => "Stop generating Overview";

		protected override bool RunAction(BefunCompileTestData.BCData[] datas)
		{
			string row = "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-15} | {5,-15} | {6,-10} | {7,-10} | {8,-10} | {9,-10} | {10,-10} | {11,-35} | {12,-10}";

			string header = string.Format(row, "Name", "Vertices", "NOPs", "Leafs", "const IO Acc", "dyn. IO Acc", "userVar", "systemVar", "Stack Acc", "Var Acc", "Size", "Cycles", "Time (ms)");

			OutputLine(outputBox, header);
			OutputLine(outputBox, new string('-', header.Length));

			foreach (var data in datas)
			{
				long swTime = Environment.TickCount;

				var compiler = new BefunCompiler(data.Code, true, new CodeGeneratorOptions(false, true, true, true, false));
				var graph = compiler.GenerateGraph();

				swTime = Environment.TickCount - swTime;

				var cellName = data.Name;
				var cellVertices = graph.Vertices.Count;
				var cellNops = graph.Vertices.Count(p => p is BCVertexNOP);
				var cellLeafs = graph.Vertices.Count(p => p.Children.Count == 0);
				var cellConstIOAcc = graph.ListConstantVariableAccess().Count();
				var cellDynIOAcc = graph.ListDynamicVariableAccess().Count();
				var cellUservar = graph.Variables.Count(p => p.isUserDefinied);
				var cellSysvar = graph.Variables.Count(p => !p.isUserDefinied);
				var cellSysscopes = graph.Variables.Where(p => !p.isUserDefinied).Sum(p => p.Scope.Count);
				var cellSystotal = string.Format("{0,-3} ({1})", cellSysvar, cellSysscopes);
				var cellStackAcc = graph.Vertices.Count(p => p.IsStackAccess());
				var cellVarAcc = graph.Vertices.Count(p => p.IsVariableAccess());
				var cellSize = graph.GetAllCodePositions().Count;
				var cellCycles = string.Join(" ", compiler.LogCycles.Select(p => string.Format("{0,3}", p)));
				var cellTime = swTime.ToString();

				var line = string.Format(row,
					cellName, cellVertices, cellNops, cellLeafs, cellConstIOAcc, cellDynIOAcc,
					cellUservar, cellSystotal, cellStackAcc, cellVarAcc, cellSize, cellCycles, cellTime);

				OutputLine(outputBox, line);

				if (ForceStop) return false;
			}

			return true;
		}
	}
}
