using System.Diagnostics;

namespace Fydar.Samples.Rendering.Layouts;

public class Layout
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ILayoutElement rootElement;

	public ILayoutElement RootElement { get; set; } = new LayoutVerticalStack(new string[0], new LayoutElementBuilder[0]);
}
