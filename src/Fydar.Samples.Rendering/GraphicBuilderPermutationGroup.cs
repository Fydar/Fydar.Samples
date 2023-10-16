using System.Collections.Generic;
using System.Diagnostics;

namespace Fydar.Samples.Rendering;

public class GraphicBuilderPermutationGroup
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly List<GraphicBuilderPermutationCallback> permutations = new();

	public event GraphicBuilderPermutationCallback Permutations
	{
		add => permutations.Add(value);
		remove => permutations.Remove(value);
	}
}
