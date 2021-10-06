using Fydar.Samples.Formatting;
using Fydar.Samples.Formatting.CSharpFormatting;
using Fydar.Samples.Formatting.JsonFormatting;
using Fydar.Samples.Rendering.Svg;
using System.Reflection;
using System.Threading.Tasks;

namespace Fydar.Samples.Demo.Samples
{
	public class HowToUse
	{
		public static async Task Demo()
		{
			#region how_to_use
			var sampleProject = SampleProject.Create()
				.AddFormattedSamples(options =>
				{
					options.AddSource(new FileSystemSource("Samples"));
					options.AddSource(new SampleReturnSampleSource(Assembly.GetEntryAssembly()));

					options.AddFormatter(new CSharpSampleFormatter());
					options.AddFormatter(new JsonSampleFormatter());
				})
				.RenderTo(new SvgSampleRenderer())
				.Build();

			await sampleProject.GenerateSamplesAsync("output");
			#endregion how_to_use
		}
	}
}
