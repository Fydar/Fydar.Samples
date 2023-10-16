using System.IO;

namespace Fydar.Samples;

public class RenderExportRequest
{

	public string LocalFileName { get; set; } = "";

	public Stream? FormattedSample { get; set; } = null;
}
