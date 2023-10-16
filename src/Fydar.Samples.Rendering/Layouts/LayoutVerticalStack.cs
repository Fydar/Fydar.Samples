using System;
using System.Linq;

namespace Fydar.Samples.Rendering.Layouts;

public class LayoutVerticalStack : ILayoutElement
{
	public string[] Styles { get; }
	public ILayoutElement[] Elements { get; }

	internal LayoutVerticalStack(string[] styles, LayoutElementBuilder[] elements)
	{
		Styles = styles;
		Elements = elements
			.Select(e => e.Build())
			.ToArray();
	}
}
