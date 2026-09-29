using GameData.Serializer;

namespace GameData.Domains.Building.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class ChickenPluckFeatherDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int FeatherValue;

	[SerializableGameDataField]
	public int ChickenCount;

	[SerializableGameDataField]
	public int CanPluckCount;

	[SerializableGameDataField]
	public int MonthlyIncrease;

	[SerializableGameDataField]
	public int RemainingDays;

	public ChickenPluckFeatherDisplayData()
	{
	}

	public ChickenPluckFeatherDisplayData(ChickenPluckFeatherDisplayData other)
	{
		FeatherValue = other.FeatherValue;
		ChickenCount = other.ChickenCount;
		CanPluckCount = other.CanPluckCount;
		MonthlyIncrease = other.MonthlyIncrease;
		RemainingDays = other.RemainingDays;
	}

	public void Assign(ChickenPluckFeatherDisplayData other)
	{
		FeatherValue = other.FeatherValue;
		ChickenCount = other.ChickenCount;
		CanPluckCount = other.CanPluckCount;
		MonthlyIncrease = other.MonthlyIncrease;
		RemainingDays = other.RemainingDays;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 20;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = FeatherValue;
		byte* num = pData + 4;
		*(int*)num = ChickenCount;
		byte* num2 = num + 4;
		*(int*)num2 = CanPluckCount;
		byte* num3 = num2 + 4;
		*(int*)num3 = MonthlyIncrease;
		byte* num4 = num3 + 4;
		*(int*)num4 = RemainingDays;
		int totalSize = (int)(num4 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		FeatherValue = *(int*)pCurrData;
		pCurrData += 4;
		ChickenCount = *(int*)pCurrData;
		pCurrData += 4;
		CanPluckCount = *(int*)pCurrData;
		pCurrData += 4;
		MonthlyIncrease = *(int*)pCurrData;
		pCurrData += 4;
		RemainingDays = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
