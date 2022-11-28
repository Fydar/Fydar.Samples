using Fydar.Samples.Rendering.Themes;
using System;
using System.Drawing;
using System.Text;

using Console = Colorful.Console;

namespace Fydar.Samples.Grammars.Json.Demo;

public class RenderBlock
{

	private readonly Theme theme;

	private int currentLineNumber = 0;

	public RenderBlock(Theme theme)
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
				displayToken = displayToken
					.Replace(' ', '\u00B7')
					.Replace("\t", "\u2192   ");
			}

			ComputedTextStyle textStyle;
			if (nodeStyle != TokenKind.Unknown)
			{
				textStyle = theme.TextStyleLibrary.GetComputedTextStyle(lexicalToken.kind, nodeStyle);
			}
			else
			{
				textStyle = theme.TextStyleLibrary.GetComputedTextStyle(lexicalToken.kind);
			}

			var parsed = ThemeColor.ParseHexColor(textStyle.Color);
			Console.Write(displayToken, Color.FromArgb(parsed.A, parsed.R, parsed.G, parsed.B));

			if (lexicalToken.kind.IsKindOf(StandardToken.Newline))
			{
				currentLineNumber++;
				RenderLineNumber();
			}
		}

		void RenderLineNumber()
		{
			var textStyle = theme.TextStyleLibrary.GetComputedTextStyle(StandardToken.LineNumber);

			var parsed = ThemeColor.ParseHexColor(textStyle.Color);
			Console.Write($"{currentLineNumber,5}  ", Color.FromArgb(parsed.A, parsed.R, parsed.G, parsed.B));
		}
	}
}
