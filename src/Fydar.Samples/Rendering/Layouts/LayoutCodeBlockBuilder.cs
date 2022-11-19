using System;
using System.Linq;

namespace Fydar.Samples.Rendering.Layouts;

public class LayoutCodeBlockBuilder : LayoutElementBuilder
{
	public bool ShowLineNumbers { get; set; } = true;

	public LayoutCodeBlockBuilder Mutate(Action<LayoutCodeBlockBuilder> construct)
	{
		construct.Invoke(this);
		return this;
	}

	public override ILayoutElement Build()
	{
		return null;
		//if (Tokens == null)
		//{
		//	throw new InvalidOperationException("Cannot build a code block that does not have any tokens.");
		//}
		//return new LayoutCodeBlock(Styles.ToArray(), Tokens, ShowLineNumbers);
	}
}
