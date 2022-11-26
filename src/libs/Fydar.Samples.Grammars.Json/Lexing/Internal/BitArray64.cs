namespace Fydar.Samples.Grammars.Json.Lexing.Internal;

internal struct BitArray64
{
	private ulong data;

	public bool this[int index]
	{
		get
		{
			ulong mask = 1ul << index;
			return (data & mask) == mask;
		}
		set
		{
			ulong mask = 1ul << index;
			if (value)
			{
				data |= mask;
			}
			else
			{
				data &= ~mask;
			}
		}
	}

	public void SetTrue(int index)
	{
		ulong mask = 1ul << index;
		data |= mask;
	}

	public void SetFalse(int index)
	{
		ulong mask = 1ul << index;
		data &= ~mask;
	}

	public void Clear()
	{
		data = 0;
	}
}
