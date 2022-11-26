namespace Fydar.Samples.Grammars.Json.Lexing;

public static class Utf8CharUtilities
{
	public static bool IsLetterOrDigit(byte character)
	{
		return IsDigit(character) || IsLetter(character);
	}

	public static bool IsDigit(byte character)
	{
		return character >= 48
			&& character <= 57;
	}

	public static bool IsLetter(byte character)
	{
		return IsUppercaseLetter(character) || IsLowercaseLetter(character);
	}

	public static bool IsUppercaseLetter(byte character)
	{
		return character >= 65
			&& character <= 90;
	}

	public static bool IsLowercaseLetter(byte character)
	{
		return character >= 97
			&& character <= 122;
	}

	public static bool IsWhitespace(byte character)
	{
		return character == 0x20
			|| character == 0x09;
	}

	public static bool IsNewline(byte character)
	{
		return character == 0x0A
			|| character == 0x0B
			|| character == 0x0C
			|| character == 0x0D;
	}
}
