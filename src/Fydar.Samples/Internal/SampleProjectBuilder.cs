using Fydar.Samples.Rendering;
using System.Collections.Generic;

namespace Fydar.Samples.Internal;

internal class SampleProjectBuilder : ISampleProjectBuilder
{
	private readonly List<ISampleLibrary> sampleLibraries = new();
	private readonly List<ISampleRenderer> sampleRenderers = new();

	public ISampleProjectBuilder AddSampleLibrary(ISampleLibrary sampleGenerator)
	{
		sampleLibraries.Add(sampleGenerator);
		return this;
	}

	public ISampleProjectBuilder RenderTo(ISampleRenderer sampleRenderer)
	{
		sampleRenderers.Add(sampleRenderer);
		return this;
	}

	public SampleProject Build()
	{
		return null;
		// return new SampleProject(sampleLibraries.ToArray(), sampleRenderers.ToArray());
	}
}
