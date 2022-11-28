using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Fydar.Samples;

internal class DirectoryDestination : IRenderExporterDestination
{
	private readonly string directory;

	public DirectoryDestination(string directory)
	{
		this.directory = directory;
	}

	public async Task WriteRenderAsync(
		RenderExportRequest renderExportRequest,
		CancellationToken cancellationToken = default)
	{
		if (renderExportRequest.FormattedSample == null)
		{
			throw new ArgumentException($"'{nameof(renderExportRequest)}' '{nameof(RenderExportRequest.FormattedSample)}' cannot be null.");
		}

		var fileInfo = new FileInfo(Path.Combine(directory, renderExportRequest.LocalFileName));

		if (!fileInfo.Directory.Exists)
		{
			fileInfo.Directory.Create();
		}
		if (fileInfo.Exists)
		{
			fileInfo.Delete();
		}
		var writeStream = fileInfo.OpenWrite();

		await renderExportRequest.FormattedSample.CopyToAsync(writeStream);
	}
}
