using GameData.Serializer;

namespace GameData.Domains.Building;

[SerializableGameData(NotForArchive = true)]
public struct BuildingProduceDependencyData : ISerializableGameData
{
	public static readonly BuildingProduceDependencyData Invalid = new BuildingProduceDependencyData(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public sbyte Level;

	[SerializableGameDataField]
	public int ResourceYieldLevelFactor;

	[SerializableGameDataField]
	public int BlockBaseYieldFactor;

	[SerializableGameDataField]
	public int ProductivityFactor;

	[SerializableGameDataField]
	public int TotalAttainmentFactor;

	[SerializableGameDataField]
	public int GainResourcePercentFactor;

	[SerializableGameDataField]
	public int SafetyCultureFactor;

	[SerializableGameDataField]
	public int ResourceSingleOutputValuation;

	[SerializableGameDataField]
	public float RandomFactorUpperLimit;

	[SerializableGameDataField]
	public float RandomFactorLowerLimit;

	public int ResourceBuildingOutput => ResourceYieldLevelFactor * ProductivityFactor / 100 * BlockBaseYieldFactor / 100 * TotalAttainmentFactor / 100 * GainResourcePercentFactor / 100;

	public int MoneyBuildingOutput => 300 * ProductivityFactor / 100 * SafetyCultureFactor / 100 * TotalAttainmentFactor / 100 * GainResourcePercentFactor / 100;

	public int AuthorityBuildingOutput => MoneyBuildingOutput / 10;

	public int GamblingHouseOutput => MoneyBuildingOutput;

	public int BrothelOutput => MoneyBuildingOutput;

	private BuildingProduceDependencyData(short templateId, sbyte level, int resourceYieldLevelFactor, int blockBaseYieldFactor, int productivityFactor, int totalAttainmentFactor, int gainResourcePercentFactor, int safetyCultureFactor, int randomFactorUpperLimit, int randomFactorLowerLimit, int collectDamping, int resourceSingleOutputValuation)
	{
		TemplateId = templateId;
		Level = level;
		ResourceYieldLevelFactor = resourceYieldLevelFactor;
		BlockBaseYieldFactor = blockBaseYieldFactor;
		ProductivityFactor = productivityFactor;
		TotalAttainmentFactor = totalAttainmentFactor;
		GainResourcePercentFactor = gainResourcePercentFactor;
		SafetyCultureFactor = safetyCultureFactor;
		RandomFactorUpperLimit = randomFactorUpperLimit;
		RandomFactorLowerLimit = randomFactorLowerLimit;
		ResourceSingleOutputValuation = resourceSingleOutputValuation;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 39;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = TemplateId;
		byte* num = pData + 2;
		*num = (byte)Level;
		byte* num2 = num + 1;
		*(int*)num2 = ResourceYieldLevelFactor;
		byte* num3 = num2 + 4;
		*(int*)num3 = BlockBaseYieldFactor;
		byte* num4 = num3 + 4;
		*(int*)num4 = ProductivityFactor;
		byte* num5 = num4 + 4;
		*(int*)num5 = TotalAttainmentFactor;
		byte* num6 = num5 + 4;
		*(int*)num6 = GainResourcePercentFactor;
		byte* num7 = num6 + 4;
		*(int*)num7 = SafetyCultureFactor;
		byte* num8 = num7 + 4;
		*(int*)num8 = ResourceSingleOutputValuation;
		byte* num9 = num8 + 4;
		*(float*)num9 = RandomFactorUpperLimit;
		byte* num10 = num9 + 4;
		*(float*)num10 = RandomFactorLowerLimit;
		int totalSize = (int)(num10 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		Level = (sbyte)(*pCurrData);
		pCurrData++;
		ResourceYieldLevelFactor = *(int*)pCurrData;
		pCurrData += 4;
		BlockBaseYieldFactor = *(int*)pCurrData;
		pCurrData += 4;
		ProductivityFactor = *(int*)pCurrData;
		pCurrData += 4;
		TotalAttainmentFactor = *(int*)pCurrData;
		pCurrData += 4;
		GainResourcePercentFactor = *(int*)pCurrData;
		pCurrData += 4;
		SafetyCultureFactor = *(int*)pCurrData;
		pCurrData += 4;
		ResourceSingleOutputValuation = *(int*)pCurrData;
		pCurrData += 4;
		RandomFactorUpperLimit = *(float*)pCurrData;
		pCurrData += 4;
		RandomFactorLowerLimit = *(float*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public int CalcSaleItemPrice(int basePrice)
	{
		return basePrice * TotalAttainmentFactor / 100 * ProductivityFactor / 100 * SafetyCultureFactor / 100 * GainResourcePercentFactor / 100;
	}

	public int BuildSaleItemAttainmentFactor(int totalAttainment)
	{
		return 40 + totalAttainment / 50;
	}
}
