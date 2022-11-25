using System;

namespace Fydar.Samples.Rendering.Layouts;

public class LayoutCodeBlock : ILayoutElement
{
	public string[] Styles { get; }
	public bool ShowLineNumbers { get; }

	internal LayoutCodeBlock(string[] styles, bool showLineNumbers = true)
	{
		Styles = styles;
		ShowLineNumbers = showLineNumbers;
	}

	public static LayoutCodeBlockBuilder New()
	{
		return new LayoutCodeBlockBuilder();
	}

	public static LayoutCodeBlockBuilder New(Action<LayoutCodeBlockBuilder> construct)
	{
		var builder = new LayoutCodeBlockBuilder();
		construct.Invoke(builder);
		return builder;
	}
}
