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
			bcGraph = new BCGraph();
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

			foreach (var vertex in g.vertices)
			{
				var vx = new PocVertex(vertex.ToString(), vertex.children.Count == 0, vertex == g.root);

				ng.AddVertex(vx);
				dic.Add(vertex, vx);
			}

			foreach (var vertex in g.vertices)
			{
				foreach (var child in vertex.children)
				{
					ng.AddEdge(new PocEdge("", dic[vertex], dic[child]));
				}
			}

			bcGraph = g;
			Graph = ng;
		}

		private void updateInfo()
		{
			var vertices = bcGraph.vertices.Count;
			var nops = bcGraph.vertices.Count(p => p is BCVertexNOP);
			var leafs = bcGraph.vertices.Count(p => p.children.Count == 0);

			GInfo = string.Format("{0} {1}.  {2} {3}.  {4} {5}",
				vertices, (vertices == 1) ? "Vertex" : "Vertices",
				nops, (nops == 1) ? "NOP" : "NOPs",
				leafs, (leafs == 1) ? "Leaf" : "Leafs");
		}
	}
}
