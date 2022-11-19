using System;
using System.Diagnostics;

namespace Fydar.Samples.Grammars;

public class LanguageLibrary
{
	internal LanguageLibrary()
	{
	}

	public static LanguageLibraryBuilder Create()
	{
		return new LanguageLibraryBuilder();
	}
}

public class Language
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string[] aliases;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string[] extensions;

	public string DisplayName { get; }

	public ReadOnlySpan<string> Aliases => aliases;

	public ReadOnlySpan<string> Extensions => extensions;
}

public class LanguageOptions
{
	public string DisplayName { get; set; } = string.Empty;

	public string[] Aliases { get; set; } = Array.Empty<string>();

	public string[] Extensions { get; set; } = Array.Empty<string>();

	public IUtf8GrammarLexer Syntax { get; set; }
}


public class LanguageLibraryBuilder
{
	public LanguageLibraryBuilder AddLanguage(Action<LanguageOptions> language)
	{

		return this;
	}

	public LanguageLibrary Build()
	{
		return new LanguageLibrary();
	}
}
