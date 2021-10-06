using System.IO;

namespace Fydar.Samples.Rendering
{
	public interface ISampleRenderer
	{
		string Extension { get; }
		void Render(Sample sample, Stream output);
	}
}
