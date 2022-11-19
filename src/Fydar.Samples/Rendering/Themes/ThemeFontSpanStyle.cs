namespace Fydar.Samples.Rendering.Themes;

public class ThemeFontSpanStyle
{
	public string? InheritFrom { get; init; }

	/// <summary>
	/// A string (typically hexadecimal) used to describe the foreground color of the text.
	/// </summary>
	public string? FontColor { get; init; }

	public string? FontWeight { get; init; }

	public FontStyle? FontStyle { get; init; }

	public TextDecorationStyle? TextDecorationStyle { get; init; }

	public TextDecorationLine? TextDecorationLine { get; init; }

	public string? TextDecorationColor { get; init; }
}
