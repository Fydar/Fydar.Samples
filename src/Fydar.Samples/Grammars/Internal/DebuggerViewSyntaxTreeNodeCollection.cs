﻿using System.Diagnostics;

namespace Fydar.Samples.Grammars.Internal;

[DebuggerDisplay("Count = {Count,nq}")]
internal struct DebuggerViewSyntaxTreeNodeCollection
{
	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private readonly DebuggerViewSyntaxTreeNode[] nodes;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count
	{
		get
		{
			return nodes.Length;
		}
	}

	public DebuggerViewSyntaxTreeNodeCollection(DebuggerViewSyntaxTreeNode[] nodes)
	{
		this.nodes = nodes;
	}

	public static implicit operator DebuggerViewSyntaxTreeNodeCollection(
		DebuggerViewSyntaxTreeNode[] nodes)
	{
		return new DebuggerViewSyntaxTreeNodeCollection(nodes);
	}
}
