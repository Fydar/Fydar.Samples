using Fydar.Samples.Rendering;
using System.Collections.Generic;

namespace Fydar.Samples.Internal
{
	internal class SampleProjectBuilder : ISampleProjectBuilder
	{
		private readonly List<ISampleGenerator> sampleGenerators = new();
		private readonly List<ISampleRenderer> sampleRenderers = new();

		public ISampleProjectBuilder AddFrom(ISampleGenerator sampleGenerator)
		{
			sampleGenerators.Add(sampleGenerator);
			return this;
		}

		public ISampleProjectBuilder RenderTo(ISampleRenderer sampleRenderer)
		{
			sampleRenderers.Add(sampleRenderer);
			return this;
		}

		public SampleProject Build()
		{
			return new SampleProject(sampleGenerators.ToArray(), sampleRenderers.ToArray());
		}
	}
}
