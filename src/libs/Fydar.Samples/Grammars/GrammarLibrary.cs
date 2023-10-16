using Fydar.Samples.Grammars.Internal;
using System;

namespace Fydar.Samples.Grammars;

public sealed class GrammarLibrary
{
	internal GrammarLibrary()
	{
	}

	public static IGrammarLibraryBuilder Create()
	{
		return new GrammarLibraryBuilder();
	}

	public static GrammarLibrary Create(Action<IGrammarLibraryBuilder> exporter)
	{
		var builder = new GrammarLibraryBuilder();
		exporter.Invoke(builder);
		return builder.Build();
	}
}
