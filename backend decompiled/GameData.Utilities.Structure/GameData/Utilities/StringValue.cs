using GameData.Serializer;

namespace GameData.Utilities;

[SerializableGameData(NotForDisplayModule = true)]
public class StringValue : Variant<string>
{
	public StringValue()
	{
	}

	public StringValue(string value)
		: base(value)
	{
	}

	public override IVariant Duplicate()
	{
		return new StringValue(Value);
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		return SerializationHelper.GetSerializedSize(Value);
	}

	public unsafe override int Serialize(byte* pData)
	{
		return SerializationHelper.Serialize(pData, Value);
	}

	public unsafe override int Deserialize(byte* pData)
	{
		return SerializationHelper.Deserialize(pData, out Value);
	}
}
