using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Fydar.Samples.Formatting.Internal;

internal class FormattedSampleLibrary : ISampleLibrary
{
	private readonly IReadOnlyDictionary<string, ISampleFormatter> sampleFormatters;
	private readonly IReadOnlyList<ISampleContentLibrary> sampleContentLibraries;

	public FormattedSampleLibrary(
		IReadOnlyDictionary<string, ISampleFormatter> sampleFormatters,
		IReadOnlyList<ISampleContentLibrary> sampleContentLibraries)
	{
		this.sampleFormatters = sampleFormatters;
		this.sampleContentLibraries = sampleContentLibraries;
	}

	public async IAsyncEnumerable<Sample> GetSamplesAsync(
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		foreach (var sampleContentLibrary in sampleContentLibraries)
		{
			var sampleContents = sampleContentLibrary.FindSampleContentsAsync(cancellationToken);

			await foreach (var sampleContent in sampleContents)
			{
				var formatter = GetFormatter(sampleContent.Extension);

				var samples = formatter.FormatAsync(sampleContent, cancellationToken);

				await foreach (var sample in samples)
				{
					yield return sample;
				}
			}
		}
	}

	private ISampleFormatter GetFormatter(string extension)
	{
		if (sampleFormatters.TryGetValue(extension, out var formatter))
		{
			return formatter;
		}
		throw new InvalidOperationException($"Cannot format samples of type '{extension}'.");
	}
}
