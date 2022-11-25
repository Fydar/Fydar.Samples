using System;

namespace Fydar.Samples.CodeSnippets;

[AttributeUsage(AttributeTargets.ReturnValue)]
public class SampleCodeSnippetAttribute : Attribute
{
	public string Format { get; }

	public SampleCodeSnippetAttribute(string format)
	{
		Format = format;
	}
}
