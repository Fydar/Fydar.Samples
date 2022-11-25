using System;

namespace Fydar.Samples.Grammars.Internal;

internal class GrammarLibraryBuilder : IGrammarLibraryBuilder
{
	public IGrammarLibraryBuilder AddGrammar(Action<GrammarOptions> grammar)
	{

		return this;
	}

	public GrammarLibrary Build()
	{
		return new GrammarLibrary();
	}
}
