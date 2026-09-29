using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData]
public struct StartMakeArguments : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public BuildingBlockKey BuildingBlockKey;

	[SerializableGameDataField]
	public ItemDisplayData Tool;

	[SerializableGameDataField]
	public ItemDisplayData Material;

	[SerializableGameDataField]
	public sbyte ItemType;

	[SerializableGameDataField]
	public List<short> ItemList;

	[SerializableGameDataField]
	public short MakeItemSubTypeId;

	[SerializableGameDataField]
	public ResourceInts ResourceCount;

	[SerializableGameDataField]
	public ResourceInts NeedResource;

	[SerializableGameDataField]
	public short EquipmentEffectId;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 81;
		totalSize = ((Tool == null) ? (totalSize + 2) : (totalSize + (2 + Tool.GetSerializedSize())));
		totalSize = ((Material == null) ? (totalSize + 2) : (totalSize + (2 + Material.GetSerializedSize())));
		totalSize = ((ItemList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ItemList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		pCurrData += BuildingBlockKey.Serialize(pCurrData);
		if (Tool != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Tool.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Material != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = Material.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)ItemType;
		pCurrData++;
		if (ItemList != null)
		{
			int elementsCount = ItemList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = ItemList[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = MakeItemSubTypeId;
		pCurrData += 2;
		pCurrData += ResourceCount.Serialize(pCurrData);
		pCurrData += NeedResource.Serialize(pCurrData);
		*(short*)pCurrData = EquipmentEffectId;
		pCurrData += 2;
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += BuildingBlockKey.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Tool = new ItemDisplayData();
			pCurrData += Tool.Deserialize(pCurrData);
		}
		else
		{
			Tool = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			Material = new ItemDisplayData();
			pCurrData += Material.Deserialize(pCurrData);
		}
		else
		{
			Material = null;
		}
		ItemType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ItemList == null)
			{
				ItemList = new List<short>();
			}
			else
			{
				ItemList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				ItemList.Add(element);
			}
		}
		else
		{
			ItemList?.Clear();
		}
		MakeItemSubTypeId = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += ResourceCount.Deserialize(pCurrData);
		pCurrData += NeedResource.Deserialize(pCurrData);
		EquipmentEffectId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
