namespace Fydar.Samples.Rendering.Themes;

public class Theme
{
	public TextStyleLibrary TextStyleLibrary { get; }

	internal Theme(TextStyleLibrary textStyleLibrary)
	{
		TextStyleLibrary = textStyleLibrary;
	}

	public static ThemeBuilder Create()
	{
		return new ThemeBuilder();
	}
}
