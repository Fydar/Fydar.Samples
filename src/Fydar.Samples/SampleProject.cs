using Fydar.Samples.Internal;
using Fydar.Samples.Rendering;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fydar.Samples;

public class SampleProject
{
	private readonly ISampleLibrary[] sampleLibraries;
	private readonly ISampleRenderer[] sampleRenderers;
	private readonly ISampleSink[] sampleSinks;

	internal SampleProject(
		ISampleLibrary[] sampleLibraries,
		ISampleRenderer[] sampleRenderers,
		ISampleSink[] sampleSinks)
	{
		this.sampleLibraries = sampleLibraries;
		this.sampleRenderers = sampleRenderers;
		this.sampleSinks = sampleSinks;
	}

	public async Task GenerateSamplesAsync(
		string outputDirectory,
		CancellationToken cancellationToken = default)
	{
		var directoryInfo = new DirectoryInfo(outputDirectory);
		if (directoryInfo.Exists)
		{
			directoryInfo.Delete(true);
		}
		directoryInfo.Create();

		foreach (var sampleLibrary in sampleLibraries)
		{
			await foreach (var sample in sampleLibrary.GetSamplesAsync(cancellationToken))
			{
				foreach (var sampleRenderer in sampleRenderers)
				{
					// string? sampleFile = Path.Combine(outputDirectory, sampleRenderer.Extension, sample.Reigion);
					// sampleFile = Path.ChangeExtension(sampleFile, sampleRenderer.Extension);
					// var sampleFileInfo = new FileInfo(sampleFile);
					// 
					// sampleFileInfo.Directory?.Create();
					// 
					// using var fileStream = File.OpenWrite(sampleFile);
					// await sampleRenderer.RenderAsync(sample, fileStream, cancellationToken);
				}
			}
		}
	}

	public static ISampleProjectBuilder Create()
	{
		return new SampleProjectBuilder();
	}
}
