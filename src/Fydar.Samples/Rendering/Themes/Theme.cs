using System.Collections.Generic;

namespace Fydar.Samples.Rendering.Themes;

public class Theme
{
	public Dictionary<string, ThemeFontSpanStyle> FontStyles { get; init; } = new();
}
