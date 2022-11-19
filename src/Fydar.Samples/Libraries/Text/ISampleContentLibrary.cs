using System.Collections.Generic;
using System.Threading;

namespace Fydar.Samples.Formatting;

public interface ISampleContentLibrary
{
	IAsyncEnumerable<SampleContent> FindSampleContentsAsync(
		CancellationToken cancellationToken = default);
}
