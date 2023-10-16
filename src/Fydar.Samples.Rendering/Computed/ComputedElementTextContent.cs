using System;

namespace Fydar.Samples.Rendering.Computed;

public class ComputedElementTextContent : IComputedElement
{
	public ComputedElementRect DocumentRect { get; set; }
	public ComputedElementTextContentSpan[] Spans { get; set; } = Array.Empty<ComputedElementTextContentSpan>();

	IComputedElement[] IComputedElement.ChildElements => Array.Empty<IComputedElement>();
}
