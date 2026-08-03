using GameData.Serializer;

namespace GameData.Utilities;

[SerializableGameData(NotForDisplayModule = true)]
public class IntValue : UnmanagedVariant<int>
{
	public IntValue()
	{
	}

	public IntValue(int value)
		: base(value)
	{
	}
}
