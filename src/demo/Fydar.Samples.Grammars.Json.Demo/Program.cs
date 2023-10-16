using Fydar.Samples.BuiltIn.Themes.VisualStudio2022Dark;
using Fydar.Samples.Grammars.Syntax;
using Fydar.Samples.Rendering.Themes;
using System;
using System.Drawing;
using System.Text;

namespace Fydar.Samples.Grammars.Json.Demo;

internal class Program
{
	private static void Main(string[] args)
	{
		Console.Title = "Fydar.Samples.Grammars.Json";

		InteractiveLoop();
	}

	private static void InteractiveLoop()
	{
		var theme = Theme.Create("test-theme")
			.UseVisualStudio2022Dark()
			.Build();

		var backgroundColor32 = ThemeColor.ParseHexColor("#1e1e1e");
		// Console.BackgroundColor = Color.FromArgb(backgroundColor32.A, backgroundColor32.R, backgroundColor32.G, backgroundColor32.B);
		Console.Clear();

		var consoleStyle = theme.GetComputedStyle<ThemeConsoleFont>(StandardToken.Identifier);
		Console.ForegroundColor = consoleStyle.ForegroundColor;
		Console.BackgroundColor = consoleStyle.BackgroundColor;

		// Console.ForegroundColor = Color.FromArgb(foregroundColor.FontColor.A, foregroundColor.FontColor.R, foregroundColor.FontColor.G, foregroundColor.FontColor.B);

		Console.WriteLine("");
		Console.WriteLine(" ╔══ [Fydar.Samples.Grammars.Json.Demo] ════════════════════════════╗");
		Console.WriteLine(" ║ Demo console application for testing Json grammars.              ║");
		Console.WriteLine(" ╚══════════════════════════════════════════════════════════════════╝");
		Console.WriteLine("");

		var renderBlock = new ColorfulConsoleRenderer(theme);

		string json = """
// An example glossery of markup languages
{
	"glossary": {
		"title": "example glossary",
		"GlossDiv": {
			"title": "S",
			"GlossList": {
				"GlossEntry": {
					"ID": 4124214,
					"SortAs": "SGML",
					"IsSupported": true,
					"Alternative": null,
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
					"GlossSee": "markup",
					"ShowSeeMore": false
				}
			}
		}
	}
}
""";
		byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

		var grammerLexer = new JsonUtf8GrammarLexer();
		var grammerParser = new JsonUtf8GrammarParser();

		var lexicalTokens = grammerLexer.Tokenize(jsonBytes);
		var syntaxTree = grammerParser.Parse(jsonBytes, lexicalTokens);

		var document = new SyntaxTreeDocument(syntaxTree, lexicalTokens);

		RecursivePrint(document.ChildNodes);

		void RecursivePrint(SyntaxTreeExplorerChildNodesEnumerable childNodes, int depth = 0)
		{
			foreach (var childNode in childNodes)
			{
				renderBlock.RenderTokens(childNode.LeadingLexicalTokens, jsonBytes, TokenKind.Unknown);

				if (childNode.ChildNodes.Count == 0)
				{
					renderBlock.RenderTokens(childNode.ContentLexicalTokens, jsonBytes, childNode.Kind);
				}
				else
				{
					RecursivePrint(childNode.ChildNodes, depth + 1);
				}

				renderBlock.RenderTokens(childNode.TrailingLexicalTokens, jsonBytes, TokenKind.Unknown);
			}
		}

		Console.WriteLine();
		Console.WriteLine();
		Console.ReadLine();
	}
}
