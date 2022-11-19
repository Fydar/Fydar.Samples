using System.Collections.Generic;
using System.Threading;

namespace Fydar.Samples.Formatting;

public interface ISampleFormatter
{
	IAsyncEnumerable<Sample> FormatAsync(
		SampleContent sampleContent,
		CancellationToken cancellationToken = default);
}
