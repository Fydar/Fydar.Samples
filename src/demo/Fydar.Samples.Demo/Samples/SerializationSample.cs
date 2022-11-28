using Fydar.Samples.BuiltIn.CodeSnippets;
using System;
using System.Text.Json;

namespace Fydar.Samples.Demo.Samples;

public class SerializationSample
{
	#region serialization_model
	public class WeatherForecast
	{
		public DateTimeOffset Date { get; set; }
		public int TemperatureCelsius { get; set; }
		public string? Summary { get; set; }
	}
	#endregion serialization_model

	#region serialization_demo
	[return: SampleCodeSnippet(format: "json")]
	public static string Run()
	{
		var weatherForecast = new WeatherForecast
		{
			Date = DateTime.Parse("2019-08-01"),
			TemperatureCelsius = 25,
			Summary = "Hot"
		};

		var options = new JsonSerializerOptions()
		{
			WriteIndented = true
		};

		return JsonSerializer.Serialize(weatherForecast, options);
	}
	#endregion serialization_demo
}
