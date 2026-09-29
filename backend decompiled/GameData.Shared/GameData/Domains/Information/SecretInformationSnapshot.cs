using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Information;

[SerializableGameData(IsExtensible = true)]
public class SecretInformationSnapshot : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort SecretInformationId = 0;

		public const ushort SecretInformationTemplateId = 1;

		public const ushort HolderCount = 2;

		public const ushort SourceCharacterId = 3;

		public const ushort UsedCount = 4;

		public const ushort Location = 5;

		public const ushort OccurenceDate = 6;

		public const ushort ParametersPack = 7;

		public const ushort AuthorityCost = 8;

		public const ushort IsInBroadcast = 9;

		public const ushort Type = 10;

		public const ushort OccurenceId = 11;

		public const ushort Count = 12;

		public static readonly string[] FieldId2FieldName = new string[12]
		{
			"SecretInformationId", "SecretInformationTemplateId", "HolderCount", "SourceCharacterId", "UsedCount", "Location", "OccurenceDate", "ParametersPack", "AuthorityCost", "IsInBroadcast",
			"Type", "OccurenceId"
		};
	}

	[SerializableGameDataField]
	public int SecretInformationId;

	[SerializableGameDataField]
	public short SecretInformationTemplateId;

	[SerializableGameDataField]
	public int HolderCount;

	[SerializableGameDataField]
	public int SourceCharacterId;

	[SerializableGameDataField]
	public int AuthorityCost;

	[SerializableGameDataField]
	public bool IsInBroadcast;

	[SerializableGameDataField]
	public int UsedCount;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public int OccurenceDate;

	[SerializableGameDataField]
	public byte[] ParametersPack;

	[SerializableGameDataField]
	public int Type;

	[SerializableGameDataField]
	public SecretOccurenceId OccurenceId;

	public SecretInformationSnapshot()
	{
	}

	public SecretInformationSnapshot(SecretInformationSnapshot other)
	{
		SecretInformationId = other.SecretInformationId;
		SecretInformationTemplateId = other.SecretInformationTemplateId;
		HolderCount = other.HolderCount;
		SourceCharacterId = other.SourceCharacterId;
		UsedCount = other.UsedCount;
		Location = other.Location;
		OccurenceDate = other.OccurenceDate;
		byte[] item = other.ParametersPack;
		int elementsCount = item.Length;
		ParametersPack = new byte[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			ParametersPack[i] = item[i];
		}
		AuthorityCost = other.AuthorityCost;
		IsInBroadcast = other.IsInBroadcast;
		Type = other.Type;
		OccurenceId = other.OccurenceId;
	}

	public void Assign(SecretInformationSnapshot other)
	{
		SecretInformationId = other.SecretInformationId;
		SecretInformationTemplateId = other.SecretInformationTemplateId;
		HolderCount = other.HolderCount;
		SourceCharacterId = other.SourceCharacterId;
		UsedCount = other.UsedCount;
		Location = other.Location;
		OccurenceDate = other.OccurenceDate;
		byte[] item = other.ParametersPack;
		int elementsCount = item.Length;
		ParametersPack = new byte[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			ParametersPack[i] = item[i];
		}
		AuthorityCost = other.AuthorityCost;
		IsInBroadcast = other.IsInBroadcast;
		Type = other.Type;
		OccurenceId = other.OccurenceId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 41;
		totalSize = ((ParametersPack == null) ? (totalSize + 2) : (totalSize + (2 + ParametersPack.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 12;
		pCurrData += 2;
		*(int*)pCurrData = SecretInformationId;
		pCurrData += 4;
		*(short*)pCurrData = SecretInformationTemplateId;
		pCurrData += 2;
		*(int*)pCurrData = HolderCount;
		pCurrData += 4;
		*(int*)pCurrData = SourceCharacterId;
		pCurrData += 4;
		*(int*)pCurrData = UsedCount;
		pCurrData += 4;
		pCurrData += Location.Serialize(pCurrData);
		*(int*)pCurrData = OccurenceDate;
		pCurrData += 4;
		if (ParametersPack != null)
		{
			int elementsCount = ParametersPack.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = ParametersPack[i];
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = AuthorityCost;
		pCurrData += 4;
		*pCurrData = (IsInBroadcast ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = Type;
		pCurrData += 4;
		pCurrData += OccurenceId.Serialize(pCurrData);
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
			SecretInformationId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			SecretInformationTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 2)
		{
			HolderCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			SourceCharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			UsedCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			pCurrData += Location.Deserialize(pCurrData);
		}
		if (fieldCount > 6)
		{
			OccurenceDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 7)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (ParametersPack == null || ParametersPack.Length != elementsCount)
				{
					ParametersPack = new byte[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ParametersPack[i] = pCurrData[i];
				}
				pCurrData += (int)elementsCount;
			}
			else
			{
				ParametersPack = null;
			}
		}
		if (fieldCount > 8)
		{
			AuthorityCost = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 9)
		{
			IsInBroadcast = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 10)
		{
			Type = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 11)
		{
			pCurrData += OccurenceId.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
