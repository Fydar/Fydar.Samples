namespace Fydar.Samples.Grammars.Json;

public static class IGrammarLibraryBuilderExtensions
{
	public static IGrammarLibraryBuilder AddJson(this IGrammarLibraryBuilder builder)
	{
		builder.AddGrammar(language =>
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
