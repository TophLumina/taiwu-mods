using GameData.Serializer;

namespace GameData.Utilities;

[SerializableGameData(NotForDisplayModule = true)]
public class SerializableGameDataVariant<T> : Variant<T> where T : ISerializableGameData, new()
{
	public SerializableGameDataVariant(T value)
		: base(value)
	{
	}

	public override IVariant Duplicate()
	{
		return new SerializableGameDataVariant<T>(Value);
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		return 4 + (Value?.GetSerializedSize() ?? 0);
	}

	public unsafe override int Serialize(byte* pData)
	{
		if (Value != null)
		{
			return 4 + (*(int*)pData = Value.Serialize(pData + 4));
		}
		*(int*)pData = 0;
		return 4;
	}

	public unsafe override int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int num = *(int*)pCurrData;
		pCurrData += 4;
		if (num != 0)
		{
			T value = Value;
			if (value == null)
			{
				Value = new T();
			}
			pCurrData += Value.Deserialize(pCurrData);
		}
		else
		{
			Value = default(T);
		}
		return (int)(pCurrData - pData);
	}
}
