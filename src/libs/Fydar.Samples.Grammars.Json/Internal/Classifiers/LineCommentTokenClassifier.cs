using Fydar.Samples.Grammars.Json.Lexing;

namespace Fydar.Samples.Grammars.Json.Internal.Classifiers;

internal class LineCommentTokenClassifier : IUtf8TokenClassifier
{
	private readonly TokenKind tokenKind;

	public LineCommentTokenClassifier(TokenKind tokenKind)
	{
		this.tokenKind = tokenKind;
	}

	/// <inheritdoc/>
	public void MoveNext(ref Utf8Classifier classifier)
	{
		if (classifier.SpanLength <= 1)
		{
			if (classifier.Current == 0x2f) // UTF-8 0x2f = '/' 
			{
				classifier.ContinueReading();
			}
			else
			{
				classifier.GiveUp();
			}
		}
		else if (Utf8CharUtilities.IsNewline(classifier.Current))
		{
			classifier.TokenizeFromLast(tokenKind);
		}
		else
		{
			classifier.ContinueReading();
		}
	}
}
