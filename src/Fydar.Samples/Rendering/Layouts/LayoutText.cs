using System;

namespace Fydar.Samples.Rendering.Layouts;

public class LayoutText : ILayoutElement
{
	public string[] Styles { get; }
	public string Content { get; }

	internal LayoutText(string[] styles, string content)
	{
		Styles = styles;
		Content = content;
	}

	public static LayoutTextBuilder New()
	{
		return new LayoutTextBuilder();
	}

	public static LayoutTextBuilder New(Action<LayoutTextBuilder> construct)
	{
		var builder = new LayoutTextBuilder();
		construct.Invoke(builder);
		return builder;
	}
}
