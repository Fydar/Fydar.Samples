using System;

namespace Fydar.Samples.Rendering.Themes;

public class ThemeBuilder
{
	private readonly TextStyleLibraryBuilder textStyleLibraryBuilder;

	internal ThemeBuilder()
	{
		textStyleLibraryBuilder = new TextStyleLibraryBuilder();
	}

	public ThemeBuilder ConfigureTextStyles(Action<TextStyleLibraryBuilder> options)
	{
		options.Invoke(textStyleLibraryBuilder);

		return this;
	}

	public Theme Build()
	{
		return new Theme(
			textStyleLibraryBuilder.Build());
	}
}
