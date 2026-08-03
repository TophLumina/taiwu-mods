using GameData.Serializer;

namespace GameData.Domains.Information.Secret;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true)]
public class SecretInformation : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort SourceCharacterId = 0;

		public const ushort Id = 1;

		public const ushort OccurenceId = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "SourceCharacterId", "Id", "OccurenceId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int SourceCharacterId = -1;

	[SerializableGameDataField(FieldIndex = 1)]
	public SecretInformationId Id = SecretInformationId.Invalid;

	[SerializableGameDataField(FieldIndex = 2)]
	public SecretOccurenceId OccurenceId = SecretOccurenceId.Invalid;

	public override string ToString()
	{
		return string.Format("{0}#{1}({2})", "SecretInformation", (int)Id, OccurenceId);
	}

	public SecretInformation()
	{
	}

	public SecretInformation(SecretInformation other)
	{
		SourceCharacterId = other.SourceCharacterId;
		Id = other.Id;
		OccurenceId = other.OccurenceId;
	}

	public void Assign(SecretInformation other)
	{
		SourceCharacterId = other.SourceCharacterId;
		Id = other.Id;
		OccurenceId = other.OccurenceId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 14;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*(int*)pCurrData = SourceCharacterId;
		pCurrData += 4;
		pCurrData += Id.Serialize(pCurrData);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			SourceCharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			pCurrData += Id.Deserialize(pCurrData);
		}
		if (num > 2)
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
