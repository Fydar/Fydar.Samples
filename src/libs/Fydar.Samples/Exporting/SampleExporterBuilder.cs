using Fydar.Samples.Exporting.Internal;
using System;

namespace Fydar.Samples.Exporting;

internal class SampleExporterBuilder : ISampleExporterBuilder
{
	public ISampleExporterBuilder AddExport(Action<object> export)
	{

		return this;
	}

	public SampleExporter Build()
	{
		return new SampleExporter();
	}
}
