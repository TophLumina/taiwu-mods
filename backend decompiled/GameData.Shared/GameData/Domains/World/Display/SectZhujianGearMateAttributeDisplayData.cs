using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.World.Display;

[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class SectZhujianGearMateAttributeDisplayData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort GearMate = 0;

		public const ushort Items = 1;

		public const ushort MainAttributes = 2;

		public const ushort CanUseWarehouse = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "GearMate", "Items", "MainAttributes", "CanUseWarehouse" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public GearMate GearMate;

	[SerializableGameDataField(FieldIndex = 1)]
	public List<ItemDisplayData> Items;

	[SerializableGameDataField(FieldIndex = 2)]
	public List<int> MainAttributes;

	[SerializableGameDataField(FieldIndex = 3)]
	public bool CanUseWarehouse;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((GearMate == null) ? (totalSize + 2) : (totalSize + (2 + GearMate.GetSerializedSize())));
		if (Items != null)
		{
			totalSize += 2;
			for (int i = 0; i < Items.Count; i++)
			{
				totalSize = ((Items[i] == null) ? (totalSize + 2) : (totalSize + (2 + Items[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((MainAttributes == null) ? (totalSize + 2) : (totalSize + (2 + 4 * MainAttributes.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
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
		if (Items != null)
		{
			int elementsCount = Items.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (Items[i] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = Items[i].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		if (MainAttributes != null)
		{
			int elementsCount2 = MainAttributes.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(int*)pCurrData = MainAttributes[j];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (CanUseWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Items == null)
				{
					Items = new List<ItemDisplayData>();
				}
				else
				{
					Items.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num2 = *(ushort*)pCurrData;
					pCurrData += 2;
					ItemDisplayData element;
					if (num2 > 0)
					{
						element = new ItemDisplayData();
						pCurrData += element.Deserialize(pCurrData);
					}
					else
					{
						element = null;
					}
					Items.Add(element);
				}
			}
			else
			{
				Items?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (MainAttributes == null)
				{
					MainAttributes = new List<int>();
				}
				else
				{
					MainAttributes.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					int element2 = *(int*)pCurrData;
					pCurrData += 4;
					MainAttributes.Add(element2);
				}
			}
			else
			{
				MainAttributes?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			CanUseWarehouse = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
