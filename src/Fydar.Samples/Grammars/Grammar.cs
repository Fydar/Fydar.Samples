using System;
using System.Diagnostics;

namespace Fydar.Samples.Grammars;

public class Grammar
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string[] aliases;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string[] extensions;

	public string DisplayName { get; }

	public ReadOnlySpan<string> Aliases => aliases;

	public ReadOnlySpan<string> Extensions => extensions;
}
