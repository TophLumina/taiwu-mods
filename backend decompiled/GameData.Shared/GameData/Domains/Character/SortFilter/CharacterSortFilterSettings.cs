using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Character.SortFilter;

/// <summary>
/// 角色筛选排序设置
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class CharacterSortFilterSettings : ISerializableGameData
{
	/// <summary>
	/// 筛选主条件类型, 即所有被包含的角色需要满足的条件 <see cref="T:GameData.Domains.Character.SortFilter.CharacterFilterType" />
	/// </summary>
	public sbyte FilterType;

	/// <summary>
	/// 筛选子条件类型, 即分页方式 <see cref="T:GameData.Domains.Character.SortFilter.CharacterFilterSubType" />
	/// </summary>
	public sbyte FilterSubType;

	/// <summary>
	/// 筛选子条件 ID, 用于切换分页 范围为 [0, <see cref="F:GameData.Domains.Character.SortFilter.CharacterFilterSubType.SubTypeToFilterCount" />)
	/// </summary>
	public int FilterSubId;

	/// <summary>
	/// 目标角色 - 当筛选条件与指定角色关联时使用, 否则为 -1
	/// </summary>
	public int TargetCharId;

	/// <summary>
	/// 目标位置 - 当筛选条件与指定位置关联时使用, 否则为 <see cref="F:GameData.Domains.Map.Location.Invalid" />
	/// </summary>
	public Location TargetLocation;

	/// <summary>
	/// 村民需求的公库物品，注意是无效的模板
	/// </summary>
	public ItemKey VillagerNeededItem;

	public readonly List<(int type, bool isDescending)> SortOrder;

	/// <summary>
	/// 构造可用初始数据
	/// </summary>
	public CharacterSortFilterSettings()
	{
		FilterType = -1;
		FilterSubType = -1;
		TargetCharId = -1;
		TargetLocation = Location.Invalid;
		FilterSubId = -1;
		SortOrder = new List<(int, bool)>();
	}

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 12 + TargetLocation.GetSerializedSize() + SortOrder.Count * 5 + VillagerNeededItem.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)FilterType;
		pCurrData++;
		*pCurrData = (byte)FilterSubType;
		pCurrData++;
		*(int*)pCurrData = FilterSubId;
		pCurrData += 4;
		*(int*)pCurrData = TargetCharId;
		pCurrData += 4;
		pCurrData += TargetLocation.Serialize(pCurrData);
		pCurrData += VillagerNeededItem.Serialize(pCurrData);
		*(ushort*)pCurrData = (ushort)SortOrder.Count;
		pCurrData += 2;
		foreach (var pair in SortOrder)
		{
			*(int*)pCurrData = pair.type;
			pCurrData += 4;
			*pCurrData = (pair.isDescending ? ((byte)1) : ((byte)0));
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		FilterType = (sbyte)(*pCurrData);
		pCurrData++;
		FilterSubType = (sbyte)(*pCurrData);
		pCurrData++;
		FilterSubId = *(int*)pCurrData;
		pCurrData += 4;
		TargetCharId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += TargetLocation.Deserialize(pCurrData);
		pCurrData += VillagerNeededItem.Deserialize(pCurrData);
		ushort count = *(ushort*)pCurrData;
		pCurrData += 2;
		SortOrder.Clear();
		for (int i = 0; i < count; i++)
		{
			int sortType = *(int*)pCurrData;
			pCurrData += 4;
			bool isDescending = *pCurrData != 0;
			pCurrData++;
			SortOrder.Add((sortType, isDescending));
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
