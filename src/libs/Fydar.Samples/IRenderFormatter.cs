using Fydar.Samples.Rendering;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fydar.Samples;

public interface IRenderFormatter
{
	public Task WriteAsync(
		Graphic graphic,
		Stream destination,
		CancellationToken cancellationToken = default);
}
