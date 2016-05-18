﻿using QuickGraph;

namespace BefunDebug.Graph
{
	public class PocGraph : BidirectionalGraph<PocVertex, PocEdge>
	{
		public PocGraph() { }

		public PocGraph(bool allowParallelEdges)
			: base(allowParallelEdges) { }

		public PocGraph(bool allowParallelEdges, int vertexCapacity)
			: base(allowParallelEdges, vertexCapacity) { }
	}
}
