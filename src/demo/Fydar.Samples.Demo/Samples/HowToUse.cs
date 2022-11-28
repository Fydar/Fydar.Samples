using Fydar.Samples.BuiltIn.CodeSnippets;
using Fydar.Samples.BuiltIn.Themes.GitHubCodeSnippets;
using Fydar.Samples.BuiltIn.Themes.VisualStudio2022Dark;
using Fydar.Samples.Exporting;
using Fydar.Samples.Rendering;
using Fydar.Samples.Rendering.Format.AsSvg;
using Fydar.Samples.Rendering.Themes;
using System.Threading.Tasks;

namespace Fydar.Samples.Demo.Samples;

public class HowToUse
{
	public static async Task Demo()
	{
		#region how_to_use
		// Collect code snippets that we want to generate samples for.
		var sampleFactory = SampleFactory.Create(samples =>
		{
			samples.AddCodeSnippetsFromSourceFiles("Samples/");
			samples.AddCodeSnippetsFromAttributes();

			// samples.HighlightCSharpSyntax();
			// samples.HighlightJsonSyntax();
		});

		var layout = new DefaultCodeSnippetLayoutProvider();
		var theme = Theme.Create("dark")
			.UseVisualStudio2022Dark()
			.UseGitHubCodeSnippetBoxDark()
			.Build();

		// Create a render stack to turn the samples into rendered graphics.
		var graphicFactory = GraphicFactory.Create(graphic =>
		{
			graphic.Theme = theme;
			graphic.LayoutProvider = layout;

			graphic.CreatePermutationForEachRegion();
		});

		var exporter = RenderExporter.Create(export =>
		{
			export.To.GitRepositoryRootDirectory("output/");
			export.Format.AsSvg();
		});

		await exporter.ExportAsync(sampleFactory, graphicFactory);
		#endregion how_to_use
	}
}
