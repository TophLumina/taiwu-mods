using System.Collections.Generic;
using System.Text;
using GameData.Domains.Character.Display;
using GameData.Domains.Information;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

[SerializableGameData(NoCopyConstructors = true)]
public class EventSelectInformationData : ISerializableGameData
{
	[SerializableGameDataField]
	public int RelatedCharacterId;

	public bool SelectComplete;

	[SerializableGameDataField]
	public bool AvailableData;

	[SerializableGameDataField]
	public bool IsForShopping;

	[SerializableGameDataField]
	public NameRelatedData CharacterNameRelatedData;

	[SerializableGameDataField]
	public List<int> ToSelectSecretInformationDataIdList;

	[SerializableGameDataField]
	public NormalInformationCollection ToSelectNormalInformation;

	[SerializableGameDataField]
	public sbyte SelectInformationType;

	[SerializableGameDataField]
	public string SaveKey;

	public string SelectForEventGuid;

	public string SelectForOptionKey;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 39;
		totalSize = ((ToSelectSecretInformationDataIdList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ToSelectSecretInformationDataIdList.Count)));
		totalSize = ((ToSelectNormalInformation == null) ? (totalSize + 2) : (totalSize + (2 + ToSelectNormalInformation.GetSerializedSize())));
		totalSize = ((SaveKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * SaveKey.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = RelatedCharacterId;
		pCurrData += 4;
		*pCurrData = (AvailableData ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsForShopping ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += CharacterNameRelatedData.Serialize(pCurrData);
		if (ToSelectSecretInformationDataIdList != null)
		{
			int elementsCount = ToSelectSecretInformationDataIdList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = ToSelectSecretInformationDataIdList[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ToSelectNormalInformation != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ToSelectNormalInformation.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)SelectInformationType;
		pCurrData++;
		if (SaveKey != null)
		{
			int elementsCount2 = SaveKey.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar = SaveKey)
			{
				for (int j = 0; j < elementsCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar[j];
				}
			}
			pCurrData += 2 * elementsCount2;
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
		RelatedCharacterId = *(int*)pCurrData;
		pCurrData += 4;
		AvailableData = *pCurrData != 0;
		pCurrData++;
		IsForShopping = *pCurrData != 0;
		pCurrData++;
		pCurrData += CharacterNameRelatedData.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ToSelectSecretInformationDataIdList == null)
			{
				ToSelectSecretInformationDataIdList = new List<int>(elementsCount);
			}
			else
			{
				ToSelectSecretInformationDataIdList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ToSelectSecretInformationDataIdList.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			ToSelectSecretInformationDataIdList?.Clear();
		}
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (ToSelectNormalInformation == null)
			{
				ToSelectNormalInformation = new NormalInformationCollection();
			}
			pCurrData += ToSelectNormalInformation.Deserialize(pCurrData);
		}
		else
		{
			ToSelectNormalInformation = null;
		}
		SelectInformationType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			int fieldSize = 2 * elementsCount2;
			SaveKey = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			SaveKey = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
