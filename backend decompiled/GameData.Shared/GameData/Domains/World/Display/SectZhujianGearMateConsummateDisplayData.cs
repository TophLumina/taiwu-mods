using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.World.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class SectZhujianGearMateConsummateDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public GearMate GearMate;

	[SerializableGameDataField]
	public CharacterDisplayData GearMateDisplayData;

	[SerializableGameDataField]
	public sbyte ConsummateLevel;

	[SerializableGameDataField]
	public bool CanUseWarehouse;

	[SerializableGameDataField]
	public List<ItemDisplayData> CanUpgradeConsummateItemList;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((GearMate == null) ? (totalSize + 2) : (totalSize + (2 + GearMate.GetSerializedSize())));
		totalSize = ((GearMateDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + GearMateDisplayData.GetSerializedSize())));
		if (CanUpgradeConsummateItemList != null)
		{
			totalSize += 2;
			for (int i = 0; i < CanUpgradeConsummateItemList.Count; i++)
			{
				totalSize = ((CanUpgradeConsummateItemList[i] == null) ? (totalSize + 2) : (totalSize + (2 + CanUpgradeConsummateItemList[i].GetSerializedSize())));
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
		*pCurrData = (byte)ConsummateLevel;
		pCurrData++;
		*pCurrData = (CanUseWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (CanUpgradeConsummateItemList != null)
		{
			int elementsCount = CanUpgradeConsummateItemList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (CanUpgradeConsummateItemList[i] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = CanUpgradeConsummateItemList[i].Serialize(pCurrData);
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
		ConsummateLevel = (sbyte)(*pCurrData);
		pCurrData++;
		CanUseWarehouse = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CanUpgradeConsummateItemList == null)
			{
				CanUpgradeConsummateItemList = new List<ItemDisplayData>();
			}
			else
			{
				CanUpgradeConsummateItemList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element;
				if (num3 > 0)
				{
					element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				CanUpgradeConsummateItemList.Add(element);
			}
		}
		else
		{
			CanUpgradeConsummateItemList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
