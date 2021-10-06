namespace Fydar.Samples
{
	public class Sample
	{
		public string Identifier { get; set; } = string.Empty;
		public SampleLine[] Lines { get; }

		public Sample(string identifier, SampleLine[] lines)
		{
			Identifier = identifier;
			Lines = lines;
		}
	}
}
