using System;

namespace Fydar.Samples.Rendering.Layouts;

public class LayoutBuilder
{
	public LayoutBuilderOptions Options { get; set; }

	internal LayoutBuilder()
	{

	}

	public LayoutBuilder Mutate(Action<LayoutBuilderOptions> options)
	{
		options.Invoke(Options);
		return this;
	}

	public Layout Build()
	{
		return new Layout(Options);
	}
}

public class LayoutBuilderOptions
{
	public LayoutElementBuilder? RootElement { get; set; }

}
