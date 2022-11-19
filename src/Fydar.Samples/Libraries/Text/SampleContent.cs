using System;
using System.IO;

namespace Fydar.Samples.Formatting;

public class SampleContent
{
	public string Name { get; set; }
	public string Extension { get; set; }
	public Func<Stream> Open { get; }

	public SampleContent(
		string name,
		string extension,
		Func<Stream> open)
	{
		Name = name;
		Extension = extension;
		Open = open;
	}
}
