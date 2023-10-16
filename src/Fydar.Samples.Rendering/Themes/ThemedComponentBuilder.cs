using Fydar.Samples.Grammars;
using System;
using System.Collections.Generic;

namespace Fydar.Samples.Rendering.Themes;

public interface IThemedComponentBuilder
{
	public object Build();
}

public class ThemedComponentBuilder<TOptions> : IThemedComponentBuilder
	where TOptions : new()
{
	private readonly List<Action<TOptions>> styleDefaultActions = new();
	private readonly Dictionary<string, List<Action<TOptions>>> styleClassActions = new();

	public void StyleDefault(Action<TOptions> classStyle)
	{
		styleDefaultActions.Add(classStyle);
	}

	public void StyleClass(string tokenKind, Action<TOptions> classStyle)
	{
		if (!styleClassActions.TryGetValue(tokenKind, out var actions))
		{
			actions = new List<Action<TOptions>>();
			styleClassActions.Add(tokenKind, actions);
		}

		actions.Add(classStyle);
	}

	public object Build()
	{
		return new ThemeOptions<TOptions>(
			styleDefaultActions,
			styleClassActions);
	}
}
