using Fydar.Samples.Internal;
using Fydar.Samples.Rendering;
using System.IO;
using System.Threading.Tasks;

namespace Fydar.Samples
{
	public class SampleProject
	{
		private readonly ISampleGenerator[] sampleGenerators;
		private readonly ISampleRenderer[] sampleRenderers;

		public SampleProject(
			ISampleGenerator[] sampleGenerators,
			ISampleRenderer[] sampleRenderers)
		{
			this.sampleGenerators = sampleGenerators;
			this.sampleRenderers = sampleRenderers;
		}

		public async Task GenerateSamplesAsync(string outputDirectory)
		{
			var directoryInfo = new DirectoryInfo(outputDirectory);
			if (directoryInfo.Exists)
			{
				directoryInfo.Delete(true);
			}
			directoryInfo.Create();

			foreach (var sampleGenerator in sampleGenerators)
			{
				await foreach (var sample in sampleGenerator.GenerateSamples())
				{
					foreach (var renderer in sampleRenderers)
					{
						string? sampleFile = Path.Combine(outputDirectory, renderer.Extension, sample.Identifier);
						sampleFile = Path.ChangeExtension(sampleFile, renderer.Extension);
						var sampleFileInfo = new FileInfo(sampleFile);


						sampleFileInfo.Directory?.Create();

						using var fileStream = File.OpenWrite(sampleFile);
						renderer.Render(sample, fileStream);
					}
				}
			}
		}

		public static ISampleProjectBuilder Create()
		{
			return new SampleProjectBuilder();
		}
	}
}
