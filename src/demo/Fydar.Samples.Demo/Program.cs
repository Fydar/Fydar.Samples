using Fydar.Samples.BuiltIn;
using Fydar.Samples.BuiltIn.CodeSnippets;
using Fydar.Samples.BuiltIn.Themes.GitHubCodeSnippets;
using Fydar.Samples.BuiltIn.Themes.VisualStudio2022Dark;
using Fydar.Samples.Exporting;
using Fydar.Samples.Rendering;
using Fydar.Samples.Rendering.Format.AsSvg;
using Fydar.Samples.Rendering.Layouts;
using Fydar.Samples.Rendering.Themes;
using System.Threading.Tasks;

namespace Fydar.Samples.Demo;

internal class Program
{
	private static async Task Main(string[] args)
	{
		// Collect code snippets that we want to generate samples for.
		var sampleFactory = SampleFactory.Create(samples =>
		{
			samples.AddCodeSnippetsFromSourceFiles("Samples/");
			samples.AddCodeSnippetsFromAttributes();

			// samples.HighlightCSharpSyntax();
			// samples.HighlightJsonSyntax();
		});

		// All of the layouts we should use.
		var layoutProviders = new ISampleLayoutProvider[]
		{
			new DefaultCodeSnippetLayoutProvider(),
			new FeaturedCodeSnippetLayoutProvider()
		};

		// Configure a theme to render the samples with.
		var themes = new Theme[]
		{
			 Theme.Create("dark")
				.UseVisualStudio2022Dark()
				.UseGitHubCodeSnippetBoxDark(),

			 Theme.Create("light")
				.UseVisualStudio2022Dark()
				.UseGitHubCodeSnippetBoxDark()
		};

		// Create a render stack to turn the samples into rendered graphics.
		var graphicFactory = GraphicFactory.Create(graphic =>
		{
			foreach (var layoutProvider in layoutProviders)
			{
				graphic.PermutationGroups["layout"].Permutations += layoutMutation =>
				{
					layoutMutation.Name = layoutProvider.Name;
					layoutMutation.LayoutProvider = layoutProvider;
				};
			}

			foreach (var theme in themes)
			{
				graphic.PermutationGroups["theme"].Permutations += themeMutation =>
				{
					themeMutation.Name = theme.Name;
					themeMutation.Theme = theme;
				};
			}
			
			var subSamplesFeature = graphic.Sample.Features.GetFeature<SubSamplesFeature>();
			if (subSamplesFeature != null)
			{
				foreach (var subSample in subSamplesFeature.SubSamples)
				{
					graphic.PermutationGroups["region"].Permutations += regionMutation =>
					{
						regionMutation.Name = subSample.Name;
						regionMutation.Sample = subSample;
						regionMutation.PostProcess<LayoutCodeBlock>(layoutCodeBlock =>
						{
							layoutCodeBlock.ShowLineNumbers = true;
						});
					};
				}
			}

			var singleFileSourceFeature = graphic.Sample.Features.GetFeature<SingleFileSourceFeature>();
			if (singleFileSourceFeature != null)
			{
				graphic.Permutations += lineNumberMutation =>
				{
					lineNumberMutation.Name = "withlinenumbers";
					lineNumberMutation.PostProcess<LayoutCodeBlock>(layoutCodeBlock =>
					{
						layoutCodeBlock.ShowLineNumbers = true;
					});
				};
			}
		});

		var exporter = RenderExporter.Create(export =>
		{
			export.To.GitRepositoryRootDirectory("output/");
			export.Format.AsSvg();
		});

		await exporter.ExportAsync(sampleFactory, graphicFactory);
	}
}
