using System;
using System.Diagnostics;

namespace Fydar.Samples.Grammars;

public sealed class Grammar
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string[] aliases;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string[] extensions;

	public string DisplayName { get; }

	public ReadOnlySpan<string> Aliases => aliases;

	public ReadOnlySpan<string> Extensions => extensions;

	internal Grammar(string[] aliases, string[] extensions, string displayName)
	{
		this.aliases = aliases;
		this.extensions = extensions;
		DisplayName = displayName;
	}
}
