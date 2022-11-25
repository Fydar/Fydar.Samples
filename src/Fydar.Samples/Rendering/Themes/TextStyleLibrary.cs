using Fydar.Samples.Grammars;
using System;
using System.Collections.Generic;

namespace Fydar.Samples.Rendering.Themes;

public class TextStyleLibrary
{
	private readonly List<Action<ComputedTextStyle>> styleDefaultActions = new();
	private readonly Dictionary<TokenKind, List<Action<ComputedTextStyle>>> styleClassActions = new();

	internal TextStyleLibrary(
		List<Action<ComputedTextStyle>> styleDefaultActions,
		Dictionary<TokenKind, List<Action<ComputedTextStyle>>> styleClassActions)
	{
		this.styleDefaultActions = styleDefaultActions;
		this.styleClassActions = styleClassActions;
	}

	public ComputedTextStyle GetComputedTextStyle(TokenKind tokenKind)
	{
		var computedStyle = new ComputedTextStyle();

		foreach (var action in styleDefaultActions)
		{
			action.Invoke(computedStyle);
		}

		foreach (var styleInhertedFrom in tokenKind.InheritsFrom)
		{
			if (styleClassActions.TryGetValue(styleInhertedFrom, out var inheritedActions))
			{
				foreach (var action in inheritedActions)
				{
					action.Invoke(computedStyle);
				}
			}
		}

		if (styleClassActions.TryGetValue(tokenKind, out var actions))
		{
			foreach (var action in actions)
			{
				action.Invoke(computedStyle);
			}
		}

		return computedStyle;
	}
	public ComputedTextStyle GetComputedTextStyle(TokenKind tokenKind, TokenKind nodeKind)
	{
		var computedStyle = new ComputedTextStyle();

		foreach (var action in styleDefaultActions)
		{
			action.Invoke(computedStyle);
		}

		foreach (var styleInhertedFrom in tokenKind.InheritsFrom)
		{
			if (styleClassActions.TryGetValue(styleInhertedFrom, out var inheritedActions))
			{
				foreach (var action in inheritedActions)
				{
					action.Invoke(computedStyle);
				}
			}
		}

		if (styleClassActions.TryGetValue(tokenKind, out var actions))
		{
			foreach (var action in actions)
			{
				action.Invoke(computedStyle);
			}
		}

		foreach (var styleInhertedFrom in nodeKind.InheritsFrom)
		{
			if (styleClassActions.TryGetValue(styleInhertedFrom, out var nodeInheritedActions))
			{
				foreach (var action in nodeInheritedActions)
				{
					action.Invoke(computedStyle);
				}
			}
		}

		if (styleClassActions.TryGetValue(nodeKind, out var nodeActions))
		{
			foreach (var action in nodeActions)
			{
				action.Invoke(computedStyle);
			}
		}

		return computedStyle;
	}

	public static TextStyleLibraryBuilder Create()
	{
		return new TextStyleLibraryBuilder();
	}
}
