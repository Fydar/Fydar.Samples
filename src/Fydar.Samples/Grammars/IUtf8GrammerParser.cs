using System;

namespace Fydar.Samples.Grammars;

public interface IUtf8GrammerParser : IGrammarProvider
{
	public SyntaxTreeData Parse(ReadOnlySpan<byte> bytes, ReadOnlySpan<GrammarToken> lexicalTokens);
}

