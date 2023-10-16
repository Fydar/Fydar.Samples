using System.IO;
using System.Reflection;

namespace Fydar.Samples.BuiltIn.CodeSnippets;

public static class ISampleModelLibraryBuilderExtensions
{
	public static ISampleFactoryBuilder AddCodeSnippetsFromSourceFiles(this ISampleFactoryBuilder builder, string path)
	{
		// builder.AddFromSampleProvider(new CodeSnippetsFromSourceFilesSampleProvider(path));
		return builder;
	}

	public static ISampleFactoryBuilder AddCodeSnippetsFromSourceFiles(this ISampleFactoryBuilder builder, DirectoryInfo directory)
	{
		// builder.AddFromSampleProvider(new CodeSnippetsFromSourceFilesSampleProvider(directory.FullName));
		return builder;
	}

	public static ISampleFactoryBuilder AddCodeSnippetsFromAttributes(this ISampleFactoryBuilder builder)
	{


		return builder;
	}

	public static ISampleFactoryBuilder AddCodeSnippetsFromAttributes(this ISampleFactoryBuilder builder, Assembly assembly)
	{


		return builder;
	}
}
