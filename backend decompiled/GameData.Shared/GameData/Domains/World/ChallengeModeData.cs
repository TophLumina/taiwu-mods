using System;
using System.Collections.Generic;
using Config;
using Config.ConfigCells;
using Config.ConfigCells.Character;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.World;

[SerializableGameData(IsExtensible = true)]
public class ChallengeModeData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort ChallengeModeIds = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "ChallengeModeIds" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	private List<int> _challengeModeIds;

	public int EnabledChallengeModeCount => _challengeModeIds?.Count ?? 0;

	public ChallengeModeData(IEnumerable<int> challengeModeIds)
	{
		_challengeModeIds = new List<int>(challengeModeIds);
	}

	public void AppendEnabledChallengeMode(int modeId)
	{
		if (_challengeModeIds == null)
		{
			_challengeModeIds = new List<int>();
		}
		_challengeModeIds.AddUnique(modeId);
	}

	public bool IsEnabled()
	{
		List<int> challengeModeIds = _challengeModeIds;
		if (challengeModeIds != null)
		{
			return challengeModeIds.Count > 0;
		}
		return false;
	}

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

	public void ApplyChallengeModeBuildingWorkHard(ref int needProgress)
	{
		if (IsEnabled(EChallengeModeImplement.BuildingWorkHard))
		{
			needProgress *= 3;
		}
	}

	public void ApplyChallengeModeLimitedNeiliAllocation(ref sbyte consummateLevel)
	{
		if (IsEnabled(EChallengeModeImplement.LimitedNeiliAllocation))
		{
			consummateLevel = Math.Min(consummateLevel, 8);
		}
	}

	public int GetCharacterResourcesCreateRate()
	{
		if (!IsEnabled(EChallengeModeImplement.ItemAndResourceAmountLess))
		{
			return 100;
		}
		return GlobalConfig.Instance.ChallengeCharacterWealthCreateRate;
	}

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

	public int GetTreasurySupplyRate()
	{
		if (!IsEnabled(EChallengeModeImplement.ItemAndResourceAmountLess))
		{
			return 100;
		}
		return GlobalConfig.Instance.ChallengeTreasurySupplyRate;
	}

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

	public int GetMerchantItemPriceBonus(int pageIndex)
	{
		if (!IsEnabled(EChallengeModeImplement.ItemAndResourceAmountLess))
		{
			return 0;
		}
		return GlobalConfig.Instance.ChallengeShopItemPriceBonus[pageIndex];
	}

	public int ApplyExchangeTargetAdvantageBonus(int advantage)
	{
		if (!IsEnabled(EChallengeModeImplement.ItemAndResourceAmountLess))
		{
			return advantage;
		}
		return advantage * (100 + GlobalConfig.Instance.ChallengeExchangeAdvantageBonus) / 100;
	}

	public ChallengeModeData()
	{
	}

	public ChallengeModeData(ChallengeModeData other)
	{
		_challengeModeIds = ((other._challengeModeIds == null) ? null : new List<int>(other._challengeModeIds));
	}

	public void Assign(ChallengeModeData other)
	{
		_challengeModeIds = ((other._challengeModeIds == null) ? null : new List<int>(other._challengeModeIds));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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
