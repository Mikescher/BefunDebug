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

			List<PocVertex> existingVertices = new List<PocVertex>();
			existingVertices.Add(new PocVertex("Sacha Barber")); //0
			existingVertices.Add(new PocVertex("Sarah Barber")); //1
			existingVertices.Add(new PocVertex("Marlon Grech")); //2
			existingVertices.Add(new PocVertex("Daniel Vaughan")); //3
			existingVertices.Add(new PocVertex("Bea Costa")); //4

			foreach (PocVertex vertex in existingVertices)
				Graph.AddVertex(vertex);

			//add some edges to the graph
			AddNewGraphEdge(existingVertices[0], existingVertices[1]);
			AddNewGraphEdge(existingVertices[0], existingVertices[2]);
			AddNewGraphEdge(existingVertices[0], existingVertices[3]);
			AddNewGraphEdge(existingVertices[0], existingVertices[4]);

			AddNewGraphEdge(existingVertices[1], existingVertices[0]);
			AddNewGraphEdge(existingVertices[1], existingVertices[2]);
			AddNewGraphEdge(existingVertices[1], existingVertices[3]);

			AddNewGraphEdge(existingVertices[2], existingVertices[0]);
			AddNewGraphEdge(existingVertices[2], existingVertices[1]);
			AddNewGraphEdge(existingVertices[2], existingVertices[3]);
			AddNewGraphEdge(existingVertices[2], existingVertices[4]);

			AddNewGraphEdge(existingVertices[3], existingVertices[0]);
			AddNewGraphEdge(existingVertices[3], existingVertices[1]);
			AddNewGraphEdge(existingVertices[3], existingVertices[3]);
			AddNewGraphEdge(existingVertices[3], existingVertices[4]);

			AddNewGraphEdge(existingVertices[4], existingVertices[0]);
			AddNewGraphEdge(existingVertices[4], existingVertices[2]);
			AddNewGraphEdge(existingVertices[4], existingVertices[3]);

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

		#region Private Methods

		private PocEdge AddNewGraphEdge(PocVertex from, PocVertex to)
		{
			string edgeString = string.Format("{0}-{1} Connected", from.ID, to.ID);

			PocEdge newEdge = new PocEdge(edgeString, from, to);
			Graph.AddEdge(newEdge);
			return newEdge;
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
	}
}
