using System;
using System.Linq;

namespace Fydar.Samples.Rendering.Layouts;

public class LayoutBoxBuilder : LayoutElementBuilder
{
	public LayoutElementBuilder? Content { get; set; }

	public LayoutBoxBuilder Mutate(Action<LayoutBoxBuilder> construct)
	{
		construct.Invoke(this);
		return this;
	}

	public override ILayoutElement Build()
	{
		return new LayoutBox(Styles.ToArray(), Content);
	}
}
