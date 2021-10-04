namespace Fydar.Samples.Formatting
{
	public class SampleContent
	{
		public string Name { get; }
		public CodeSpan[][] Lines { get; }

		public SampleContent(string name, CodeSpan[][] lines)
		{
			Name = name;
			Lines = lines;
		}
	}
}
