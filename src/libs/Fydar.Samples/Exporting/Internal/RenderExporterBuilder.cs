using Fydar.Samples.Internal;
using System.Diagnostics;

namespace Fydar.Samples.Exporting.Internal;

internal class RenderExporterBuilder : IRenderExporterBuilder
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]	
	private readonly RenderExporterDestinationBuilder to;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly RenderExporterFormatBuilder format;

	public IRenderExporterDestinationBuilder To => to;

	public IRenderExporterFormatBuilder Format => format;

	internal RenderExporterBuilder()
	{
		to = new RenderExporterDestinationBuilder();
		format = new RenderExporterFormatBuilder();
	}

	public RenderExporter Build()
	{
		return new RenderExporter(to.Build(), format);
	}
}
