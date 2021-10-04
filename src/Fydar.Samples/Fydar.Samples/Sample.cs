using Fydar.Samples.Formatting;

namespace Fydar.Samples
{
	public class Sample
	{
		public string Identifier { get; set; } = string.Empty;
		public SampleContent Content { get; set; }

		public Sample(string identifier, SampleContent content)
		{
			Identifier = identifier;
			Content = content;
		}
	}
}
