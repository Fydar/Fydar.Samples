namespace Fydar.Samples.Grammars;

/// <summary>
/// A set of standardised set of tokens used across multiple languages.
/// </summary>
public static class StandardToken
{
	/// <summary>
	/// A token that represents the line number.
	/// </summary>
	public static readonly TokenKindName LineNumber = new("linenumber", "ln");

	/// <summary>
	/// A token that represents an identifier across multiple languages.
	/// </summary>
	public static readonly TokenKindName Whitespace = new("whitespace", "w");

	/// <summary>
	/// A token that represents an identifier across multiple languages.
	/// </summary>
	public static readonly TokenKindName Newline = new("whitespace-newline", "nl", Whitespace);

	/// <summary>
	/// A token that represents an identifier across multiple languages.
	/// </summary>
	public static readonly TokenKindName Identifier = new("identifier", "i");

	/// <summary>
	/// A token that represents a property name across multiple languages.
	/// </summary>
	public static readonly TokenKindName PropertyName = new("propertyname", "pn");

	/// <summary>
	/// A token that represents a keyword across multiple languages.
	/// </summary>
	public static readonly TokenKindName Keyword = new("keyword", "kw");

	/// <summary>
	/// A token that represents a keyword across multiple languages.
	/// </summary>
	public static readonly TokenKindName KeywordControl = new("keyword-control", "kwc");

	/// <summary>
	/// A token that represents a string across multiple languages.
	/// </summary>
	public static readonly TokenKindName String = new("string", "s");

	/// <summary>
	/// A token that represents an escaped portion of a string across multiple languages.
	/// </summary>
	public static readonly TokenKindName StringEscaped = new("string-escaped", "se", String);

	/// <summary>
	/// A token that represents a numberic literal across multiple languages.
	/// </summary>
	public static readonly TokenKindName Number = new("number", "n");

	/// <summary>
	/// A token that represents a comment across multiple languages.
	/// </summary>
	public static readonly TokenKindName Comment = new("comment", "c");

	/// <summary>
	/// A token that represents a type across multiple languages.
	/// </summary>
	public static readonly TokenKindName Type = new("type", "t");

	/// <summary>
	/// A token that represents a structure across multiple languages.
	/// </summary>
	public static readonly TokenKindName Structure = new("structure", "st");
}
