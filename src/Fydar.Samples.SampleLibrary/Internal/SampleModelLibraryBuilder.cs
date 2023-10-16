
using Fydar.Samples.SampleLibrary;

namespace Fydar.Samples.Internal;

internal class SampleModelLibraryBuilder : ISampleFactoryBuilder
{
	public SampleFactory Build()
	{
		return new SampleFactory();
	}
}
