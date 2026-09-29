using GameData.Serializer;

namespace GameData.Domains.Character.Display;

public class CharacterInfoCountData : ISerializableGameData
{
	[SerializableGameDataField]
	public int HoldInfoCount;

	[SerializableGameDataField]
	public int HoldInfoTaiwuDontHoldCount;

	[SerializableGameDataField]
	public int HoldInfoTaiwuRelatedCount;

	public CharacterInfoCountData()
	{
	}

	public CharacterInfoCountData(CharacterInfoCountData other)
	{
		HoldInfoCount = other.HoldInfoCount;
		HoldInfoTaiwuDontHoldCount = other.HoldInfoTaiwuDontHoldCount;
		HoldInfoTaiwuRelatedCount = other.HoldInfoTaiwuRelatedCount;
	}

	public void Assign(CharacterInfoCountData other)
	{
		HoldInfoCount = other.HoldInfoCount;
		HoldInfoTaiwuDontHoldCount = other.HoldInfoTaiwuDontHoldCount;
		HoldInfoTaiwuRelatedCount = other.HoldInfoTaiwuRelatedCount;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = HoldInfoCount;
		byte* num = pData + 4;
		*(int*)num = HoldInfoTaiwuDontHoldCount;
		byte* num2 = num + 4;
		*(int*)num2 = HoldInfoTaiwuRelatedCount;
		int totalSize = (int)(num2 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		HoldInfoCount = *(int*)pCurrData;
		pCurrData += 4;
		HoldInfoTaiwuDontHoldCount = *(int*)pCurrData;
		pCurrData += 4;
		HoldInfoTaiwuRelatedCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
