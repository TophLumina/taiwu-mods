using GameData.Serializer;

namespace GameData.Domains.Item.Display;

[SerializableGameData(NotForArchive = true)]
public struct ItemPowerInfo : ISerializableGameData
{
	[SerializableGameDataField]
	public short Power;

	[SerializableGameDataField]
	public short MaxPower;

	[SerializableGameDataField]
	public short RequirementsPower;

	public static ItemPowerInfo Default => new ItemPowerInfo
	{
		Power = 100,
		MaxPower = 100,
		RequirementsPower = 100
	};

	public bool AnyValue
	{
		get
		{
			if (Power <= 0 && MaxPower <= 0)
			{
				return RequirementsPower > 0;
			}
			return true;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = Power;
		byte* num = pData + 2;
		*(short*)num = MaxPower;
		byte* num2 = num + 2;
		*(short*)num2 = RequirementsPower;
		int totalSize = (int)(num2 + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		Power = *(short*)pCurrData;
		pCurrData += 2;
		MaxPower = *(short*)pCurrData;
		pCurrData += 2;
		RequirementsPower = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
