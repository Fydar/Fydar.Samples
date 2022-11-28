using System;

namespace Fydar.Samples.Rendering.Layouts;

public class LayoutBox : ILayoutElement
{
	public string[] Styles { get; }
	public ILayoutElement? Content { get; }

	internal LayoutBox(string[] styles, LayoutElementBuilder? content)
	{
		Styles = styles;
		Content = content?.Build();
	}
}
