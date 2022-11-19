namespace Fydar.Samples;

public class Sample
{
	/// <summary>
	/// The path to the sample relative to the sample project root.
	/// </summary>
	public string PathToFile { get; } = string.Empty;

	/// <summary>
	/// The named region that the sample is sampled from.
	/// </summary>
	public string Region { get; } = string.Empty;

	/// <summary>
	/// The line that this sample starts on.
	/// </summary>
	public int? StartLineNumber { get; } = null;

	/// <summary>
	/// The line that this sample ends on.
	/// </summary>
	public int? EndLineNumber { get; } = null;

	public Sample(string pathToFile, string region, int? startLineNumber, int? endLineNumber)
	{
		PathToFile = pathToFile;
		Region = region;
		StartLineNumber = startLineNumber;
		EndLineNumber = endLineNumber;
	}
}
