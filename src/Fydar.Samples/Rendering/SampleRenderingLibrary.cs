using Fydar.Samples.Rendering.Internal;
using System;

namespace Fydar.Samples.Rendering;

public class SampleRenderingLibrary
{
	internal SampleRenderingLibrary()
	{
	}

	public static ISampleRenderingLibraryBuilder Create()
	{
		return new SampleRenderingLibraryBuilder();
	}

	public static SampleRenderingLibrary Create(Action<ISampleRenderingLibraryBuilder> factory)
	{
		var builder = new SampleRenderingLibraryBuilder();
		factory.Invoke(builder);
		return builder.Build();
	}
}
