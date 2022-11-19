using System;

namespace Fydar.Samples.Rendering.ComputedElements;

public class ComputedElementTextStyle
{
	public string Identifier { get; set; } = string.Empty;
	public double FontSize { get; set; }
	public string Color { get; set; } = string.Empty;
	public ComputedElementTextStyleDecoration[] Decorations { get; set; } = Array.Empty<ComputedElementTextStyleDecoration>();
}
