using System;

namespace Fydar.Samples.Rendering.ComputedElements;

public class ComputedElementBox : IComputedElement
{
	public ComputedElementRect DocumentRect { get; set; }

	public ComputedElementBorder BorderTop { get; set; }
	public ComputedElementBorder BorderBottom { get; set; }
	public ComputedElementBorder BorderLeft { get; set; }
	public ComputedElementBorder BorderRight { get; set; }

	public ComputedElementBorderCorner BorderCornerTopLeft { get; set; }
	public ComputedElementBorderCorner BorderCornerTopRight { get; set; }
	public ComputedElementBorderCorner BorderCornerBottomLeft { get; set; }
	public ComputedElementBorderCorner BorderCornerBottomRight { get; set; }

	public ComputedElementBackground Background { get; set; }
	public ComputedElementBoxShadow[] BoxShadows { get; set; } = Array.Empty<ComputedElementBoxShadow>();

	public IComputedElement[] ChildElements { get; set; } = Array.Empty<IComputedElement>();
}
