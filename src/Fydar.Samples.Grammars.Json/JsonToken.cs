namespace Fydar.Samples.Grammars.Json;

public static class JsonToken
{
	/// <summary>
	/// A token that represents Json keywords, such as <c>true</c>, <c>false</c>, and <c>null</c>.
	/// </summary>
	public static readonly TokenKindName JsonKeyword = new("json-keyword", "js-kw", StandardToken.Keyword);

	/// <summary>
	/// A token that represents Json <c>null</c> literal.
	/// </summary>
	public static readonly TokenKindName JsonNullLiteral = new("json-literal-null", "js-nl", JsonKeyword);

	/// <summary>
	/// A token that represents Json <c>true</c> literal.
	/// </summary>
	public static readonly TokenKindName JsonTrueLiteral = new("json-literal-true", "js-tr", JsonKeyword);

	/// <summary>
	/// A token that represents Json <c>true</c> literal.
	/// </summary>
	public static readonly TokenKindName JsonFalseLiteral = new("json-literal-false", "js-fl", JsonKeyword);

	/// <summary>
	/// A token that represents Json strings.
	/// </summary>
	public static readonly TokenKindName JsonString = new("json-string", "js-s", StandardToken.String);

	/// <summary>
	/// A token that represents an escaped portion of a Json string.
	/// </summary>
	public static readonly TokenKindName JsonStringEscaped = new("json-string-escaped", "js-se", StandardToken.StringEscaped);

	/// <summary>
	/// A token that represents Json number.
	/// </summary>
	public static readonly TokenKindName JsonNumeric = new("json-number", "js-n", StandardToken.Number);

	/// <summary>
	/// A token that represents Json comment.
	/// </summary>
	public static readonly TokenKindName JsonComment = new("json-comment", "js-c", StandardToken.Comment);

	/// <summary>
	/// A token that represents Json structure character.
	/// </summary>
	public static readonly TokenKindName JsonStructure = new("json-structure", "js-st", StandardToken.Structure);

	/// <summary>
	/// A token that represents Json start object token.
	/// </summary>
	public static readonly TokenKindName JsonStructureStartObject = new("json-structure-start-object", "js-o-s", StandardToken.Structure);

	/// <summary>
	/// A token that represents Json start array token.
	/// </summary>
	public static readonly TokenKindName JsonStructureStartArray = new("json-structure-start-array", "js-a-s", StandardToken.Structure);

	/// <summary>
	/// A token that represents Json end object token.
	/// </summary>
	public static readonly TokenKindName JsonStructureEndObject = new("json-structure-end-object", "js-o-e", StandardToken.Structure);

	/// <summary>
	/// A token that represents Json end array token.
	/// </summary>
	public static readonly TokenKindName JsonStructureEndArray = new("json-structure-end-array", "js-a-e", StandardToken.Structure);

	/// <summary>
	/// A token that represents Json colon token.
	/// </summary>
	public static readonly TokenKindName JsonStructureColon = new("json-structure-colon", "js-st-col", StandardToken.Structure);

	/// <summary>
	/// A token that represents Json comma token.
	/// </summary>
	public static readonly TokenKindName JsonStructureComma = new("json-structure-comma", "js-st-cpm", StandardToken.Structure);


	/// <summary>
	/// A token that represents a json object.
	/// </summary>
	public static readonly TokenKindName JsonObject = new("json-object", "js-o");

	/// <summary>
	/// A token that represents a json property.
	/// </summary>
	public static readonly TokenKindName JsonProperty = new("json-property", "js-p");

	/// <summary>
	/// A token that represents Json property name.
	/// </summary>
	public static readonly TokenKindName JsonPropertyName = new("json-property-name", "js-pn", StandardToken.Identifier);

	/// <summary>
	/// A token that represents Json property value.
	/// </summary>
	public static readonly TokenKindName JsonPropertyValue = new("json-property-value", "js-pv");

	/// <summary>
	/// A token that represents a json array.
	/// </summary>
	public static readonly TokenKindName JsonArray = new("json-array", "js-a");

	/// <summary>
	/// A token that represents Json property value.
	/// </summary>
	public static readonly TokenKindName JsonArrayElement = new("json-array-element", "js-a-e");
}
