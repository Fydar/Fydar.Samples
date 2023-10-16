using System.Collections.Generic;

namespace Fydar.Samples.Grammars;

public class TokenKindName
{
	internal static List<TokenKindName> catalogue = new(64)
	{
		new TokenKindName()
	};

	public TokenKind Identifier { get; }

	public string ClassName { get; }

	public string ShortClassName { get; }

	public TokenKindName[] InheritFromNames { get; }

	public IEnumerable<TokenKind> AllInheritsFrom
	{
		get
		{
			for (int i = 0; i < InheritFromNames.Length; i++)
			{
				var inheritsFromName = InheritFromNames[i];

				yield return inheritsFromName.Identifier;

				foreach (var subName in inheritsFromName.AllInheritsFrom)
				{
					yield return subName;
				}
			}
		}
	}

	private TokenKindName()
	{
		ClassName = "Unknown";
		ShortClassName = "x";
		Identifier = new TokenKind(0);
		InheritFromNames = [];
	}

	public TokenKindName(string className, string shortClassName)
	{
		Identifier = NewId();
		ClassName = className;
		ShortClassName = shortClassName;
		InheritFromNames = [];
	}

	public TokenKindName(string className, string shortClassName, params TokenKindName[] inheritFrom)
	{
		Identifier = NewId();
		ClassName = className;
		ShortClassName = shortClassName;
		InheritFromNames = inheritFrom;
	}

	private TokenKind NewId()
	{
		int count = catalogue.Count;
		catalogue.Add(this);
		return new((ushort)count);
	}

	public static implicit operator TokenKind(TokenKindName tokenKind)
	{
		return tokenKind.Identifier;
	}

	public static bool operator ==(TokenKind tokenKind, TokenKindName tokenKindName)
	{
		return tokenKind.tokenId == tokenKindName.Identifier.tokenId;
	}

	public static bool operator !=(TokenKind tokenKind, TokenKindName tokenKindName)
	{
		return tokenKind.tokenId != tokenKindName.Identifier.tokenId;
	}

	public override string ToString()
	{
		return $"{ClassName}";
	}
}
