using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Display;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class VillagerRoleManageDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public short RoleTemplateId;

	[Obsolete]
	[SerializableGameDataField]
	public int AvailableSeats;

	[SerializableGameDataField]
	public List<int> CharacterIds;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((CharacterIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * CharacterIds.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = RoleTemplateId;
		pCurrData += 2;
		*(int*)pCurrData = AvailableSeats;
		pCurrData += 4;
		if (CharacterIds != null)
		{
			int elementsCount = CharacterIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = CharacterIds[i];
			}
			pCurrData += 4 * elementsCount;
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
		RoleTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		AvailableSeats = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CharacterIds == null)
			{
				CharacterIds = new List<int>(elementsCount);
			}
			else
			{
				CharacterIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterIds.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			CharacterIds?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
