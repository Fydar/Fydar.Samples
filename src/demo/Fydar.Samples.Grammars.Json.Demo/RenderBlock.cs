using Fydar.Samples.Rendering.Themes;
using System;
using System.Drawing;
using System.Text;

using Console = Colorful.Console;

namespace Fydar.Samples.Grammars.Json.Demo;

public class RenderBlock
{
	public struct Color32
	{
		public byte r;
		public byte g;
		public byte b;
		public byte a;

		public Color32(byte r, byte g, byte b, byte a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}
	}

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

			var parsed = ParseHexColor(textStyle.Color);
			Console.Write(displayToken, Color.FromArgb(parsed.a, parsed.r, parsed.g, parsed.b));

			if (lexicalToken.kind.IsKindOf(StandardToken.Newline))
			{
				currentLineNumber++;
				RenderLineNumber();
			}
		}

		void RenderLineNumber()
		{
			var textStyle = theme.TextStyleLibrary.GetComputedTextStyle(StandardToken.LineNumber);

			var parsed = ParseHexColor(textStyle.Color);
			Console.Write($"{currentLineNumber,5}  ", Color.FromArgb(parsed.a, parsed.r, parsed.g, parsed.b));
		}
	}

	public static Color32 ParseHexColor(string data)
	{
		data = data.Replace(" ", "");

		if (data[0] != '#')
		{
			throw new InvalidOperationException(string.Format("The hex color \"{0}\" must start with a \"#\".", data));
		}

		byte a = byte.MaxValue;
		if (data.Length is 3 or 4)
		{
			byte r = DoubleHex(data[1]);
			byte g = DoubleHex(data[2]);
			byte b = DoubleHex(data[3]);

			if (data.Length == 4)
			{
				a = DoubleHex(data[4]);
			}
			return new Color32(r, g, b, a);
		}
		else if (data.Length is 7 or 9)
		{
			byte r = ParseHex(data[1], data[2]);
			byte g = ParseHex(data[3], data[4]);
			byte b = ParseHex(data[5], data[6]);

			if (data.Length == 9)
			{
				a = ParseHex(data[7], data[8]);
			}
			return new Color32(r, g, b, a);
		}
		else
		{
			throw new InvalidOperationException(string.Format("The hex color \"{0}\" is an invalid length.", data));
		}
	}

	private static byte DoubleHex(char c)
	{
		byte value = PhraseHex(c);

		return (byte)((value << 4) + value);
	}

	private static byte PhraseHex(char c)
	{
		return c switch
		{
			'0' => 0,
			'1' => 1,
			'2' => 2,
			'3' => 3,
			'4' => 4,
			'5' => 5,
			'6' => 6,
			'7' => 7,
			'8' => 8,
			'9' => 9,
			'a' or 'A' => 10,
			'b' or 'B' => 11,
			'c' or 'C' => 12,
			'd' or 'D' => 13,
			'e' or 'E' => 14,
			'f' or 'F' => 15,
			_ => throw new InvalidOperationException(string.Format("The character \"{0}\" is not a valid hexadecimal character", c)),
		};
	}

	private static byte ParseHex(char a, char b)
	{
		return (byte)((PhraseHex(a) << 4) + PhraseHex(b));
	}
}
