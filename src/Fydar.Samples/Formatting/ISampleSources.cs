using System.Collections.Generic;

namespace Fydar.Samples.Formatting
{
	public interface ISampleSources
	{
		IAsyncEnumerable<SampleSource> LocateSamples();
	}
}
