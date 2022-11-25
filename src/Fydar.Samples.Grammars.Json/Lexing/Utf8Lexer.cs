using Fydar.Samples.Grammars;
using System;

namespace Fydar.Samples.Lexing;

/// <summary>
/// A lexer used to classify spans of text using an <see cref="IUtf8LexerLanguage"/>.
/// </summary>
public class Utf8Lexer
{
	/// <summary>
	/// The <see cref="IUtf8LexerLanguage"/> that this <see cref="Utf8Lexer"/> uses to classify spans.
	/// </summary>
	public IUtf8LexerLanguage LexerLanguage { get; }

	/// <summary>
	/// Constructs a new instance of the <see cref="Utf8Lexer"/> class.
	/// </summary>
	/// <param name="lexerLanguage">The language used to classify spans.</param>
	public Utf8Lexer(IUtf8LexerLanguage lexerLanguage)
	{
		LexerLanguage = lexerLanguage;
	}

	/// <summary>
	/// An enumerable structure used to tokenise a source.
	/// </summary>
	public readonly ref struct Utf8GrammerTokenizer
	{
		private readonly IUtf8TokenClassifier[] classifiers;
		private readonly ReadOnlySpan<byte> bytes;

		internal Utf8GrammerTokenizer(IUtf8TokenClassifier[] classifiers, ReadOnlySpan<byte> bytes)
		{
			this.classifiers = classifiers;
			this.bytes = bytes;
		}

		public Utf8GrammerTokenizerEnumerator GetEnumerator()
		{
			return new Utf8GrammerTokenizerEnumerator(classifiers, bytes);
		}

		public ref struct Utf8GrammerTokenizerEnumerator
		{
			private readonly IUtf8TokenClassifier[] classifiers;
			private readonly ReadOnlySpan<byte> bytes;

			private int currentIndex;
			private int startIndex;
			private int minimumActiveClassifierIndex;
			private Utf8Classifier classifierAction;

			public GrammarToken Current { get; private set; }

			internal Utf8GrammerTokenizerEnumerator(IUtf8TokenClassifier[] classifiers, ReadOnlySpan<byte> bytes)
			{
				this.classifiers = classifiers;
				this.bytes = bytes;

				currentIndex = 0;
				startIndex = 0;
				minimumActiveClassifierIndex = 0;

				classifierAction = new Utf8Classifier()
				{
					favouredTokenLength = -1
				};

				Current = default;
			}

			public bool MoveNext()
			{
				int classifiersCount = classifiers.Length;

				while (currentIndex <= bytes.Length)
				{
					// Read the next UTF8 character.
					// TODO: Utilise proper end-of-file or end-of-stream indicators.
					// TODO: Utilise the System.Text Rune API for representing the current character.

					classifierAction.anyContinuing = false;
					classifierAction.Current = currentIndex != bytes.Length
						? bytes[currentIndex]
						: (byte)32; // UTF8 for SPACE;

					// Iterate through all of our classifiers until they have all given up or tokenized.
					for (int i = minimumActiveClassifierIndex; i < classifiersCount; i++)
					{
						if (classifierAction.hasClassifierGivenUp[i])
						{
							// To optimize, once we have assessed that this classifier has given up, don't re-check it in the future.
							if (i == minimumActiveClassifierIndex)
							{
								minimumActiveClassifierIndex++;
							}
							continue;
						}

						classifierAction.currentClassifierIndex = i;

						var classifier = classifiers[i];
						classifier.MoveNext(ref classifierAction);
					}

					if (classifierAction.anyContinuing)
					{
						classifierAction.SpanLength++;
						currentIndex++;
					}
					else
					{
						// Where we able to classify the span?
						if (classifierAction.favouredTokenLength != -1)
						{
							int favouredTokenEndIndex = startIndex + classifierAction.favouredTokenLength;

							Current = new GrammarToken(
								classifierAction.favouredTokenKind,
								new Range(startIndex, favouredTokenEndIndex + 1)
							);

							startIndex = favouredTokenEndIndex + 1;
							currentIndex = favouredTokenEndIndex + 1;
						}
						else
						{
							// Inform the consumer that we are unable to classify the span.
							Current = new GrammarToken(
								TokenKind.Unknown,
								new Range(startIndex, startIndex + 1)
							);

							// Advance by a single index and try again.
							currentIndex = startIndex + 1;
							startIndex += 1;
						}

						// Reset classifier state
						classifierAction.SpanLength = 0;
						classifierAction.favouredTokenLength = -1;
						classifierAction.favouredTokenKind = TokenKind.Unknown;
						classifierAction.hasClassifierGivenUp.Clear();

						minimumActiveClassifierIndex = 0;
						break;
					}
				}
				return currentIndex <= bytes.Length;
			}
		}
	}

	/// <summary>
	/// Iterates over the classifiable spans present in the source.
	/// </summary>
	/// <param name="bytes">A span to classify.</param>
	/// <returns>A collection representing every classified token in the source.</returns>
	public Utf8GrammerTokenizer Tokenize(ReadOnlySpan<byte> bytes)
	{
		return new Utf8GrammerTokenizer(LexerLanguage.Classifiers, bytes);
	}
}
