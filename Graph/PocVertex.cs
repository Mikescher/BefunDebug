using System.Diagnostics;

namespace BefunGen
{
	[DebuggerDisplay("{ID}")]
	public class PocVertex
	{
		public string ID { get; private set; }

		public PocVertex(string id)
		{
			ID = id;
		}

		public override string ToString()
		{
			return string.Format("{0}", ID);
		}
	}
}
