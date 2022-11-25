using Fydar.Samples.CodeSnippets.Text;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Fydar.Samples.CodeSnippets.FromSampleReturn;

public class SampleReturnContentLibrary : ISampleContentLibrary
{
	private readonly Assembly assembly;

	public SampleReturnContentLibrary(Assembly assembly)
	{
		this.assembly = assembly;
	}

	public async IAsyncEnumerable<SampleContent> FindSampleContentsAsync(
		[EnumeratorCancellation] CancellationToken cancellationToken = default)
	{
		foreach (var type in assembly.GetTypes())
		{
			var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (var method in methods)
			{
				foreach (var attribute in method.GetCustomAttributes<SampleReturnAttribute>())
				{
					if (method.GetParameters().Length == 0)
					{
						object? result = method.Invoke(null, null);

						if (result is string resultString)
						{
							yield return new SampleContent(
								attribute.Name,
								attribute.Extension,
								() => new MemoryStream(Encoding.UTF8.GetBytes(resultString)));
						}
					}
				}
			}
		}
	}
}
