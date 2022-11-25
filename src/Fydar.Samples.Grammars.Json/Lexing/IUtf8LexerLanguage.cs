namespace Fydar.Samples.Lexing;

/// <summary>
/// A language used to classify spans of text.
/// </summary>
public interface IUtf8LexerLanguage
{
	/// <summary>
	/// A collection of <see cref="IUtf8TokenClassifier"/>s used to classify spans of text.
	/// </summary>
	public IUtf8TokenClassifier[] Classifiers { get; }
}
