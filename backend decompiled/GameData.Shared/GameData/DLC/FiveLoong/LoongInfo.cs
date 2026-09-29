using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC.FiveLoong;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class LoongInfo : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CharacterTemplateId = 0;

		public const ushort IsDisappear = 1;

		public const ushort TaiwuDebuffCount = 2;

		public const ushort LoongTerrainCenterLocation = 3;

		public const ushort LoongCurrentLocation = 4;

		public const ushort CoveredMapBlockTemplateId = 5;

		public const ushort DisappearDate = 6;

		public const ushort MinionLoongBlockList = 7;

		public const ushort CharacterDebuffCounts = 8;

		public const ushort MapBlockExtraItems = 9;

		public const ushort Count = 10;

		public static readonly string[] FieldId2FieldName = new string[10] { "CharacterTemplateId", "IsDisappear", "TaiwuDebuffCount", "LoongTerrainCenterLocation", "LoongCurrentLocation", "CoveredMapBlockTemplateId", "DisappearDate", "MinionLoongBlockList", "CharacterDebuffCounts", "MapBlockExtraItems" };
	}

	public const short LoongTerrainRange = 3;

	public const short LoongDisappearTime = 108;

	[SerializableGameDataField]
	public short CharacterTemplateId;

	[SerializableGameDataField]
	public bool IsDisappear;

	[SerializableGameDataField]
	public int DisappearDate;

	[Obsolete]
	[SerializableGameDataField]
	public ushort TaiwuDebuffCount;

	[SerializableGameDataField]
	public Location LoongTerrainCenterLocation;

	[SerializableGameDataField]
	public Location LoongCurrentLocation;

	[SerializableGameDataField]
	public Dictionary<short, short> CoveredMapBlockTemplateId;

	[SerializableGameDataField]
	public Dictionary<Location, Inventory> MapBlockExtraItems = new Dictionary<Location, Inventory>();

	[Obsolete]
	[SerializableGameDataField]
	public List<short> MinionLoongBlockList;

	[SerializableGameDataField]
	public Dictionary<int, ushort> CharacterDebuffCounts;

	public short LoongTemplateId => (short)(CharacterTemplateId - 246);

	public LoongItem ConfigData => Loong.Instance[LoongTemplateId];

	public void ChangeCharacterDebuffCount(int charId, int delta)
	{
		if (CharacterDebuffCounts == null)
		{
			CharacterDebuffCounts = new Dictionary<int, ushort>();
		}
		if (CharacterDebuffCounts.TryGetValue(charId, out var value))
		{
			value = (ushort)MathUtils.Clamp(value + delta, 0, GlobalConfig.Instance.FiveLoongDlcMaxDebuffCount);
			if (value == 0)
			{
				CharacterDebuffCounts.Remove(charId);
			}
			else
			{
				CharacterDebuffCounts[charId] = value;
			}
		}
		else if (delta > 0)
		{
			CharacterDebuffCounts.Add(charId, (ushort)delta);
		}
	}

	public ushort GetCharacterDebuffCount(int charId)
	{
		if (CharacterDebuffCounts == null)
		{
			return 0;
		}
		if (!CharacterDebuffCounts.TryGetValue(charId, out var value))
		{
			return 0;
		}
		return value;
	}

	public static short CharacterTemplateIdToLoongTemplateId(short charTemplateId)
	{
		return (short)(charTemplateId - 246);
	}

	public LoongInfo(short charTemplateId, Location initialLocation, Dictionary<short, short> coveredMapBlockTemplateId)
	{
		CharacterTemplateId = charTemplateId;
		LoongCurrentLocation = initialLocation;
		LoongTerrainCenterLocation = initialLocation;
		CoveredMapBlockTemplateId = coveredMapBlockTemplateId;
	}

	public LoongInfo()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 19;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CoveredMapBlockTemplateId);
		totalSize = ((MinionLoongBlockList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * MinionLoongBlockList.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CharacterDebuffCounts);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(MapBlockExtraItems);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 10;
		pCurrData += 2;
		*(short*)pCurrData = CharacterTemplateId;
		pCurrData += 2;
		*pCurrData = (IsDisappear ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(ushort*)pCurrData = TaiwuDebuffCount;
		pCurrData += 2;
		pCurrData += LoongTerrainCenterLocation.Serialize(pCurrData);
		pCurrData += LoongCurrentLocation.Serialize(pCurrData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref CoveredMapBlockTemplateId);
		*(int*)pCurrData = DisappearDate;
		pCurrData += 4;
		if (MinionLoongBlockList != null)
		{
			int elementsCount = MinionLoongBlockList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = MinionLoongBlockList[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref CharacterDebuffCounts);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref MapBlockExtraItems);
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			CharacterTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 1)
		{
			IsDisappear = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			TaiwuDebuffCount = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 3)
		{
			pCurrData += LoongTerrainCenterLocation.Deserialize(pCurrData);
		}
		if (fieldCount > 4)
		{
			pCurrData += LoongCurrentLocation.Deserialize(pCurrData);
		}
		if (fieldCount > 5)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref CoveredMapBlockTemplateId);
		}
		if (fieldCount > 6)
		{
			DisappearDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 7)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (MinionLoongBlockList == null)
				{
					MinionLoongBlockList = new List<short>(elementsCount);
				}
				else
				{
					MinionLoongBlockList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					MinionLoongBlockList.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				MinionLoongBlockList?.Clear();
			}
		}
		if (fieldCount > 8)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref CharacterDebuffCounts);
		}
		if (fieldCount > 9)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref MapBlockExtraItems);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
