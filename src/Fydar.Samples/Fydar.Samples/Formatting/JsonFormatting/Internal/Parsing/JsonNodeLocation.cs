namespace Fydar.Samples.Formatting.JsonFormatting.Internal.Parsing
{
	public readonly struct JsonNodeLocation
	{
		public enum LocationType
		{
			Array,
			Object,
			Value
		}

		public LocationType Type { get; }

		public JsonNodeLocation(LocationType type)
		{
			Type = type;
		}
	}
}
