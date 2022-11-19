namespace Fydar.Samples.Grammars;

public readonly ref struct SyntaxTreeData
{
	public readonly SyntaxTreeDataNode[] nodes;

	public SyntaxTreeData(SyntaxTreeDataNode[] nodes)
	{
		this.nodes = nodes;
	}
}

