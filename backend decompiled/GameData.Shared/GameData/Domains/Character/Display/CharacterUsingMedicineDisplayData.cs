using System.Collections.Generic;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 用药界面的显示数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class CharacterUsingMedicineDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public CharacterAttributeDisplayData AttributeDisplayData;

	[SerializableGameDataField]
	public CharacterInjuryDisplayData InjuryDisplayData;

	[SerializableGameDataField]
	public List<ItemDisplayData> ItemList;

	[SerializableGameDataField]
	public int MaxLoad;

	[SerializableGameDataField]
	public int CurLoad;

	[SerializableGameDataField]
	public int MoveTimeCostPercent;

	[SerializableGameDataField]
	public bool NeedAutoUseMedicine;

	[SerializableGameDataField]
	public Inventory AutoUseMedicineInventory;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 145;
		totalSize = ((InjuryDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + InjuryDisplayData.GetSerializedSize())));
		if (ItemList != null)
		{
			totalSize += 2;
			int elementsCount = ItemList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				ItemDisplayData element = ItemList[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((AutoUseMedicineInventory == null) ? (totalSize + 2) : (totalSize + (2 + AutoUseMedicineInventory.GetSerializedSize())));
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
		pCurrData += AttributeDisplayData.Serialize(pCurrData);
		if (InjuryDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = InjuryDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ItemList != null)
		{
			int elementsCount = ItemList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				ItemDisplayData element = ItemList[i];
				if (element != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr2 = (ushort)subDataSize;
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
		*(int*)pCurrData = MaxLoad;
		pCurrData += 4;
		*(int*)pCurrData = CurLoad;
		pCurrData += 4;
		*(int*)pCurrData = MoveTimeCostPercent;
		pCurrData += 4;
		*pCurrData = (NeedAutoUseMedicine ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (AutoUseMedicineInventory != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = AutoUseMedicineInventory.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize2;
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (AttributeDisplayData == null)
		{
			AttributeDisplayData = new CharacterAttributeDisplayData();
		}
		pCurrData += AttributeDisplayData.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (InjuryDisplayData == null)
			{
				InjuryDisplayData = new CharacterInjuryDisplayData();
			}
			pCurrData += InjuryDisplayData.Deserialize(pCurrData);
		}
		else
		{
			InjuryDisplayData = null;
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ItemList == null)
			{
				ItemList = new List<ItemDisplayData>(elementsCount);
			}
			else
			{
				ItemList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num2 > 0)
				{
					ItemDisplayData element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
					ItemList.Add(element);
				}
				else
				{
					ItemList.Add(null);
				}
			}
		}
		else
		{
			ItemList?.Clear();
		}
		MaxLoad = *(int*)pCurrData;
		pCurrData += 4;
		CurLoad = *(int*)pCurrData;
		pCurrData += 4;
		MoveTimeCostPercent = *(int*)pCurrData;
		pCurrData += 4;
		NeedAutoUseMedicine = *pCurrData != 0;
		pCurrData++;
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			if (AutoUseMedicineInventory == null)
			{
				AutoUseMedicineInventory = new Inventory();
			}
			pCurrData += AutoUseMedicineInventory.Deserialize(pCurrData);
		}
		else
		{
			AutoUseMedicineInventory = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
