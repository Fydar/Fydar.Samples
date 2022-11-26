using Fydar.Samples.Grammars.Json.Lexing;
using System.Text;

namespace Fydar.Samples.Grammars.Json.Internal.Classifiers;

internal class KeywordTokenClassifier : IUtf8TokenClassifier
{
	private readonly byte[] keywordBytes;
	private readonly TokenKind tokenKind;

	public KeywordTokenClassifier(string keyword, TokenKind tokenKind)
	{
		keywordBytes = Encoding.UTF8.GetBytes(keyword);
		this.tokenKind = tokenKind;
	}

	/// <inheritdoc/>
	public void MoveNext(ref Utf8Classifier classifier)
	{
		if (classifier.SpanLength == keywordBytes.Length)
		{
			if (Utf8CharUtilities.IsLetterOrDigit(classifier.Current))
			{
				classifier.GiveUp();
			}
			else
			{
				classifier.TokenizeFromLast(tokenKind);
			}
		}
		else if (classifier.Current == keywordBytes[classifier.SpanLength])
		{
			classifier.ContinueReading();
		}
		else
		{
			classifier.GiveUp();
		}
	}
}
