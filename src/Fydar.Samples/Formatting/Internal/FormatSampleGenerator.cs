using System;
using System.Collections.Generic;

namespace Fydar.Samples.Formatting.Internal
{
	internal class FormatSampleGenerator : ISampleGenerator
	{
		private readonly ISampleFormatter[] formatters;
		private readonly ISampleSources[] sources;

		public FormatSampleGenerator(
			ISampleFormatter[] formatters,
			ISampleSources[] sources)
		{
			this.formatters = formatters;
			this.sources = sources;
		}

		public async IAsyncEnumerable<Sample> GenerateSamples()
		{
			foreach (var sampleFinder in sources)
			{
				var sampleSources = sampleFinder.LocateSamples();

				await foreach (var sampleSource in sampleSources)
				{
					var formatter = GetFormatter(sampleSource.Extension);

					using var stream = sampleSource.Open();
					var samples = formatter.FormatAsync(sampleSource.Name, stream);

					await foreach (var sample in samples)
					{
						yield return sample;
					}
				}
			}
		}

		private ISampleFormatter GetFormatter(string extension)
		{
			foreach (var formatter in formatters)
			{
				if (formatter.CanFormat(extension))
				{
					return formatter;
				}
			}
			throw new InvalidOperationException($"Cannot format samples of type '{extension}'.");
		}
	}
}
