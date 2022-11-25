namespace Fydar.Samples.Grammars.CSharp;

public static class CSharpToken
{
	public static readonly TokenKindName CSharpKeyword = new("csharp-keyword", "cs-kw", StandardToken.Keyword);
	public static readonly TokenKindName CSharpKeywordControl = new("csharp-keyword-control", "cs-kw-c", CSharpKeyword);

	public static readonly TokenKindName CSharpLocal = new("csharp-local", "cs-l", StandardToken.Identifier);
	public static readonly TokenKindName CSharpParameter = new("csharp-parameter", "cs-pa", StandardToken.Identifier);
	public static readonly TokenKindName CSharpField = new("csharp-field", "cs-f", StandardToken.Identifier);
	public static readonly TokenKindName CSharpProperty = new("csharp-property", "cs-pr", StandardToken.Identifier);
	public static readonly TokenKindName CSharpMethod = new("csharp-method", "cs-m", StandardToken.Identifier);

	public static readonly TokenKindName CSharpString = new("csharp-string", "cs-s", StandardToken.String);
	public static readonly TokenKindName CSharpStringEscaped = new("csharp-string-escaped", "cs-se", StandardToken.StringEscaped);
	public static readonly TokenKindName CSharpNumber = new("csharp-number", "cs-n", StandardToken.Number);

	public static readonly TokenKindName CSharpType = new("csharp-type", "cs-t", StandardToken.Type);
	public static readonly TokenKindName CSharpTypeClass = new("csharp-type-class", "cs-t-c", CSharpType);
	public static readonly TokenKindName CSharpTypeDelegate = new("csharp-type-delegate", "cs-t-d", CSharpType);
	public static readonly TokenKindName CSharpTypeStruct = new("csharp-type-struct", "cs-t-s", CSharpType);
	public static readonly TokenKindName CSharpTypeInterface = new("csharp-type-interface", "cs-t-i", CSharpType);
	public static readonly TokenKindName CSharpTypeEnum = new("csharp-type-enum", "cs-t-e", CSharpType);
	public static readonly TokenKindName CSharpTypeGeneric = new("csharp-type-generic", "cs-t-g", CSharpType);

	public static readonly TokenKindName CSharpComment = new("csharp-comment", "cs-c", StandardToken.Comment);
	public static readonly TokenKindName CSharpCommentXml = new("csharp-comment-xml", "cs-c-x", StandardToken.Comment);
}
