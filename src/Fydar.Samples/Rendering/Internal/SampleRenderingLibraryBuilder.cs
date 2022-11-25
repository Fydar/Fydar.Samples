using System;

namespace Fydar.Samples.Rendering.Internal;

internal class SampleRenderingLibraryBuilder : ISampleRenderingLibraryBuilder
{
	public ISampleRenderingLibraryBuilder Configure(Action<SampleRenderer> value)
	{

		return this;
	}

	public ISampleRenderingLibraryBuilder Configure<TModel>(Action<SampleRenderer<TModel>> value)
	{

		return this;
	}

	public SampleRenderingLibrary Build()
	{
		return new SampleRenderingLibrary();
	}
}
