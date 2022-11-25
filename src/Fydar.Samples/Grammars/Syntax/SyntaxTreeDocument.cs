using System;
using System.Diagnostics;

namespace Fydar.Samples.Grammars.Syntax;

public readonly ref struct SyntaxTreeDocument
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly SyntaxTreeData syntaxTreeData;

	public ReadOnlySpan<GrammarToken> LexicalTokens { get; }

	public SyntaxTreeExplorerChildNodesEnumerable ChildNodes => new(this, 0, syntaxTreeData.nodes.Length, 0);

	public SyntaxTreeDocument(SyntaxTreeData syntaxTreeData, ReadOnlySpan<GrammarToken> lexicalTokens)
	{
		this.syntaxTreeData = syntaxTreeData;

		LexicalTokens = lexicalTokens;
	}
}
