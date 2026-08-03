using GameData.Serializer;

namespace GameData.Utilities;

[SerializableGameData(NotForDisplayModule = true)]
public class BoolValue : UnmanagedVariant<bool>
{
	public BoolValue()
	{
	}

	public BoolValue(bool value)
		: base(value)
	{
	}
}
