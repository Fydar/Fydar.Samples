using Fydar.Samples.Internal;

namespace Fydar.Samples;

public class Sample
{
	public string Name { get; }
	public IReadOnlyFeatureCollection<ISampleFeature> Features { get; }

	internal Sample(string name, IReadOnlyFeatureCollection<ISampleFeature> features)
	{
		Features = features;
	}

	public static ISampleBuilder Create(string name)
	{
		return new SampleBuilder(name);
	}
}
