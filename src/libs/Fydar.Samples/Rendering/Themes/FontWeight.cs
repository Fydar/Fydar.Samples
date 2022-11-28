namespace Fydar.Samples.Rendering.Themes;

public readonly struct FontWeight
{
	public static FontWeight Thin => new(100);

	public static FontWeight ExtraLight => new(200);

	public static FontWeight Light => new(200);

	public static FontWeight Normal => new(400);

	public static FontWeight Medium => new(500);

	public static FontWeight SemiBold => new(600);

	public static FontWeight Bold => new(700);

	public static FontWeight ExtraBold => new(800);

	public static FontWeight Black => new(900);

	private readonly int weight;

	public int Numeric
	{
		get
		{
			if (weight == 0)
			{
				return 400;
			}
			return weight;
		}
	}

	public FontWeight(int weight)
	{
		this.weight = weight;
	}

	public FontWeight Bolder()
	{
		if (this < Normal)
		{
			return Normal;
		}
		if (this < SemiBold)
		{
			return Bold;
		}
		return Black;
	}

	public FontWeight Lighter()
	{
		if (this < SemiBold)
		{
			return Thin;
		}
		if (this < ExtraBold)
		{
			return Normal;
		}
		return Bold;
	}

	public static bool operator <(FontWeight a, FontWeight b)
	{
		return a.Numeric < b.Numeric;
	}

	public static bool operator >(FontWeight a, FontWeight b)
	{
		return a.Numeric > b.Numeric;
	}

	public static bool operator <=(FontWeight a, FontWeight b)
	{
		return a.Numeric <= b.Numeric;
	}

	public static bool operator >=(FontWeight a, FontWeight b)
	{
		return a.Numeric > b.Numeric;
	}

	public static bool operator ==(FontWeight a, FontWeight b)
	{
		return a.Numeric == b.Numeric;
	}

	public static bool operator !=(FontWeight a, FontWeight b)
	{
		return a.Numeric != b.Numeric;
	}

	public static implicit operator FontWeight(int numeric)
	{
		return new FontWeight(numeric);
	}


	public static bool operator <(int a, FontWeight b)
	{
		return a < b.Numeric;
	}

	public static bool operator >(int a, FontWeight b)
	{
		return a > b.Numeric;
	}

	public static bool operator <=(int a, FontWeight b)
	{
		return a <= b.Numeric;
	}

	public static bool operator >=(int a, FontWeight b)
	{
		return a > b.Numeric;
	}

	public static bool operator ==(int a, FontWeight b)
	{
		return a == b.Numeric;
	}

	public static bool operator !=(int a, FontWeight b)
	{
		return a != b.Numeric;
	}


	public static bool operator <(FontWeight a, int b)
	{
		return a.Numeric < b;
	}

	public static bool operator >(FontWeight a, int b)
	{
		return a.Numeric > b;
	}

	public static bool operator <=(FontWeight a, int b)
	{
		return a.Numeric <= b;
	}

	public static bool operator >=(FontWeight a, int b)
	{
		return a.Numeric > b;
	}

	public static bool operator ==(FontWeight a, int b)
	{
		return a.Numeric == b;
	}

	public static bool operator !=(FontWeight a, int b)
	{
		return a.Numeric != b;
	}
}
