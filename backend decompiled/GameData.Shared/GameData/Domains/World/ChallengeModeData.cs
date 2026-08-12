using System;
using System.Collections.Generic;
using Config;
using Config.ConfigCells;
using Config.ConfigCells.Character;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.World;

/// <summary>
/// 玄狱模式数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class ChallengeModeData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort ChallengeModeIds = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "ChallengeModeIds" };
	}

	/// <summary>
	/// 已激活的玄狱词条
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	private List<int> _challengeModeIds;

	/// <summary>
	/// 已启用的玄狱词条数量
	/// </summary>
	public int EnabledChallengeModeCount => _challengeModeIds?.Count ?? 0;

	/// <summary>
	/// 基于指定词条构造
	/// </summary>
	public ChallengeModeData(IEnumerable<int> challengeModeIds)
	{
		_challengeModeIds = new List<int>(challengeModeIds);
	}

	/// <summary>
	/// 追加启用的玄狱词条
	/// </summary>
	public void AppendEnabledChallengeMode(int modeId)
	{
		if (_challengeModeIds == null)
		{
			_challengeModeIds = new List<int>();
		}
		_challengeModeIds.AddUnique(modeId);
	}

	/// <summary>
	/// 是否开启
	/// </summary>
	/// <returns></returns>
	public bool IsEnabled()
	{
		List<int> challengeModeIds = _challengeModeIds;
		if (challengeModeIds != null)
		{
			return challengeModeIds.Count > 0;
		}
		return false;
	}

	/// <summary>
	/// 指定词条是否已激活
	/// </summary>
	public bool IsEnabled(EChallengeModeImplement implement)
	{
		List<int> challengeModeIds = _challengeModeIds;
		if (challengeModeIds == null || challengeModeIds.Count <= 0)
		{
			return false;
		}
		foreach (int modeId in _challengeModeIds)
		{
			if (ChallengeMode.Instance[modeId].Implement == implement)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 百废难兴
	/// 太吾村完成采集、经营、招募、代制等收获所需的工作进度提高200%
	/// </summary>
	public void ApplyChallengeModeBuildingWorkHard(ref int needProgress)
	{
		if (IsEnabled(EChallengeModeImplement.BuildingWorkHard))
		{
			needProgress *= 3;
		}
	}

	/// <summary>
	/// 真元难聚
	/// </summary>
	public void ApplyChallengeModeLimitedNeiliAllocation(ref sbyte consummateLevel)
	{
		if (IsEnabled(EChallengeModeImplement.LimitedNeiliAllocation))
		{
			consummateLevel = Math.Min(consummateLevel, 8);
		}
	}

	/// <summary>
	/// 物以稀贵
	/// 调整人物创建时的资源比例
	/// </summary>
	public int GetCharacterResourcesCreateRate()
	{
		if (!IsEnabled(EChallengeModeImplement.ItemAndResourceAmountLess))
		{
			return 100;
		}
		return GlobalConfig.Instance.ChallengeCharacterWealthCreateRate;
	}

	/// <summary>
	/// 物以稀贵
	/// 调整人物创建时的物品概率
	/// </summary>
	/// <returns></returns>
	public void ApplyCharacterItemsCreateRate(List<PresetInventoryItem> inventory, IRandomSource randomSource)
	{
		if (IsEnabled(EChallengeModeImplement.ItemAndResourceAmountLess))
		{
			int count = ((inventory.Count <= 1) ? inventory.Count : (inventory.Count * GlobalConfig.Instance.ChallengeCharacterWealthCreateRate / 100));
			int removeCount = inventory.Count - count;
			while (removeCount > 0)
			{
				removeCount--;
				int index = randomSource.Next(inventory.Count);
				inventory.RemoveAt(index);
			}
		}
	}

	/// <summary>
	/// 物以稀贵
	/// 调整库房补充资源的比例
	/// </summary>
	public int GetTreasurySupplyRate()
	{
		if (!IsEnabled(EChallengeModeImplement.ItemAndResourceAmountLess))
		{
			return 100;
		}
		return GlobalConfig.Instance.ChallengeTreasurySupplyRate;
	}

	/// <summary>
	/// 物以稀贵
	/// 调整商店创建时的物品项数
	/// </summary>
	/// <returns></returns>
	public void ApplyMerchantItemsCreateRate(List<PresetItemTemplateIdGroup> pool, IRandomSource randomSource)
	{
		if (IsEnabled(EChallengeModeImplement.ItemAndResourceAmountLess))
		{
			int count = ((pool.Count <= 1) ? pool.Count : (pool.Count * GlobalConfig.Instance.ChallengeCharacterWealthCreateRate / 100));
			int removeCount = pool.Count - count;
			while (removeCount > 0)
			{
				removeCount--;
				int index = randomSource.Next(pool.Count);
				pool.RemoveAt(index);
			}
		}
	}

	/// <summary>
	/// 物以稀贵
	/// 获取商店物价的加成
	/// </summary>
	/// <param name="pageIndex">商品所在级别</param>
	/// <returns></returns>
	public int GetMerchantItemPriceBonus(int pageIndex)
	{
		if (!IsEnabled(EChallengeModeImplement.ItemAndResourceAmountLess))
		{
			return 0;
		}
		return GlobalConfig.Instance.ChallengeShopItemPriceBonus[pageIndex];
	}

	/// <summary>
	/// 物以稀贵
	/// 获取交换系统对方的优势加成
	/// </summary>
	/// <returns></returns>
	public int ApplyExchangeTargetAdvantageBonus(int advantage)
	{
		if (!IsEnabled(EChallengeModeImplement.ItemAndResourceAmountLess))
		{
			return advantage;
		}
		return advantage * (100 + GlobalConfig.Instance.ChallengeExchangeAdvantageBonus) / 100;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public ChallengeModeData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public ChallengeModeData(ChallengeModeData other)
	{
		_challengeModeIds = ((other._challengeModeIds == null) ? null : new List<int>(other._challengeModeIds));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(ChallengeModeData other)
	{
		_challengeModeIds = ((other._challengeModeIds == null) ? null : new List<int>(other._challengeModeIds));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((_challengeModeIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _challengeModeIds.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 1;
		pCurrData += 2;
		if (_challengeModeIds != null)
		{
			int elementsCount = _challengeModeIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _challengeModeIds[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_challengeModeIds == null)
				{
					_challengeModeIds = new List<int>(elementsCount);
				}
				else
				{
					_challengeModeIds.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					_challengeModeIds.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				_challengeModeIds?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
