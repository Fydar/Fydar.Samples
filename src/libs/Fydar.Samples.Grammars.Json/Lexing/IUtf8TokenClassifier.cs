namespace Fydar.Samples.Grammars.Json.Lexing;

/// <summary>
/// A classifier used to classify spans of text.
/// </summary>
public interface IUtf8TokenClassifier
{
	/// <summary>
	/// Allows the token classifier to read the next character.
	/// </summary>
	/// <param name="classifier">The current state of the classifier.</param>
	public void MoveNext(
		ref Utf8Classifier classifier);
}
