using Fydar.Samples.Rendering.Themes;
using System;

namespace Fydar.Samples.BuiltIn.Themes.VisualStudio2022Dark;

public static class ThemeBuilderExtensions
{
	public static ThemeBuilder UseVisualStudio2022Dark(this ThemeBuilder theme)
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
		theme.Configure<ThemeRichFont>("type", style =>
		{
			style.FontColor = "#d7ba7d";
		});
		theme.Configure<ThemeRichFont>("csharp-type-interface", style =>
		{
			style.FontColor = "#b8d7a3";
		});
		theme.Configure<ThemeRichFont>("csharp-type-enum", style =>
		{
			style.FontColor = "#b8d7a3";
		});
		theme.Configure<ThemeRichFont>("csharp-type-struct", style =>
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


		theme.Configure<ThemeConsoleFont>(style =>
		{
			style.ForegroundColor = ConsoleColor.Gray;
		});
		theme.Configure<ThemeConsoleFont>("linenumber", style =>
		{
			style.ForegroundColor = ConsoleColor.DarkGray;
		});
		theme.Configure<ThemeConsoleFont>("whitespace", style =>
		{
			style.ForegroundColor = ConsoleColor.DarkGray;
		});
		theme.Configure<ThemeConsoleFont>("keyword", style =>
		{
			style.ForegroundColor = ConsoleColor.Magenta;
		});
		theme.Configure<ThemeConsoleFont>("keyword-control", style =>
		{
			style.ForegroundColor = ConsoleColor.DarkMagenta;
		});
		theme.Configure<ThemeConsoleFont>("number", style =>
		{
			style.ForegroundColor = ConsoleColor.Yellow;
		});
		theme.Configure<ThemeConsoleFont>("string", style =>
		{
			style.ForegroundColor = ConsoleColor.Blue;
		});
		theme.Configure<ThemeConsoleFont>("string-escaped", style =>
		{
			style.ForegroundColor = ConsoleColor.DarkBlue;
		});
		theme.Configure<ThemeConsoleFont>("propertyname", style =>
		{
			style.ForegroundColor = ConsoleColor.Cyan;
		});
		theme.Configure<ThemeConsoleFont>("comment", style =>
		{
			style.ForegroundColor = ConsoleColor.Green;
		});
		theme.Configure<ThemeConsoleFont>("comment-docs", style =>
		{
			style.ForegroundColor = ConsoleColor.DarkGreen;
		});
		theme.Configure<ThemeConsoleFont>("class", style =>
		{
			style.ForegroundColor = ConsoleColor.Cyan;
		});
		theme.Configure<ThemeConsoleFont>("interface", style =>
		{
			style.ForegroundColor = ConsoleColor.Cyan;
		});
		theme.Configure<ThemeConsoleFont>("enum", style =>
		{
			style.ForegroundColor = ConsoleColor.Cyan;
		});
		theme.Configure<ThemeConsoleFont>("structure", style =>
		{
			style.ForegroundColor = ConsoleColor.DarkGray;
		});
		theme.Configure<ThemeConsoleFont>("method", style =>
		{
			style.ForegroundColor = ConsoleColor.Yellow;
		});
		theme.Configure<ThemeConsoleFont>("parameter", style =>
		{
			style.ForegroundColor = ConsoleColor.Gray;
		});
		theme.Configure<ThemeConsoleFont>("local", style =>
		{
			style.ForegroundColor = ConsoleColor.Gray;
		});

		return theme;
	}
}
