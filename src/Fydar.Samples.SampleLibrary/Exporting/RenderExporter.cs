using Fydar.Samples.Rendering;
using Fydar.Samples.SampleLibrary.Exporting.Internal;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fydar.Samples.SampleLibrary.Exporting;

public class RenderExporter
{
	private readonly IRenderExporterDestination[] to;

	private readonly IRenderExporterFormatBuilder format;

	internal RenderExporter(
		IRenderExporterDestination[] to,
		IRenderExporterFormatBuilder format)
	{
		this.to = to;
		this.format = format;
	}

	public static IRenderExporterBuilder Create()
	{
		return new RenderExporterBuilder();
	}

	public static RenderExporter Create(Action<IRenderExporterBuilder> exporter)
	{
		var builder = new RenderExporterBuilder();
		exporter.Invoke(builder);
		return builder.Build();
	}

	public async Task ExportAsync(
		SampleFactory sampleFactory,
		GraphicFactory graphicFactory,
		CancellationToken cancellationToken = default)
	{
		await Task.Yield();

		// await foreach (var sample in sampleFactory.CreateSamplesAsync())
		// {
		//      var graphics = graphicFactory.RenderAllGraphics(sample);
		//      
		//      foreach (var graphic in graphics)
		//      {
		//      	var buffer = new MemoryStream();
		//      	await format.Formatter.WriteAsync(graphic, buffer, cancellationToken);
		//      
		//      	foreach (var destination in to)
		//      	{
		//      		var request = new RenderExportRequest()
		//      		{
		//      			LocalFileName = graphic.Name + format.Extension,
		//      			FormattedSample = buffer
		//      		};
		//      		await destination.WriteRenderAsync(request, cancellationToken);
		//      	}
		//      }
		// }
	}
}
