using Fydar.Samples.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Fydar.Samples;

public class SampleFactory
{
	internal SampleFactory()
	{
	}

	public async IAsyncEnumerable<Sample> CreateSamplesAsync(
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		await Task.Delay(10);

		yield return Sample.Create("a")
			.Build();
	}

	public static ISampleFactoryBuilder Create()
	{
		return new SampleModelLibraryBuilder();
	}

	public static SampleFactory Create(Action<ISampleFactoryBuilder> samples)
	{
		var builder = new SampleModelLibraryBuilder();
		samples.Invoke(builder);
		return builder.Build();
	}
}
