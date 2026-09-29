using Config;
using GameData.Serializer;

namespace GameData.Domains.Taiwu;

public struct ReadingBookStrategies : ISerializableGameData
{
	public const int StrategiesPerPage = 3;

	private const int MaxTotalStrategyCount = 18;

	public unsafe fixed sbyte StrategyIds[18];

	public unsafe fixed sbyte Bonus[18];

	public unsafe void Initialize()
	{
		fixed (sbyte* strategyIds = StrategyIds)
		{
			sbyte* num = strategyIds;
			*(long*)num = -1L;
			((long*)num)[1] = -1L;
			((short*)num)[8] = -1;
		}
		fixed (sbyte* strategyIds = Bonus)
		{
			sbyte* num2 = strategyIds;
			*(long*)num2 = 0L;
			((long*)num2)[1] = 0L;
			((short*)num2)[8] = 0;
		}
	}

	public unsafe sbyte GetPageStrategy(byte pageIndex, int strategyIndex)
	{
		return StrategyIds[pageIndex * 3 + strategyIndex];
	}

	public unsafe void SetPageStrategy(byte pageIndex, int strategyIndex, sbyte strategyId, sbyte efficiencyBonus = 0)
	{
		int index = pageIndex * 3 + strategyIndex;
		StrategyIds[index] = strategyId;
		Bonus[index] = efficiencyBonus;
	}

	public unsafe void ClearPageStrategies(byte pageIndex)
	{
		for (int i = 0; i < 3; i++)
		{
			int index = pageIndex * 3 + i;
			StrategyIds[index] = -1;
			Bonus[index] = 0;
		}
	}

	public unsafe bool IsStrategySlotsFullAtPage(byte pageIndex)
	{
		for (int i = 0; i < 3; i++)
		{
			if (StrategyIds[pageIndex * 3 + i] == -1)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsAllSlotsFull(byte pageCount)
	{
		for (byte page = 0; page < pageCount; page++)
		{
			if (!IsStrategySlotsFullAtPage(page))
			{
				return false;
			}
		}
		return true;
	}

	public unsafe short GetPageIntCostChange(byte pageIndex)
	{
		short intCostReduction = 0;
		for (int i = 0; i < 3; i++)
		{
			sbyte strategyId = StrategyIds[pageIndex * 3 + i];
			if (strategyId >= 0)
			{
				intCostReduction += ReadingStrategy.Instance[strategyId].CurrPageIntCostChange;
			}
		}
		return intCostReduction;
	}

	public unsafe bool PageContainsStrategy(byte pageIndex, sbyte strategyId)
	{
		for (int i = 0; i < 3; i++)
		{
			sbyte currStrategyId = StrategyIds[pageIndex * 3 + i];
			if (strategyId == currStrategyId)
			{
				return true;
			}
		}
		return false;
	}

	public unsafe bool GetSkipPage(byte pageIndex)
	{
		for (int i = 0; i < 3; i++)
		{
			sbyte strategyId = StrategyIds[pageIndex * 3 + i];
			if (strategyId >= 0 && ReadingStrategy.Instance[strategyId].SkipPage)
			{
				return true;
			}
		}
		return false;
	}

	public unsafe int GetPageReadingEfficiencyBonus(byte pageIndex)
	{
		int efficiencyBonus = 0;
		int curPageStartIndex = pageIndex * 3;
		for (int p = 0; p < pageIndex; p++)
		{
			int pageEfficiencyBonus = 0;
			int doubleStratecyCount = 0;
			for (int i = 0; i < 3; i++)
			{
				sbyte strategyId = StrategyIds[p * 3 + i];
				if (strategyId >= 0)
				{
					pageEfficiencyBonus += ReadingStrategy.Instance[strategyId].FollowingPagesEfficiencyChange;
					if (strategyId == 5)
					{
						doubleStratecyCount++;
					}
				}
			}
			for (int j = 0; j < doubleStratecyCount; j++)
			{
				pageEfficiencyBonus *= 2;
			}
			efficiencyBonus += pageEfficiencyBonus;
		}
		for (int k = curPageStartIndex; k < curPageStartIndex + 3; k++)
		{
			if (StrategyIds[k] >= 0)
			{
				efficiencyBonus += Bonus[k];
			}
		}
		return efficiencyBonus;
	}

	public unsafe override string ToString()
	{
		string str = "";
		for (byte pageIndex = 0; pageIndex < 6; pageIndex++)
		{
			for (int strategyIndex = 0; strategyIndex < 3; strategyIndex++)
			{
				sbyte templateId = StrategyIds[pageIndex * 3 + strategyIndex];
				str = str + ReadingStrategy.Instance[templateId].Name + " ";
			}
			str += "\n";
		}
		return str;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 36;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (sbyte* pItems = StrategyIds)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
			((short*)pData)[8] = ((short*)pItems)[8];
		}
		fixed (sbyte* pItems2 = Bonus)
		{
			*(long*)(pData + 18) = *(long*)pItems2;
			*(long*)(pData + 26) = ((long*)pItems2)[1];
			((short*)pData)[17] = ((short*)pItems2)[8];
		}
		int totalSize = 36;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* strategyIds = StrategyIds)
		{
			sbyte* num = strategyIds;
			*(long*)num = *(long*)pData;
			((long*)num)[1] = ((long*)pData)[1];
			((short*)num)[8] = ((short*)pData)[8];
		}
		fixed (sbyte* strategyIds = Bonus)
		{
			sbyte* num2 = strategyIds;
			*(long*)num2 = *(long*)(pData + 18);
			((long*)num2)[1] = *(long*)(pData + 26);
			((short*)num2)[8] = ((short*)pData)[17];
		}
		int totalSize = 36;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
