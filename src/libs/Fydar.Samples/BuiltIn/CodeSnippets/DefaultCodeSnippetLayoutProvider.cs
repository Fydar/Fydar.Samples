using Fydar.Samples.Rendering;
using Fydar.Samples.Rendering.Layouts;
using Fydar.Samples.Rendering.Themes;

namespace Fydar.Samples.BuiltIn.CodeSnippets;

public class DefaultCodeSnippetLayoutProvider : ISampleLayoutProvider
{
	public string Name => "default";

	public Layout CreateLayout(Sample sample, Theme theme)
	{
		var codeSnippetFeature = sample.Features.GetFeature<CodeSnippetFeature>();
		if (codeSnippetFeature != null)
		{
			return false;
		}

		var layout = new Layout();
		layout.RootElement = LayoutVerticalStack.New(
			background =>
			{
				background.Styles.Add("background");

				background.Elements.Add(LayoutVerticalStack.New(panel =>
				{
					panel.Styles.Add("panel");

					panel.Elements.Add(LayoutHorizontalStack.New(panelTitle =>
					{
						panel.Styles.Add("panel-title");

						panelTitle.Elements.Add(LayoutBox.New(panelTitleBoxA =>
						{
							panelTitleBoxA.Styles.Add("panel-title-button");
							panelTitleBoxA.Styles.Add("panel-title-button-a");
						}));
						panelTitle.Elements.Add(LayoutBox.New(panelTitleBoxB =>
						{
							panelTitleBoxB.Styles.Add("panel-title-button");
							panelTitleBoxB.Styles.Add("panel-title-button-b");
						}));
						panelTitle.Elements.Add(LayoutBox.New(panelTitleBoxC =>
						{
							panelTitleBoxC.Styles.Add("panel-title-button");
							panelTitleBoxC.Styles.Add("panel-title-button-c");
						}));
					}));

					panel.Elements.Add(LayoutText.New(panelTitleText =>
					{
						panelTitleText.Styles.Add("panel-title-text");

						panelTitleText.Text = sample.PathToFile;
					}));
				}));

				background.Elements.Add(LayoutCodeBlock.New(panelCodeBlock =>
				{
					panelCodeBlock.Styles.Add("panel-code");

					// panelCodeBlock.Tokens = sample.Tokens;
				}));
			});

		return true;
	}
}
