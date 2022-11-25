using Fydar.Samples.CodeSnippets;
using Fydar.Samples.Grammars.CSharp;
using Fydar.Samples.Grammars.Json;
using Fydar.Samples.Themes.VisualStudio2022Dark;
using System.Threading.Tasks;

namespace Fydar.Samples.Demo;

internal class Program
{
	private static async Task Main(string[] args)
	{
		var sampleProject = SampleProject.Create(project =>
		{
			project.Grammars.AddCSharp();
			project.Grammars.AddJson();

			project.Samples.AddFromSourceFiles("Samples/");
			project.Samples.AddMethodReturns();

			project.Rendering.Configure<CodeSnippet>(render =>
			{
				render.Layout.UseCodeSnippet(render.Model);
				render.Theme.UseVisualStudio2022Dark();
			});

			project.Exporter.AddExport(export =>
			{
				export.Format.AsSvg();
				export.To.Directory("output/svg/");
			});
		});

		await sampleProject.ExportAsync();
	}
}
