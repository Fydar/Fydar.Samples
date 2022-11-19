using System.IO;

namespace Fydar.Samples.Rendering;

public class SampleSinkWriteSampleRequest
{
	public Stream Body { get; }

	public SampleSinkWriteSampleRequest(Stream body)
	{
		Body = body;
	}
}
