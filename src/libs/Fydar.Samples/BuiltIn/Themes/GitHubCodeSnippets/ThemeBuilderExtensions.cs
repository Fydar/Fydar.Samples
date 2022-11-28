using Fydar.Samples.Rendering.Themes;

namespace Fydar.Samples.BuiltIn.Themes.GitHubCodeSnippets;

public static class ThemeBuilderExtensions
{
	public static ThemeBuilder UseGitHubCodeSnippetBoxDark(this ThemeBuilder theme)
	{
		theme.Configure<ThemeSpanFont>(style =>
		{
			style.FontColor = "#dcdcdc";
		});
		theme.Configure<ThemeSpanFont>("linenumber", style =>
		{
			style.FontColor = "#2b91af";
		});
		theme.Configure<ThemeSpanFont>("whitespace", style =>
		{
			style.FontColor = "#144852";
		});
		theme.Configure<ThemeSpanFont>("keyword", style =>
		{
			style.FontColor = "#569cd6";
		});
		theme.Configure<ThemeSpanFont>("keyword-control", style =>
		{
			style.FontColor = "#b5cfa8";
		});
		theme.Configure<ThemeSpanFont>("number", style =>
		{
			style.FontColor = "#b5cfa8";
		});
		theme.Configure<ThemeSpanFont>("string", style =>
		{
			style.FontColor = "#d69d85";
		});
		theme.Configure<ThemeSpanFont>("string-escaped", style =>
		{
			style.FontColor = "#ffd68f";
		});
		theme.Configure<ThemeSpanFont>("propertyname", style =>
		{
			style.FontColor = "#d7ba7d";
		});
		theme.Configure<ThemeSpanFont>("comment", style =>
		{
			style.FontColor = "#57a64a";
		});
		theme.Configure<ThemeSpanFont>("comment-docs", style =>
		{
			style.FontColor = "#608b4e";
		});


		theme.Configure<ThemeSpanFont>("class", style =>
		{
			style.FontColor = "#d7ba7d";
		});
		theme.Configure<ThemeSpanFont>("interface", style =>
		{
			style.FontColor = "#b8d7a3";
		});
		theme.Configure<ThemeSpanFont>("enum", style =>
		{
			style.FontColor = "#b8d7a3";
		});
		theme.Configure<ThemeSpanFont>("structure", style =>
		{
			style.FontColor = "#86c691";
		});
		theme.Configure<ThemeSpanFont>("method", style =>
		{
			style.FontColor = "#dcdcaa";
		});
		theme.Configure<ThemeSpanFont>("parameter", style =>
		{
			style.FontColor = "#9cdcfe";
		});
		theme.Configure<ThemeSpanFont>("local", style =>
		{
			style.FontColor = "#9cdcfe";
		});

		return theme;
	}
}
