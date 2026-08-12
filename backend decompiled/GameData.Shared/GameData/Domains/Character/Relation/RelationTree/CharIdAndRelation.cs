using GameData.Serializer;

namespace GameData.Domains.Character.Relation.RelationTree;

/// <summary>
/// 角色 ID 和角色关系
/// </summary>
[SerializableGameData(NotForDisplayModule = true)]
public struct CharIdAndRelation : ISerializableGameData
{
	/// <summary>
	/// 角色 ID
	/// </summary>
	public int CharId;

	/// <summary>
	/// 角色关系.
	/// <see cref="T:GameData.Domains.Character.Relation.RelationType" />
	/// </summary>
	public ushort RelationType;

	/// <summary>
	/// 角色 ID 和角色关系
	/// </summary>
	/// <param name="charId"></param>
	/// <param name="relationType"></param>
	public CharIdAndRelation(int charId, ushort relationType)
	{
		CharId = charId;
		RelationType = relationType;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = CharId;
		((short*)pData)[2] = (short)RelationType;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		CharId = *(int*)pData;
		RelationType = ((ushort*)pData)[2];
		return 8;
	}
}
