using Fydar.Samples.Lexing;
using System;
using System.Text;

namespace Fydar.Samples.Grammars.Json.Internal.Classifiers;

internal class SingleCharacterTokenClassifier : IUtf8TokenClassifier
{
	private readonly byte matchedCharacterByte;
	private readonly TokenKind tokenKind;

	public SingleCharacterTokenClassifier(char matchedCharacter, TokenKind tokenKind)
	{
		byte[] matchedCharacterBytes = Encoding.UTF8.GetBytes(matchedCharacter.ToString());

		if (matchedCharacterBytes.Length > 1)
		{
			throw new InvalidOperationException($"Unable to create a single-character token classifier using the UTF8 multi-byte character '{matchedCharacter}'.");
		}
		matchedCharacterByte = matchedCharacterBytes[0];

		this.tokenKind = tokenKind;
	}

	/// <inheritdoc/>
	public void MoveNext(ref Utf8Classifier classifier)
	{
		if (classifier.Current == matchedCharacterByte)
		{
			classifier.TokenizeFromCurrent(tokenKind);
		}
		else
		{
			classifier.GiveUp();
		}
	}
}
