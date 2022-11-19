using Fydar.Samples.Formatting;
using Fydar.Samples.Formatting.CSharpFormatting;
using Fydar.Samples.Grammars;
using Fydar.Samples.Grammars.Json;
using Fydar.Samples.Rendering.ToSvg;
using System.Threading.Tasks;

namespace Fydar.Samples.Demo;

internal class Program
{
	private static async Task Main(string[] args)
	{
		var grammars = LanguageLibrary.Create()
			.AddJson()
			.Build();

		var sampleProject = SampleProject.Create()
			.AddFormattedSamples(options =>
			{
				options.AddSource(new FileSystemSampleContentLibrary("Samples"));
				options.AddSource(new SampleReturnContentLibrary(typeof(Program).Assembly));
			})
			.RenderTo(new SvgSampleRenderer())
			.Build();

		await sampleProject.GenerateSamplesAsync("output");
	}
}
