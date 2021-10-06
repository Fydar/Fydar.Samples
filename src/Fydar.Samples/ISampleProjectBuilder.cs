using Fydar.Samples.Rendering;

namespace Fydar.Samples
{
	public interface ISampleProjectBuilder
	{
		ISampleProjectBuilder AddSamples(ISampleGenerator sampleGenerator);
		ISampleProjectBuilder RenderTo(ISampleRenderer sampleRenderer);
		SampleProject Build();
	}
}
