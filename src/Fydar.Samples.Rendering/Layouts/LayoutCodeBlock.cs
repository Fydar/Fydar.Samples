namespace Fydar.Samples.Rendering.Layouts;

public class LayoutCodeBlock : ILayoutElement
{
	public string[] Styles { get; set; }
	public bool ShowLineNumbers { get; set; }

	internal LayoutCodeBlock(string[] styles, bool showLineNumbers = true)
	{
		Styles = styles;
		ShowLineNumbers = showLineNumbers;
	}
}
