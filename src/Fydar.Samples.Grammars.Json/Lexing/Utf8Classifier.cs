using Fydar.Samples.Grammars;
using Fydar.Samples.Lexing.Internal;

namespace Fydar.Samples.Lexing;

/// <summary>
/// The interface that an <see cref="IUtf8TokenClassifier"/> has to interact with the <see cref="Utf8Lexer"/>.
/// </summary>
public ref struct Utf8Classifier
{
	internal TokenKind favouredTokenKind;
	internal int favouredTokenLength;

	internal bool anyContinuing;
	internal int currentClassifierIndex;
	internal BitArray64 hasClassifierGivenUp;

	/// <summary>
	/// The length of the span that the classifier is currently considering.
	/// </summary>
	public int SpanLength { get; internal set; }

	/// <summary>
	/// The current byte that the classifier is currently considering.
	/// </summary>
	public byte Current { get; internal set; }

	/// <summary>
	/// Instructs the <see cref="Utf8Lexer"/> to ignore this classifier and the tokens it could produce.
	/// </summary>
	public void GiveUp()
	{
		hasClassifierGivenUp.SetTrue(currentClassifierIndex);
	}

	/// <summary>
	/// Proposes a tokenized span to the <see cref="Utf8Lexer"/> from the end of the last token to the
	/// <b>previous</b> character this classifier assessed.
	/// </summary>
	public void TokenizeFromLast(TokenKind tokenKind)
	{
		int endLength = SpanLength - 1;

		if (endLength > favouredTokenLength)
		{
			favouredTokenLength = endLength;
			favouredTokenKind = tokenKind;
		}
		hasClassifierGivenUp.SetTrue(currentClassifierIndex);
	}

	/// <summary>
	/// Proposes a tokenized span to the <see cref="Utf8Lexer"/> from the end of the last token to the
	/// <b>current</b> character this classifier is assessing.
	/// </summary>
	public void TokenizeFromCurrent(TokenKind tokenKind)
	{
		if (SpanLength > favouredTokenLength)
		{
			favouredTokenLength = SpanLength;
			favouredTokenKind = tokenKind;
		}
		hasClassifierGivenUp.SetTrue(currentClassifierIndex);
	}

	/// <summary>
	/// Instructs the <see cref="Utf8Lexer"/> to continue reading.
	/// </summary>
	public void ContinueReading()
	{
		anyContinuing = true;
	}
}
