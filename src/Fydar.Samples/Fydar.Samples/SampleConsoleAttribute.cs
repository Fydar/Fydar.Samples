using System;

namespace Fydar.Samples
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class SampleConsoleAttribute : Attribute
	{
		public string Name { get; }

		public SampleConsoleAttribute(string name)
		{
			Name = name;
		}
	}
}
