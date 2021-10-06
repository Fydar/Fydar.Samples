using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Fydar.Samples.Formatting
{
	public class SampleReturnSampleSource : ISampleSources
	{
		private readonly Assembly assembly;

		public SampleReturnSampleSource(Assembly assembly)
		{
			this.assembly = assembly;
		}

		public async IAsyncEnumerable<SampleSource> LocateSamples()
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
								yield return new SampleSource(
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
}
