using Fydar.Samples.Grammars.Json.Internal.Classifiers;
using Fydar.Samples.Lexing;

namespace Fydar.Samples.Grammars.Json.Internal;

internal class JsonLexerLanguage : IUtf8LexerLanguage
{
	/// <inheritdoc/>
	public IUtf8TokenClassifier[] Classifiers { get; } = new IUtf8TokenClassifier[]
	{
		// Placing the single character token classifiers first allow for faster iteration
		// Due to the Lexer classifier start index offset.
		new SingleCharacterTokenClassifier('{', JsonToken.JsonStructureStartObject),
		new SingleCharacterTokenClassifier('}', JsonToken.JsonStructureEndObject),
		new SingleCharacterTokenClassifier('[', JsonToken.JsonStructureStartArray),
		new SingleCharacterTokenClassifier(']', JsonToken.JsonStructureEndArray),
		new SingleCharacterTokenClassifier(',', JsonToken.JsonStructureComma),
		new SingleCharacterTokenClassifier(':', JsonToken.JsonStructureColon),

		new KeywordTokenClassifier("null", JsonToken.JsonNullLiteral),
		new KeywordTokenClassifier("true", JsonToken.JsonTrueLiteral),
		new KeywordTokenClassifier("false", JsonToken.JsonFalseLiteral),

		new MultiLineCommentTokenClassifier(JsonToken.JsonComment),
		new LineCommentTokenClassifier(JsonToken.JsonComment),

		new NumericTokenClassifier(JsonToken.JsonNumeric),
		new StringTokenClassifier(JsonToken.JsonString),

		new WhitespaceTokenClassifier(StandardToken.Whitespace),
		new NewlineTokenClassifier(StandardToken.Newline),
	};
}
