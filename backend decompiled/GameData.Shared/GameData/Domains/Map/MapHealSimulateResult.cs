using GameData.Domains.Character;
using GameData.Serializer;

namespace GameData.Domains.Map;

[SerializableGameData(NotForArchive = true)]
public struct MapHealSimulateResult : ISerializableGameData
{
	[SerializableGameDataField]
	private int _serializeType;

	[SerializableGameDataField]
	public int CostHerb;

	[SerializableGameDataField]
	public int CostMoney;

	[SerializableGameDataField]
	public int CostSpiritualDebt;

	[SerializableGameDataField]
	public int HealEffect;

	[SerializableGameDataField]
	public int MaxRequireAttainment;

	public EHealActionType Type => (EHealActionType)_serializeType;

	public MapHealSimulateResult(EHealActionType type, int costHerb, int costMoney, int healEffect, int costSpiritualDebt, int maxRequireAttainment)
	{
		_serializeType = (int)type;
		CostHerb = costHerb;
		CostMoney = costMoney;
		HealEffect = healEffect;
		CostSpiritualDebt = costSpiritualDebt;
		MaxRequireAttainment = maxRequireAttainment;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 24;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = _serializeType;
		byte* num = pData + 4;
		*(int*)num = CostHerb;
		byte* num2 = num + 4;
		*(int*)num2 = CostMoney;
		byte* num3 = num2 + 4;
		*(int*)num3 = CostSpiritualDebt;
		byte* num4 = num3 + 4;
		*(int*)num4 = HealEffect;
		byte* num5 = num4 + 4;
		*(int*)num5 = MaxRequireAttainment;
		int totalSize = (int)(num5 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		_serializeType = *(int*)pCurrData;
		pCurrData += 4;
		CostHerb = *(int*)pCurrData;
		pCurrData += 4;
		CostMoney = *(int*)pCurrData;
		pCurrData += 4;
		CostSpiritualDebt = *(int*)pCurrData;
		pCurrData += 4;
		HealEffect = *(int*)pCurrData;
		pCurrData += 4;
		MaxRequireAttainment = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
