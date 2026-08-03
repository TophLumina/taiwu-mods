using GameData.Domains.Character;
using GameData.Serializer;

namespace GameData.Domains.Information.Secret.Attachment;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public struct CharacterExtraInfo : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort OrgInfo = 0;

		public const ushort FameType = 1;

		public const ushort MonkType = 2;

		public const ushort AliveState = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "OrgInfo", "FameType", "MonkType", "AliveState" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public OrganizationInfo OrgInfo;

	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte FameType;

	[SerializableGameDataField(FieldIndex = 2)]
	public byte MonkType;

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte AliveState;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		totalSize += OrgInfo.GetSerializedSize();
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
		pCurrData += OrgInfo.Serialize(pCurrData);
		*pCurrData = (byte)FameType;
		pCurrData++;
		*pCurrData = MonkType;
		pCurrData++;
		*pCurrData = (byte)AliveState;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += OrgInfo.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			FameType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 2)
		{
			MonkType = *pCurrData;
			pCurrData++;
		}
		if (num > 3)
		{
			AliveState = (sbyte)(*pCurrData);
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
