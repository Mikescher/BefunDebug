using BefunCompile.Graph;
using System.Diagnostics;

namespace BefunDebug.Graph
{
	[DebuggerDisplay("{ID}")]
	public class PocVertex
	{
		public BCVertex Vertex;

		public string ID { get; private set; }
		public bool isLeaf { get; private set; }
		public bool isRoot { get; private set; }
		public bool isBlock { get; private set; }

		public PocVertex(BCVertex v, string id, bool leaf, bool root, bool block)
		{
			Vertex = v;

			ID = id;
			isLeaf = leaf;
			isRoot = root;
			isBlock = block;
		}

		public override string ToString()
		{
			return string.Format("{0}", ID);
		}
	}
}
