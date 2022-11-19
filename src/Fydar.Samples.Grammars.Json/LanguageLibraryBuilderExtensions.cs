namespace Fydar.Samples.Grammars.Json;

public static class LanguageLibraryBuilderExtensions
{
	public static LanguageLibraryBuilder AddJson(this LanguageLibraryBuilder builder)
	{
		builder.AddLanguage(language =>
		{
			language.DisplayName = "Json";
			language.Aliases = new[]
			{
				"json",
				"jsonc"
			};
			language.Extensions = new[]
			{
				".json"
			};
		});
		return builder;
	}
}
