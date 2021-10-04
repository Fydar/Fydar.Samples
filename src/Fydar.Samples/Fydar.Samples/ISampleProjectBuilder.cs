using Fydar.Samples.Rendering;

namespace Fydar.Samples
{
	public interface ISampleProjectBuilder
	{
		ISampleProjectBuilder AddFrom(ISampleGenerator sampleGenerator);
		ISampleProjectBuilder RenderTo(ISampleRenderer sampleRenderer);
		SampleProject Build();
	}
}
