using Fydar.Samples.Lexing;

namespace Fydar.Samples.Grammars.Json.Internal.Classifiers;

internal class WhitespaceTokenClassifier : IUtf8TokenClassifier
{
	private readonly TokenKind tokenKind;

	public WhitespaceTokenClassifier(TokenKind tokenKind)
	{
		this.tokenKind = tokenKind;
	}

	/// <inheritdoc/>
	public void MoveNext(ref Utf8Classifier classifier)
	{
		bool isMatched = Utf8CharUtilities.IsWhitespace(classifier.Current);

		if (classifier.SpanLength != 0)
		{
			if (!isMatched)
			{
				classifier.TokenizeFromLast(tokenKind);
			}
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
