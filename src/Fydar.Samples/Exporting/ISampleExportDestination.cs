using System.Threading.Tasks;

namespace Fydar.Samples.Exporting;

public interface ISampleExportDestination
{
	public Task WriteSampleAsync(SampleExportDestinationWriteRequest request);
}
