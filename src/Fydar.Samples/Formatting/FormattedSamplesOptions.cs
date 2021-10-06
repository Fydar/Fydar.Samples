using System.Collections.Generic;

namespace Fydar.Samples.Formatting
{
	public class FormattedSamplesOptions
	{
		internal readonly List<ISampleFormatter> sampleFormatters = new();
		internal readonly List<ISampleSources> sampleSources = new();

		public void AddFormatter(ISampleFormatter sampleFormatter)
		{
			sampleFormatters.Add(sampleFormatter);
		}

		public void AddSource(ISampleSources sampleSource)
		{
			sampleSources.Add(sampleSource);
		}
	}
}
