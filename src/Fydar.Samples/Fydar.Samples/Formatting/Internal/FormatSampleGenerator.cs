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
					var formattedContents = formatter.Format(stream);

					await foreach (var formattedContent in formattedContents)
					{
						var sample = new Sample(sampleSource.Name, formattedContent);

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
