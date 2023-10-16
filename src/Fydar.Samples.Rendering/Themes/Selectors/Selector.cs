namespace Fydar.Samples.Rendering.Themes.Selectors;

public abstract class Selector
{
	public static implicit operator Selector(string text)
	{
		return Parse(text);
	}

	public static Selector Parse(string text)
	{
		// TODO: Parse the selectors.
		return new ClassSelectorElement(text);
	}
}
