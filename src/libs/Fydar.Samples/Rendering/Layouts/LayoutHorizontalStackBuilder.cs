using System;
using System.Linq;

namespace Fydar.Samples.Rendering.Layouts;

public class LayoutHorizontalStackBuilder : LayoutStackBuilder
{
	public LayoutHorizontalStackBuilder Mutate(Action<LayoutHorizontalStackBuilder> construct)
	{
		construct.Invoke(this);
		return this;
	}

	public override ILayoutElement Build()
	{
		return new LayoutHorizontalStack(Styles.ToArray(), Elements.ToArray());
	}
}
