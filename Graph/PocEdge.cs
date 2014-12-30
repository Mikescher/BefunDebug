﻿using QuickGraph;
using System.Diagnostics;

namespace BefunGen
{
	[DebuggerDisplay("{Source.ID} -> {Target.ID}")]
	public class PocEdge : Edge<PocVertex>
	{
		public string ID
		{
			get;
			private set;
		}

		public PocEdge(string id, PocVertex source, PocVertex target)
			: base(source, target)
		{
			ID = id;
		}
	}
}
