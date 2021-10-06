using System;
using System.Collections.Generic;

namespace Fydar.Samples.Formatting
{
	public class SampleBuilder
	{
		private readonly List<SampleSpan> currentLine;
		private readonly List<SampleLine> lines;

		public int Indent { get; }
		public string Name { get; }

		public SampleBuilder(int indent)
		{
			currentLine = new List<SampleSpan>();
			lines = new List<SampleLine>();
			Name = "";
			Indent = indent;
		}

		public SampleBuilder(string name, int indent)
		{
			currentLine = new List<SampleSpan>();
			lines = new List<SampleLine>();
			Name = name;
			Indent = indent;
		}

		public void Write(ReadOnlySpan<char> value)
		{
			Write(value, null, null);
		}

		public void Write(ReadOnlySpan<char> value, string? style)
		{
			Write(value, style, null);
		}

		public void Write(ReadOnlySpan<char> value, string? style, string? linkUrl)
		{
			while (true)
			{
				int index = value.IndexOf(Environment.NewLine);
				if (index == -1)
				{
					break;
				}
				var sliced = value[..index];
				currentLine.Add(new SampleSpan(sliced.ToString(), style, linkUrl));
				WriteNewline();
				value = value[(index + Environment.NewLine.Length)..];
			}
			currentLine.Add(new SampleSpan(value.ToString(), style, linkUrl));
		}

		public void RestartLine()
		{
			currentLine.Clear();
		}

		public void WriteNewline()
		{
			var addLine = currentLine.ToArray();
			currentLine.Clear();

			lines.Add(new SampleLine(addLine));
		}

		public Sample Build()
		{
			if (currentLine.Count > 0)
			{
				bool empty = true;
				foreach (var span in currentLine)
				{
					empty &= string.IsNullOrWhiteSpace(span.Content);
				}
				if (!empty)
				{
					lines.Add(new SampleLine(currentLine.ToArray()));
					currentLine.Clear();
				}
			}

			return new Sample(Name, lines.ToArray());
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
