using System.Diagnostics;

namespace BefunGen
{
	[DebuggerDisplay("{ID}")]
	public class PocVertex
	{
		public string ID { get; private set; }
		public bool isLeaf { get; private set; }
		public bool isRoot { get; private set; }

		public PocVertex(string id, bool leaf, bool root)
		{
			ID = id;
			isLeaf = leaf;
			isRoot = root;
		}

		public override string ToString()
		{
			return string.Format("{0}", ID);
		}
	}
}
