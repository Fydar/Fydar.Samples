namespace Fydar.Samples.Rendering.Themes.Selectors;

public sealed class ClassSelectorElement : Selector
{
	public string ClassName { get; set; }

	public ClassSelectorElement(string className)
	{
		ClassName = className;
	}
}
