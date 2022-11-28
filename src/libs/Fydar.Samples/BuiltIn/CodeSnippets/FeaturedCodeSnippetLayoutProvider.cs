using Fydar.Samples.Rendering;

namespace Fydar.Samples.BuiltIn.CodeSnippets;

public class FeaturedCodeSnippetLayoutProvider : ISampleLayoutProvider
{
	public string Name => "featured";

	public bool TryConfigureGraphic(IGraphicBuilder graphic)
	{
		return false;
	}
}
