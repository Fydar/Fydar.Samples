using System;
using System.Linq;

namespace Fydar.Samples.Rendering.Layouts;

public class LayoutVerticalStackBuilder : LayoutStackBuilder
{
	public LayoutVerticalStackBuilder Mutate(Action<LayoutVerticalStackBuilder> construct)
	{
		construct.Invoke(this);
		return this;
	}

	public override ILayoutElement Build()
	{
		return new LayoutVerticalStack(Styles.ToArray(), Elements.ToArray());
	}
}
