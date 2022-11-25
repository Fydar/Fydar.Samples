using System;

namespace Fydar.Samples.Exporting.Internal;

internal class SampleExporter
{
	internal SampleExporter()
	{
	}

	public static SampleExporterBuilder Create()
	{
		return new SampleExporterBuilder();
	}

	public static SampleExporter Create(Action<SampleExporterBuilder> exporter)
	{
		var builder = new SampleExporterBuilder();
		exporter.Invoke(builder);
		return builder.Build();
	}
}
