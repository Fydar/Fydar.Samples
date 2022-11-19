using Fydar.Samples.Lexing;

namespace Fydar.Samples.Grammars.Json.Internal.Classifiers;

internal class MultiLineCommentTokenClassifier : IUtf8TokenClassifier
{
	private enum State : byte
	{
		ExpectingStartingSlash,
		ExpectingStartingAsterisk,
		ExpectingEndingAsterisk,
		ExpectingEndingSlash,
	}

	private readonly TokenKind tokenKind;

	private State state;

	public MultiLineCommentTokenClassifier(TokenKind tokenKind)
	{
		this.tokenKind = tokenKind;
	}

	/// <inheritdoc/>
	public void MoveNext(ref Utf8Classifier classifier)
	{
		if (state == State.ExpectingStartingSlash)
		{
			if (classifier.Current == 0x2f) // UTF-8 0x2f = '/' 
			{
				state = State.ExpectingStartingAsterisk;
				classifier.ContinueReading();
			}
			else
			{
				classifier.GiveUp();
			}
		}
		else if (state == State.ExpectingStartingAsterisk)
		{
			if (classifier.Current == 0x2a) // UTF-8 0x2A = '*' 
			{
				state = State.ExpectingEndingAsterisk;
				classifier.ContinueReading();
			}
			else
			{
				state = State.ExpectingStartingSlash;
				classifier.GiveUp();
			}
		}
		else if (state == State.ExpectingEndingAsterisk)
		{
			if (classifier.Current == 0x2a) // UTF-8 0x2A = '*' 
			{
				state = State.ExpectingEndingSlash;
			}
			classifier.ContinueReading();
		}
		else if (classifier.Current == 0x2f) // UTF-8 0x2f = '/' 
		{
			state = State.ExpectingStartingSlash;
			classifier.TokenizeFromCurrent(tokenKind);
		}
		else
		{
			state = State.ExpectingStartingAsterisk;
			classifier.ContinueReading();
		}
	}
}
