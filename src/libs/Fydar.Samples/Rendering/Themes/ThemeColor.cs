using System;

namespace Fydar.Samples.Rendering.Themes;

public readonly struct ThemeColor
{
	public readonly byte R { get; }
	public readonly byte G { get; }
	public readonly byte B { get; }
	public readonly byte A { get; }

	public ThemeColor(byte r, byte g, byte b, byte a)
	{
		R = r;
		G = g;
		B = b;
		A = a;
	}

	public static implicit operator ThemeColor(string hexColor)
	{
		return ParseHexColor(hexColor);
	}

	public static ThemeColor ParseHexColor(string hexColor)
	{
		hexColor = hexColor.Replace(" ", "");

		if (hexColor[0] != '#')
		{
			throw new InvalidOperationException(string.Format("The hex color \"{0}\" must start with a \"#\".", hexColor));
		}

		byte a = byte.MaxValue;
		if (hexColor.Length is 3 or 4)
		{
			byte r = DoubleHex(hexColor[1]);
			byte g = DoubleHex(hexColor[2]);
			byte b = DoubleHex(hexColor[3]);

			if (hexColor.Length == 4)
			{
				a = DoubleHex(hexColor[4]);
			}
			return new ThemeColor(r, g, b, a);
		}
		else if (hexColor.Length is 7 or 9)
		{
			byte r = ParseHex(hexColor[1], hexColor[2]);
			byte g = ParseHex(hexColor[3], hexColor[4]);
			byte b = ParseHex(hexColor[5], hexColor[6]);

			if (hexColor.Length == 9)
			{
				a = ParseHex(hexColor[7], hexColor[8]);
			}
			return new ThemeColor(r, g, b, a);
		}
		else
		{
			throw new InvalidOperationException(string.Format("The hex color \"{0}\" is an invalid length.", hexColor));
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
