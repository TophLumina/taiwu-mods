using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

/// <summary>
/// 经营建筑的收获数据
/// </summary>
/// TODO: 该数据需要迁移, 禁止使用ModificationState做特殊处理
public class BuildingEarningsData : ISerializableGameData
{
	/// <summary>
	/// 采集建筑收获的物品列表 (当铺生成的物品超过一定时间没领取会消失,使用ModificationState记录存在时间)；和售卖道具的区别是售卖道具是定长的，没有道具的地方是空
	/// </summary>
	[SerializableGameDataField]
	public List<ItemKey> CollectionItemList;

	/// <summary>
	/// 采集建筑获得的银钱威望列表，first代表银钱或者威望类型，second代表数量
	/// </summary>
	[SerializableGameDataField]
	public List<IntPair> CollectionResourceList;

	/// <summary>
	/// 放在商店售卖的物品;(ItemKey:道具id) ShopSoldItemList长度等于建筑规模，长度只有建筑扩建时改变;和ShopSoldItemEarnList按索引对应使用
	/// 第一次创建的时候是定长,等于slotCount，没有道具的地方是ItemKey.Invalid
	/// </summary>
	[SerializableGameDataField]
	public List<ItemKey> ShopSoldItemList;

	/// <summary>
	/// 放在商店售卖物品获得的银钱或威望(和ShopSoldItemList按索引对应，同一个位置的索引都为空时代表这个位置没有道具，也没有卖出道具收到的资源)
	/// first代表银钱或者威望类型，second代表数量
	/// </summary>
	[SerializableGameDataField]
	public List<IntPair> ShopSoldItemEarnList;

	/// <summary>
	/// //招募的人才等级列表 first是等级，second是存在时间，超过三个月会消失
	/// </summary>
	[SerializableGameDataField]
	public List<IntPair> RecruitLevelList;

	/// <summary>
	/// 藏书阁修补的书籍
	/// </summary>
	[SerializableGameDataField]
	public List<ItemKey> FixBookInfoList;

	/// <summary>
	/// 构造方法，初始化所有集合.
	/// </summary>
	public BuildingEarningsData()
	{
		CollectionItemList = new List<ItemKey>();
		CollectionResourceList = new List<IntPair>();
		ShopSoldItemList = new List<ItemKey>();
		ShopSoldItemEarnList = new List<IntPair>();
		RecruitLevelList = new List<IntPair>();
		FixBookInfoList = new List<ItemKey>();
	}

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((CollectionItemList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * CollectionItemList.Count)));
		totalSize = ((CollectionResourceList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * CollectionResourceList.Count)));
		totalSize = ((ShopSoldItemList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * ShopSoldItemList.Count)));
		totalSize = ((ShopSoldItemEarnList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * ShopSoldItemEarnList.Count)));
		totalSize = ((RecruitLevelList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * RecruitLevelList.Count)));
		totalSize = ((FixBookInfoList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * FixBookInfoList.Count)));
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
		if (CollectionItemList != null)
		{
			int elementsCount = CollectionItemList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += CollectionItemList[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CollectionResourceList != null)
		{
			int elementsCount2 = CollectionResourceList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += CollectionResourceList[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ShopSoldItemList != null)
		{
			int elementsCount3 = ShopSoldItemList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData += ShopSoldItemList[k].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ShopSoldItemEarnList != null)
		{
			int elementsCount4 = ShopSoldItemEarnList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData += ShopSoldItemEarnList[l].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RecruitLevelList != null)
		{
			int elementsCount5 = RecruitLevelList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				pCurrData += RecruitLevelList[m].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FixBookInfoList != null)
		{
			int elementsCount6 = FixBookInfoList.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				pCurrData += FixBookInfoList[n].Serialize(pCurrData);
			}
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

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CollectionItemList == null)
			{
				CollectionItemList = new List<ItemKey>(elementsCount);
			}
			else
			{
				CollectionItemList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ItemKey element = default(ItemKey);
				pCurrData += element.Deserialize(pCurrData);
				CollectionItemList.Add(element);
			}
		}
		else
		{
			CollectionItemList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CollectionResourceList == null)
			{
				CollectionResourceList = new List<IntPair>(elementsCount2);
			}
			else
			{
				CollectionResourceList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				IntPair element2 = default(IntPair);
				pCurrData += element2.Deserialize(pCurrData);
				CollectionResourceList.Add(element2);
			}
		}
		else
		{
			CollectionResourceList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (ShopSoldItemList == null)
			{
				ShopSoldItemList = new List<ItemKey>(elementsCount3);
			}
			else
			{
				ShopSoldItemList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ItemKey element3 = default(ItemKey);
				pCurrData += element3.Deserialize(pCurrData);
				ShopSoldItemList.Add(element3);
			}
		}
		else
		{
			ShopSoldItemList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (ShopSoldItemEarnList == null)
			{
				ShopSoldItemEarnList = new List<IntPair>(elementsCount4);
			}
			else
			{
				ShopSoldItemEarnList.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				IntPair element4 = default(IntPair);
				pCurrData += element4.Deserialize(pCurrData);
				ShopSoldItemEarnList.Add(element4);
			}
		}
		else
		{
			ShopSoldItemEarnList?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (RecruitLevelList == null)
			{
				RecruitLevelList = new List<IntPair>(elementsCount5);
			}
			else
			{
				RecruitLevelList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				IntPair element5 = default(IntPair);
				pCurrData += element5.Deserialize(pCurrData);
				RecruitLevelList.Add(element5);
			}
		}
		else
		{
			RecruitLevelList?.Clear();
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (FixBookInfoList == null)
			{
				FixBookInfoList = new List<ItemKey>(elementsCount6);
			}
			else
			{
				FixBookInfoList.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				ItemKey element6 = default(ItemKey);
				pCurrData += element6.Deserialize(pCurrData);
				FixBookInfoList.Add(element6);
			}
		}
		else
		{
			FixBookInfoList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
