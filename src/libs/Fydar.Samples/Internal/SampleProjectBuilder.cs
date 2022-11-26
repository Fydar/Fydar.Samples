using Fydar.Samples.Exporting.Internal;
using Fydar.Samples.Grammars;
using Fydar.Samples.Rendering;

namespace Fydar.Samples.Internal;

internal class SampleProjectBuilder : ISampleProjectBuilder
{
	public IGrammarLibraryBuilder Grammars { get; }

	public ISampleModelLibraryBuilder Samples { get; }

	public ISampleRenderingLibraryBuilder Rendering { get; }

	public ISampleExporterBuilder Exporter { get; }

	internal SampleProjectBuilder()
	{
		Grammars = GrammarLibrary.Create();
		Samples = SampleModelLibrary.Create();
		Rendering = SampleRenderingLibrary.Create();
		Exporter = SampleExporter.Create();
	}

	public SampleProject Build()
	{
		return new SampleProject();
	}
}
