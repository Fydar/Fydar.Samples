namespace Fydar.Samples.Rendering.Themes;

public class ThemeFontSpanStyle
{
	public string? InheritFrom { get; set; }

	/// <summary>
	/// A string (typically hexadecimal) used to describe the foreground color of the text.
	/// </summary>
	public string? FontColor { get; set; }

	public string? FontWeight { get; set; }

	public FontStyle? FontStyle { get; set; }

	public TextDecorationStyle? TextDecorationStyle { get; set; }

	public TextDecorationLine? TextDecorationLine { get; set; }

	public string? TextDecorationColor { get; set; }
}
