using System;

namespace Fydar.Samples.Grammars;

public readonly struct GrammarToken
{
	public readonly TokenKind kind;
	public readonly Range range;

	public GrammarToken(TokenKind kind, Range range)
	{
		this.kind = kind;
		this.range = range;
	}

	public override string ToString()
	{
		return $"{range}: {kind}";
	}
}
