namespace Fydar.Samples.Grammars.Syntax;

public readonly struct SyntaxTreeData
{
	public readonly SyntaxTreeDataNode[] nodes;

	public SyntaxTreeData(SyntaxTreeDataNode[] nodes)
	{
		this.nodes = nodes;
	}
}
