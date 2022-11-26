using Fydar.Samples.Grammars.Json.Internal;
using Fydar.Samples.Grammars.Json.Lexing;
using System;
using System.Collections.Generic;

namespace Fydar.Samples.Grammars.Json;

public sealed class JsonUtf8GrammarLexer : IUtf8GrammarLexer
{
	private readonly Utf8Lexer lexer;

	public JsonUtf8GrammarLexer()
	{
		lexer = new Utf8Lexer(new JsonLexerLanguage());
	}

	public ReadOnlySpan<GrammarToken> Tokenize(ReadOnlySpan<byte> bytes)
	{
		var result = new List<GrammarToken>();
		foreach (var token in lexer.Tokenize(bytes))
		{
			result.Add(token);
		}
		return result.ToArray();
	}
}
