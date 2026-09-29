using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class CharacterDisplayDataForGuard : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public List<NameRelatedData> Guards = new List<NameRelatedData>();

	[SerializableGameDataField]
	public bool HasGuard;

	[SerializableGameDataField]
	public bool IsMain;

	[SerializableGameDataField]
	public bool GuardCanAffectInteract;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		totalSize = ((Guards == null) ? (totalSize + 2) : (totalSize + (2 + 32 * Guards.Count)));
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
		if (Guards != null)
		{
			int elementsCount = Guards.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Guards[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (HasGuard ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsMain ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (GuardCanAffectInteract ? ((byte)1) : ((byte)0));
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Guards == null)
			{
				Guards = new List<NameRelatedData>();
			}
			else
			{
				Guards.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				NameRelatedData element = new NameRelatedData();
				pCurrData += element.Deserialize(pCurrData);
				Guards.Add(element);
			}
		}
		else
		{
			Guards?.Clear();
		}
		HasGuard = *pCurrData != 0;
		pCurrData++;
		IsMain = *pCurrData != 0;
		pCurrData++;
		GuardCanAffectInteract = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
