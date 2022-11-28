namespace Fydar.Samples;

public interface ISampleFactoryBuilder
{
	public void Add(Sample sample);

	public void AddFromSampleProvider(ISampleProvider sampleProvider);
}
