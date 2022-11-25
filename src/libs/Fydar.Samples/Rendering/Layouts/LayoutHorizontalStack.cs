using System;
using System.Linq;

namespace Fydar.Samples.Rendering.Layouts;

public class LayoutHorizontalStack : ILayoutElement
{
	public string[] Styles { get; }
	public ILayoutElement[] Elements { get; }

	internal LayoutHorizontalStack(string[] styles, LayoutElementBuilder[] elements)
	{
		Styles = styles;
		Elements = elements
			.Select(e => e.Build())
			.ToArray();
	}

	public static LayoutHorizontalStackBuilder New()
	{
		return new LayoutHorizontalStackBuilder();
	}

	public static LayoutHorizontalStackBuilder New(Action<LayoutHorizontalStackBuilder> construct)
	{
		var builder = new LayoutHorizontalStackBuilder();
		construct.Invoke(builder);
		return builder;
	}
}
