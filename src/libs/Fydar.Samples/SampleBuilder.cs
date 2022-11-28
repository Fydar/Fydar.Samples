namespace Fydar.Samples;

public class SampleBuilder
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
