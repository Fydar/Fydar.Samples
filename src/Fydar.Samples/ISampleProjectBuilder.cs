using Fydar.Samples.Grammars;
using Fydar.Samples.Rendering;

namespace Fydar.Samples;

public interface ISampleProjectBuilder
{
	ISampleExporterBuilder Exporter { get; }

	IGrammarLibraryBuilder Grammars { get; }

	ISampleRenderingLibraryBuilder Rendering { get; }

	ISampleModelLibraryBuilder Samples { get; }

	SampleProject Build();
}
