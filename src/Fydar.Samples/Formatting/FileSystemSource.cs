using System.Collections.Generic;
using System.IO;

namespace Fydar.Samples.Formatting
{
	public class FileSystemSource : ISampleSources
	{
		private readonly string directory;

		public FileSystemSource(string directory)
		{
			this.directory = directory;
		}

		public async IAsyncEnumerable<SampleSource> LocateSamples()
		{
			foreach (string file in Directory.EnumerateFiles(directory, "*"))
			{
				var fileInfo = new FileInfo(file);

				yield return new SampleSource(
					fileInfo.Name,
					fileInfo.Extension,
					() => fileInfo.OpenRead());
			}
		}
	}
}
