using Fydar.Samples.Rendering.Themes.Selectors;
using System;
using System.Collections.Generic;

namespace Fydar.Samples.Rendering.Themes;

public class ThemeBuilder
{
	private readonly string name;
	private readonly Dictionary<Type, IThemedComponentBuilder> themedComponentBuilders;

	internal ThemeBuilder(string name)
	{
		this.name = name;
		themedComponentBuilders = [];
	}

	public ThemeBuilder Configure<TStyle>(Action<TStyle> style)
		where TStyle : new()
	{
		themedComponentBuilders.TryGetValue(typeof(TStyle), out var themedComponentCollection);
		if (themedComponentCollection is not ThemedComponentBuilder<TStyle> themedComponents)
		{
			themedComponents = new ThemedComponentBuilder<TStyle>();
			themedComponentBuilders[typeof(TStyle)] = themedComponents;
		}

		themedComponents.StyleDefault(style);
		return this;
	}

	public ThemeBuilder Configure<TStyle>(Selector selector, Action<TStyle> style)
		where TStyle : new()
	{
		if (selector is ClassSelectorElement classSelectorElement)
		{
			themedComponentBuilders.TryGetValue(typeof(TStyle), out var collection);
			if (collection is not ThemedComponentBuilder<TStyle> optionsOfType)
			{
				optionsOfType = new ThemedComponentBuilder<TStyle>();
				themedComponentBuilders[typeof(TStyle)] = optionsOfType;
			}

			optionsOfType.StyleClass(classSelectorElement.ClassName, style);
		}

		return this;
	}

	public Theme Build()
	{
		var builtThemedComponents = new Dictionary<Type, object>();
		foreach (var themedComponent in themedComponentBuilders)
		{
			builtThemedComponents[themedComponent.Key] = themedComponent.Value.Build();
		}

		return new Theme(
			name,
			builtThemedComponents);
	}

	public static implicit operator Theme(ThemeBuilder builder)
	{
		return builder.Build();
	}
}
