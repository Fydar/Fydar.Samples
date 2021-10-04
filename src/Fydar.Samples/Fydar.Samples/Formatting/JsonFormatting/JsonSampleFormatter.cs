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

		public async IAsyncEnumerable<SampleContent> Format(Stream sampleContent)
		{
			using var streamReader = new StreamReader(sampleContent);

			yield return JsonSyntax.ToCodeBlocks(await streamReader.ReadToEndAsync());
		}
	}
}
