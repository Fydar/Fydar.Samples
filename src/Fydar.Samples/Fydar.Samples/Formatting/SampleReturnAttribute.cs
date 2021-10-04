using System;

namespace Fydar.Samples.Formatting
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class SampleReturnAttribute : Attribute
	{
		public string Extension { get; }
		public string Name { get; }

		public SampleReturnAttribute(string extension, string name)
		{
			Extension = extension;
			Name = name;
		}
	}
}
