namespace Fydar.Samples.Grammars.Json;

public static class IGrammarLibraryBuilderExtensions
{
	public static IGrammarLibraryBuilder AddJson(this IGrammarLibraryBuilder builder)
	{
		builder.AddGrammar(language =>
		{
			language.DisplayName = "Json";
			language.Aliases =
			[
				"json",
				"jsonc"
			];
			language.Extensions =
			[
				".json"
			];
		});
		return builder;
	}
}
