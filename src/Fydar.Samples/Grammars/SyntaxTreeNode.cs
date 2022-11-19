using System;
using System.Diagnostics;

namespace Fydar.Samples.Grammars;

public readonly ref struct SyntaxTreeNode
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly SyntaxTreeDocument syntaxTreeDocument;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly int syntaxTreeNodeIndex;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int lexicalTokenIndex;

	public TokenKind Kind
	{ 
		get
		{
			ref var node = ref syntaxTreeDocument.syntaxTreeData.nodes[syntaxTreeNodeIndex];
			return node.kind;
		}
	}

	public SyntaxTreeExplorerChildNodesEnumerable ChildNodes
	{
		get
		{
			ref var node = ref syntaxTreeDocument.syntaxTreeData.nodes[syntaxTreeNodeIndex];

			return new SyntaxTreeExplorerChildNodesEnumerable(syntaxTreeDocument, syntaxTreeNodeIndex + 1, node.childNodeCount, lexicalTokenIndex);
		}
	}

	public ReadOnlySpan<GrammarToken> LeadingLexicalTokens
	{
		get
		{
			ref var node = ref syntaxTreeDocument.syntaxTreeData.nodes[syntaxTreeNodeIndex];

			if (node.leadingLexicalTokensCount == 0)
			{
				return ReadOnlySpan<GrammarToken>.Empty;
			}
			return syntaxTreeDocument.LexicalTokens.Slice(lexicalTokenIndex - node.leadingLexicalTokensCount, node.leadingLexicalTokensCount);
		}
	}

	public ReadOnlySpan<GrammarToken> TrailingLexicalTokens
	{
		get
		{
			ref var node = ref syntaxTreeDocument.syntaxTreeData.nodes[syntaxTreeNodeIndex];

			int childNodesSize = 0;
			foreach (var childNode in ChildNodes)
			{
				ref var childNodeData = ref syntaxTreeDocument.syntaxTreeData.nodes[childNode.syntaxTreeNodeIndex];

				childNodesSize += childNodeData.leadingLexicalTokensCount;
				childNodesSize += childNodeData.totalLexicalTokenSize;
			}
			return Span<GrammarToken>.Empty;

			// return syntaxTreeDocument.lexicalTokens.Slice(
			// 	lexicalTokenIndex + childNodesSize,
			// 	(node.leadingLexicalTokensCount - childNodesSize));
		}
	}

	public ReadOnlySpan<GrammarToken> ContentLexicalTokens
	{
		get
		{
			ref var node = ref syntaxTreeDocument.syntaxTreeData.nodes[syntaxTreeNodeIndex];

			// int childNodesSize = 0;
			// foreach (var childNode in ChildNodes)
			// {
			// 	ref var childNodeData = ref syntaxTreeDocument.syntaxTreeData.nodes[childNode.syntaxTreeNodeIndex];
			// 
			// 	childNodesSize += childNodeData.leadingLexicalTokensCount;
			// 	childNodesSize += childNodeData.totalLexicalTokenSize;
			// }

			return syntaxTreeDocument.LexicalTokens.Slice(
				lexicalTokenIndex,
				node.totalLexicalTokenSize + 1);
		}
	}

	public Range LeadingLexicalTokensRange
	{
		get
		{
			ref var node = ref syntaxTreeDocument.syntaxTreeData.nodes[syntaxTreeNodeIndex];

			if (node.leadingLexicalTokensCount == 0)
			{
				return new Range(lexicalTokenIndex, lexicalTokenIndex);
			}
			return new Range(lexicalTokenIndex - node.leadingLexicalTokensCount, lexicalTokenIndex);
		}
	}

	public Range ContentLexicalTokensRange
	{
		get
		{
			ref var node = ref syntaxTreeDocument.syntaxTreeData.nodes[syntaxTreeNodeIndex];

			// int childNodesSize = 0;
			// foreach (var childNode in ChildNodes)
			// {
			// 	ref var childNodeData = ref syntaxTreeDocument.syntaxTreeData.nodes[childNode.syntaxTreeNodeIndex];
			// 
			// 	childNodesSize += childNodeData.leadingLexicalTokensCount;
			// 	childNodesSize += childNodeData.totalLexicalTokenSize;
			// }

			return new Range(
				lexicalTokenIndex,
				lexicalTokenIndex + node.totalLexicalTokenSize + 1);
		}
	}

	internal SyntaxTreeNode(
		SyntaxTreeDocument syntaxTreeDocument,
		int syntaxTreeNodeIndex,
		int lexicalTokenIndex)
	{
		this.syntaxTreeDocument = syntaxTreeDocument;
		this.syntaxTreeNodeIndex = syntaxTreeNodeIndex;
		this.lexicalTokenIndex = lexicalTokenIndex;
	}
}
