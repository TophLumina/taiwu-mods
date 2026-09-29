using GameData.Serializer;

namespace GameData.Utilities;

[SerializeFrom(typeof(int?))]
public struct NullableIntDto : ISerializableGameData
{
	[SerializableGameDataField]
	public bool HasValue;

	[SerializableGameDataField]
	public int Value;

	public static implicit operator NullableIntDto(int? value)
	{
		return new NullableIntDto
		{
			HasValue = value.HasValue,
			Value = value.GetValueOrDefault()
		};
	}

	public static implicit operator int?(NullableIntDto dto)
	{
		if (!dto.HasValue)
		{
			return null;
		}
		return dto.Value;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (HasValue ? ((byte)1) : ((byte)0));
		byte* num = pData + 1;
		*(int*)num = Value;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		HasValue = *pCurrData != 0;
		pCurrData++;
		Value = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
