using Fydar.Samples.Grammars.Json.Lexing;

namespace Fydar.Samples.Grammars.Json.Internal.Classifiers;

internal class StringTokenClassifier : IUtf8TokenClassifier
{
	private readonly TokenKind tokenKind;

	private bool isEscaped = false;

	public StringTokenClassifier(TokenKind tokenKind)
	{
		this.tokenKind = tokenKind;
	}

	/// <inheritdoc/>
	public void MoveNext(ref Utf8Classifier classifier)
	{
		if (classifier.SpanLength == 0)
		{
			if (classifier.Current == 0x22) // UTF-8 0x22 = '"'
			{
				classifier.ContinueReading();
			}
			else
			{
				classifier.GiveUp();
			}
		}
		else if (classifier.Current == 0x5c) // UTF-8 0x5c = '\' 
		{
			isEscaped = true;
			classifier.ContinueReading();
		}
		else if (classifier.Current == 0x22) // UTF-8 0x22 = '"'
		{
			if (isEscaped)
			{
				isEscaped = false;
				classifier.ContinueReading();
			}
			else
			{
				Reset();
				classifier.TokenizeFromCurrent(tokenKind);
			}
		}
		else
		{
			isEscaped = false;
			classifier.ContinueReading();
		}
	}

	private void Reset()
	{
		isEscaped = false;
	}
}

// TODO: Tokenise escaped characters with a seperate token.
/*
var remaining = content;
while (true)
{
int index = remaining.IndexOf('\\');
if (index == -1)
{
	break;
}
var upToIndex = remaining[..index];
output.Write(upToIndex, style);

int lengthToEscape = 2;
char nextChar = remaining[index + 1];
if (nextChar == 'u')
{
	lengthToEscape = 6;
}
output.Write(remaining[new Range(index, index + lengthToEscape)], escapedString);

remaining = remaining[(index + lengthToEscape)..];
}
output.Write(remaining, style);
*/
