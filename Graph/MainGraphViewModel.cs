using BefunCompile.Graph;
using BefunCompile.Graph.Vertex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BefunGen
{
	public class MainGraphViewModel : INotifyPropertyChanged
	{
		private BCGraph bcGraph;

		#region Data
		private string layoutAlgorithmType;
		private string graphInfo;
		private PocGraph graph;
		private List<String> layoutAlgorithmTypes = new List<string>();
		#endregion

		#region Ctor
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
		#endregion

		#region Public Properties

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

		public string GInfo
		{
			get { return graphInfo; }
			set
			{
				graphInfo = value;
				NotifyPropertyChanged("GInfo");
			}
		}

		public PocGraph Graph
		{
			get { return graph; }
			set
			{
				graph = value;
				NotifyPropertyChanged("Graph");
				updateInfo();
			}
		}
		#endregion

		#region INotifyPropertyChanged Implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		#endregion

		public void loadGraph(BCGraph g)
		{
			var ng = new PocGraph();

			Dictionary<BCVertex, PocVertex> dic = new Dictionary<BCVertex, PocVertex>();

			foreach (var vertex in g.Vertices)
			{
				var vx = new PocVertex(vertex.ToString(), vertex.Children.Count == 0, vertex == g.Root, vertex.IsBlock());

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

		private void updateInfo()
		{
			var vertices = bcGraph.Vertices.Count;
			var nops = bcGraph.Vertices.Count(p => p is BCVertexNOP);
			var leafs = bcGraph.Vertices.Count(p => p.Children.Count == 0);
			var constIO = bcGraph.ListConstantVariableAccess().Count();
			var dynIO = bcGraph.ListDynamicVariableAccess().Count();
			var vars = bcGraph.Variables.Count;
			var positions = bcGraph.GetAllCodePositions();

			GInfo = string.Format("{0} {1}.  {2} {3}.  {4} {5}. {6} const IO Access. {7} dynamic IO Access. {8} {9}. {10} program size.",
				vertices, (vertices == 1) ? "Vertex" : "Vertices",
				nops, (nops == 1) ? "NOP" : "NOPs",
				leafs, (leafs == 1) ? "Leaf" : "Leafs",
				constIO,
				dynIO,
				vars, (vars == 1) ? "Variable" : "Variables",
				positions.Count);
		}
	}
}
