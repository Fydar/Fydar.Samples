using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Fydar.Samples.Rendering.ToSvg;

public class SvgSampleRenderer : ISampleRenderer
{
	public string Extension => ".svg";

	public async Task RenderAsync(
		Sample sample,
		Stream output,
		CancellationToken cancellationToken = default)
	{
		using var streamWriter = new StreamWriter(output);

		double verticalPadding = 10.0;
		double lineHeight = 21.0;

		double totalHeight = (sample.Tokens.Length * lineHeight) + (verticalPadding * 1.5);

		await streamWriter.WriteAsync(@"<svg viewBox=""0 0 1200 ");
		streamWriter.Write(totalHeight);
		await streamWriter.WriteAsync(@""" width=""1200"" height=""");
		streamWriter.Write(totalHeight);
		await streamWriter.WriteAsync(@""" xmlns =""http://www.w3.org/2000/svg"">

	<defs>
		<clipPath id=""round-left-corners"">
			<rect x=""0"" y=""0"" width=""100"" height=""100%"" rx=""8"" ry=""8""/>
		</clipPath>
	</defs>
	<style>
		.code { font-size: 17px; font-family: Consolas, ui-monospace,SFMono-Regular,SF Mono,Menlo,Liberation Mono,monospace; fill: rgba(220, 220, 220, 255); dominant-baseline: hanging; }
		.code-background { fill: #161b22; }
		.code-background-linenumber { fill: #111418; }
		.c-ln { font-size: 17px; font-family: Consolas, ui-monospace,SFMono-Regular,SF Mono,Menlo,Liberation Mono,monospace; fill: #2b90af; text-anchor: end; pointer-events: none; user-select: none; dominant-baseline: hanging; }
		.c-keyword { fill: rgba(86, 156, 214, 255); }
		.c-control { fill: rgba(216, 160, 223, 255); }
		.c-string { fill: rgba(214, 157, 133, 255); }
		.c-numeric { fill: rgba(181, 207, 168, 255); }
		.c-comment { fill: rgba(87, 166, 74, 255); }
		.c-class { fill: rgba(78, 201, 176, 255); }
		.c-interface { fill: rgba(184, 215, 163, 255); }
		.c-enum { fill: rgba(184, 215, 163, 255); }
		.c-structure { fill: rgba(134, 198, 145, 255); }
		.c-method { fill: rgba(220, 220, 170, 255); }
		.c-parameter { fill: rgba(156, 220, 254, 255); }
		.c-local { fill: rgba(156, 220, 254, 255); }
		.c-pn { fill: rgba(215, 186, 125, 255); }
		.c-kw { fill: rgba(86, 156, 214, 255); }
		.c-s { fill: rgba(214, 157, 133, 255); }
		.c-es { fill: rgba(255, 214, 143, 255); }
		.c-n { fill: rgba(181, 206, 168, 255); }
		.c-c { fill: rgba(87, 166, 74, 255); }
	</style>
	<rect x=""0"" y=""0"" width=""100%"" height=""100%"" rx=""8"" ry=""8"" class=""code-background"" />
	<rect x=""0"" y=""0"" width=""46"" height=""100%"" class=""code-background-linenumber"" clip-path=""url(#round-left-corners)"" />");

		for (int i = 0; i < sample.Tokens.Length; i++)
		{
			double yOffset = (i * lineHeight) + verticalPadding;
			streamWriter.Write($"\t<text x=\"38\" y=\"{yOffset}\" class=\"c-ln\">{i + 1}</text>\n");
		}

		for (int i = 0; i < sample.Tokens.Length; i++)
		{
			var line = sample.Tokens[i];

			double yOffset = (i * lineHeight) + verticalPadding;
			bool wroteStart = false;
			for (int y = 0; y < line.Spans.Length; y++)
			{
				var span = line.Spans[y];

				string spanContent = span.Content;
				spanContent = spanContent.Replace(' ', '\u00A0');

				if (!wroteStart)
				{
					streamWriter.Write($"\t<text x=\"64\" y=\"{yOffset}\" class=\"code\">");
					wroteStart = true;
				}

				if (span.Style == null)
				{
					streamWriter.Write(XmlEscape(spanContent));
				}
				else
				{
					streamWriter.Write("<tspan class=\"");
					streamWriter.Write(span.Style);
					streamWriter.Write("\">");
					streamWriter.Write(XmlEscape(spanContent));
					streamWriter.Write("</tspan>");
				}
			}
			if (wroteStart)
			{
				streamWriter.Write("</text>\n");
			}
		}
		streamWriter.WriteLine("</svg>");
	}

	private static string XmlEscape(string unescaped)
	{
		var xmlDocument = new XmlDocument();
		var node = xmlDocument.CreateElement("root");
		node.InnerText = unescaped;
		return node.InnerXml;
	}
}
