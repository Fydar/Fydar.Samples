namespace Fydar.Samples.Internal;

internal class SampleBuilder : ISampleBuilder
{
	public string Name { get; set; }
	public IFeatureCollection<ISampleFeature> Features { get; }

	internal SampleBuilder(string name)
	{
		Name = name;
		Features = new FeatureCollection<ISampleFeature>();
	}

	public Sample Build()
	{
		return new Sample(Name, Features);
	}
}
