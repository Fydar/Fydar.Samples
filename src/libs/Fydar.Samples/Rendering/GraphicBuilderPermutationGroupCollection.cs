using System.Collections.Generic;

namespace Fydar.Samples.Rendering;

public class GraphicBuilderPermutationGroupCollection
{
	internal IGraphicBuilder graphicBuilder;

	internal readonly Dictionary<string, GraphicBuilderPermutationGroup> mutationGroups;

	public GraphicBuilderPermutationGroup this[string name]
	{
		get
		{
			if (!mutationGroups.TryGetValue(name, out var mutationGroup))
			{
				mutationGroup = new GraphicBuilderPermutationGroup();
				mutationGroups[name] = mutationGroup;
			}
			return mutationGroup;
		}
	}

	internal GraphicBuilderPermutationGroupCollection(IGraphicBuilder graphicBuilder)
	{
		this.graphicBuilder = graphicBuilder;
		mutationGroups = new();
	}
}
