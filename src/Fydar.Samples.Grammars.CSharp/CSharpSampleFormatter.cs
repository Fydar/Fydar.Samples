using Fydar.Samples.Formatting.CSharpFormatting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Fydar.Samples.Formatting.CSharpFormatting;

public class CSharpSampleFormatter : ISampleFormatter
{
	public async IAsyncEnumerable<Sample> FormatAsync(
		SampleContent sampleContent,
		CancellationToken cancellationToken = default)
	{
		using var sampleContentStream = sampleContent.Open();
		using var streamReader = new StreamReader(sampleContentStream);

		yield break;

		// var codeBlocks = CSharpSyntax.ToCodeBlocks(sampleContent.Name, await streamReader.ReadToEndAsync());
		// 
		// foreach (var codeBlock in codeBlocks)
		// {
		// 	yield return codeBlock;
		// }
	}

	static CSharpSampleFormatter()
	{
		ForceLoadDependencies();
	}

	private static void ForceLoadDependencies()
	{
		var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
		string[] alreadyLoadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();
		string[] assemblyPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");

		foreach (string assemblyPath in assemblyPaths)
		{
			if (alreadyLoadedPaths.Contains(assemblyPath, StringComparer.InvariantCultureIgnoreCase))
			{
				continue;
			}
			try
			{
				var loaddedAssembly = AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(assemblyPath));
				loadedAssemblies.Add(loaddedAssembly);
			}
			catch
			{
			}
		}
	}
}
