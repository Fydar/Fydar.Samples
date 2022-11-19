using Fydar.Samples.Formatting;
using Fydar.Samples.Formatting.CSharpFormatting;
using Fydar.Samples.Rendering.ToSvg;
using System.Reflection;
using System.Threading.Tasks;

namespace Fydar.Samples.Demo.Samples;

public class HowToUse
{
	public static async Task Demo()
	{
		#region how_to_use
		var sampleProject = SampleProject.Create()
			.AddFormattedSamples(options =>
			{
				options.AddSource(new FileSystemSampleContentLibrary("Samples"));
				options.AddSource(new SampleReturnContentLibrary(Assembly.GetEntryAssembly()));

				options.AddGrammar(".cs", new CSharpSampleFormatter());
				options.AddGrammar(".json", new JsonSampleFormatter());
			})
			.RenderTo(new SvgSampleRenderer())
			.Build();

		await sampleProject.GenerateSamplesAsync("output");
		#endregion how_to_use
	}
}
