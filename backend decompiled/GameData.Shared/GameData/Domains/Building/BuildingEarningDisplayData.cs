using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class BuildingEarningDisplayData : ISerializableGameData
{
	/// <summary>
	/// 收获物品
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> CollectionItemDisplayList;

	/// <summary>
	/// 采集建筑获得的银钱威望列表，first代表银钱或者威望类型，second代表数量
	/// </summary>
	[SerializableGameDataField]
	public List<IntPair> CollectionResourceList;

	/// <summary>
	/// 放在商店售卖的物品;(ItemKey:道具id) ShopSoldItemList长度等于建筑规模，长度只有建筑扩建时改变;和ShopSoldItemEarnList按索引对应使用
	/// 定长，没有的地方用null占位
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> ShopSoldItemDisplayList;

	/// <summary>
	/// 放在商店售卖物品获得的银钱或威望(和ShopSoldItemDisplayList按索引对应，同一个位置的索引都为空时代表这个位置没有道具，也没有卖出道具收到的资源)
	/// first代表银钱或者威望类型，second代表数量
	/// </summary>
	[SerializableGameDataField]
	public List<IntPair> ShopSoldItemEarnList;

	/// <summary>
	/// 招募人才
	/// </summary>
	[SerializableGameDataField]
	public List<RecruitCharacterData> RecruitCharacterDataList;

	/// <summary>
	/// //招募的人才等级列表 first是等级，second是存在时间，超过三个月会消失
	/// </summary>
	[SerializableGameDataField]
	public List<IntPair> RecruitLevelList;

	/// <summary>
	/// 藏书阁修补的书籍
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> FixBookInfoDisplayList;

	/// <summary>
	/// 自动上货
	/// </summary>
	[SerializableGameDataField]
	public bool AutoSoldItem;

	/// <summary>
	/// 自动派遣
	/// </summary>
	[SerializableGameDataField]
	public bool AutoArrange;

	/// <summary>
	/// 自动入住
	/// </summary>
	[SerializableGameDataField]
	public bool AutoCheckIn;

	/// <summary>
	/// 经营人员信息
	/// </summary>
	[SerializableGameDataField]
	public List<BuildingManagerDisplayData> ManagerDisplayDataList;

	/// <summary>
	/// 居所
	/// </summary>
	[SerializableGameDataField]
	public List<CharacterDisplayData> Residences;

	/// <summary>
	/// 厢房
	/// </summary>
	[SerializableGameDataField]
	public List<CharacterDisplayData> ComfortableHouses;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (CollectionItemDisplayList != null)
		{
			totalSize += 2;
			for (int i = 0; i < CollectionItemDisplayList.Count; i++)
			{
				totalSize = ((CollectionItemDisplayList[i] == null) ? (totalSize + 2) : (totalSize + (2 + CollectionItemDisplayList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CollectionResourceList != null)
		{
			totalSize += 2;
			for (int j = 0; j < CollectionResourceList.Count; j++)
			{
				totalSize += CollectionResourceList[j].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (ShopSoldItemDisplayList != null)
		{
			totalSize += 2;
			for (int k = 0; k < ShopSoldItemDisplayList.Count; k++)
			{
				totalSize = ((ShopSoldItemDisplayList[k] == null) ? (totalSize + 2) : (totalSize + (2 + ShopSoldItemDisplayList[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (ShopSoldItemEarnList != null)
		{
			totalSize += 2;
			for (int l = 0; l < ShopSoldItemEarnList.Count; l++)
			{
				totalSize += ShopSoldItemEarnList[l].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (RecruitCharacterDataList != null)
		{
			totalSize += 2;
			for (int m = 0; m < RecruitCharacterDataList.Count; m++)
			{
				totalSize = ((RecruitCharacterDataList[m] == null) ? (totalSize + 2) : (totalSize + (2 + RecruitCharacterDataList[m].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (RecruitLevelList != null)
		{
			totalSize += 2;
			for (int n = 0; n < RecruitLevelList.Count; n++)
			{
				totalSize += RecruitLevelList[n].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (FixBookInfoDisplayList != null)
		{
			totalSize += 2;
			for (int num = 0; num < FixBookInfoDisplayList.Count; num++)
			{
				totalSize = ((FixBookInfoDisplayList[num] == null) ? (totalSize + 2) : (totalSize + (2 + FixBookInfoDisplayList[num].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (ManagerDisplayDataList != null)
		{
			totalSize += 2;
			for (int num2 = 0; num2 < ManagerDisplayDataList.Count; num2++)
			{
				totalSize = ((ManagerDisplayDataList[num2] == null) ? (totalSize + 2) : (totalSize + (2 + ManagerDisplayDataList[num2].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (Residences != null)
		{
			totalSize += 2;
			for (int num3 = 0; num3 < Residences.Count; num3++)
			{
				totalSize = ((Residences[num3] == null) ? (totalSize + 2) : (totalSize + (2 + Residences[num3].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (ComfortableHouses != null)
		{
			totalSize += 2;
			for (int num4 = 0; num4 < ComfortableHouses.Count; num4++)
			{
				totalSize = ((ComfortableHouses[num4] == null) ? (totalSize + 2) : (totalSize + (2 + ComfortableHouses[num4].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CollectionItemDisplayList != null)
		{
			int elementsCount = CollectionItemDisplayList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (CollectionItemDisplayList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = CollectionItemDisplayList[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
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
				int fieldSize2 = CollectionResourceList[j].Serialize(pCurrData);
				pCurrData += fieldSize2;
				Tester.Assert(fieldSize2 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ShopSoldItemDisplayList != null)
		{
			int elementsCount3 = ShopSoldItemDisplayList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (ShopSoldItemDisplayList[k] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = ShopSoldItemDisplayList[k].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize3;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
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
				int fieldSize4 = ShopSoldItemEarnList[l].Serialize(pCurrData);
				pCurrData += fieldSize4;
				Tester.Assert(fieldSize4 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RecruitCharacterDataList != null)
		{
			int elementsCount5 = RecruitCharacterDataList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				if (RecruitCharacterDataList[m] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize5 = RecruitCharacterDataList[m].Serialize(pCurrData);
					pCurrData += fieldSize5;
					Tester.Assert(fieldSize5 <= 65535);
					*(ushort*)intPtr3 = (ushort)fieldSize5;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RecruitLevelList != null)
		{
			int elementsCount6 = RecruitLevelList.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				int fieldSize6 = RecruitLevelList[n].Serialize(pCurrData);
				pCurrData += fieldSize6;
				Tester.Assert(fieldSize6 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FixBookInfoDisplayList != null)
		{
			int elementsCount7 = FixBookInfoDisplayList.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				if (FixBookInfoDisplayList[num] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int fieldSize7 = FixBookInfoDisplayList[num].Serialize(pCurrData);
					pCurrData += fieldSize7;
					Tester.Assert(fieldSize7 <= 65535);
					*(ushort*)intPtr4 = (ushort)fieldSize7;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (AutoSoldItem ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoArrange ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AutoCheckIn ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (ManagerDisplayDataList != null)
		{
			int elementsCount8 = ManagerDisplayDataList.Count;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				if (ManagerDisplayDataList[num2] != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int fieldSize8 = ManagerDisplayDataList[num2].Serialize(pCurrData);
					pCurrData += fieldSize8;
					Tester.Assert(fieldSize8 <= 65535);
					*(ushort*)intPtr5 = (ushort)fieldSize8;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Residences != null)
		{
			int elementsCount9 = Residences.Count;
			Tester.Assert(elementsCount9 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount9;
			pCurrData += 2;
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				if (Residences[num3] != null)
				{
					byte* intPtr6 = pCurrData;
					pCurrData += 2;
					int fieldSize9 = Residences[num3].Serialize(pCurrData);
					pCurrData += fieldSize9;
					Tester.Assert(fieldSize9 <= 65535);
					*(ushort*)intPtr6 = (ushort)fieldSize9;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ComfortableHouses != null)
		{
			int elementsCount10 = ComfortableHouses.Count;
			Tester.Assert(elementsCount10 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount10;
			pCurrData += 2;
			for (int num4 = 0; num4 < elementsCount10; num4++)
			{
				if (ComfortableHouses[num4] != null)
				{
					byte* intPtr7 = pCurrData;
					pCurrData += 2;
					int fieldSize10 = ComfortableHouses[num4].Serialize(pCurrData);
					pCurrData += fieldSize10;
					Tester.Assert(fieldSize10 <= 65535);
					*(ushort*)intPtr7 = (ushort)fieldSize10;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CollectionItemDisplayList == null)
			{
				CollectionItemDisplayList = new List<ItemDisplayData>();
			}
			else
			{
				CollectionItemDisplayList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element;
				if (num > 0)
				{
					element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				CollectionItemDisplayList.Add(element);
			}
		}
		else
		{
			CollectionItemDisplayList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CollectionResourceList == null)
			{
				CollectionResourceList = new List<IntPair>();
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
			if (ShopSoldItemDisplayList == null)
			{
				ShopSoldItemDisplayList = new List<ItemDisplayData>();
			}
			else
			{
				ShopSoldItemDisplayList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element3;
				if (num2 > 0)
				{
					element3 = new ItemDisplayData();
					pCurrData += element3.Deserialize(pCurrData);
				}
				else
				{
					element3 = null;
				}
				ShopSoldItemDisplayList.Add(element3);
			}
		}
		else
		{
			ShopSoldItemDisplayList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (ShopSoldItemEarnList == null)
			{
				ShopSoldItemEarnList = new List<IntPair>();
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
			if (RecruitCharacterDataList == null)
			{
				RecruitCharacterDataList = new List<RecruitCharacterData>();
			}
			else
			{
				RecruitCharacterDataList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				RecruitCharacterData element5;
				if (num3 > 0)
				{
					element5 = new RecruitCharacterData();
					pCurrData += element5.Deserialize(pCurrData);
				}
				else
				{
					element5 = null;
				}
				RecruitCharacterDataList.Add(element5);
			}
		}
		else
		{
			RecruitCharacterDataList?.Clear();
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (RecruitLevelList == null)
			{
				RecruitLevelList = new List<IntPair>();
			}
			else
			{
				RecruitLevelList.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				IntPair element6 = default(IntPair);
				pCurrData += element6.Deserialize(pCurrData);
				RecruitLevelList.Add(element6);
			}
		}
		else
		{
			RecruitLevelList?.Clear();
		}
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (FixBookInfoDisplayList == null)
			{
				FixBookInfoDisplayList = new List<ItemDisplayData>();
			}
			else
			{
				FixBookInfoDisplayList.Clear();
			}
			for (int num4 = 0; num4 < elementsCount7; num4++)
			{
				ushort num5 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element7;
				if (num5 > 0)
				{
					element7 = new ItemDisplayData();
					pCurrData += element7.Deserialize(pCurrData);
				}
				else
				{
					element7 = null;
				}
				FixBookInfoDisplayList.Add(element7);
			}
		}
		else
		{
			FixBookInfoDisplayList?.Clear();
		}
		AutoSoldItem = *pCurrData != 0;
		pCurrData++;
		AutoArrange = *pCurrData != 0;
		pCurrData++;
		AutoCheckIn = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount8 > 0)
		{
			if (ManagerDisplayDataList == null)
			{
				ManagerDisplayDataList = new List<BuildingManagerDisplayData>();
			}
			else
			{
				ManagerDisplayDataList.Clear();
			}
			for (int num6 = 0; num6 < elementsCount8; num6++)
			{
				ushort num7 = *(ushort*)pCurrData;
				pCurrData += 2;
				BuildingManagerDisplayData element8;
				if (num7 > 0)
				{
					element8 = new BuildingManagerDisplayData();
					pCurrData += element8.Deserialize(pCurrData);
				}
				else
				{
					element8 = null;
				}
				ManagerDisplayDataList.Add(element8);
			}
		}
		else
		{
			ManagerDisplayDataList?.Clear();
		}
		ushort elementsCount9 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount9 > 0)
		{
			if (Residences == null)
			{
				Residences = new List<CharacterDisplayData>();
			}
			else
			{
				Residences.Clear();
			}
			for (int num8 = 0; num8 < elementsCount9; num8++)
			{
				ushort num9 = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element9;
				if (num9 > 0)
				{
					element9 = new CharacterDisplayData();
					pCurrData += element9.Deserialize(pCurrData);
				}
				else
				{
					element9 = null;
				}
				Residences.Add(element9);
			}
		}
		else
		{
			Residences?.Clear();
		}
		ushort elementsCount10 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount10 > 0)
		{
			if (ComfortableHouses == null)
			{
				ComfortableHouses = new List<CharacterDisplayData>();
			}
			else
			{
				ComfortableHouses.Clear();
			}
			for (int num10 = 0; num10 < elementsCount10; num10++)
			{
				ushort num11 = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element10;
				if (num11 > 0)
				{
					element10 = new CharacterDisplayData();
					pCurrData += element10.Deserialize(pCurrData);
				}
				else
				{
					element10 = null;
				}
				ComfortableHouses.Add(element10);
			}
		}
		else
		{
			ComfortableHouses?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
