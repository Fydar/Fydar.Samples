using Fydar.Samples.Rendering;

namespace Fydar.Samples;

public interface ISampleProjectBuilder
{
	ISampleProjectBuilder AddSampleLibrary(ISampleLibrary sampleGenerator);
	ISampleProjectBuilder RenderTo(ISampleRenderer sampleRenderer);
	SampleProject Build();
}
