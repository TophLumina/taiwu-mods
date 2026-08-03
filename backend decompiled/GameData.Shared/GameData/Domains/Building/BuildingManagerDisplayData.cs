using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class BuildingManagerDisplayData : ISerializableGameData
{
	/// <summary>
	///             角色
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData CharacterDisplayData;

	/// <summary>
	/// 是主事
	/// </summary>
	[SerializableGameDataField]
	public bool IsLeader;

	/// <summary>
	/// 主事身份匹配，服众
	/// </summary>
	[SerializableGameDataField]
	public bool LeaderRoleMatch;

	/// <summary>
	/// 传授品级
	/// </summary>
	[SerializableGameDataField]
	public sbyte LeaderTeachGrade;

	/// <summary>
	/// 剩余潜力
	/// </summary>
	[SerializableGameDataField]
	public sbyte LeftPotentialCount;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((CharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CharacterDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsLeader ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (LeaderRoleMatch ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)LeaderTeachGrade;
		pCurrData++;
		*pCurrData = (byte)LeftPotentialCount;
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
			CharacterDisplayData = new CharacterDisplayData();
			pCurrData += CharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayData = null;
		}
		IsLeader = *pCurrData != 0;
		pCurrData++;
		LeaderRoleMatch = *pCurrData != 0;
		pCurrData++;
		LeaderTeachGrade = (sbyte)(*pCurrData);
		pCurrData++;
		LeftPotentialCount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
