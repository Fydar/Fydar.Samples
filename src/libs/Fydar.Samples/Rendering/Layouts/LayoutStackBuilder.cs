using System.Collections.Generic;
using System.Linq;

namespace Fydar.Samples.Rendering.Layouts;

public abstract class LayoutStackBuilder : LayoutElementBuilder
{
	public List<LayoutElementBuilder> Elements { get; set; } = new();

	public override ILayoutElement Build()
	{
		return new LayoutHorizontalStack(Styles.ToArray(), Elements.ToArray());
	}
}
