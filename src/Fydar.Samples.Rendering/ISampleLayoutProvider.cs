using Fydar.Samples.Rendering;
using Fydar.Samples.Rendering.Layouts;
using Fydar.Samples.Rendering.Themes;

namespace Fydar.Samples;

public interface ISampleLayoutProvider
{
	public string Name { get; }

	public Layout CreateLayout(Sample sample, Theme theme);
}
