namespace Fydar.Samples;

public interface ISampleBuilder
{
	public IFeatureCollection<ISampleFeature> Features { get; }
	public string Name { get; set; }

	public Sample Build();
}
