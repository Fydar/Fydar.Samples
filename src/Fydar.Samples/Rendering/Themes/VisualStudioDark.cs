using System.Collections.Generic;

namespace Fydar.Samples.Rendering.Themes;

public static class VisualStudioDark
{
	public static Theme Theme { get; }

	static VisualStudioDark()
	{
		Theme = new Theme()
		{
			FontStyles = new Dictionary<string, ThemeFontSpanStyle>()
			{
				["default"] = new()
				{
					FontColor = "#dcdcdc",
					FontWeight = "normal"
				},
				["col.ln.number"] = new()
				{
					InheritFrom = "default",
					FontColor = "#b90af"
				},
				["code"] = new()
				{
					InheritFrom = "default"
				},
				["code.keyword"] = new()
				{
					InheritFrom = "code",
					FontColor = "#569cd6"
				},
				["code.control"] = new()
				{
					InheritFrom = "code",
					FontColor = "#d8a0df"
				},
				["code.string"] = new()
				{
					InheritFrom = "code",
					FontColor = "#d69d85"
				},
				["code.string.escape"] = new()
				{
					InheritFrom = "code.string",
					FontColor = "#ffd68f"
				},
				["code.numeric"] = new()
				{
					InheritFrom = "code",
					FontColor = "#b5cfa8"
				},
				["code.comment"] = new()
				{
					InheritFrom = "code",
					FontColor = "#57a64a"
				},
				["code.class"] = new()
				{
					InheritFrom = "code",
					FontColor = "#4ec9b0"
				},
				["code.interface"] = new()
				{
					InheritFrom = "code",
					FontColor = "#b8d7a3"
				},
				["code.enum"] = new()
				{
					InheritFrom = "code",
					FontColor = "#b8d7a3"
				},
				["code.structure"] = new()
				{
					InheritFrom = "code",
					FontColor = "#86c691"
				},
				["code.method"] = new()
				{
					InheritFrom = "code",
					FontColor = "#dcdcaa"
				},
				["code.parameter"] = new()
				{
					InheritFrom = "code",
					FontColor = "#9cdcfe"
				},
				["code.local"] = new()
				{
					InheritFrom = "code",
					FontColor = "#9cdcfe"
				},
				["code.json.propertyname"] = new()
				{
					InheritFrom = "code",
					FontColor = "#d7ba7d"
				}
			}
		};
	}
}
