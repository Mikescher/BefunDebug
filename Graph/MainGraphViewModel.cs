using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BefunCompile.Graph;
using BefunCompile.Graph.Vertex;
using System.Text;

namespace BefunDebug.Graph
{
	public class MainGraphViewModel : INotifyPropertyChanged
	{
		private BCGraph bcGraph;

		private string layoutAlgorithmType;
		private string graphInfo = "";
		private string vertexInfo = "";
		private PocGraph graph;
		private List<String> layoutAlgorithmTypes = new List<string>();

		private PocVertex _selectedVertex;
		public PocVertex SelectedVertex
		{
			get { return _selectedVertex; }
			set { _selectedVertex = value; OnSelectionChanged(); }
		}

		public MainGraphViewModel()
		{
			bcGraph = new BCGraph(new long[,] { { } }, 0, 0);
			Graph = new PocGraph(true);

			//Add Layout Algorithm Types
			layoutAlgorithmTypes.Add("BoundedFR");
			layoutAlgorithmTypes.Add("Circular");
			layoutAlgorithmTypes.Add("CompoundFDP");
			layoutAlgorithmTypes.Add("EfficientSugiyama");
			layoutAlgorithmTypes.Add("FR");
			layoutAlgorithmTypes.Add("ISOM");
			layoutAlgorithmTypes.Add("KK");
			layoutAlgorithmTypes.Add("LinLog");
			layoutAlgorithmTypes.Add("Tree");

			//Pick a default Layout Algorithm Type
			LayoutAlgorithmType = "KK";
		}

		public List<String> LayoutAlgorithmTypes
		{
			get { return layoutAlgorithmTypes; }
		}

		public string LayoutAlgorithmType
		{
			get { return layoutAlgorithmType; }
			set
			{
				layoutAlgorithmType = value;
				NotifyPropertyChanged("LayoutAlgorithmType");
			}
		}

		public string GInfo1
		{
			get { return graphInfo; }
			set
			{
				graphInfo = value;
				NotifyPropertyChanged("GInfo1");
			}
		}

		public string GInfo2
		{
			get { return vertexInfo; }
			set
			{
				vertexInfo = value;
				NotifyPropertyChanged("GInfo2");
			}
		}

		public PocGraph Graph
		{
			get { return graph; }
			set
			{
				graph = value;
				NotifyPropertyChanged("Graph");
				UpdateInfo();
				SelectedVertex = null;
			}
		}
		
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string info)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
		}

		public void LoadGraph(BCGraph g)
		{
			var ng = new PocGraph();

			Dictionary<BCVertex, PocVertex> dic = new Dictionary<BCVertex, PocVertex>();

			foreach (var vertex in g.Vertices)
			{
				var vx = new PocVertex(vertex, vertex.ToString(), vertex.Children.Count == 0, vertex == g.Root, vertex.IsBlock());

				ng.AddVertex(vx);
				dic.Add(vertex, vx);
			}

			foreach (var vertex in g.Vertices)
			{
				foreach (var child in vertex.Children)
				{
					ng.AddEdge(new PocEdge("", dic[vertex], dic[child]));
				}
			}

			bcGraph = g;
			Graph = ng;
		}

		private void UpdateInfo()
		{
			var vertices = bcGraph.Vertices.Count;
			var nops = bcGraph.Vertices.Count(p => p is BCVertexNOP);
			var leafs = bcGraph.Vertices.Count(p => p.Children.Count == 0);
			var constIO = bcGraph.ListConstantVariableAccess().Count();
			var dynIO = bcGraph.ListDynamicVariableAccess().Count();
			var vars = bcGraph.Variables.Count;
			var vars_user = bcGraph.Variables.Count(p => p.isUserDefinied);
			var vars_system = bcGraph.Variables.Count(p => !p.isUserDefinied);
			var stackacc = bcGraph.Vertices.Count(p => p.IsStackAccess());
			var varacc = bcGraph.Vertices.Count(p => p.IsVariableAccess());
			var positions = bcGraph.GetAllCodePositions();

			GInfo1 = string.Format("{0} {1}.  {2} {3}.  {4} {5}." + "\r\n"
								+ "{6} const IO Access. {7} dynamic IO Access." + "\r\n"
								+ "{8} {9} ({10} user + {11} system)." + "\r\n"
								+ "{12} stack access. {13} variable access." + "\r\n"
								+ "{14} program size.",
				vertices,
				(vertices == 1) ? "Vertex" : "Vertices",
				nops,
				(nops == 1) ? "NOP" : "NOPs",
				leafs,
				(leafs == 1) ? "Leaf" : "Leafs",
				constIO,
				dynIO,
				vars,
				(vars == 1) ? "Variable" : "Variables",
				vars_user,
				vars_system,
				stackacc,
				varacc,
				positions.Count);
		}

		private void OnSelectionChanged()
		{
			if (SelectedVertex == null) { GInfo2 = ""; return; }

			var v = SelectedVertex.Vertex;

			StringBuilder b = new StringBuilder();

			b.AppendLine($"Type: {v.GetType().Name}");
			b.AppendLine($"SideEffects: {v.GetSideEffects()}");

			b.Append($"{"Positions:",-9}");
			int i = 1;
			foreach (var p in v.Positions)
			{
				if (i++ % 5 == 0) b.AppendLine();
				b.Append($" [{p.X,+3}|{p.Y,-3}]");
			}
			b.AppendLine();

			GInfo2 = b.ToString();
		}
	}
}
