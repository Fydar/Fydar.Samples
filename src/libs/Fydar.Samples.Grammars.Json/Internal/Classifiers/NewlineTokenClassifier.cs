using Fydar.Samples.Lexing;

namespace Fydar.Samples.Grammars.Json.Internal.Classifiers;

internal class NewlineTokenClassifier : IUtf8TokenClassifier
{
	private readonly TokenKind tokenKind;

	public NewlineTokenClassifier(TokenKind tokenKind)
	{
		this.tokenKind = tokenKind;
	}

	/// <inheritdoc/>
	public void MoveNext(ref Utf8Classifier classifier)
	{
		if (classifier.Current == 0x0A) // UTF-8 0x0A = LF
		{
			classifier.TokenizeFromCurrent(tokenKind);
		}
		else if (classifier.Current == 0x0D) // UTF-8 0x0D = CR
		{
			classifier.ContinueReading();
		}
		else
		{
			classifier.GiveUp();
		}
	}
}
