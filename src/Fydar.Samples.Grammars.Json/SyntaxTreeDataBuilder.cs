using System;
using System.Collections.Generic;

namespace Fydar.Samples.Grammars.Json;

public class SyntaxTreeDataBuilder
{
	internal readonly List<SyntaxTreeDataNode> nodeData = new(16);
	internal readonly Stack<WriterNode> openNodes = new(8);

	internal ushort childNodeCounter;
	internal ushort childLexicalTokenCounter;
	internal int lastWrappedLexicalTokenIndex;

	public SyntaxTreeDataBuilder()
	{
		childNodeCounter = 0;
		childLexicalTokenCounter = 0;
		lastWrappedLexicalTokenIndex = 0;
	}

	public LexicalTokenScanEnumerable ScanLexicalTokens(ReadOnlySpan<GrammarToken> lexicalTokens)
	{
		return new LexicalTokenScanEnumerable(this, lexicalTokens);
	}

	public SyntaxTreeData Build()
	{
		return new SyntaxTreeData(nodeData.ToArray());
	}

	public readonly ref struct LexicalTokenScanEnumerable
	{
		private readonly SyntaxTreeDataBuilder syntaxTreeDataBuilder;
		private readonly ReadOnlySpan<GrammarToken> lexicalTokens;

		public LexicalTokenScanEnumerable(
			SyntaxTreeDataBuilder syntaxTreeDataBuilder,
			ReadOnlySpan<GrammarToken> lexicalTokens)
		{
			this.syntaxTreeDataBuilder = syntaxTreeDataBuilder;
			this.lexicalTokens = lexicalTokens;
		}

		public ref struct LexicalTokenScanEnumerator
		{
			private readonly SyntaxTreeDataBuilder syntaxTreeDataBuilder;
			private readonly ReadOnlySpan<GrammarToken> lexicalTokens;

			private int index;

			public LexicalTokenScanEnumerator(
				SyntaxTreeDataBuilder syntaxTreeDataBuilder,
				ReadOnlySpan<GrammarToken> lexicalTokens)
			{
				this.syntaxTreeDataBuilder = syntaxTreeDataBuilder;
				this.lexicalTokens = lexicalTokens;
				index = -1;
			}

			public SyntaxTreeDataBuilderLexicalToken Current => new(syntaxTreeDataBuilder, lexicalTokens, index);

			public bool MoveNext()
			{
				index++;

				syntaxTreeDataBuilder.childLexicalTokenCounter++;
				foreach (var openNode in syntaxTreeDataBuilder.openNodes)
				{
					openNode.totalLexicalTokensCounter++;
				}

				if ( index < lexicalTokens.Length)
				{
					return true;
				}
				else
				{
					while (syntaxTreeDataBuilder.openNodes.Count > 0)
					{
						Current.CloseNode();
					}
					return false;
				}
			}
		}

		public LexicalTokenScanEnumerator GetEnumerator()
		{
			return new LexicalTokenScanEnumerator(syntaxTreeDataBuilder, lexicalTokens);
		}
	}
}
