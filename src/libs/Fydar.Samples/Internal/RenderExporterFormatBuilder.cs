using Fydar.Samples.Rendering.Format.AsSvg;

namespace Fydar.Samples.Internal;

internal class RenderExporterFormatBuilder : IRenderExporterFormatBuilder
{
	public string Extension { get; set; } = string.Empty;

	public IRenderFormatter Formatter { get; set; }

	internal RenderExporterFormatBuilder()
	{
		Formatter = SvgRenderFormatter.Instance;
	}
}
