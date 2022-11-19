namespace Fydar.Samples.Grammars;

public readonly struct SyntaxTreeData
{
	public readonly SyntaxTreeDataNode[] nodes;

	public SyntaxTreeData(SyntaxTreeDataNode[] nodes)
	{
		this.nodes = nodes;
	}
}
