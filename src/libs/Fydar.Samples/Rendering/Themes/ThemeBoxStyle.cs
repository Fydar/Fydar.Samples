using System;

namespace Fydar.Samples.Rendering.Themes;

public class ThemeBoxStyle
{
	public int? PaddingTop { get; set; }
	public int? PaddingBottom { get; set; }
	public int? PaddingLeft { get; set; }
	public int? PaddingRight { get; set; }

	public IThemeFill[] Background { get; set; } = Array.Empty<IThemeFill>();
}
