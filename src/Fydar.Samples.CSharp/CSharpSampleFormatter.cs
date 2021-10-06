using Fydar.Samples.Formatting.CSharpFormatting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Fydar.Samples.Formatting.CSharpFormatting
{
	public class CSharpSampleFormatter : ISampleFormatter
	{
		static CSharpSampleFormatter()
		{
			ForceLoadDependencies();
		}

		public bool CanFormat(string extension)
		{
			return string.Equals(extension, ".cs", StringComparison.OrdinalIgnoreCase);
		}

		public async IAsyncEnumerable<Sample> FormatAsync(string name, Stream sampleContent)
		{
			using var streamReader = new StreamReader(sampleContent);

			var codeBlocks = CSharpSyntax.ToCodeBlocks(name, await streamReader.ReadToEndAsync());

			foreach (var codeBlock in codeBlocks)
			{
				yield return codeBlock;
			}
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
}
