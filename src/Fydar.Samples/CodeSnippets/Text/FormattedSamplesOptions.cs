using System;
using System.Collections.Generic;

namespace Fydar.Samples.CodeSnippets.Text;

public class FormattedSamplesOptions
{
	internal readonly Dictionary<string, ISampleFormatter> sampleFormatters = new(
			StringComparer.OrdinalIgnoreCase);
	internal readonly List<ISampleContentLibrary> sampleContentLibraries = new();

	public void AddGrammar(string extension, ISampleFormatter sampleFormatter)
	{
		sampleFormatters.Add(extension, sampleFormatter);
	}

	public void AddFormatter(string[] extensions, ISampleFormatter sampleFormatter)
	{
		foreach (string? extension in extensions)
		{
			AddGrammar(extension, sampleFormatter);
		}
	}

	public void AddSource(ISampleContentLibrary sampleContentLibrary)
	{
		sampleContentLibraries.Add(sampleContentLibrary);
	}
}
