using Fydar.Samples.Grammars;
using System;
using System.Collections.Generic;

namespace Fydar.Samples.Rendering.Themes;

public class Theme
{
	private readonly Dictionary<Type, object> themedComponents;

	public string Name { get; }

	internal Theme(
		string name,
		Dictionary<Type, object> themedComponents)
	{
		Name = name;
		this.themedComponents = themedComponents;
	}

	public TComponent GetComputedStyle<TComponent>(TokenKind first)
		where TComponent : new()
	{
		if (themedComponents.TryGetValue(typeof(TComponent), out object? component))
		{
			var builder = (ThemeOptions<TComponent>)component;
			return builder.GetComputedStyle(first);
		}
		return new();
	}

	public TComponent GetComputedStyle<TComponent>(TokenKind first, TokenKind second)
		where TComponent : new()
	{
		if (themedComponents.TryGetValue(typeof(TComponent), out object? component))
		{
			var builder = (ThemeOptions<TComponent>)component;
			return builder.GetComputedStyle(first, second);
		}
		return new();
	}

	public static ThemeBuilder Create(string name)
	{
		return new ThemeBuilder(name);
	}
}
