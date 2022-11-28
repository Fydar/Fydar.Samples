namespace Fydar.Samples.Rendering.Themes;

public class Theme
{
	public string Name { get; }

	public TextStyleLibrary TextStyleLibrary { get; }

	internal Theme(
		string name,
		TextStyleLibrary textStyleLibrary)
	{
		Name = name;
		TextStyleLibrary = textStyleLibrary;
	}

	public static ThemeBuilder Create(string name)
	{
		return new ThemeBuilder(name);
	}
}
