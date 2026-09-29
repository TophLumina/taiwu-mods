using GameData.Serializer;

namespace GameData.Domains.LegendaryBook;

[SerializableGameData(NoCopyConstructors = true)]
public class LegendaryBookPresetDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int MaxPresetAmount;

	[SerializableGameDataField]
	public int CurrentUnlockedAmount;

	[SerializableGameDataField]
	public int CurrentUsingPresetIndex;

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
		*(int*)pData = MaxPresetAmount;
		byte* num = pData + 4;
		*(int*)num = CurrentUnlockedAmount;
		byte* num2 = num + 4;
		*(int*)num2 = CurrentUsingPresetIndex;
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
		MaxPresetAmount = *(int*)pCurrData;
		pCurrData += 4;
		CurrentUnlockedAmount = *(int*)pCurrData;
		pCurrData += 4;
		CurrentUsingPresetIndex = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
