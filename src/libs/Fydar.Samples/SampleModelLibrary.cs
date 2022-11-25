using Fydar.Samples.Internal;
using System;

namespace Fydar.Samples;

public class SampleModelLibrary
{
	internal SampleModelLibrary()
	{
	}

	public static ISampleModelLibraryBuilder Create()
	{
		return new SampleModelLibraryBuilder();
	}

	public static SampleModelLibrary Create(Action<ISampleModelLibraryBuilder> samples)
	{
		var builder = new SampleModelLibraryBuilder();
		samples.Invoke(builder);
		return builder.Build();
	}
}
