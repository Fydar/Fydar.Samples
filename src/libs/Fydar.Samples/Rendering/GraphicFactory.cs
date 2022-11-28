using Fydar.Samples.Rendering.Internal;
using System;
using System.Collections.Generic;

namespace Fydar.Samples.Rendering;

public class GraphicFactory
{
	private readonly Action<IGraphicBuilder> pipeline;

	internal GraphicFactory(Action<IGraphicBuilder> pipeline)
	{
	}

	public Graphic[] RenderAllGraphics(Sample sample)
	{
		var output = new List<Graphic>();

		var graphicBuilder = new GraphicBuilder(sample);
		pipeline.Invoke(graphicBuilder);
		output.Add(graphicBuilder.Build());

		return output.ToArray();
	}

	public static GraphicFactory Create(Action<IGraphicBuilder> factory)
	{
		return new GraphicFactory(factory);
	}
}
