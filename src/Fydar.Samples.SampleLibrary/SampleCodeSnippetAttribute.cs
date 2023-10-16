using System;

namespace Fydar.Samples.BuiltIn.CodeSnippets;

[AttributeUsage(AttributeTargets.ReturnValue)]
public class SampleCodeSnippetAttribute : Attribute
{
	public string Format { get; }

	public SampleCodeSnippetAttribute(string format = "txt")
	{
		Format = format;
	}
}
