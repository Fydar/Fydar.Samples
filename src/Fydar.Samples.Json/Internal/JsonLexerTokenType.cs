namespace Fydar.Samples.Formatting.JsonFormatting.Internal
{
	internal enum JsonLexerTokenType
	{
		String,
		Numeric,

		Whitespace,
		Newline,
		MultiLineComment,
		LineComment,

		OpenObject,
		CloseObject,
		OpenArray,
		CloseArray,
		Comma,
		Colon,

		Null,
		True,
		False
	}
}
