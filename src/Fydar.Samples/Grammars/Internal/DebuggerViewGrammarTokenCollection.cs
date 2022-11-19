using System;
using System.Diagnostics;

namespace Fydar.Samples.Grammars.Internal;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
internal struct DebuggerViewGrammarTokenCollection
{
	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private readonly GrammarToken[] tokens;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public string DebuggerDisplay
	{
		get
		{
			if (tokens.Length == 0)
			{
				return "Empty";
			}
			return new Range(tokens[0].range.Start, tokens[^1].range.End).ToString();
		}
	}

	public DebuggerViewGrammarTokenCollection(GrammarToken[] tokens)
	{
		this.tokens = tokens;
	}

	public static implicit operator DebuggerViewGrammarTokenCollection(
		GrammarToken[] tokens)
	{
		return new DebuggerViewGrammarTokenCollection(tokens);
	}
}
