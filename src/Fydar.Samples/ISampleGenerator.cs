using System.Collections.Generic;

namespace Fydar.Samples
{
	public interface ISampleGenerator
	{
		IAsyncEnumerable<Sample> GenerateSamples();
	}
}
