using System;

namespace Fydar.Samples;

public interface ISampleExporterBuilder
{
	public ISampleExporterBuilder AddExport(Action<object> export);
}
