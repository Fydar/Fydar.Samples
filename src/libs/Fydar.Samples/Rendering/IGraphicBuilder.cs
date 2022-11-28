using Fydar.Samples.Rendering.Layouts;
using Fydar.Samples.Rendering.Themes;
using System;

namespace Fydar.Samples.Rendering;

public interface IGraphicBuilder
{
	public string Name { get; set; }

	public Sample Sample { get; set; }

	public Theme Theme { get; set; }

	public ISampleLayoutProvider? LayoutProvider { get; set; }

	public GraphicBuilderPermutationGroupCollection PermutationGroups { get; }


	public event GraphicBuilderPermutationCallback Permutations;

	public void PostProcess<TLayoutElement>(Action<TLayoutElement> value)
		where TLayoutElement : ILayoutElement;

	public Graphic Build();
}
