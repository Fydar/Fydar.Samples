using Fydar.Samples.Formatting.Internal;
using System;

namespace Fydar.Samples.Formatting;

public static class ISampleProjectBuilderExtensions
{
	public static ISampleProjectBuilder AddFormattedSamples(
		this ISampleProjectBuilder sampleProjectBuilder,
		Action<FormattedSamplesOptions> options)
	{
		var optionsModel = new FormattedSamplesOptions();

		options.Invoke(optionsModel);

		sampleProjectBuilder.AddSampleLibrary(new FormattedSampleLibrary(
			optionsModel.sampleFormatters,
			optionsModel.sampleContentLibraries
		));

		return sampleProjectBuilder;
	}
}
