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
}
