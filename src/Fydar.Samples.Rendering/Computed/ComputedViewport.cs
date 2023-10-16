using Fydar.Samples.Rendering.Layouts;
using Fydar.Samples.Rendering.Themes;
using System;

namespace Fydar.Samples.Rendering.Computed;

public class ComputedViewport : IComputedElement
{
	public int Width { get; set; } = 128;
	public int Height { get; set; } = 128;
	public IComputedElement[] ChildElements { get; set; } = Array.Empty<IComputedElement>();

	public static ComputedViewport Compute(Layout layout, Theme theme)
	{

		return new ComputedViewport()
		{

		};
	}

	private static IComputedElement[] ComputeRecursive(ILayoutElement layoutElement, Theme theme)
	{
		if (layoutElement is LayoutBox)
		{
			return new IComputedElement[] { new ComputedElementBox()
			{

			}};
		}

		return Array.Empty<IComputedElement>();
	}
}
