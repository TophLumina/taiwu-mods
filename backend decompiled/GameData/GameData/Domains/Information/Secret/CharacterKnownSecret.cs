using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Information.Secret;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class CharacterKnownSecret : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort KnownSecrets = 0;

		public const ushort UsedCounts = 1;

		public const ushort ConfidentialOccurenceIds = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "KnownSecrets", "UsedCounts", "ConfidentialOccurenceIds" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public List<SecretInformationId> KnownSecrets = new List<SecretInformationId>();

	[SerializableGameDataField(FieldIndex = 1)]
	public Dictionary<SecretInformationId, int> UsedCounts = new Dictionary<SecretInformationId, int>();

	[SerializableGameDataField(FieldIndex = 2)]
	public List<SecretOccurenceId> ConfidentialOccurenceIds = new List<SecretOccurenceId>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((KnownSecrets == null) ? (totalSize + 2) : (totalSize + (2 + 4 * KnownSecrets.Count)));
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(UsedCounts);
		totalSize = ((ConfidentialOccurenceIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ConfidentialOccurenceIds.Count)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		if (KnownSecrets != null)
		{
			int elementsCount = KnownSecrets.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += KnownSecrets[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref UsedCounts);
		if (ConfidentialOccurenceIds != null)
		{
			int elementsCount2 = ConfidentialOccurenceIds.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += ConfidentialOccurenceIds[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (KnownSecrets == null)
				{
					KnownSecrets = new List<SecretInformationId>(elementsCount);
				}
				else
				{
					KnownSecrets.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					SecretInformationId element = new SecretInformationId();
					pCurrData += element.Deserialize(pCurrData);
					KnownSecrets.Add(element);
				}
			}
			else
			{
				KnownSecrets?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref UsedCounts);
		}
		if (fieldCount > 2)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (ConfidentialOccurenceIds == null)
				{
					ConfidentialOccurenceIds = new List<SecretOccurenceId>(elementsCount2);
				}
				else
				{
					ConfidentialOccurenceIds.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					SecretOccurenceId element2 = new SecretOccurenceId();
					pCurrData += element2.Deserialize(pCurrData);
					ConfidentialOccurenceIds.Add(element2);
				}
			}
			else
			{
				ConfidentialOccurenceIds?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
