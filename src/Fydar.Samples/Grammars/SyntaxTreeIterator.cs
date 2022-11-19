using System;
using System.Diagnostics;

namespace Fydar.Samples.Grammars;

public ref struct SyntaxTreeToken
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly SyntaxTreeDocument syntaxTreeDocument;

	public Index LexicalTokenIndex { get; }

	public GrammarToken GrammarToken
	{
		get
		{
			return syntaxTreeDocument.LexicalTokens[LexicalTokenIndex];
		}
	}

	public SyntaxTreeToken(
		SyntaxTreeDocument syntaxTreeDocument,
		Index lexicalTokenIndex)
	{
		this.syntaxTreeDocument = syntaxTreeDocument;
		
		LexicalTokenIndex = lexicalTokenIndex;
	}
}
