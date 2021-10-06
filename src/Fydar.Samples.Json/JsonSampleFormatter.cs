using Fydar.Samples.Formatting.JsonFormatting.Internal;
using System;
using System.Collections.Generic;
using System.IO;

namespace Fydar.Samples.Formatting.JsonFormatting
{
	public class JsonSampleFormatter : ISampleFormatter
	{
		public bool CanFormat(string extension)
		{
			return string.Equals(extension, ".json", StringComparison.OrdinalIgnoreCase);
		}

		public async IAsyncEnumerable<Sample> FormatAsync(string name, Stream sampleContent)
		{
			using var streamReader = new StreamReader(sampleContent);

			yield return JsonSyntax.ToCodeBlocks(name, await streamReader.ReadToEndAsync());
		}
	}
}
