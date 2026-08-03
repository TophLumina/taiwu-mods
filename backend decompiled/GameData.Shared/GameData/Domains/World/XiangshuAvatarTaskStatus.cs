using GameData.Serializer;

namespace GameData.Domains.World;

/// <summary>
/// 相枢化身的任务状态
/// </summary>
public struct XiangshuAvatarTaskStatus : ISerializableGameData
{
	/// <summary>
	/// 剑冢攻克状态
	/// <see cref="T:GameData.Domains.World.SwordTombStatus" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte SwordTombStatus;

	/// <summary>
	/// 紫竹化身的任务状态.
	/// <see cref="T:GameData.Domains.World.JuniorXiangshuTaskStatus" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte JuniorXiangshuTaskStatus;

	/// <summary>
	/// 紫竹化身对应的角色ID
	/// </summary>
	[SerializableGameDataField]
	public int JuniorXiangshuCharId;

	/// <summary>
	/// 相枢化身的状态
	/// </summary>
	/// <param name="swordTombStatus"></param>
	/// <param name="juniorXiangshuTaskStatus"></param>
	/// <param name="juniorXiangshuCharId"></param>
	public XiangshuAvatarTaskStatus(sbyte swordTombStatus, sbyte juniorXiangshuTaskStatus, int juniorXiangshuCharId)
	{
		SwordTombStatus = swordTombStatus;
		JuniorXiangshuTaskStatus = juniorXiangshuTaskStatus;
		JuniorXiangshuCharId = juniorXiangshuCharId;
	}

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
