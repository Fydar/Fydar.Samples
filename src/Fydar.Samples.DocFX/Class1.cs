using Docfx.Plugins;
using System.Collections.Immutable;
using System.Composition;

namespace Fydar.Samples.DocFX;

[Export(nameof(MyProcessor), typeof(IPostProcessor))]
public class MyProcessor : IPostProcessor
{
	public ImmutableDictionary<string, object> PrepareMetadata(ImmutableDictionary<string, object> metadata)
	{
		// TODO: add/remove/update property from global metadata
		return metadata;
	}

	public Manifest Process(Manifest manifest, string outputFolder)
	{
		foreach (var page in manifest.Files)
		{
		}
		// TODO: add/remove/update all the files included in manifest
		return manifest;
	}
}
