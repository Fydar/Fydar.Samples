namespace Fydar.Samples;

public interface IRenderExporterBuilder
{
	public IRenderExporterDestinationBuilder To { get; }

	public IRenderExporterFormatBuilder Format { get; }
}
