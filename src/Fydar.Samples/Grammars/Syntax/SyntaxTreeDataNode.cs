namespace Fydar.Samples.Grammars.Syntax;

public readonly struct SyntaxTreeDataNode
{
	/// <summary>
	/// The type of this Node.
	/// </summary>
	public readonly TokenKind kind;

	/// <summary>
	/// The amount of child Nodes that this Node contains.
	/// </summary>
	public readonly ushort childNodeCount;

	/// <summary>
	/// The amount of Lexical Tokens that prefix this Node (but are <b>not</b> contained within this node).
	/// </summary>
	public readonly ushort leadingLexicalTokensCount;

	/// <summary>
	/// The amount of Lexical Tokens that this Node (and all children Nodes) contains.
	/// </summary>
	public readonly ushort totalLexicalTokenSize;

	public SyntaxTreeDataNode(
		TokenKind kind,
		ushort childNodeCount,
		ushort leadingLexicalTokensCount,
		ushort totalLexicalTokenSize)
	{
		this.kind = kind;
		this.childNodeCount = childNodeCount;
		this.leadingLexicalTokensCount = leadingLexicalTokensCount;
		this.totalLexicalTokenSize = totalLexicalTokenSize;
	}

	public override string ToString()
	{
		return $"{kind} | {childNodeCount} | {leadingLexicalTokensCount} + {totalLexicalTokenSize}";
	}
}
