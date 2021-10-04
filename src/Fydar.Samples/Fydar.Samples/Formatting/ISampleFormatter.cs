using System.Collections.Generic;
using System.IO;

namespace Fydar.Samples.Formatting
{
	public interface ISampleFormatter
	{
		bool CanFormat(string extension);

		IAsyncEnumerable<SampleContent> Format(Stream sampleContent);
	}
}
