using System.Threading.Tasks;

namespace Fydar.Samples.Rendering;

public interface ISampleSink
{
	public Task WriteSampleAsync(SampleSinkWriteSampleRequest request);
}
