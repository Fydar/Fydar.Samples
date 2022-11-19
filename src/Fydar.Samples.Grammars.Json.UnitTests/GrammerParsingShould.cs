using NUnit.Framework;
using System;
using System.Text;
using System.Text.Json;

namespace Fydar.Samples.Grammars.Json.UnitTests;

public class GrammerParsingShould
{
	private class WeatherForecast
	{
		public DateTimeOffset Date { get; set; }
		public int TemperatureCelsius { get; set; }
		public string Summary { get; set; } = string.Empty;
	}

	[Test]
	public void Parse()
	{
		// var weatherForecast = new WeatherForecast
		// {
		// 	Date = DateTime.Parse("2019-08-01"),
		// 	TemperatureCelsius = 25,
		// 	Summary = "Hot"
		// };
		// 
		// var options = new JsonSerializerOptions()
		// {
		// 	WriteIndented = true
		// };
		// 
		// byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes(weatherForecast, options);

		var json = """
// An example glossery of markup languages
{
	"glossary": {
		"title": "example glossary",
		"GlossDiv": {
			"title": "S",
			"GlossList": {
				"GlossEntry": {
					"ID": "SGML",
					"SortAs": "SGML",
					"GlossTerm": "Standard Generalized Markup Language",
					"Acronym": "SGML",
					"Abbrev": "ISO 8879:1986",
					"GlossDef": {
						"para": "A meta-markup language, used to create markup languages such as DocBook.",
						"GlossSeeAlso": [
							"GML",
							"XML",
							{
								"SearchUrl": "https://example.com"
							}
						]
					},
					"GlossSee": "markup"
				}
			}
		}
	}
}
""";
		var jsonBytes = Encoding.UTF8.GetBytes(json);

		var grammerLexer = new JsonUtf8GrammarLexer();
		var lexicalTokens = grammerLexer.Tokenize(jsonBytes);

		var grammerParser = new JsonUtf8GrammarParser();
		var syntaxTree = grammerParser.Parse(jsonBytes, lexicalTokens);

		var textStyles = TextStyleLibrary.Create()
			.StyleDefault(style =>
			{
				style.Color = ConsoleColor.Gray;
			})
			.StyleClass(StandardToken.Comment, style =>
			{
				style.Color = ConsoleColor.DarkGreen;
			})
			.StyleClass(StandardToken.String, style =>
			{
				style.Color = ConsoleColor.Yellow;
			})
			.StyleClass(StandardToken.PropertyName, style =>
			{
				style.Color = ConsoleColor.Cyan;
			})
			.StyleClass(StandardToken.Keyword, style =>
			{
				style.Color = ConsoleColor.Blue;
			})
			.StyleClass(StandardToken.Structure, style =>
			{
				style.Color = ConsoleColor.DarkGray;
			})
			.StyleClass(StandardToken.Number, style =>
			{
				style.Color = ConsoleColor.DarkCyan;
			})
			.Build();

		var document = new SyntaxTreeDocument(syntaxTree, lexicalTokens);
		RecursivePrint(document.ChildNodes);

		void RecursivePrint(SyntaxTreeExplorerChildNodesEnumerable childNodes, int depth = 0)
		{
			foreach (var childNode in childNodes)
			{
				string indent = new(' ', depth * 2);

				if (childNode.ChildNodes.Count != 0)
				{
					Console.WriteLine($"{indent}{childNode.Kind}");
				}
				else
				{
					Console.Write(indent);
					Console.Write(childNode.Kind);
					Console.Write(": ");
					foreach (var lexicalToken in childNode.ContentLexicalTokens)
					{
						string displayToken = Encoding.UTF8.GetString(jsonBytes[lexicalToken.range]);
						Console.Write($"{displayToken}");
					}
					Console.WriteLine();
				}

				RecursivePrint(childNode.ChildNodes, depth + 1);
			}
		}
	}

	[Test]
	public void Lex()
	{
		// var weatherForecast = new WeatherForecast
		// {
		// 	Date = DateTime.Parse("2019-08-01"),
		// 	TemperatureCelsius = 25,
		// 	Summary = "Hot"
		// };
		// 
		// var options = new JsonSerializerOptions()
		// {
		// 	WriteIndented = true
		// };
		// 
		// byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes(weatherForecast, options);

		var json = """
// An example glossery of markup languages
{
	"glossary": {
		"title": "example glossary",
		"GlossDiv": {
			"title": "S",
			"GlossList": {
				"GlossEntry": {
					"ID": "SGML",
					"SortAs": "SGML",
					"GlossTerm": "Standard Generalized Markup Language",
					"Acronym": "SGML",
					"Abbrev": "ISO 8879:1986",
					"GlossDef": {
						"para": "A meta-markup language, used to create markup languages such as DocBook.",
						"GlossSeeAlso": [
							"GML",
							"XML",
							{
								"SearchUrl": "https://example.com"
							}
						]
					},
					"GlossSee": "markup"
				}
			}
		}
	}
}
""";
		var jsonBytes = Encoding.UTF8.GetBytes(json);

		var grammerLexer = new JsonUtf8GrammarLexer();
		var lexicalTokens = grammerLexer.Tokenize(jsonBytes);

		foreach (var lexicalToken in lexicalTokens)
		{
			Console.Write($"[{Encoding.UTF8.GetString(jsonBytes[lexicalToken.range])}]");
		}
	}

	public class TextStyleLibrary
	{
		internal TextStyleLibrary()
		{
		}

		public ComputedTextStyle GetComputedTextStyle(TokenKind tokenKind)
		{

			return null;
		}

		public static TextStyleLibraryBuilder Create()
		{
			return new TextStyleLibraryBuilder();
		}
	}

	public class TextStyleLibraryBuilder
	{
		public TextStyleLibraryBuilder StyleDefault(Action<ComputedTextStyle> classStyle)
		{

			return this;
		}

		public TextStyleLibraryBuilder StyleClass(TokenKind tokenKind, Action<ComputedTextStyle> classStyle)
		{

			return this;
		}

		public TextStyleLibrary Build()
		{
			return new TextStyleLibrary();
		}
	}


	public class ComputedTextStyle
	{
		public ConsoleColor Color;
	}
}
