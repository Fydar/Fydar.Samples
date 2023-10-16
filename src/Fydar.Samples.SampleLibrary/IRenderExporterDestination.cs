using System.Threading;
using System.Threading.Tasks;

namespace Fydar.Samples;

public interface IRenderExporterDestination
{
	public Task WriteRenderAsync(
		RenderExportRequest renderExportRequest,
		CancellationToken cancellationToken = default);
}
