namespace Fydar.Samples.BuiltIn;

public class SingleFileSourceFeature : ISampleFeature
{
	public string? FullName { get; set; }

	public string? Name { get; set; }

	public string? Extension { get; set; }

	public int StartLineNumber { get; set; } = -1;

	public int EndLineNumber { get; set; } = -1;
}
