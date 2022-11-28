namespace Fydar.Samples.Internal;

internal class SampleModelLibraryBuilder : ISampleFactoryBuilder
{
	public void AddFromSampleProvider(ISampleProvider sampleProvider)
	{
		throw new System.NotImplementedException();
	}

	public SampleFactory Build()
	{
		return new SampleFactory();
	}
}
