using Fydar.Samples.Rendering.Themes;

namespace Fydar.Samples.BuiltIn.Themes.GitHubCodeSnippets;

public static class ThemeBuilderExtensions
{
	public static ThemeBuilder UseGitHubCodeSnippetBoxDark(this ThemeBuilder theme)
	{
		theme.Configure<ThemeRichFont>(style =>
		{
			style.FontColor = "#dcdcdc";
		});
		theme.Configure<ThemeRichFont>("linenumber", style =>
		{
			style.FontColor = "#2b91af";
		});
		theme.Configure<ThemeRichFont>("whitespace", style =>
		{
			style.FontColor = "#144852";
		});
		theme.Configure<ThemeRichFont>("keyword", style =>
		{
			style.FontColor = "#569cd6";
		});
		theme.Configure<ThemeRichFont>("keyword-control", style =>
		{
			style.FontColor = "#b5cfa8";
		});
		theme.Configure<ThemeRichFont>("number", style =>
		{
			style.FontColor = "#b5cfa8";
		});
		theme.Configure<ThemeRichFont>("string", style =>
		{
			style.FontColor = "#d69d85";
		});
		theme.Configure<ThemeRichFont>("string-escaped", style =>
		{
			style.FontColor = "#ffd68f";
		});
		theme.Configure<ThemeRichFont>("propertyname", style =>
		{
			style.FontColor = "#d7ba7d";
		});
		theme.Configure<ThemeRichFont>("comment", style =>
		{
			style.FontColor = "#57a64a";
		});
		theme.Configure<ThemeRichFont>("comment-docs", style =>
		{
			style.FontColor = "#608b4e";
		});


		theme.Configure<ThemeRichFont>("class", style =>
		{
			style.FontColor = "#d7ba7d";
		});
		theme.Configure<ThemeRichFont>("interface", style =>
		{
			style.FontColor = "#b8d7a3";
		});
		theme.Configure<ThemeRichFont>("enum", style =>
		{
			style.FontColor = "#b8d7a3";
		});
		theme.Configure<ThemeRichFont>("structure", style =>
		{
			style.FontColor = "#86c691";
		});
		theme.Configure<ThemeRichFont>("method", style =>
		{
			style.FontColor = "#dcdcaa";
		});
		theme.Configure<ThemeRichFont>("parameter", style =>
		{
			style.FontColor = "#9cdcfe";
		});
		theme.Configure<ThemeRichFont>("local", style =>
		{
			style.FontColor = "#9cdcfe";
		});

		return theme;
	}
}
