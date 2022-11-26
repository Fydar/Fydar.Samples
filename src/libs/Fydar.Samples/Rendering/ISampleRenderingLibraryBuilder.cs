using System;

namespace Fydar.Samples.Rendering;

public interface ISampleRenderingLibraryBuilder
{
	ISampleRenderingLibraryBuilder Configure(Action<SampleRenderer> value);

	ISampleRenderingLibraryBuilder Configure<TModel>(Action<SampleRenderer<TModel>> value);

	SampleRenderingLibrary Build();
}
