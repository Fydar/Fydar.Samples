using System;

namespace Fydar.Samples.Rendering.Themes;

public class ThemeBuilder
{
	private readonly string name;
	private readonly TextStyleLibraryBuilder textStyleLibraryBuilder;

	internal ThemeBuilder(string name)
	{
		this.name = name;
		textStyleLibraryBuilder = new TextStyleLibraryBuilder();
	}

	public ThemeBuilder Configure<TStyle>(Action<TStyle> style)
	{


		return this;
	}

	public ThemeBuilder Configure<TStyle>(string key, Action<TStyle> style)
	{


		return this;
	}

	public Theme Build()
	{
		return new Theme(
			name,
			textStyleLibraryBuilder.Build());
	}

	public static implicit operator Theme(ThemeBuilder builder)
	{
		return builder.Build();
	}
}
