using Fydar.Samples.Grammars;
using Fydar.Samples.Rendering.Themes;

namespace Fydar.Samples.Themes.VisualStudio2022Dark;

public static class ThemeBuilderExtensions
{
	public static ThemeBuilder UseVisualStudio2022Dark(this ThemeBuilder themeBuilder)
	{
		themeBuilder.ConfigureTextStyles(textStyles =>
		{
			textStyles.StyleDefault(style =>
			{
				style.Color = "#dcdcdc";
			});

			textStyles.StyleClass(StandardToken.LineNumber, style =>
			{
				style.Color = "#2b91af";
			});
			textStyles.StyleClass(StandardToken.Whitespace, style =>
			{
				style.Color = "#144852";
			});
			textStyles.StyleClass(StandardToken.Number, style =>
			{
				style.Color = "#b5cfa8";
			});
			textStyles.StyleClass(StandardToken.Keyword, style =>
			{
				style.Color = "#569cd6";
			});
			textStyles.StyleClass(StandardToken.KeywordControl, style =>
			{
				style.Color = "#d8a0df";
			});
			textStyles.StyleClass(StandardToken.String, style =>
			{
				style.Color = "#d69d85";
			});
			textStyles.StyleClass(StandardToken.StringEscaped, style =>
			{
				style.Color = "#ffd68f";
			});
			textStyles.StyleClass(StandardToken.Comment, style =>
			{
				style.Color = "#57a64a";
			});
			textStyles.StyleClass(StandardToken.PropertyName, style =>
			{
				style.Color = "#d7ba7d";
			});
		});

		return themeBuilder;

		//  ["default"] = new()
		//  {
		//  	FontColor = "#dcdcdc",
		//  	FontWeight = "normal"
		//  },
		//  ["col.ln.number"] = new()
		//  {
		//  	InheritFrom = "default",
		//  	FontColor = "#b90af"
		//  },
		//  ["code"] = new()
		//  {
		//  	InheritFrom = "default"
		//  },
		//  ["code.keyword"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#569cd6"
		//  },
		//  ["code.control"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#d8a0df"
		//  },
		//  ["code.string"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#d69d85"
		//  },
		//  ["code.string.escape"] = new()
		//  {
		//  	InheritFrom = "code.string",
		//  	FontColor = "#ffd68f"
		//  },
		//  ["code.numeric"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#b5cfa8"
		//  },
		//  ["code.comment"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#57a64a"
		//  },
		//  ["code.class"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#4ec9b0"
		//  },
		//  ["code.interface"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#b8d7a3"
		//  },
		//  ["code.enum"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#b8d7a3"
		//  },
		//  ["code.structure"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#86c691"
		//  },
		//  ["code.method"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#dcdcaa"
		//  },
		//  ["code.parameter"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#9cdcfe"
		//  },
		//  ["code.local"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#9cdcfe"
		//  },
		//  ["code.json.propertyname"] = new()
		//  {
		//  	InheritFrom = "code",
		//  	FontColor = "#d7ba7d"
		//  }
	}
}
