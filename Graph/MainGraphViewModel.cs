using BefunCompile.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BefunGen
{
	public class MainGraphViewModel : INotifyPropertyChanged
	{
		#region Data
		private string layoutAlgorithmType;
		private PocGraph graph;
		private List<String> layoutAlgorithmTypes = new List<string>();
		#endregion

		#region Ctor
		public MainGraphViewModel()
		{
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

		public PocGraph Graph
		{
			get { return graph; }
			set
			{
				graph = value;
				NotifyPropertyChanged("Graph");
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

			Graph = ng;
		}
	}
}
