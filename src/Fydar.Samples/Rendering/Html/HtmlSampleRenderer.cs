using System.IO;
using System.Xml;

namespace Fydar.Samples.Rendering.Html
{
	public class HtmlSampleRenderer : ISampleRenderer
	{
		public string Extension => ".html";

		public void Render(Sample sample, Stream output)
		{
			using var streamWriter = new StreamWriter(output);

			double verticalPadding = 10.0;
			double lineHeight = 21.0;

			double totalHeight = (sample.Lines.Length * lineHeight) + (verticalPadding * 1.5);

			streamWriter.Write($@"<!DOCTYPE html>
<html lang=""en"">
<head>
	<meta charset=""UTF-8"">
	<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
	<title>{sample.Identifier}</title>
	<link rel=""stylesheet"" asp-append-version=""true"" href=""../patio.min.css"" />
</head>
<body>
	<div class=""container"">");

			HtmlSampleTableRenderer(streamWriter, sample);

			streamWriter.Write(@"</div></body></html>");
		}

		private static void HtmlSampleTableRenderer(StreamWriter output, Sample region)
		{
			output.WriteLine("<table class=\"code-table\">");

			for (int i = 0; i < region.Lines.Length; i++)
			{
				var line = region.Lines[i];
				output.Write("\t<tr>\n\t\t<th>");
				output.Write(i + 1);
				output.Write("</th>\n\t\t<td>");

				foreach (var span in line.Spans)
				{
					if (span.Style == null)
					{
						output.Write(XmlEscape(span.Content));
					}
					else
					{
						output.Write("<span class=\"");
						output.Write(span.Style);
						output.Write("\">");
						output.Write(XmlEscape(span.Content));
						output.Write("</span>");
					}
				}
				output.Write("</td>\n\t</tr>\n");
			}
			output.WriteLine("</table>");
		}

		private static string XmlEscape(string unescaped)
		{
			var doc = new XmlDocument();
			var node = doc.CreateElement("root");
			node.InnerText = unescaped;
			return node.InnerXml;
		}
	}
}
