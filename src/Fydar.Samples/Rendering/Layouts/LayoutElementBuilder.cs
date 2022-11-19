using System.Collections.Generic;

namespace Fydar.Samples.Rendering.Layouts;

public abstract class LayoutElementBuilder
{
	public HashSet<string> Styles { get; set; } = new();

	public abstract ILayoutElement Build();
}
