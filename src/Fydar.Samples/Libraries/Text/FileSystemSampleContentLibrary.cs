using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Fydar.Samples.Formatting;

public class FileSystemSampleContentLibrary : ISampleContentLibrary
{
	private readonly string directory;

	public FileSystemSampleContentLibrary(string directory)
	{
		this.directory = directory;
	}

	public async IAsyncEnumerable<SampleContent> FindSampleContentsAsync(
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		foreach (string file in Directory.EnumerateFiles(directory, "*"))
		{
			var fileInfo = new FileInfo(file);

			yield return new SampleContent(
				fileInfo.Name,
				fileInfo.Extension,
				() => fileInfo.OpenRead());
		}
	}
}
