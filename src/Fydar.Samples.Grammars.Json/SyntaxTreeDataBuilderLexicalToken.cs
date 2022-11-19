using System;

namespace Fydar.Samples.Grammars.Json;

public ref struct SyntaxTreeDataBuilderLexicalToken
{
	private readonly SyntaxTreeDataBuilder syntaxTreeDataBuilder;
	private readonly ReadOnlySpan<GrammarToken> lexicalTokens;

	public int LexicalTokenIndex { get; }
	public int Depth { get; private set; }

	public TokenKind ParentNodeKind
	{
		get
		{
			if (syntaxTreeDataBuilder.openNodes.Count == 0)
			{
				return TokenKind.Unknown;
			}
			var peek = syntaxTreeDataBuilder.openNodes.Peek();
			return peek.tokenKind;
		}
	}

	public GrammarToken LexicalToken => lexicalTokens[LexicalTokenIndex];
	public TokenKind Kind => lexicalTokens[LexicalTokenIndex].kind;

	public SyntaxTreeDataBuilderLexicalToken(
		SyntaxTreeDataBuilder syntaxTreeDataBuilder,
		ReadOnlySpan<GrammarToken> lexicalTokens,
		int lexicalTokenIndex)
	{
		this.syntaxTreeDataBuilder = syntaxTreeDataBuilder;
		this.lexicalTokens = lexicalTokens;

		LexicalTokenIndex = lexicalTokenIndex;
		Depth = 0;
	}

	public void OpenNode(TokenKind tokenKind)
	{
		foreach (var openNode in syntaxTreeDataBuilder.openNodes)
		{
			openNode.totalChildNodesCounter++;
		}

		syntaxTreeDataBuilder.nodeData.Add(new SyntaxTreeDataNode());

		var prefixLexicalTokens = LexicalTokenIndex - syntaxTreeDataBuilder.lastWrappedLexicalTokenIndex;

		syntaxTreeDataBuilder.openNodes.Push(new WriterNode()
		{
			tokenKind = tokenKind,
			nodeIndex = syntaxTreeDataBuilder.nodeData.Count - 1,
			startLexicalToken = LexicalTokenIndex,
			leadingLexicalTokens = (ushort)prefixLexicalTokens
		});

		syntaxTreeDataBuilder.childNodeCounter++;
		syntaxTreeDataBuilder.lastWrappedLexicalTokenIndex = LexicalTokenIndex;
		Depth++;
	}

	public void CloseNode()
	{
		var popped = syntaxTreeDataBuilder.openNodes.Pop();

		syntaxTreeDataBuilder.lastWrappedLexicalTokenIndex = LexicalTokenIndex + 1;

		syntaxTreeDataBuilder.nodeData[popped.nodeIndex] = new SyntaxTreeDataNode(
			popped.tokenKind,
			popped.totalChildNodesCounter,
			popped.leadingLexicalTokens,
			popped.totalLexicalTokensCounter);
		Depth--;
	}
}
