using System;

namespace Fydar.Samples.Grammars;

public interface IGrammarLibraryBuilder
{
	public IGrammarLibraryBuilder AddGrammar(Action<GrammarOptions> grammar);

	public GrammarLibrary Build();
}
