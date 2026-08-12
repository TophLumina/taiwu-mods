using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC.FiveLoong;

/// <summary>
/// 地图上神龙的信息
/// </summary>
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

	/// <summary>
	/// 神龙地形范围：距离中心位置
	/// </summary>
	public const short LoongTerrainRange = 3;

	/// <summary>
	/// 神龙消失再次出现的时间间隔
	/// 108=9年*12
	/// </summary>
	public const short LoongDisappearTime = 108;

	/// <summary>
	/// 角色模板id
	/// </summary>
	[SerializableGameDataField]
	public short CharacterTemplateId;

	/// <summary>
	/// 是否处于被降服的状态
	/// </summary>
	[SerializableGameDataField]
	public bool IsDisappear;

	/// <summary>
	/// 被降服的时间
	/// </summary>
	[SerializableGameDataField]
	public int DisappearDate;

	/// <summary>
	/// 太吾的标记数量
	/// </summary>
	[Obsolete]
	[SerializableGameDataField]
	public ushort TaiwuDebuffCount;

	/// <summary>
	/// 神龙地形的中心位置
	/// </summary>
	[SerializableGameDataField]
	public Location LoongTerrainCenterLocation;

	/// <summary>
	/// 神龙当前的位置（移动用）
	/// </summary>
	[SerializableGameDataField]
	public Location LoongCurrentLocation;

	/// <summary>
	/// 地格被覆盖前的类型
	/// key: blockId  value:TemplateId
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, short> CoveredMapBlockTemplateId;

	/// <summary>
	/// 地格额外物品数据表
	/// key: blockId value:额外物品数据集合
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<Location, Inventory> MapBlockExtraItems = new Dictionary<Location, Inventory>();

	/// <summary>
	/// 神龙被击败后小龙逃窜的地格；神龙再次出现前要移除他们
	/// </summary>
	[Obsolete]
	[SerializableGameDataField]
	public List<short> MinionLoongBlockList;

	/// <summary>
	/// npc的标记数量
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, ushort> CharacterDebuffCounts;

	/// <summary>
	/// 龙的 ID
	/// </summary>
	public short LoongTemplateId => (short)(CharacterTemplateId - 246);

	/// <summary>
	/// 模板数据
	/// </summary>
	public LoongItem ConfigData => Loong.Instance[LoongTemplateId];

	/// <summary>
	/// 修改角色的 Debuff 数量
	/// </summary>
	/// <param name="charId"></param>
	/// <param name="delta"></param>
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

	/// <summary>
	/// 获取角色的 Debuff 数量
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 角色模板ID 转为 龙的模板ID
	/// </summary>
	/// <param name="charTemplateId"><see cref="T:Config.Character" /></param>
	/// <returns><see cref="T:Config.Loong" /></returns>
	public static short CharacterTemplateIdToLoongTemplateId(short charTemplateId)
	{
		return (short)(charTemplateId - 246);
	}

	/// <summary>
	/// 构造方法
	/// </summary>
	/// <param name="charTemplateId"></param>
	/// <param name="initialLocation"></param>
	/// <param name="coveredMapBlockTemplateId"></param>
	public LoongInfo(short charTemplateId, Location initialLocation, Dictionary<short, short> coveredMapBlockTemplateId)
	{
		CharacterTemplateId = charTemplateId;
		LoongCurrentLocation = initialLocation;
		LoongTerrainCenterLocation = initialLocation;
		CoveredMapBlockTemplateId = coveredMapBlockTemplateId;
	}

	/// <summary>
	/// 反序列化器所必须
	/// </summary>
	public LoongInfo()
	{
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
