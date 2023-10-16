using Fydar.Samples.Grammars;
using System;
using System.Collections.Generic;

namespace Fydar.Samples.Rendering.Themes;

public class ThemeOptions<TOptions>
	where TOptions : new()
{
	private readonly List<Action<TOptions>> styleDefaultActions = new();
	private readonly Dictionary<string, List<Action<TOptions>>> styleClassActions = new();

	internal ThemeOptions(
		List<Action<TOptions>> styleDefaultActions,
		Dictionary<string, List<Action<TOptions>>> styleClassActions)
	{
		this.styleDefaultActions = styleDefaultActions;
		this.styleClassActions = styleClassActions;
	}

	public TOptions GetComputedStyle(TokenKind tokenKind)
	{
		var computedStyle = new TOptions();

		foreach (var action in styleDefaultActions)
		{
			action.Invoke(computedStyle);
		}

		foreach (var styleInhertedFrom in tokenKind.InheritsFrom)
		{
			if (styleClassActions.TryGetValue(styleInhertedFrom.Name.ClassName, out var inheritedActions))
			{
				foreach (var action in inheritedActions)
				{
					action.Invoke(computedStyle);
				}
			}
		}

		if (styleClassActions.TryGetValue(tokenKind.Name.ClassName, out var actions))
		{
			foreach (var action in actions)
			{
				action.Invoke(computedStyle);
			}
		}

		return computedStyle;
	}

	public TOptions GetComputedStyle(TokenKind tokenKind, TokenKind nodeKind)
	{
		var computedStyle = new TOptions();

		foreach (var action in styleDefaultActions)
		{
			action.Invoke(computedStyle);
		}

		foreach (var styleInhertedFrom in tokenKind.InheritsFrom)
		{
			if (styleClassActions.TryGetValue(styleInhertedFrom.Name.ClassName, out var inheritedActions))
			{
				foreach (var action in inheritedActions)
				{
					action.Invoke(computedStyle);
				}
			}
		}

		if (styleClassActions.TryGetValue(tokenKind.Name.ClassName, out var actions))
		{
			foreach (var action in actions)
			{
				action.Invoke(computedStyle);
			}
		}

		foreach (var styleInhertedFrom in nodeKind.InheritsFrom)
		{
			if (styleClassActions.TryGetValue(styleInhertedFrom.Name.ClassName, out var nodeInheritedActions))
			{
				foreach (var action in nodeInheritedActions)
				{
					action.Invoke(computedStyle);
				}
			}
		}

		if (styleClassActions.TryGetValue(nodeKind.Name.ClassName, out var nodeActions))
		{
			foreach (var action in nodeActions)
			{
				action.Invoke(computedStyle);
			}
		}

		return computedStyle;
	}
}
