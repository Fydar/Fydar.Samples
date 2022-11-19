using System;

namespace Fydar.Samples.Grammars.Json;

public sealed class JsonUtf8GrammarParser : IUtf8GrammerParser
{
	public JsonUtf8GrammarParser()
	{
	}

	public SyntaxTreeData Parse(ReadOnlySpan<byte> bytes, ReadOnlySpan<GrammarToken> lexicalTokens)
	{
		var syntaxTreeBuilder = new SyntaxTreeDataBuilder();

		foreach (var token in syntaxTreeBuilder.ScanLexicalTokens(lexicalTokens))
		{
			if (token.Kind == JsonToken.JsonStructureStartObject)
			{
				if (token.ParentNodeKind == JsonToken.JsonArray)
				{
					token.OpenNode(JsonToken.JsonArrayElement);
				}
				else if (token.ParentNodeKind == JsonToken.JsonProperty)
				{
					token.OpenNode(JsonToken.JsonPropertyValue);
				}
				token.OpenNode(JsonToken.JsonObject);
			}

			else if (token.Kind == JsonToken.JsonStructureStartArray)
			{
				if (token.ParentNodeKind == JsonToken.JsonArray)
				{
					token.OpenNode(JsonToken.JsonArrayElement);
				}
				else if (token.ParentNodeKind == JsonToken.JsonProperty)
				{
					token.OpenNode(JsonToken.JsonPropertyValue);
				}
				token.OpenNode(JsonToken.JsonArray);
			}

			else if (token.Kind == JsonToken.JsonStructureEndArray
				|| token.Kind == JsonToken.JsonStructureEndObject)
			{
				token.CloseNode();

				if (token.ParentNodeKind == JsonToken.JsonArrayElement
					|| token.ParentNodeKind == JsonToken.JsonPropertyValue)
				{
					token.CloseNode();
				}
			}

			else if (token.Kind == JsonToken.JsonString)
			{
				if (token.ParentNodeKind == JsonToken.JsonArray)
				{
					token.OpenNode(JsonToken.JsonArrayElement);
					token.CloseNode();
				}
				else if (token.ParentNodeKind == JsonToken.JsonProperty)
				{
					token.OpenNode(JsonToken.JsonPropertyValue);
					token.CloseNode();

					if (token.ParentNodeKind == JsonToken.JsonProperty)
					{
						token.CloseNode();
					}
				}
				else
				{
					token.OpenNode(JsonToken.JsonProperty);

					token.OpenNode(JsonToken.JsonPropertyName);
					token.CloseNode();
				}
			}

			else if (token.Kind.IsKindOf(JsonToken.JsonKeyword)
				|| token.Kind == JsonToken.JsonNumeric)
			{
				token.OpenNode(JsonToken.JsonPropertyValue);
				token.CloseNode();

				if (token.ParentNodeKind == JsonToken.JsonProperty)
				{
					token.CloseNode();
				}
			}
		}

		return syntaxTreeBuilder.Build();
	}
}
