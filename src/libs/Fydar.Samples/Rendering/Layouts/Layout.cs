using System.Diagnostics;

namespace Fydar.Samples.Rendering.Layouts;

public class Layout
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ILayoutElement rootElement;

	public ILayoutElement RootElement => rootElement;

	internal Layout(LayoutBuilderOptions layoutBuilderOptions)
	{
		rootElement = layoutBuilderOptions.RootElement.Build();
	}

	public static LayoutBuilder Create()
	{
		return new LayoutBuilder();
	}
}
