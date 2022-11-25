using System;

namespace Fydar.Samples.Grammars;

/// <summary>
/// A lexer that reads a UTF-8 encoded string and outputs tokens representing the symbols.
/// </summary>
public interface IUtf8GrammarLexer : IGrammarProvider
{
	public ReadOnlySpan<GrammarToken> Tokenize(
		ReadOnlySpan<byte> bytes);
}
