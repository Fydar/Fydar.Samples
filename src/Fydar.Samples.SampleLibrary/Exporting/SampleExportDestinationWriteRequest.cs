using System.IO;

namespace Fydar.Samples.Exporting;

public class SampleExportDestinationWriteRequest
{
	public Stream Body { get; }

	public SampleExportDestinationWriteRequest(Stream body)
	{
		Body = body;
	}
}
