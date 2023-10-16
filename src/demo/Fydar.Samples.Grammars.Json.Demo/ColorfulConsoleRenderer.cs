using Fydar.Samples.Rendering.Themes;
using System;
using System.Text;

namespace Fydar.Samples.Grammars.Json.Demo;

public class ColorfulConsoleRenderer
{
	private readonly Theme theme;

	private int currentLineNumber = 0;

	public ColorfulConsoleRenderer(Theme theme)
	{
		this.theme = theme;
	}

	public void RenderTokens(ReadOnlySpan<GrammarToken> tokens, ReadOnlySpan<byte> content, TokenKind nodeStyle)
	{
		if (currentLineNumber == 0)
		{
			currentLineNumber++;
			RenderLineNumber();
		}

		foreach (var lexicalToken in tokens)
		{
			string displayToken = Encoding.UTF8.GetString(content[lexicalToken.range]);

			if (lexicalToken.kind.IsKindOf(StandardToken.Whitespace))
			{
				// displayToken = displayToken
				// 	.Replace(' ', '\u00B7')
				// 	.Replace("\t", "\u2192   ");

				displayToken = displayToken
					.Replace("\t", "    ");
			}

			// ThemeRichFont textStyle;
			// if (nodeStyle != TokenKind.Unknown)
			// {
			// 	textStyle = theme.TextStyleLibrary.GetComputedTextStyle(lexicalToken.kind, nodeStyle);
			// }
			// else
			// {
			// 	textStyle = theme.TextStyleLibrary.GetComputedTextStyle(lexicalToken.kind);
			// }
			// Console.Write(displayToken, Color.FromArgb(textStyle.FontColor.A, textStyle.FontColor.R, textStyle.FontColor.G, textStyle.FontColor.B));

			ThemeConsoleFont consoleStyle;
			if (nodeStyle != TokenKind.Unknown)
			{
				consoleStyle = theme.GetComputedStyle<ThemeConsoleFont>(lexicalToken.kind, nodeStyle);
			}
			else
			{
				consoleStyle = theme.GetComputedStyle<ThemeConsoleFont>(lexicalToken.kind);
			}
			Console.ForegroundColor = consoleStyle.ForegroundColor;
			Console.BackgroundColor = consoleStyle.BackgroundColor;
			Console.Write(displayToken);

			if (lexicalToken.kind.IsKindOf(StandardToken.Newline))
			{
				currentLineNumber++;
				RenderLineNumber();
			}
		}

		void RenderLineNumber()
		{
			var consoleStyle = theme.GetComputedStyle<ThemeConsoleFont>(StandardToken.LineNumber);
			Console.ForegroundColor = consoleStyle.ForegroundColor;
			Console.BackgroundColor = consoleStyle.BackgroundColor;
			Console.Write($"{currentLineNumber,5}│");

			// Console.Write($"{currentLineNumber,5}  ", Color.FromArgb(textStyle.FontColor.A, textStyle.FontColor.R, textStyle.FontColor.G, textStyle.FontColor.B));
		}
	}
}
