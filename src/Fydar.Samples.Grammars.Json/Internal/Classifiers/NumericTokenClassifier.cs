using Fydar.Samples.Lexing;

namespace Fydar.Samples.Grammars.Json.Internal.Classifiers;

internal class NumericTokenClassifier : IUtf8TokenClassifier
{
	private readonly TokenKind tokenKind;

	public NumericTokenClassifier(TokenKind tokenKind)
	{
		this.tokenKind = tokenKind;
	}

	/// <inheritdoc/>
	public void MoveNext(ref Utf8Classifier classifier)
	{
		bool isMatched = Utf8CharUtilities.IsDigit(classifier.Current)
			|| classifier.Current == 0x2e; // 0x2e = UTF-8 '.'

		if (classifier.SpanLength == 0)
		{
			if (classifier.Current == 0x2d)  // 0x2d = UTF-8 '-'
			{
				classifier.ContinueReading();
				return;
			}
		}
		else if (!isMatched)
		{
			classifier.TokenizeFromLast(tokenKind);
			return;
		}

		if (isMatched)
		{
			classifier.ContinueReading();
		}
		else
		{
			classifier.GiveUp();
		}
	}
}
