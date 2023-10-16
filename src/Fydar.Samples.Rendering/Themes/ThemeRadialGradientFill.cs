using System;

namespace Fydar.Samples.Rendering.Themes;

public class ThemeRadialGradientFill : IThemeFill
{

	public float PositionX { get; set; }

	public float PositionY { get; set; }

	public ThemeGradientKeyframe[] Keyframes { get; set; } = Array.Empty<ThemeGradientKeyframe>();
}
