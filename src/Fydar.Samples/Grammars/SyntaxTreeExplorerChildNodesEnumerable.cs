using Fydar.Samples.Grammars.Internal;
using System.Diagnostics;

namespace Fydar.Samples.Grammars;

[DebuggerDisplay("Count = {Count,nq}")]
public readonly ref struct SyntaxTreeExplorerChildNodesEnumerable
{
	public ref struct SyntaxTreeExplorerChildNodesEnumerator
	{
		private readonly SyntaxTreeDocument syntaxTreeDocument;
		private readonly int offset;
		private readonly int length;

		private int currentNodeIndex;
		private int currentLexicalTokenIndex;

		public SyntaxTreeExplorerChildNodesEnumerator(
			SyntaxTreeDocument syntaxTreeDocument,
			int offset,
			int length,
			int lexicalTokenIndex)
		{
			this.syntaxTreeDocument = syntaxTreeDocument;
			this.offset = offset;
			this.length = length;

			currentNodeIndex = -1;
			currentLexicalTokenIndex = lexicalTokenIndex;
		}

		public SyntaxTreeNode Current => new(syntaxTreeDocument, currentNodeIndex, currentLexicalTokenIndex);

		public bool MoveNext()
		{
			if (length == 0)
			{
				return false;
			}

			if (currentNodeIndex == -1)
			{
				currentNodeIndex = offset;

				ref var currentNode = ref syntaxTreeDocument.syntaxTreeData.nodes[currentNodeIndex];
				currentLexicalTokenIndex += currentNode.leadingLexicalTokensCount;
			}
			else
			{
				ref var lastNode = ref syntaxTreeDocument.syntaxTreeData.nodes[currentNodeIndex];
				currentLexicalTokenIndex += lastNode.totalLexicalTokenSize;

				if (lastNode.childNodeCount == 0)
				{
					currentNodeIndex++;
				}
				else
				{
					currentNodeIndex += lastNode.childNodeCount + 1;
				}

				if (currentNodeIndex < syntaxTreeDocument.syntaxTreeData.nodes.Length)
				{
					ref var currentNode = ref syntaxTreeDocument.syntaxTreeData.nodes[currentNodeIndex];
					currentLexicalTokenIndex += currentNode.leadingLexicalTokensCount + 1;
				}
			}
			return currentNodeIndex <= offset + length - 1;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly SyntaxTreeDocument syntaxTreeDocument;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int offset;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int length;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int lexicalTokenIndex;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count
	{
		get
		{
			int counter = 0;
			var enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				counter++;
			}
			return counter;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private DebuggerViewSyntaxTreeNode[] DebuggerView
	{
		get
		{
			var debuggerView = new DebuggerViewSyntaxTreeNode[Count];
			int index = 0;

			foreach (var childNode in this)
			{
				debuggerView[index] = new DebuggerViewSyntaxTreeNode(childNode);
				index++;
			}
			return debuggerView;
		}
	}

	public SyntaxTreeExplorerChildNodesEnumerable(
		SyntaxTreeDocument syntaxTreeDocument,
		int offset,
		int length,
		int lexicalTokenIndex)
	{
		this.syntaxTreeDocument = syntaxTreeDocument;
		this.offset = offset;
		this.length = length;
		this.lexicalTokenIndex = lexicalTokenIndex;
	}

	public SyntaxTreeExplorerChildNodesEnumerator GetEnumerator()
	{
		return new SyntaxTreeExplorerChildNodesEnumerator(syntaxTreeDocument, offset, length, lexicalTokenIndex);
	}
}
