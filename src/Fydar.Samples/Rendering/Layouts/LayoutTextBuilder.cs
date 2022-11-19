using System;
using System.Linq;

namespace Fydar.Samples.Rendering.Layouts;

public class LayoutTextBuilder : LayoutElementBuilder
{
	public string Text { get; set; } = string.Empty;

	public LayoutTextBuilder Mutate(Action<LayoutTextBuilder> construct)
	{
		construct.Invoke(this);
		return this;
	}

	public override ILayoutElement Build()
	{
		return new LayoutText(Styles.ToArray(), Text);
	}
}
