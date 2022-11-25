using Fydar.Samples.Grammars;
using System;
using System.Collections.Generic;

namespace Fydar.Samples.Rendering.Themes;

public class TextStyleLibraryBuilder
{
	private readonly List<Action<ComputedTextStyle>> styleDefaultActions = new();
	private readonly Dictionary<TokenKind, List<Action<ComputedTextStyle>>> styleClassActions = new();

	public TextStyleLibraryBuilder StyleDefault(Action<ComputedTextStyle> classStyle)
	{
		styleDefaultActions.Add(classStyle);
		return this;
	}

	public TextStyleLibraryBuilder StyleClass(TokenKind tokenKind, Action<ComputedTextStyle> classStyle)
	{
		if (!styleClassActions.TryGetValue(tokenKind, out var actions))
		{
			actions = new List<Action<ComputedTextStyle>>();
			styleClassActions.Add(tokenKind, actions);
		}

		actions.Add(classStyle);
		return this;
	}

	public TextStyleLibrary Build()
	{
		return new TextStyleLibrary(
			styleDefaultActions,
			styleClassActions);
	}
}
