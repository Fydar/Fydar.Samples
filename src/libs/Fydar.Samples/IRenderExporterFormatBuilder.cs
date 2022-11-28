namespace Fydar.Samples;

public interface IRenderExporterFormatBuilder
{
	public string Extension { get; set; }

	public IRenderFormatter Formatter { get; set; }
}
