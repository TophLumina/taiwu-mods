using GameData.Serializer;

namespace GameData.Domains.World;

public struct XiangshuAvatarTaskStatus(sbyte swordTombStatus, sbyte juniorXiangshuTaskStatus, int juniorXiangshuCharId) : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte SwordTombStatus = swordTombStatus;

	[SerializableGameDataField]
	public sbyte JuniorXiangshuTaskStatus = juniorXiangshuTaskStatus;

	[SerializableGameDataField]
	public int JuniorXiangshuCharId = juniorXiangshuCharId;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)SwordTombStatus;
		byte* num = pData + 1;
		*num = (byte)JuniorXiangshuTaskStatus;
		byte* num2 = num + 1;
		*(int*)num2 = JuniorXiangshuCharId;
		int totalSize = (int)(num2 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		SwordTombStatus = (sbyte)(*pCurrData);
		pCurrData++;
		JuniorXiangshuTaskStatus = (sbyte)(*pCurrData);
		pCurrData++;
		JuniorXiangshuCharId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
