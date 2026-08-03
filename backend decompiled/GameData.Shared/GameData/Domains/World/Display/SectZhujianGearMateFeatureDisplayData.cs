using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.World.Display;

/// <summary>
/// 地区主线 - 铸剑 - 机关人 - 特性 显示数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class SectZhujianGearMateFeatureDisplayData : ISerializableGameData
{
	/// <summary>
	/// 机关人数据
	/// </summary>
	[SerializableGameDataField]
	public GearMate GearMate;

	/// <summary>
	/// 机关人显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData GearMateDisplayData;

	/// <summary>
	/// 机关人特性
	/// </summary>
	[SerializableGameDataField]
	public List<short> FeatureIds;

	/// <summary>
	/// 是否可以使用仓库
	/// </summary>
	[SerializableGameDataField]
	public bool CanUseWarehouse;

	/// <summary>
	/// 太吾持有的机关人可升级特性的物品（包含行囊、私库、公库）
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> CanUpgradeFeatureItemList;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
		totalSize = ((GearMate == null) ? (totalSize + 2) : (totalSize + (2 + GearMate.GetSerializedSize())));
		totalSize = ((GearMateDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + GearMateDisplayData.GetSerializedSize())));
		totalSize = ((FeatureIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * FeatureIds.Count)));
		if (CanUpgradeFeatureItemList != null)
		{
			totalSize += 2;
			for (int i = 0; i < CanUpgradeFeatureItemList.Count; i++)
			{
				totalSize = ((CanUpgradeFeatureItemList[i] == null) ? (totalSize + 2) : (totalSize + (2 + CanUpgradeFeatureItemList[i].GetSerializedSize())));
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
		if (GearMate != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = GearMate.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GearMateDisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = GearMateDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FeatureIds != null)
		{
			int elementsCount = FeatureIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = FeatureIds[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (CanUseWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (CanUpgradeFeatureItemList != null)
		{
			int elementsCount2 = CanUpgradeFeatureItemList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (CanUpgradeFeatureItemList[j] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = CanUpgradeFeatureItemList[j].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)fieldSize3;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			GearMate = new GearMate();
			pCurrData += GearMate.Deserialize(pCurrData);
		}
		else
		{
			GearMate = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			GearMateDisplayData = new CharacterDisplayData();
			pCurrData += GearMateDisplayData.Deserialize(pCurrData);
		}
		else
		{
			GearMateDisplayData = null;
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (FeatureIds == null)
			{
				FeatureIds = new List<short>();
			}
			else
			{
				FeatureIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				FeatureIds.Add(element);
			}
		}
		else
		{
			FeatureIds?.Clear();
		}
		CanUseWarehouse = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CanUpgradeFeatureItemList == null)
			{
				CanUpgradeFeatureItemList = new List<ItemDisplayData>();
			}
			else
			{
				CanUpgradeFeatureItemList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element2;
				if (num3 > 0)
				{
					element2 = new ItemDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				CanUpgradeFeatureItemList.Add(element2);
			}
		}
		else
		{
			CanUpgradeFeatureItemList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
