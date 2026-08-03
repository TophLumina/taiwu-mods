using GameData.Serializer;

namespace GameData.Utilities;

[SerializableGameData(NotForDisplayModule = true)]
public class FloatValue : UnmanagedVariant<float>
{
	public FloatValue()
	{
	}

	public FloatValue(float value)
		: base(value)
	{
	}
}
