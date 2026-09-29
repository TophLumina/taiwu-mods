using System;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[Obsolete]
[SerializableGameData(NoCopyConstructors = true)]
public class TaiwuVillageStorage : ISerializableGameData
{
	[SerializableGameDataField]
	public ResourceInts Resources;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public Inventory[] Inventories;

	public bool NeedCommit;

	public TaiwuVillageStorage()
	{
		Resources.Initialize();
		Inventories = Array.Empty<Inventory>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 32;
		if (Inventories != null)
		{
			totalSize += 2;
			int elementsCount = Inventories.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				Inventory element = Inventories[i];
				totalSize = ((element == null) ? (totalSize + 4) : (totalSize + (4 + element.GetSerializedSize())));
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
		pCurrData += Resources.Serialize(pCurrData);
		if (Inventories != null)
		{
			int elementsCount = Inventories.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				Inventory element = Inventories[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 4;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= int.MaxValue);
					*(int*)intPtr = subDataSize;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
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
		pCurrData += Resources.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Inventories == null || Inventories.Length != elementsCount)
			{
				Inventories = new Inventory[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int num = *(int*)pCurrData;
				pCurrData += 4;
				if (num > 0)
				{
					Inventory element = Inventories[i] ?? new Inventory();
					pCurrData += element.Deserialize(pCurrData);
					Inventories[i] = element;
				}
				else
				{
					Inventories[i] = null;
				}
			}
		}
		else
		{
			Inventories = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
