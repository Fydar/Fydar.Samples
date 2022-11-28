using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Fydar.Samples.BuiltIn.CodeSnippets;

internal class CodeSnippetsFromSourceFilesSampleProvider : ISampleProvider
{
	private readonly string path;

	public CodeSnippetsFromSourceFilesSampleProvider(string path)
	{
		this.path = path;
	}

	public async IAsyncEnumerable<SampleBuilder> ProvideSamplesAsync(CancellationToken cancellationToken = default)
	{
		foreach (string filePath in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
		{
			var sampleBuilder = Sample.Create();

			var codeSnippetFeature = sampleBuilder.Features.GetOrCreateFeature<CodeSnippetFeature>();
			codeSnippetFeature.Code = await File.ReadAllTextAsync(filePath, cancellationToken);

			var singleFileSourceFeature = sampleBuilder.Features.GetOrCreateFeature<SingleFileSourceFeature>();
			singleFileSourceFeature.FullName = filePath;

			var fileInfo = new FileInfo(filePath);
			singleFileSourceFeature.Name = fileInfo.Name;
			singleFileSourceFeature.Extension = fileInfo.Extension;

			yield return sampleBuilder;
		}
	}
}
