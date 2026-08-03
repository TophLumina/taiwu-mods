using System;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 用于存储一本书中每一页使用的研读策略
/// </summary>
public struct ReadingBookStrategies : ISerializableGameData
{
	/// <summary>
	/// 一页最多多少个研读策略
	/// </summary>
	public const int StrategiesPerPage = 3;

	/// <summary>
	/// 最多总共有多少个研读策略
	/// </summary>
	private const int MaxTotalStrategyCount = 18;

	/// <summary>
	/// 一本书最多6页，每页三个研读策略，默认值为 -1
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// </summary>
	/// <remarks>
	/// 最大长度为 <see cref="F:GameData.Domains.Item.CombatSkillBookPage.Count" /> * <see cref="F:GameData.Domains.Taiwu.ReadingBookStrategies.StrategiesPerPage" />
	/// </remarks>
	public unsafe fixed sbyte StrategyIds[18];

	/// <summary>
	/// 每一个研读策略提供的研读效率，由于是范围内的随机值因此需要保存，默认值为 0
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// </summary>
	/// <remarks>
	/// 最大长度为 <see cref="F:GameData.Domains.Item.CombatSkillBookPage.Count" /> * <see cref="F:GameData.Domains.Taiwu.ReadingBookStrategies.StrategiesPerPage" />
	/// </remarks>
	public unsafe fixed sbyte Bonus[18];

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值 -1
	/// 其实现依赖 每本书最多6页 * 每页3个策略 == 18.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 获取指定书页位置的研读策略
	/// </summary>
	/// <param name="pageIndex">本书的书页Id（注意不是功法内部书页索引）</param>
	/// <param name="strategyIndex"></param>
	/// <returns></returns>
	public unsafe sbyte GetPageStrategy(byte pageIndex, int strategyIndex)
	{
		return StrategyIds[pageIndex * 3 + strategyIndex];
	}

	/// <summary>
	/// 设置指定书页位置的研读策略
	/// </summary>
	/// <param name="pageIndex">本书的书页Id（注意不是功法内部书页索引）</param>
	/// <param name="strategyIndex"></param>
	/// <param name="strategyId"></param>
	/// <param name="efficiencyBonus"></param>
	public unsafe void SetPageStrategy(byte pageIndex, int strategyIndex, sbyte strategyId, sbyte efficiencyBonus = 0)
	{
		int index = pageIndex * 3 + strategyIndex;
		StrategyIds[index] = strategyId;
		Bonus[index] = efficiencyBonus;
	}

	/// <summary>
	/// 清空指定书页的策略
	/// </summary>
	/// <param name="pageIndex">本书的书页Id（注意不是功法内部书页索引）</param>
	public unsafe void ClearPageStrategies(byte pageIndex)
	{
		for (int i = 0; i < 3; i++)
		{
			int index = pageIndex * 3 + i;
			StrategyIds[index] = -1;
			Bonus[index] = 0;
		}
	}

	/// <summary>
	/// 检查指定书页的三个策略栏位是否全都有策略
	/// </summary>
	/// <param name="pageIndex">本书的书页Id（注意不是功法内部书页索引）</param>
	/// <returns></returns>
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

	/// <summary>
	/// 检查所有书页的策略栏位是否全部占满
	/// </summary>
	/// <param name="pageCount">本书的总页数</param>
	/// <returns></returns>
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

	/// <summary>
	/// 获得指定书页的研读策略是否会导致跳过书页
	/// </summary>
	/// <param name="pageIndex">本书的书页Id（注意不是功法内部书页索引）</param>
	/// <returns>是否跳过指定书页</returns>
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

	/// <summary>
	/// 获得指定书页的研读效率加成。
	/// </summary>
	/// <param name="pageIndex">本书的书页Id（注意不是功法内部书页索引）</param>
	/// <returns>研读策略带来的效率总加成</returns>
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
					if (strategyId >= ReadingStrategy.Instance.Count)
					{
						throw new Exception($"strategy id {strategyId} at index {p * 3 + i} out of range: [0, {ReadingStrategy.Instance.Count}).");
					}
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
			sbyte strategyId2 = StrategyIds[k];
			if (strategyId2 >= ReadingStrategy.Instance.Count)
			{
				throw new Exception($"strategy id {strategyId2} at index {k} out of range: [0, {ReadingStrategy.Instance.Count}).");
			}
			if (strategyId2 >= 0)
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
