using Fydar.Samples.Rendering.Layouts;
using Fydar.Samples.Rendering.Themes;
using System;
using System.Collections.Generic;

namespace Fydar.Samples.Rendering.Internal;

internal class GraphicBuilder : IGraphicBuilder
{
	private readonly List<GraphicBuilderPermutationCallback> permutations = new();

	public string Name { get; set; }

	public Sample Sample { get; set; }

	public Theme Theme { get; set; }

	public ISampleLayoutProvider? LayoutProvider { get; set; }

	public GraphicBuilderPermutationGroupCollection PermutationGroups { get; }

	public event GraphicBuilderPermutationCallback Permutations
	{
		add => permutations.Add(value);
		remove => permutations.Remove(value);
	}

	public GraphicBuilder(Sample sample)
	{
		Sample = sample;
		PermutationGroups = new GraphicBuilderPermutationGroupCollection(this);
	}

	public int Count
	{
		get
		{
			int current = 1;

			for (int i = 0; i < permutations.Count; i++)
			{
				current *= 2;
			}

			foreach (var mutationGroup in PermutationGroups.mutationGroups)
			{
				current *= mutationGroup.Value.permutations.Count;
			}

			return current;
		}
	}

	public Graphic Build()
	{
		var factoryForThis = () =>
		{
			return new Graphic(Name, Name, Sample, Theme, null, null, null);
		};

		int[] indexes = new int[permutations.Count + PermutationGroups.mutationGroups.Count];

		for (int c = 0; c < Count; c++)
		{
			int tally = c;

			// yield return new MatrixSet(this, indexes);

			int r = 0;
			for (int i = 0; i < permutations.Count; i++)
			{
				r++;
			}

			foreach (var mutationGroup in PermutationGroups.mutationGroups)
			{
				current *= mutationGroup.Value.permutations.Count;
				r++;
			}



			for (int j = 0; j < indexes.Length; j++)
			{
				var matrix = Matrix[j];

				indexes[j] = tally % matrix.Count;
				tally /= matrix.Count;
			}
		}


		foreach (var permutation in permutations)
		{
		}

		return new Graphic(Name, Name, Sample, Theme, null, null, null);
	}

	public void PostProcess<TLayoutElement>(Action<TLayoutElement> value)
		where TLayoutElement : ILayoutElement
	{

	}
}
