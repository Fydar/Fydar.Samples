namespace Fydar.Samples.Grammars.CSharp;

public static class IGrammarLibraryBuilderExtensions
{
	public static IGrammarLibraryBuilder AddCSharp(this IGrammarLibraryBuilder builder)
	{
		_ = builder.AddGrammar(language =>
		{
			language.DisplayName = "C#";
			language.Aliases = new[]
			{
				"csharp"
			};
			language.Extensions = new[]
			{
				".cs"
			};
		});
		return builder;
	}
}
