using System.Collections.Generic;

namespace Fydar.Samples.Internal;

internal class RenderExporterDestinationBuilder : IRenderExporterDestinationBuilder
{
	private readonly List<IRenderExporterDestination> destinations;

	internal RenderExporterDestinationBuilder()
	{
		destinations = new List<IRenderExporterDestination>(1);
	}

	public void Destination(IRenderExporterDestination destination)
	{
		destinations.Add(destination);
	}

	public IRenderExporterDestination[] Build()
	{
		return destinations.ToArray();
	}
}
