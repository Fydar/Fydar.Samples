using Fydar.Samples.Formatting;

namespace Fydar.Samples
{
	public readonly struct SampleLine
	{
		public SampleSpan[] Spans { get; }

		public SampleLine(SampleSpan[] spans)
		{
			Spans = spans;
		}
	}
}
