using Fydar.Samples.Rendering.Internal;
using Fydar.Samples.Rendering.Layouts;
using Fydar.Samples.Rendering.Themes;
using System;
using System.Diagnostics;

namespace Fydar.Samples.Rendering;

public class GraphicPermutationGroups
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Graphic[] permutations;

	public string Name { get; }

	public ReadOnlySpan<Graphic> Permutations => permutations;
}


public class Graphic
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Graphic[] permutations;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GraphicPermutationGroups[] permutationGroups;

	public string Name { get; }

	public string FullName { get; }

	public Sample Sample { get; }

	public Theme Theme { get; set; }

	public Layout Layout { get; set; }

	public ReadOnlySpan<Graphic> Permutations => permutations;

	public ReadOnlySpan<GraphicPermutationGroups> PermutationGroups => permutationGroups;

	internal Graphic(
		string name,
		string fullName,
		Sample sample,
		Theme theme,
		Layout layout,
		Graphic[] permutations,
		GraphicPermutationGroups[] permutationGroups)
	{
		this.permutations = permutations;
		this.permutationGroups = permutationGroups;

		Name = name;
		FullName = fullName;
		Sample = sample;
		Theme = theme;
		Layout = layout;
	}

	public static IGraphicBuilder Create(Sample sample)
	{
		return new GraphicBuilder(sample);
	}

	public static Graphic Create(Sample sample, Action<IGraphicBuilder> factory)
	{
		var builder = new GraphicBuilder(sample);
		factory.Invoke(builder);
		return builder.Build();
	}
}
