using Fydar.Samples.Rendering.Layouts;
using Fydar.Samples.Rendering.Themes;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fydar.Samples.Rendering;

public interface ISampleRenderer
{
	public string Extension { get; }

	public Task RenderAsync(
		Sample sample,
		Layout layout,
		Theme theme,
		Stream output,
		CancellationToken cancellationToken = default);
}
