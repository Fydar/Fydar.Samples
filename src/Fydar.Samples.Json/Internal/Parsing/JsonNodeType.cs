namespace Fydar.Samples.Formatting.JsonFormatting.Internal.Parsing
{
	internal enum JsonNodeType
	{
		StartObject,
		EndObject,
		StartArray,
		EndArray,
		PropertyName,
		PropertyValueDeliminator,
		SingleLineComment,
		MultiLineComment,
		ValueDeliminator,
		StringLiteral,
		NumberLiteral,
		TrueLiteral,
		FalseLiteral,
		NullLiteral,
		Whitespace,
		Newline,
	}
}
