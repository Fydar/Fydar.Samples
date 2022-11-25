using Fydar.Samples.Internal;
using System;

namespace Fydar.Samples;

public class SampleProject
{
	internal SampleProject()
	{
	}

	public static ISampleProjectBuilder Create()
	{
		return new SampleProjectBuilder();
	}

	public static SampleProject Create(Action<ISampleProjectBuilder> project)
	{
		var builder = new SampleProjectBuilder();
		project.Invoke(builder);
		return builder.Build();
	}
}
