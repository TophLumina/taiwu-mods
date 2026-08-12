using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Information;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true)]
public class SecretInformationShopCharacterData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CollectedSecretInformationIds = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "CollectedSecretInformationIds" };
	}

	[SerializableGameDataField]
	public List<int> CollectedSecretInformationIds = new List<int>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((CollectedSecretInformationIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * CollectedSecretInformationIds.Count)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 1;
		pCurrData += 2;
		if (CollectedSecretInformationIds != null)
		{
			int elementsCount = CollectedSecretInformationIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = CollectedSecretInformationIds[i];
			}
			pCurrData += 4 * elementsCount;
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
				if (CollectedSecretInformationIds == null)
				{
					CollectedSecretInformationIds = new List<int>(elementsCount);
				}
				else
				{
					CollectedSecretInformationIds.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					CollectedSecretInformationIds.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				CollectedSecretInformationIds?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
