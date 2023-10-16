using System;

namespace Fydar.Samples.Rendering.Themes;

public class ThemeLinearGradientFill : IThemeFill
{

	public float Angle { get; set; }

	public ThemeGradientKeyframe[] Keyframes { get; set; } = Array.Empty<ThemeGradientKeyframe>();
}
