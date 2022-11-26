using System;

namespace Fydar.Samples.Grammars;

public class GrammarOptions
{
	public string DisplayName { get; set; } = string.Empty;

	public string[] Aliases { get; set; } = Array.Empty<string>();

	public string[] Extensions { get; set; } = Array.Empty<string>();

	public IUtf8GrammarLexer? Syntax { get; set; }
}
