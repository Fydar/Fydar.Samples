using System;
using System.Diagnostics;

namespace Fydar.Samples.Grammars.Internal;

[DebuggerDisplay("{Kind,nq}")]
internal struct DebuggerViewSyntaxTreeNode
{
	public TokenKind Kind { get; }

	public DebuggerViewSyntaxTreeNodeCollection ChildNodes { get; }

	public DebuggerViewGrammarTokenCollection ContentLexicalTokens { get; }

	public DebuggerViewGrammarTokenCollection LeadingLexicalTokens { get; }

	public DebuggerViewGrammarTokenCollection TrailingLexicalTokens { get; }

	public DebuggerViewSyntaxTreeNode(SyntaxTreeNode syntaxTreeNode)
	{
		var childNodes = new DebuggerViewSyntaxTreeNode[syntaxTreeNode.ChildNodes.Count];
		int index = 0;
		foreach (var childNode in syntaxTreeNode.ChildNodes)
		{
			childNodes[index] = new DebuggerViewSyntaxTreeNode(childNode);
			index++;
		}

		var nodeData = syntaxTreeNode.syntaxTreeDocument.syntaxTreeData.nodes[syntaxTreeNode.syntaxTreeNodeIndex];

		ChildNodes = childNodes;
		Kind = nodeData.kind;

		if (syntaxTreeNode.ContentLexicalTokens.Length > 0)
		{
			ContentLexicalTokens = syntaxTreeNode.ContentLexicalTokens.ToArray();
		}
		else
		{
			ContentLexicalTokens = Array.Empty<GrammarToken>();
		}

		if (syntaxTreeNode.LeadingLexicalTokens.Length > 0)
		{
			LeadingLexicalTokens = syntaxTreeNode.LeadingLexicalTokens.ToArray();
		}
		else
		{
			LeadingLexicalTokens = Array.Empty<GrammarToken>();
		}

		if (syntaxTreeNode.TrailingLexicalTokens.Length > 0)
		{
			TrailingLexicalTokens = syntaxTreeNode.TrailingLexicalTokens.ToArray();
		}
		else
		{
			TrailingLexicalTokens = Array.Empty<GrammarToken>();
		}
	}
}
