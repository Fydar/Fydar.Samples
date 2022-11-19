using System.Collections.Generic;
using System.Threading;

namespace Fydar.Samples;

public interface ISampleLibrary
{
	IAsyncEnumerable<Sample> GetSamplesAsync(
		CancellationToken cancellationToken = default);
}
