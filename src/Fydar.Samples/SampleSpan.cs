namespace Fydar.Samples.Formatting
{
	public readonly struct SampleSpan
	{
		public string Content { get; }
		public string? Style { get; }
		public string? LinkURL { get; }

		public SampleSpan(string content)
		{
			Content = content;
			Style = null;
			LinkURL = null;
		}

		public SampleSpan(string content, string? style)
		{
			Content = content;
			Style = style;
			LinkURL = null;
		}

		public SampleSpan(string content, string? style, string? linkUrl)
		{
			Content = content;
			Style = style;
			LinkURL = linkUrl;
		}
	}
}
