using Fydar.Samples.Rendering.Layouts;
using Fydar.Samples.Rendering.Themes;

namespace Fydar.Samples.Rendering;

public class SampleRenderer
{
	public ThemeBuilder Theme { get; }
	public Layout Layout { get; }
	public object Model { get; }
}

public class SampleRenderer<TModel>
{
	public ThemeBuilder Theme { get; }
	public Layout Layout { get; }
	public TModel Model { get; }
}
